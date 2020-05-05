﻿using MessagePack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hzdtf.Utility.Standard.Language
{
    /// <summary>
    /// 语系信息
    /// @ 黄振东
    /// </summary>
    [MessagePackObject]
    public class LanguageInfo
    {
        /// <summary>
        /// 简体中文
        /// </summary>
        public const string zh_CN = "zh-CN";

        /// <summary>
        /// 繁体中文
        /// </summary>
        public const string zh_TW = "zh-TW";

        /// <summary>
        /// 英文
        /// </summary>
        public const string en_US = "en-US";

        /// <summary>
        /// 键
        /// </summary>
        [JsonProperty("key")]
        [Key("key")]
        public string Key
        {
            get;
            set;
        }

        /// <summary>
        /// 简体中文
        /// </summary>
        [JsonProperty("zh-CN")]
        [Key("zh-CN")]
        public string ZH_CN
        {
            get;
            set;
        }

        /// <summary>
        /// 繁体中文
        /// </summary>
        [JsonProperty("zh-TW")]
        [Key("zh-TW")]
        public string ZH_TW
        {
            get;
            set;
        }

        /// <summary>
        /// 英文
        /// </summary>
        [JsonProperty("en-US")]
        [Key("en-US")]
        public string EN_US
        {
            get;
            set;
        }
    }
}
