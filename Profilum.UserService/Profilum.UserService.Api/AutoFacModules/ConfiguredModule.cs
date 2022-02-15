using Autofac;
using Profilum.UserService.Api.Models;

namespace Profilum.UserService.Api.AutoFacModules
{
    public abstract class ConfiguredModule : Module, IConfiguredModule
    {
        protected ConfiguredModule(Settings settings)
        {
            Settings = settings;
        }

        public Settings Settings { get; set; }
    }
}