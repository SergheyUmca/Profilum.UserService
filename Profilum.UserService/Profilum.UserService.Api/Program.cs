using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using Profilum.UserService.Api.AutoFacModules;
using Profilum.UserService.Common.BaseModels;

var _grpcPortDefault = 7001;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appSettings = new AppSettings
{
    ConnectionString =  builder.Configuration.GetSection("MongoConnection:ConnectionString").Value,
    Database = builder.Configuration.GetSection("MongoConnection:Database").Value,
    GrpcServerPort = int.TryParse(builder.Configuration.GetSection("Application:GrpcServerPort")?.Value, out var grpcPort)
        ? grpcPort
        : _grpcPortDefault
};
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(b =>
    b.RegisterConfiguredModulesFromAssemblyContaining<DiModule>(appSettings));

// builder.Services.AddTransient<UserService>();
// builder.Services.AddHostedService<GrpcServer>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();