using biblioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace biblioApi.Data
{
    public class BiblioDbContext:DbContext
    {
        public BiblioDbContext(DbContextOptions options):base(options){}

        public DbSet<Livres> livres {get; set;}
    }
}