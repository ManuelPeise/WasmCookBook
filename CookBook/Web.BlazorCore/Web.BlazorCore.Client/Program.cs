using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web.Shared.ViewModels;
using Web.Shared.ViewModels.Cookbook;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<AddRecipePageViewModel>();
builder.Services.AddTransient<CookbookViewModel>();

await builder.Build().RunAsync();
