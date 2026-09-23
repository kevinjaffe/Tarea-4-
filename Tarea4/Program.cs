using Tarea4.Hubs;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSignalR();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.MapHub<LoginConVerificacionHub>("/login");

app.MapGet("/verificar/usuario/{userId}", (string userId,
    ILogger<LoginConVerificacionHub> logger,
    IHubContext<LoginConVerificacionHub> hubContext) =>
{
    logger.LogInformation($"Se notificará al cliente con id {userId}");
    hubContext.Clients.Client(userId).SendAsync("VerificacionOk", userId);
});

app.Run();