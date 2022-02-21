using Autofac;
using Profilum.UserService.Common.BaseModels;

namespace Profilum.UserService.Api.AutoFacModules
{
    public abstract class ConfiguredModule : Module, IConfiguredModule
    {
        protected ConfiguredModule(AppSettings settings)
        {
            Settings = settings;
        }

        public AppSettings Settings { get; set; }
    }
}