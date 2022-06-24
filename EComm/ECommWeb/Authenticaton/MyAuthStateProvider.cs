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

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var userSeesionResult = await _sessionStorage.GetAsync<UserSession>("UserSession");
                var userSession = userSeesionResult.Success ? userSeesionResult.Value : null;
                if (userSession == null) return new AuthenticationState(_anon);
                var user = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }, "CustomAuth"));
                return new AuthenticationState(user);
            }
            catch
            {
                return new AuthenticationState(_anon);
            }
        }

        public async Task UpdateAuthenticationState(UserSession userSession)
        {
            ClaimsPrincipal claimsPrincipal;
            if (userSession != null)
            {
                await _sessionStorage.SetAsync("UserSession", userSession);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role)
                }));
            }
            else
            {
                await _sessionStorage.DeleteAsync("UserSession");
                claimsPrincipal = _anon;
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
