using Labb3_API.Models;

namespace Labb3_API.Services.Interface
{
    public interface ILink
    {
        Task<IEnumerable<Link>> GetAll();
    }
}
