
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ESCommonTestAwakeSystem : AwakeSystem<ESCommonTest,Transform> 
	{
		public override void Awake(ESCommonTest self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ESCommonTestDestroySystem : DestroySystem<ESCommonTest> 
	{
		public override void Destroy(ESCommonTest self)
		{
			self.DestroyWidget();
		}
	}
}
