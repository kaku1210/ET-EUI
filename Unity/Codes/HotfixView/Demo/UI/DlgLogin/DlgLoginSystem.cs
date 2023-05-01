using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ET
{
	public static  class DlgLoginSystem
	{

		public static void RegisterUIEvent(this DlgLogin self)
		{
			self.View.E_LoginButton.AddListener(() => { self.OnLoginClickHandler();});
		}

		public static void ShowWindow(this DlgLogin self, Entity contextData = null)
		{
			self.View.ESCommonTest.SetLabelText("登录界面, 测试公共UI");
		}
		
		public static void OnLoginClickHandler(this DlgLogin self)
		{
			// LoginHelper.Login(
			// 	self.DomainScene(),
			// 	ConstValue.LoginAddress,
			// 	self.View.E_AccountInputField.GetComponent<InputField>().text,
			// 	self.View.E_PasswordInputField.GetComponent<InputField>().text).Coroutine();
			Debug.Log("在Login界面, 切换回Test界面");
			self.Domain.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Test);
			self.Domain.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Login);

		}
		
		public static void HideWindow(this DlgLogin self)
		{

		}
		
	}
}
