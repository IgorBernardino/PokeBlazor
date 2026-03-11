using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PokeBlazor.Components;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5000");

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<PokeService>();
builder.Services.AddSingleton<GameState>();

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// ✅ Abre o navegador automaticamente ao iniciar
app.Lifetime.ApplicationStarted.Register(() =>
{
    Process.Start(new ProcessStartInfo
    {
        FileName  = "http://localhost:5000",
        UseShellExecute = true
    });
});

app.Run();