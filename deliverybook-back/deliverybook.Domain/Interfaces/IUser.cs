using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace deliverybook.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        string GetUserId();
        string GetUserEmail();
        string GetUserName();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
