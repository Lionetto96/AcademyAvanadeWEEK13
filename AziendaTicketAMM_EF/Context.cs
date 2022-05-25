using AziendaTicketAMM_CORE.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AziendaTicketAMM_EF
{
    public class Context :DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Stato> Stati { get; set; }
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestioneTicketAziendaAMM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Ticket>(new TicketConfiguration());
            modelBuilder.ApplyConfiguration<Categoria>(new CategoriaConfiguration());
            modelBuilder.ApplyConfiguration<Stato>(new StatoConfiguration());

        }
    }
}
