using Labb3_API.Data;
using Labb3_API.Models;
using Labb3_API.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Services.Repos
{
    public class LinkRepository : ILink
    {
        private AppDbContext _appDbContext;

        public LinkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Link>> GetAll()
        {
            return await _appDbContext.Links.ToListAsync();
        }
    }
}
