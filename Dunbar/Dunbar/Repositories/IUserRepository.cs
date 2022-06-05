using Dunbar.Models;
using System.Collections.Generic;

namespace Dunbar.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
    }
}