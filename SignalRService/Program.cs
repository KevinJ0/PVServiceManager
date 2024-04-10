using SignalRService.Hubs;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<MainHub>("/mainHub");

app.Run();
