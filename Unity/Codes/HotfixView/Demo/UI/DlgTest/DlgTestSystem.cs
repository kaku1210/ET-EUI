using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace ET
{
	[FriendClass(typeof(DlgTest))]
	public static  class DlgTestSystem
	{

		/// <summary>
		/// 用于 控件的显示绑定
		/// </summary>
		/// <param name="self"></param>
		public static void RegisterUIEvent(this DlgTest self)
		{
			self.View.E_StartButton.onClick.AddListener(self.OnStartButtonClicked);
			// 注册循环组件的刷新方法: AddItemRefreshListener, 调用 lambda 表达式(为了热更, 如果直接传func, 热更会失效)
			self.View.ETestLooplListLoopHorizontalScrollRect.AddItemRefreshListener( ((Transform trans, int index) => {self.OnLoopListItemRefreshHandler(trans, index);}));
		}

		/// <summary>
		/// 显示时调用
		/// </summary>
		/// <param name="self"></param>
		/// <param name="contextData"></param>
		public static void ShowWindow(this DlgTest self, Entity contextData = null)
		{
			self.View.ELabelText.text = "Hello World";
			self.View.ESCommonTest.SetLabelText("测试公共UI");

			int count = 18;
			// 添加 循环列表项  参数1: 对应dic. 参数2: 列表项数量
			self.AddUIScrollItems(ref self.ScrollItemLessonTests, count);

			// 调用 显示层的 循环列表 的 显隐方法. 参数1: 是否显示. 参数2: 显示数量(这个好像是总共多少个)
			// 上面那个 count 的 数量 就不知道什么时候生效的了.
			self.View.ETestLooplListLoopHorizontalScrollRect.SetVisible(true, count);
		}

		// 创建 隐藏窗口 时的调用方法
		public static void HideWindow(this DlgTest self, Entity contextData = null)
		{
			// 关闭窗口时, 释放循环列表
			self.RemoveUIScrollItems(ref self.ScrollItemLessonTests);
		}

		public static void OnStartButtonClicked(this DlgTest self)
		{
			Debug.Log("OnStartButton Clicked");
			self.View.E_RedImage.gameObject.SetActive( !self.View.E_RedImage.gameObject.activeSelf );
			self.Domain.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Login);
			self.Domain.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Test);
		}

		public static void OnLoopListItemRefreshHandler(this DlgTest self, Transform trans, int index)
		{
			// 总共 count 个
			// index 从 0 到 count - 1
			// self.ScrollItemLessonTests.Count 是 count + 1

			// 循环列表, 只会显示其中一部分 (对象池原理)

			// 通过索引 获取 对应的index. 绑定transform
			Scroll_Item_LessonTest itemServerTest = self.ScrollItemLessonTests[index].BindTrans(trans);

			// 直接 .出来就可以用 item 下的组件
			float f = (float)index / (float)self.ScrollItemLessonTests.Count;
			itemServerTest.EBgImage.color = new Color(f,f,f);
			itemServerTest.EFgImage.color = new Color(1 - f, 1 - f, 1 - f);
			itemServerTest.ENameText.text = index + " / " + self.ScrollItemLessonTests.Count + " = " + f;
			itemServerTest.ENameText.color = new Color(f,f,f);

		}

	}
}
