using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace AWork.Candidates.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        Guid  CandidateId { get; }
        Guid GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
        //IEnumerable<Claim> GetEntitiesUser();

    }
}
