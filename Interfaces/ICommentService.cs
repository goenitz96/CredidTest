using Models;

namespace Interfaces;

public interface ICommentService
{
    Task<IEnumerable<Comment>> getComments();
    Task<IEnumerable<Comment>> searchByNameOrBody(string name, string body);
}