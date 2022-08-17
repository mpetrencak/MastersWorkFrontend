using DP.Frontend;
using DP.Frontend.Handlers;
using DP.Frontend.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var config = builder.Configuration;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient<IHttpClientService, HttpClientService>
(
    client => client.BaseAddress = new Uri(config["ApiUrl"])
).AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddHttpClient<IAnonymousHttpClientService, AnonymousHttpClientService>
(
    client => client.BaseAddress = new Uri(config["ApiUrl"])
);

builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = config["IdentityServerUrl"];
    options.ProviderOptions.ClientId = "BlazorWasm";
    //options for react project
    options.ProviderOptions.RedirectUri = config["ReactUrl"] + "/authentication/login-callback";
    options.ProviderOptions.PostLogoutRedirectUri = config["ReactUrl"] + "/authentication/logout-callback";

    //options for wasm from VS
    //options.ProviderOptions.RedirectUri = config["WasmUrl"] + "/authentication/login-callback";
    //options.ProviderOptions.PostLogoutRedirectUri = config["WasmUrl"] + "/authentication/logout-callback";

    options.ProviderOptions.DefaultScopes.Add("openid");
    options.ProviderOptions.DefaultScopes.Add("profile");
    options.ProviderOptions.DefaultScopes.Add("email");
    options.ProviderOptions.DefaultScopes.Add("dpapi");
    options.ProviderOptions.DefaultScopes.Add("role");
    options.ProviderOptions.ResponseType = "code";
});

builder.Services.AddAuthorizationCore(authorizationOptions =>
{
    authorizationOptions.AddPolicy(Policies.CanHaveAdmin, Policies.CanHaveAdminPolicy());
    authorizationOptions.AddPolicy(Policies.CanHaveModerator, Policies.CanHaveModeratorPolicy());
});

builder.RootComponents.RegisterForJavaScript<App>("blazor-app-react");

await builder.Build().RunAsync();