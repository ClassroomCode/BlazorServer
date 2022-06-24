using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace ECommWeb.Authenticaton
{
    public class MyAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedBrowserStorage _sessionStorage;
        private ClaimsPrincipal _anon = new ClaimsPrincipal(new ClaimsIdentity());

        public MyAuthStateProvider(ProtectedBrowserStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
