using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web.Shared.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<CookBookViewModel>();

await builder.Build().RunAsync();
