﻿namespace Showcase.Services.Data.Contracts
{
    using Showcase.Data.Models;
    using System.Linq;

    using Showcase.Services.Common;

    public interface IUsersService : IService
    {
        string GetUserId(string username);

        Task<User> GetAccountAsync(string username, string password);
        IQueryable<User> GetByUsername(string username);
    }
}