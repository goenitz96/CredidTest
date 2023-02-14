using Models;

namespace Interfaces;

public interface ICommentService
{
    Task<IEnumerable<Comment>> getComments();
}