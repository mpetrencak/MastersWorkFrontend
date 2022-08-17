using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace DP.Frontend.Handlers
{
    public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigation, IConfiguration configuration) : base(provider, navigation)
        {
            //ConfigureHandler(authorizedUrls: new[] { "https://localhost:44000" }, null, "https://localhost:44001");
            ConfigureHandler(authorizedUrls: new[] { configuration["ApiUrl"] });
        }
    }
}
