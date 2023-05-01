
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_LessonTestDestroySystem : DestroySystem<Scroll_Item_LessonTest> 
	{
		public override void Destroy( Scroll_Item_LessonTest self )
		{
			self.DestroyWidget();
		}
	}
}
