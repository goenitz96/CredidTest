using Models;

namespace Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> getUsers();
}