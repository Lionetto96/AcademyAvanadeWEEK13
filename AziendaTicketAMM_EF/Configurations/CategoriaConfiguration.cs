using AziendaTicketAMM_CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AziendaTicketAMM_EF
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.NomeCategoria).IsRequired();
            builder.Property(c => c.Descrizione).IsRequired();

            //relazione con Ticket
            builder.HasMany(c => c.Tickets).WithOne(c => c.Categoria);
            builder.HasData(new Categoria() { Id = 1, NomeCategoria = "System", Descrizione = "Descrizione System" },
                new Categoria() { Id = 2, NomeCategoria = "Development", Descrizione = "descrizione Development" },
                new Categoria() { Id = 3, NomeCategoria = "Office Application", Descrizione = "descrizione Office App" },
                new Categoria() { Id = 4, NomeCategoria = "SAP", Descrizione = "descrizione SAP" },
                new Categoria() { Id = 5, NomeCategoria = "Other", Descrizione = "descrizione other" });
        }
    }
}