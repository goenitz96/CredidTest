using Models;

namespace Interfaces;

public interface IPostService
{
    Task<IEnumerable<Post>> getPosts();
}