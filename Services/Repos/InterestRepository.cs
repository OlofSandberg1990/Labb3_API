using Labb3_API.Data;
using Labb3_API.Models;
using Labb3_API.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Services.Repos
{
    public class InterestRepository : IInterest
    {
        private AppDbContext _appDbContext;

        public InterestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _appDbContext.Interests.ToListAsync();
        }
    }
}
