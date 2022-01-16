using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using MMM.Models;

namespace DataAccessLibrary
{
    public class AuthUserData : IAuthUserData
    {
        public AuthUser_Model authUser { get; set; }

        private AuthenticationStateProvider _authenticationStateProvider { get; set; }
        private UserManager<IdentityUser> _userManager { get; set; }

        public AuthUserData(AuthenticationStateProvider authenticationStateProvider, UserManager<IdentityUser> userManager)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _userManager = userManager;
            authUser = new();
        }

        public async Task<AuthUser_Model> GetAuthUserData()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();

            var currentUser = await _userManager.GetUserAsync(authState.User);
            authUser.Id = currentUser.Id;
            authUser.Username = currentUser.UserName;

            return authUser;
        }
    }
}
