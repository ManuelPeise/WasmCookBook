using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web.Shared.ViewModels.Cookbook;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<AddRecipePageViewModel>();
builder.Services.AddTransient<CookbookViewModel>();
builder.Services.AddTransient<RecipeManagementViewModel>();

await builder.Build().RunAsync();
