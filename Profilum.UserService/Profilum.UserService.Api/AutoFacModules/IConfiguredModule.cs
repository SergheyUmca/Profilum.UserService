using Profilum.UserService.Common.BaseModels;

namespace Profilum.UserService.Api.AutoFacModules
{
    public interface IConfiguredModule
    {
        AppSettings Settings { get; set; }
    }
}