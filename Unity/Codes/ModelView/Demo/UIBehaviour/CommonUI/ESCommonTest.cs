
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class ESCommonTest : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image EBgImageImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBgImageImage == null )
     			{
		    		this.m_EBgImageImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EBgImage");
     			}
     			return this.m_EBgImageImage;
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
		    		this.m_ELabelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel");
     			}
     			return this.m_ELabelText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EBgImageImage = null;
			this.m_ELabelText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EBgImageImage = null;
		private UnityEngine.UI.Text m_ELabelText = null;
		public Transform uiTransform = null;
	}
}
