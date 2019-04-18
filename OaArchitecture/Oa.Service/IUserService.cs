namespace Oa.Service
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Oa.Data;

    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(Guid id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid id);
    }
}