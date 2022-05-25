using AziendaTicketAMM_CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AziendaTicketAMM_EF
{
    public class StatoConfiguration : IEntityTypeConfiguration<Stato>
    {
        public void Configure(EntityTypeBuilder<Stato> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.NomeStato).IsRequired();


            //relazione con Ticket
            builder.HasMany(s => s.Tickets).WithOne(s => s.Stato);
            builder.HasData(new Stato() { Id = 1, NomeStato = "Nuovo" },
                new Stato() { Id = 2, NomeStato = "Assegnato" },
                new Stato() { Id = 3, NomeStato = "In Risoluzione" },
                new Stato() { Id = 4, NomeStato = "Chiuso" });
        }
    }
}