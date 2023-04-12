using BlazorCQRS.Api;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

await app.ConfigureDatabaseAsync();

app.Run();
