
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgTestViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EGBackGroundRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGBackGroundRectTransform == null )
     			{
		    		this.m_EGBackGroundRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround");
     			}
     			return this.m_EGBackGroundRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_StartButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartButton == null )
     			{
		    		this.m_E_StartButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EGBackGround/E_Start");
     			}
     			return this.m_E_StartButton;
     		}
     	}

		public UnityEngine.UI.Image E_StartImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartImage == null )
     			{
		    		this.m_E_StartImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/E_Start");
     			}
     			return this.m_E_StartImage;
     		}
     	}

		public UnityEngine.UI.Text ELabelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabelText == null )
     			{
		    		this.m_ELabelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EGBackGround/ELabel");
     			}
     			return this.m_ELabelText;
     		}
     	}

		public UnityEngine.UI.Image E_RedImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RedImage == null )
     			{
		    		this.m_E_RedImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Red");
     			}
     			return this.m_E_RedImage;
     		}
     	}

		public ESCommonTest ESCommonTest
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_escommontest == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ESCommonTest");
		    	   this.m_escommontest = this.AddChild<ESCommonTest,Transform>(subTrans);
     			}
     			return this.m_escommontest;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect ETestLooplListLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETestLooplListLoopHorizontalScrollRect == null )
     			{
		    		this.m_ETestLooplListLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"ETestLooplList");
     			}
     			return this.m_ETestLooplListLoopHorizontalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_E_StartButton = null;
			this.m_E_StartImage = null;
			this.m_ELabelText = null;
			this.m_E_RedImage = null;
			this.m_escommontest?.Dispose();
			this.m_escommontest = null;
			this.m_ETestLooplListLoopHorizontalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Button m_E_StartButton = null;
		private UnityEngine.UI.Image m_E_StartImage = null;
		private UnityEngine.UI.Text m_ELabelText = null;
		private UnityEngine.UI.Image m_E_RedImage = null;
		private ESCommonTest m_escommontest = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_ETestLooplListLoopHorizontalScrollRect = null;
		public Transform uiTransform = null;
	}
}
