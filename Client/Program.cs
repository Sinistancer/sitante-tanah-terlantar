using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazor.Client;
using Blazor.Client.BFF;
using Microsoft.AspNetCore.Components.Authorization;
using Blazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, BffAuthenticationStateProvider>();

builder.Services.AddSingleton<BreadcrumbUpdateService>();
builder.Services.AddSingleton<SideBarUpdateService>();
builder.Services.AddScoped<BodyCssService>();
builder.Services.AddSingleton<SharedDataService>();

// HTTP client configuration
builder.Services.AddTransient<AntiforgeryHandler>();

builder.Services
    .AddHttpClient("backend", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<AntiforgeryHandler>();

builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("backend"));

await builder.Build().RunAsync();
