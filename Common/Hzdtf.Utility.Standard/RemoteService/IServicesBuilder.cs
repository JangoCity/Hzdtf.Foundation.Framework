﻿using Hzdtf.Utility.Standard.LoadBalance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hzdtf.Utility.Standard.RemoteService
{
    /// <summary>
    /// 服务生成器接口
    /// @ 黄振东
    /// </summary>
    public interface IServicesBuilder
    {
        /// <summary>
        /// 服务提供者
        /// </summary>
        IServicesProvider ServiceProvider
        {
            get;
            set;
        }

        /// <summary>
        /// 服务名
        /// </summary>
        string ServiceName
        {
            get;
            set;
        }

        /// <summary>
        /// 方案
        /// </summary>
        string Sheme
        {
            get;
            set;
        }

        /// <summary>
        /// 标签
        /// </summary>
        string Tag
        {
            get;
            set;
        }

        /// <summary>
        /// 负载均衡策略
        /// </summary>
        ILoadBalance LoadBalance
        {
            get;
            set;
        }

        /// <summary>
        /// 异步生成Uri
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>生成Uri任务</returns>
        Task<Uri> BuilderAsync(string path);
    }
}
