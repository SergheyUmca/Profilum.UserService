using Autofac;
using Autofac.Core;
using Profilum.UserService.BLL.Handlers.Implementations;
using Profilum.UserService.BLL.Handlers.Interfaces;
using Profilum.UserService.Common.BaseModels;

namespace Profilum.UserService.Api.AutoFacModules
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DiModule : ConfiguredModule
    {
        public DiModule(AppSettings settings) : base(settings)
        {
            
        }
        protected override void Load(ContainerBuilder builder)
        {
            var parameters = new List<Parameter>
            {
                new NamedParameter("connectionString", Settings.ConnectionString),
                new NamedParameter("dbName", Settings.Database)
            };
            
            builder.RegisterType<Services.UserService>().As<UserService.UserServiceBase>();
            builder.RegisterType<UserHandler>().As<IUserHandler>().WithParameters(parameters);
            builder.RegisterType<GrpcServer>().As<IHostedService>().InstancePerDependency().WithParameter( new NamedParameter("settings", Settings));
        }

        
    }
}