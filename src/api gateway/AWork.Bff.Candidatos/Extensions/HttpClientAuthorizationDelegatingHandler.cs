﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AWork.Candidatos.Domain.Interfaces;
using System.Net.Http.Headers;
using System.Threading;
using AWork.WebAPI.Core.Identity;
using AWork.WebAPI.Core.User;

namespace AWork.Bff.Candidatos.Extensions
{
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {

        private readonly IAspNetUser _user;

        public HttpClientAuthorizationDelegatingHandler(IAspNetUser user)
        {
            _user = user;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {

            var authorizationHeader = _user.GetHttpContext().Request.Headers["Authorization"];

            if (!string.IsNullOrEmpty(authorizationHeader))
                request.Headers.Add("Authorization", new List<string>() {authorizationHeader});

            var token = _user.GetUserToken();

            if (token != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return base.SendAsync(request, cancellationToken);
        }
    }
}