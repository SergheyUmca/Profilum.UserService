using Autofac;
using Autofac.Core;
using Profilum.UserService.Api.Models;
using Profilum.UserService.BLL.Handlers.Implementations;
using Profilum.UserService.BLL.Handlers.Interfaces;

namespace Profilum.UserService.Api.AutoFacModules
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class HandlersModule : ConfiguredModule
    {
        public HandlersModule(Settings settings) : base(settings)
        {
            
        }
        protected override void Load(ContainerBuilder builder)
        {
            var parameters = new List<Parameter>
            {
                new NamedParameter("connectionString", Settings.ConnectionString),
                new NamedParameter("dbName", Settings.Database)
            };

            builder.RegisterType<UserHandler>().As<IUserHandler>().WithParameters(parameters);
        }

        
    }
}