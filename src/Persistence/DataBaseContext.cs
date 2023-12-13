using Microsoft.EntityFrameworkCore;
using Apizinha.src.Models;
namespace Apizinha.src.Persistence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options){

        }

        public DbSet<Person> Pessoas { get; set; }
        public DbSet<Contract> Contratos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Person>(tabela =>
            {
                tabela.HasKey(e => e.Id);
                tabela
                .HasMany(e => e.contratos)
                .WithOne()
                .HasForeignKey(c => c.PessoaId);
            });

            builder.Entity<Contract>(tabela => {
                tabela.HasKey(e => e.Id);
            });
        }



    }
}
