﻿using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace FitnessApp.Data
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private ISessionStorageService _sessionStorageService;
        public AuthStateProvider(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var email = await _sessionStorageService.GetItemAsync<string>("email");
            ClaimsIdentity identity;

            if (email != null) {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, email)
                }, "apiauth_type");
            }
            else
            {
                identity = new ClaimsIdentity();
            }
            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));
        }

        public void SetUserAuthenticated(string email)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, email)
            }, "apiauth_type");
            var user = new ClaimsPrincipal (identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void SetUserLoggedOut()
        {
            _sessionStorageService.RemoveItemAsync("email");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
