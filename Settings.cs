using Newtonsoft.Json;
using PeterHan.PLib.Options;


namespace DupeAttrMod
{
    [RestartRequired]
    [JsonObject(MemberSerialization.OptIn)]//只有带[JsonProperty]的属性会序列化
    public class Settings
    {
        private static Settings _instance;
        public const int CURRENT_CONFIG_VERSION = 0;
        public Settings()
        {
            ConfigVersion = CURRENT_CONFIG_VERSION;
        }
        [JsonProperty]
        public int ConfigVersion
        {
            get; set;
        }
        public static Settings Instance
        {
            get
            {
                var opts = _instance;
                if (opts == null)
                {
                    opts = POptions.ReadSettings<Settings>();
                    if (opts == null || opts.ConfigVersion < CURRENT_CONFIG_VERSION)
                    {
                        opts = new Settings();
                        POptions.WriteSettings(opts);
                    }
                    _instance = opts;
                }
                return opts;
            }
        }

        [Option("力量调整" , null)]
        [Limit(0 , 9999)]
        [JsonProperty]
        public int Strength { get; set; } = 1000;

        [Option("医疗调整" , null)]
        [Limit(0 , 9999)]
        [JsonProperty]
        public int Caring { get; set; } = 1000;

        [Option("建造调整" , null)]
        [Limit(0 , 9999)]
        [JsonProperty]
        public int Construction { get; set; } = 1000;

        [Option("挖掘调整" , null)]
        [Limit(0 , 9999)]
        [JsonProperty]
        public int Digging { get; set; } = 1000;

        [Option("机械调整" , null)]
        [Limit(0 , 9999)]
        [JsonProperty]
        public int Machinery { get; set; } = 1000;

        [Option("科学调整" , null)]
        [Limit(0 , 9999)]
        [JsonProperty]
        public int Learning { get; set; } = 1000;

        [Option("烹饪调整" , null)]
        [Limit(0 , 9999)]
        [JsonProperty]
        public int Cooking { get; set; } = 1000;

        [Option("农业调整" , null)]
        [Limit(0 , 9999)]
        [JsonProperty]
        public int Botanist { get; set; } = 1000;

        [Option("创作调整" , null)]
        [Limit(0 , 9999)]
        [JsonProperty]
        public int Art { get; set; } = 1000;

        [Option("畜牧调整" , null)]
        [Limit(0 , 9999)]
        [JsonProperty]
        public int Ranching { get; set; } = 1000;

        [Option("运动调整" , null)]
        [Limit(0 , 9999)]
        [JsonProperty]
        public int Athletics { get; set; } = 1000;

        [Option("驾驶调整" , null)]
        [Limit(0 , 9999)]
        [JsonProperty]
        public int SpaceNavigation { get; set; } = 1000;
    }
}
