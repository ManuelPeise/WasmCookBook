using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web.Shared.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<AddRecipeViewModel>();

await builder.Build().RunAsync();
