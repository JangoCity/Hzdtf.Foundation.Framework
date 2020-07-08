﻿using Hzdtf.Authorization.Web.Core;
using Hzdtf.Autofac.Extend.Standard;
using Hzdtf.BasicFunction.WorkFlow.Standard;
using Hzdtf.Platform.Contract.Standard;
using Hzdtf.Platform.Impl.Core;
using Hzdtf.Utility.Standard.Model;
using Hzdtf.Utility.Standard.Model.Return;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hzdtf.WebTest3_1.Core.AppStart
{
    /// <summary>
    /// 用户配置
    /// </summary>
    public static class UserConfig
    {
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            UserTool.GetCurrUserFunc = () =>
            {
                ReturnInfo<BasicUserInfo> returnInfo = AutofacTool.Resolve<IdentityCookieAuth>().Reader();
                if (returnInfo.Success() && returnInfo.Data != null)
                {
                    return returnInfo.Data;
                }

                if (PlatformTool.AppConfig["User:AllowTest"] != null && Convert.ToBoolean(PlatformTool.AppConfig["User:AllowTest"]))
                {
                    return UserTool.TestUser;
                }

                return null;
            };

            UserWorkflowUtil.InitValiUserHandleVali();
        }
    }
}
