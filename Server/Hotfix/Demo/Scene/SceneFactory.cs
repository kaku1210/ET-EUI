

using System.Net;

namespace ET
{
    public static class SceneFactory
    {
        public static async ETTask<Scene> Create(Entity parent, string name, SceneType sceneType)
        {
            long instanceId = IdGenerater.Instance.GenerateInstanceId();
            return await Create(parent, instanceId, instanceId, parent.DomainZone(), name, sceneType);
        }
        
        public static async ETTask<Scene> Create(Entity parent, long id, long instanceId, int zone, string name, SceneType sceneType, StartSceneConfig startSceneConfig = null)
        {
            await ETTask.CompletedTask;
            Scene scene = EntitySceneFactory.CreateScene(id, instanceId, zone, sceneType, name, parent);

            scene.AddComponent<MailBoxComponent, MailboxType>(MailboxType.UnOrderMessageDispatcher);

            switch (scene.SceneType)
            {
                case SceneType.Realm:
                    scene.AddComponent<NetKcpComponent, IPEndPoint, int>(startSceneConfig.OuterIPPort, SessionStreamDispatcherType.SessionStreamDispatcherServerOuter);
                    break;
                case SceneType.Gate:
                    scene.AddComponent<NetKcpComponent, IPEndPoint, int>(startSceneConfig.OuterIPPort, SessionStreamDispatcherType.SessionStreamDispatcherServerOuter);
                    scene.AddComponent<PlayerComponent>();
                    scene.AddComponent<GateSessionKeyComponent>();
                    break;
                case SceneType.Map:
                    scene.AddComponent<UnitComponent>();
                    scene.AddComponent<AOIManagerComponent>();
                    // 也有可能会操作数据库 --> DBManagerComponent --> 但因为 DBManagerComponent 是单例的，所以这里不添加后可能会出现错乱(单例只有一个)
                    // --> 本地 or 单一server时, 这里不需要添加. But 如果是分布式, 这里就可以考虑添加了
                    break;
                case SceneType.Location:
                    scene.AddComponent<LocationComponent>();
                    break;
                case SceneType.Account:
                    // 需要对外通讯 --> NetKcpComponent 组件 ( 直接Copy其他的 )  --> 有了这个组件, Client 就可以直接连接到 Account 服务器
                    scene.AddComponent<NetKcpComponent, IPEndPoint, int>(startSceneConfig.OuterIPPort, SessionStreamDispatcherType.SessionStreamDispatcherServerOuter);
                    // 需要连接数据库, 获取玩家数据 --> 数据库相关的 管理组件  --> 有了这个组件, 就可以直接操作数据库了
                    // 这个也可以考虑 在 Create ZoneScene 之前, 直接添加给 Game.Scene. 就不用写在这了
                    //scene.AddComponent<DBManagerComponent>();
                    break;
            }

            return scene;
        }
    }
}