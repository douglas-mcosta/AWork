using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace AWork.WebAPI.Core.User
{
    public interface IAspNetUser
    {
        string Name { get; }
        Guid  CandidateId { get; }
        Guid GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        string GetUserToken();
        IEnumerable<Claim> GetClaimsIdentity();
        //IEnumerable<Claim> GetEntitiesUser();
        HttpContext GetHttpContext();


    }
}
