using Grpc.Core;
using Profilum.UserService.Common.BaseModels;
using UserGrpcService = Profilum.UserService.Api.Services.UserService;

namespace Profilum.UserService.Api;

internal class GrpcServer : IHostedService
{
    private readonly Server _server;
    //private readonly UserGrpcService _userService;

    public GrpcServer(UserService.UserServiceBase userService, AppSettings settings)
    {
        //var credentials = BuildSSLCredentials(); // строим креды из сертификата и приватного ключа. 
        _server = new Server //создаем объект сервера
        {
            Ports = { new ServerPort("localhost", settings.GrpcServerPort, ServerCredentials.Insecure) }, // биндим сервер к адресу и порту
            Services = // прописываем службы которые будут доступны на сервере
            {
                UserService.BindService(userService)
            }
        };            
    }

    /// <summary>
    /// Вспомогательный метод генерации серверных кредов из сертификата
    /// </summary>
    private ServerCredentials BuildSSLCredentials()
    {
        var cert = File.ReadAllText("cert\\server.crt");
        var key = File.ReadAllText("cert\\server.key");

        var keyCertPair = new KeyCertificatePair(cert, key);
        return new SslServerCredentials(new[] { keyCertPair });
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _server.Start();
        return Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _server.ShutdownAsync();
    }
}