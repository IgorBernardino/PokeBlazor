using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PokeBlazor.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Serviços do jogo
builder.Services.AddSingleton<PokeService>();
builder.Services.AddSingleton<GameState>();

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
