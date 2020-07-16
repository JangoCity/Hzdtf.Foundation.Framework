﻿using System;
using Autofac;
using Hzdtf.Authorization.Contract.Standard.IdentityAuth;
using Hzdtf.Authorization.Contract.Standard.IdentityAuth.Token;
using Hzdtf.Authorization.Web.Core;
using Hzdtf.Autofac.Extend.Standard;
using Hzdtf.BasicFunction.Model.Standard;
using Hzdtf.BasicFunction.Service.Impl.Standard;
using Hzdtf.BasicFunction.Service.Impl.Standard.Expand.Attachment;
using Hzdtf.BasicFunction.WorkFlow.Standard;
using Hzdtf.Platform.Config.Contract.Standard.Config.App;
using Hzdtf.Platform.Contract.Standard;
using Hzdtf.Platform.Contract.Standard.Config.AssemblyConfig;
using Hzdtf.Utility.Standard.Data;
using Hzdtf.WorkFlow.Service.Contract.Standard.Engine;
using Hzdtf.WorkFlow.Service.Impl.Standard.Engine;
using Microsoft.AspNetCore.Http;

namespace Hzdtf.WebTest3_1.Core.AppStart
{
    /// <summary>
    /// 依赖注入
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// 注册组件
        /// </summary>
        /// <param name="builder">内容生成</param>
        public static void RegisterComponents(ContainerBuilder builder)
        {
            AssemblyConfigLocalMember assemblyConfigLocalMember = new AssemblyConfigLocalMember();
            assemblyConfigLocalMember.ProtoAssemblyConfigReader = new AssemblyConfigJson();
            AssemblyConfigInfo assemblyConfig = assemblyConfigLocalMember.Reader();

            builder.UnifiedRegisterAssemblysV3_0(new BuilderParam()
            {
                AssemblyServices = assemblyConfig.Services,
                IsLoadAutoMapperConfig = assemblyConfig.IsLoadAutoMapperConfig,
                RegisteringServiceAction = () =>
                {
                    builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().AsSelf().PropertiesAutowired();

                    builder.RegisterType<IdentityCookieAuth<UserInfo>>().As<IIdentityAuth<UserInfo>>().AsSelf().PropertiesAutowired();
                    builder.RegisterType<IdentityCookieAuth<UserInfo>>().As<IIdentityAuthVali>().AsSelf().PropertiesAutowired();
                    builder.RegisterType<IdentityCookieAuth<UserInfo>>().As<IIdentityExit>().AsSelf().PropertiesAutowired();

                    //builder.RegisterType<IdentityJwtAuth<UserInfo>>().As<IIdentityTokenAuth>().AsSelf().PropertiesAutowired(); // 如果需要jwt认证，则需配置此句
                    //builder.RegisterType<IdentityJwtAuth<UserInfo>>().As<IReader<ReturnInfo<UserInfo>>>().AsSelf().PropertiesAutowired();// 如果需要jwt认证，则需配置此句

                    builder.RegisterType<WorkflowConfigCache>().As<IWorkflowConfigReader>().AsSelf().PropertiesAutowired();
                    builder.RegisterType<WorkflowInitSequenceService>().As<IWorkflowFormService>().AsSelf().PropertiesAutowired();

                    builder.RegisterType<AutofacInstance>().As<IInstance>().AsSelf().PropertiesAutowired().SingleInstance();
                }
            });
            builder.RegisterBuildCallback(container =>
            {
                PlatformTool.AppConfig = container.Resolve<IAppConfiguration>();

                AttachmentService attachmentService = container.Resolve<AttachmentService>();
                AttachmentOwnerLocalMember attachmentOwnerLocalMember = container.Resolve<AttachmentOwnerLocalMember>();
                attachmentOwnerLocalMember.ProtoAttachmentOwnerReader = container.Resolve<AttachmentOwnerJson>();

                attachmentService.AttachmentOwnerReader = attachmentOwnerLocalMember;
            });
        }
    }
}