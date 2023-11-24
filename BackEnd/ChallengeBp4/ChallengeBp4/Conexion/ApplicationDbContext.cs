using ChallengeBp4.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace ChallengeBp4.Conexion
{
    public class ApplicationDbContext: DbContext
    {
        

        public DbSet<Cliente> Clientes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
    }
}
