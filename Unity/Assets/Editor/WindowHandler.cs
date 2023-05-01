using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using UnityEditor;
using UnityEngine;

public partial class UpdateUnityEditorProcess
{
    public delegate bool EnumThreadWindowsCallback(IntPtr hWnd, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern bool EnumWindows(EnumThreadWindowsCallback callback, IntPtr extraData);
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowThreadProcessId(HandleRef handle, out int processId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
    public static extern IntPtr GetWindow(HandleRef hWnd, int uCmd);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern bool IsWindowVisible(HandleRef hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetParent(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern bool GetWindowText(int hWnd, StringBuilder title, int maxBufSize);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private extern static int GetWindowTextLength(IntPtr hWnd);

    [DllImport("user32.dll", EntryPoint = "SetWindowText", CharSet = CharSet.Auto)]
    public extern static int SetWindowText(int hwnd, string lpString);

    public IntPtr hwnd = IntPtr.Zero;
    private bool haveMainWindow = false;
    private IntPtr mainWindowHandle = IntPtr.Zero;
    private int processId = 0;
    private IntPtr hwCurr = IntPtr.Zero;
    private static StringBuilder sbtitle = new StringBuilder(255);
    private static string ProjectName = "";
    private static string ProjectPath = "";
    public static float lasttime = 0;

    private static UpdateUnityEditorProcess _instance;
    public static UpdateUnityEditorProcess Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UpdateUnityEditorProcess();
                _instance.hwnd = _instance.GetMainWindowHandle(Process.GetCurrentProcess().Id);
                var strArr = Application.dataPath.Split("/");
                ProjectName = strArr[strArr.Length - 2];
                ProjectPath = Application.dataPath.Replace("/Assets", "");
            }
            return _instance;
        }
    }

    public void SetTitle()
    {

        lasttime = 0;
        if (Time.realtimeSinceStartup > lasttime)
        {
            sbtitle.Length = 0;
            lasttime = Time.realtimeSinceStartup + 2f;
            int length = GetWindowTextLength(hwnd);
            hwnd = _instance.hwnd;
            GetWindowText(hwnd.ToInt32(), sbtitle, 255);
            string strTitle = sbtitle.ToString();
            string[] ss = strTitle.Split('-');
            if (ss.Length > 0 && !strTitle.Contains(ProjectPath))
            {
                SetWindowText(hwnd.ToInt32(), strTitle.Replace(ProjectName, ProjectPath));
            }
        }
    }

    public IntPtr GetMainWindowHandle(int processId)
    {
        if (!this.haveMainWindow)
        {
            this.mainWindowHandle = IntPtr.Zero;
            this.processId = processId;
            EnumThreadWindowsCallback callback = new EnumThreadWindowsCallback(this.EnumWindowsCallback);
            EnumWindows(callback, IntPtr.Zero);
            GC.KeepAlive(callback);
            this.haveMainWindow = true;
        }
        return this.mainWindowHandle;
    }

    private bool EnumWindowsCallback(IntPtr handle, IntPtr extraParameter)
    {
        int num;
        GetWindowThreadProcessId(new HandleRef(this, handle), out num);
        if ((num == this.processId) && this.IsMainWindow(handle))
        {
            this.mainWindowHandle = handle;
        }
        return true;
    }

    private bool IsMainWindow(IntPtr handle)
    {

        return (GetParent(handle) == IntPtr.Zero && !(GetWindow(new HandleRef(this, handle), 4) != IntPtr.Zero) && IsWindowVisible(new HandleRef(this, handle)));
    }
}

#if UNITY_EDITOR_WIN

[InitializeOnLoad]
class UpdateUnityEditorTitle
{
    private static bool isInGame = false;

    [System.Obsolete]
    static UpdateUnityEditorTitle()
    {
        EditorApplication.delayCall += DoUpdateTitleFunc;

        EditorApplication.hierarchyChanged += DoUpdateTitleFunc;

        EditorApplication.playmodeStateChanged += OnPlaymodeStateChanged;
    }

    static void OnPlaymodeStateChanged()
    {
        if (EditorApplication.isPlaying == isInGame) return;
        isInGame = EditorApplication.isPlaying;
        UpdateUnityEditorProcess.lasttime = 0;
        DoUpdateTitleFunc();
    }

    static void DoUpdateTitleFunc()
    {
        UpdateUnityEditorProcess.lasttime = 0;
        UpdateUnityEditorProcess.Instance.SetTitle();
    }

}
#endif