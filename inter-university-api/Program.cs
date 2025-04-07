using inter_university_api;

var builder = WebApplication.CreateBuilder(args);

// Usa la clase Startup
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
