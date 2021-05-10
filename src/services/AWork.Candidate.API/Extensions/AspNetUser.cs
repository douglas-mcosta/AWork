﻿using AWork.Candidates.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace AWork.Candidates.API.Extensions
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        public AspNetUser(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;
        public Guid CandidateId => GetUserId();

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string GetUserEmail()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetUserEmail() : "";
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool IsInRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }
        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

    }

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));
            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);

            return claim?.Value;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentException(nameof(principal));
            var claim = principal.FindFirst(ClaimTypes.Email);

            return claim?.Value;
        }
    }
}