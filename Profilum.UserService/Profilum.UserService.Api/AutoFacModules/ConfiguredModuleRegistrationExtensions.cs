﻿using System.Reflection;
using Autofac;
using Autofac.Core;
using Profilum.UserService.Api.Models;

namespace Profilum.UserService.Api.AutoFacModules
{
    public static class ConfiguredModuleRegistrationExtensions
    {
        public static void RegisterConfiguredModulesFromAssemblyContaining<TType>(this ContainerBuilder builder,
            Settings settings)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            var metaBuilder = new ContainerBuilder();

            metaBuilder.RegisterInstance(settings);
            metaBuilder.RegisterAssemblyTypes(typeof(TType).GetTypeInfo().Assembly)
                .AssignableTo<IModule>()
                .As<IModule>()
                .PropertiesAutowired();

            // ReSharper disable once ConvertToUsingDeclaration
            using (var metaContainer = metaBuilder.Build())
            {
                foreach (var module in metaContainer.Resolve<IEnumerable<IModule>>())
                    builder.RegisterModule(module);
            }
        }
    }
}