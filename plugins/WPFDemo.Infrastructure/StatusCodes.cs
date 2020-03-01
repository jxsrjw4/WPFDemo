using System.ComponentModel;

namespace WPFDemo.Infrastructure
{
    public static class StatusCodes
    {
        public const string Success = "SUCCESS";

        public const string Unknown = "UNKNOWN";

        public const string InvalidEmail = "INVALID_EMAIL";

        public const string RegisteredEmail = "REGISTERED_EMAIL";

        public const string TooFrequentRequest = "TOO_FREQUENT_REQEUST";

        public const string InvalidSessionId = "INVALID_SESSIONID";

        public const string InvalidPassword = "INVALID_PASSWORD";

        public const string InvalidVerificationCode = "INVALID_VERIFICATIONCODE";

        public const string InvalidEmailOrPassword = "INVALID_EMAIL_PASSWORD";
    }

    public enum MenuBehaviorType
    {
        ExitCurrentPage,
        ExitAllPage,
        ExitAllExcept,
    }

    /// <summary>
    /// 模块类型
    /// </summary>
    public enum ModuleType
    {
        //[Description("产品信息", "\xe642")]
        //Product,

        //[Description("生产计划", "\xe63a")]
        //ProductionPlan,

        //[Description("仓库管理", "\xe81b")]
        //WarehouseManagement,

        //[Description("设备管理", "\xe64a")]
        //EquipmentManagement,

        //[Description("插件管理", "\xe63b")]
        //PluginManagement,

        //[Description("参数配置", "\xe6ee")]
        //ParameterConfiguration,

        //[Description("调试软件", "\xe629")]
        //DebuggingSoftware,

        //[Description("演示平台", "\xe667")]
        //DemoPlatform,

        //[Description("演示软件", "\xe6a0")]
        //DemoSoftware,

        //[Description("标签功能", "\xe75c")]
        //LabelFunction,

        [Description("基础数据")]
        BasicData,

        //[Description("公共数据", "\xe610")]
        //PublicData,

        //[Description("文档中心", "\xe64d")]
        //DocumentCenter,

        [Description("设置中心")]
        SystemSettings,
    }
}
