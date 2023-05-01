using System.Collections.Generic;

namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgTest :Entity,IAwake,IUILogic
	{

		public DlgTestViewComponent View { get => this.Parent.GetComponent<DlgTestViewComponent>();}

		public Dictionary<int, Scroll_Item_LessonTest> ScrollItemLessonTests;

	}
}
