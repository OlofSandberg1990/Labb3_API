using Microsoft.EntityFrameworkCore;
using Labb3_API.Models;

namespace Labb3_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<PersonInterest> PersonInterests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Person) 
                .WithMany(p => p.PersonInterests) 
                .HasForeignKey(pi => pi.PersonId);

            modelBuilder.Entity<PersonInterest>()
                .HasOne(pi => pi.Interest)
                .WithMany(i => i.PersonInterests)
                .HasForeignKey(pi => pi.InterestId);

            

            modelBuilder.Entity<Link>()
                .HasOne(l => l.PersonInterest) 
                .WithMany(pi => pi.Links) 
                .HasForeignKey(l => l.PersonInterestId); 

            
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Erik Andersson", PhoneNumber = "0701234567" },                
                new Person { Id = 2, Name = "Jonatan Nordin", PhoneNumber = "072344412412" },
                new Person { Id = 3, Name = "Olof Sandberg", PhoneNumber = "07234124124" },
                new Person { Id = 4, Name = "Nina Lindberg Nilsson", PhoneNumber = "0723412123123" },
                new Person { Id = 5, Name = "Pär Sandberg", PhoneNumber = "072341233334" },
                new Person { Id = 6, Name = "Sara Johansson", PhoneNumber = "0762055271" }
               
            );

           
            modelBuilder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Gardening", Description = "Growing plants and vegetables" },
                new Interest { Id = 2, Title = "Programming", Description = "Developing software and applications" },
                new Interest { Id = 3, Title = "Discgolf", Description = "Playing Discgolf" },
                new Interest { Id = 4, Title = "Soccer", Description = "Playing Soccer" }
            );

            
            modelBuilder.Entity<PersonInterest>().HasData(
                new PersonInterest { Id = 1, PersonId = 1, InterestId = 1 },
                new PersonInterest { Id = 2, PersonId = 1, InterestId = 2 },
                new PersonInterest { Id = 3, PersonId = 2, InterestId = 2 },
                new PersonInterest { Id = 4, PersonId = 1, InterestId = 3 },
                new PersonInterest { Id = 5, PersonId = 5, InterestId = 4 }
                
            );

            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, URL = "http://www.gardeningexample.com", PersonInterestId = 1 }, 
                new Link { Id = 2, URL = "http://www.programmingexample.com", PersonInterestId = 1 }, 
                new Link { Id = 3, URL = "http://www.discGolfWithOlof.com", PersonInterestId =  3},                  
                new Link { Id = 4, URL = "http://www.discGolfWithOlofPROEDITION.com", PersonInterestId = 4 } 
);

        }



    }
}
