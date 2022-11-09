using Fiap.GlobalSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.GlobalSolution.Persistencia
{
    public class GlobalSolutionContext : DbContext
    {
        public DbSet<Corrida> Corridas{ get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<Passageiro> Passageiros { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<PontoTrabalho> PontosTrabalho{ get; set; }
        public DbSet<MotoristaPontoTrabalho> MotoristaPontoTrabalhos { get; set; }
        public GlobalSolutionContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MotoristaPontoTrabalho>()
                .HasKey(m => new { m.PontoTrabalhoId, m.MotoristaId });
            modelBuilder.Entity<MotoristaPontoTrabalho>()
                .HasOne(m => m.Motorista)
                .WithMany(m => m.MotoristaPontoTrabalhos)
                .HasForeignKey(m => m.MotoristaId);
            modelBuilder.Entity<MotoristaPontoTrabalho>()
                .HasOne(m => m.PontoTrabalho)
                .WithMany(m => m.MotoristaPontoTrabalhos)
                .HasForeignKey(m => m.PontoTrabalhoId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
