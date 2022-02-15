using Profilum.UserService.Api.Models;

namespace Profilum.UserService.Api.AutoFacModules
{
    public interface IConfiguredModule
    {
        Settings Settings { get; set; }
    }
}