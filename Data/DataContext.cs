using Fiap.Web.AspNet3.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet3.Data
{
    public class DataContext : DbContext
    {

        public DataContext()
        {

        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<RepresentanteModel> Representantes { get; set; }

        public DbSet<GerenteModel> Gerentes { get; set; }

        

    }
}
