using Microsoft.EntityFrameworkCore;
using RestApi_Uppgift.Models;

namespace RestApi_Uppgift.Data
{
    public class WorkDBContext: DbContext
    {
        public WorkDBContext(DbContextOptions<WorkDBContext> options) : base(options)
        {

        }

        public DbSet<Arbetserfarenhet> erfarenheter { get; set; }
        public DbSet<Person> person { get; set; }
        public DbSet<Utbildning> utbildnings { get; set; }
    }
}