using Labb3_API.Data;
using Labb3_API.Models;

namespace Labb3_API.Services.Interface
{
    public interface IPerson
    {
        Task<IEnumerable<Person>> GetAll();
        Task<IEnumerable<Link>> GetLinksById(int id);
        Task<IEnumerable<Interest>>GetInterestById(int id);
                               
        Task<PersonInterest> AddNewPersonInterest(int personId, int interestId);
        Task<Link> AddLink(int personId, int interestId, string url);

    }
}
