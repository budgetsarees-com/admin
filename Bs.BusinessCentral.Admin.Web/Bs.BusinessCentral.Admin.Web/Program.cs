using Blazored.LocalStorage;
using Bs.BusinessCentral.Admin.Web;
using Bs.BusinessCentral.Admin.Web.Helpers;
using Bs.BusinessCentral.Admin.Web.Services.AccountService;
using Bs.BusinessCentral.Admin.Web.Services.ProductType;
using Bs.BusinessCentral.Admin.Web.Services.SessionService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, BsStateProvider>();
builder.Services.AddScoped<BsStateProvider, BsStateProvider>();
builder.Services.AddScoped<BsHttpClient, BsHttpClient>();

builder.Services.AddTransient<IAccountSrv, AccountSrv>();
builder.Services.AddTransient<ISessionSrv, SessionSrv>();
builder.Services.AddTransient<ITokenSrv, TokenSrv>();
builder.Services.AddTransient<IProductTypeSrv, ProductTypeSrv>();

if (builder.HostEnvironment.IsDevelopment())
{
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7088/api/") });
}
else
{
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://api.budgetsarees.com/api/") });
}

builder.Services.AddBlazorBootstrap();
builder.Services.RegisterLocalStorage();

//builder.Services.AddBlazoredToast();BsStateProvider

await builder.Build().RunAsync();
