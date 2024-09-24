using AlunosApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var startup = new Startup(builder.Configuration);

var services = builder.Services;
startup.ConfigureServices(services);

var app = builder.Build();

// Configure the HTTP request pipeline.
var webHostEnvironment = app.Environment;

startup.Configrue(app, webHostEnvironment);

app.Run();
