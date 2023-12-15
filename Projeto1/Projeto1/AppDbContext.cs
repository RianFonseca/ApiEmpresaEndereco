using Microsoft.EntityFrameworkCore;

namespace Teste
{

    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public int Empresa { get; internal set; }
    }
}