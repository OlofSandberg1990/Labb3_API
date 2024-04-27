using Labb3_API.Data;
using Labb3_API.Models;
using Labb3_API.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Labb3_API.Services.Repos
{
    public class PersonRepository : IPerson
    {
        private AppDbContext _appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Link> AddLink(int personId, int interestId, string url)
        {

            //Skapar en personInterest-variabel som får det inskickade personId och InterestId
            var result = await _appDbContext.PersonInterests
                .FirstOrDefaultAsync(pi => pi.PersonId == personId && pi.InterestId == interestId);

            //Om inte denna relationen finns, retunera null
            if (result == null)
            {
                return null;
            }

            //Skapar en ny Link och lägger till i databasen.
            var newLink = new Link
            {
                URL = url,
                PersonInterestId = result.Id
            };
            _appDbContext.Links.Add(newLink);
            await _appDbContext.SaveChangesAsync();

            return newLink;
        }

        public async Task<PersonInterest> AddNewPersonInterest(int personId, int interestId)
        {
            //Kollat först om relationen redan finns mellan personId och interestId
            var existingUser = await _appDbContext.PersonInterests.FirstOrDefaultAsync(
                pi => pi.PersonId == personId && pi.InterestId == interestId);

            
            if (existingUser != null)
            {
                return null;
            }

            // Annars skapas ett nytt objekt av PersonInterest...
            var newInterest = new PersonInterest
            {
                PersonId = personId,
                InterestId = interestId
            };

            // ...som sedan läggs till och sparas i PersonInterest-tabellen
            _appDbContext.PersonInterests.Add(newInterest);
            await _appDbContext.SaveChangesAsync();
            return newInterest;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _appDbContext.Persons.ToListAsync();
        }

        public async Task<IEnumerable<Interest>> GetInterestById(int personId)
        {
            return await _appDbContext.PersonInterests
                .Where(pi => pi.PersonId == personId)   //Filtrerar PersonIntrest baserat på personId:t som skickas med som inparameter
                .Select(pi => pi.Interest)      //Väljer ut de intresseobjekt från de hittade relationerna
                .ToListAsync();
        }

        public async Task<IEnumerable<Link>> GetLinksById(int id)
        {
            return await _appDbContext.PersonInterests
                .Where(pi => pi.PersonId == id) //Filtrera PersonIntrests baserat på det medskickade id:t
                .Include(pi => pi.Links) //Inkludera även länkobjekten
                .SelectMany(pi => pi.Links) //Välj ut de länkar som är inkluderade
                .ToListAsync();
        }
    }
}
