namespace ET
{
    public enum AccountType
    {
        /// <summary>
        /// 黑名单用户
        /// </summary>
        Black = -1,

        /// <summary>
        /// 普通用户
        /// </summary>
        Normal = 0,

        /// <summary>
        /// VIP
        /// </summary>
        Vip = 1,

        /// <summary>
        /// GM
        /// </summary>
        GM = 2,
    }

    // 是一个实体 --> 继承 Entity
    // 需要进行创建出来 --> 继承 IAwake
    public class Account : Entity, IAwake
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 账号创建时间
        /// </summary>
        public long CreateTime { get; set; }


        // ??? 这里使用 int or AccountType? 有什么区别? 都可以用?
        /// <summary>
        /// 账号类型
        /// </summary>
        public int AccountType { get; set; }
    }
}