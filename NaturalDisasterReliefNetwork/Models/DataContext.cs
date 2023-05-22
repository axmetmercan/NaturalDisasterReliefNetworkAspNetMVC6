using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace NaturalDisasterReliefNetwork.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //public DbSet<Request> Requests { get; set; }


        public DbSet<Cities> Cities { get; set; }
        public DbSet<Counties> Counties { get; set; }

        public DbSet<AddressesHasTypes> AddressesHasTypes { get; set; }

        public DbSet<Materials> Materials { get; set; }
        public DbSet<Categories> Categories { get; set; }   
        public DbSet<Authority> Authority { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<RequirementList> Requirements { get; set; }
    }

}
