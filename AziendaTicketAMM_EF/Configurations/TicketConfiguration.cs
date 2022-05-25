using AziendaTicketAMM_CORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AziendaTicketAMM_EF
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DataCreazione).IsRequired();
            builder.Property(c => c.Richiedente).IsRequired();
            builder.Property(c => c.DescrizioneBreve).IsRequired();
            builder.Property(c => c.DescrizioneLunga).IsRequired();
            builder.Property(c => c.Assegnatario);
            builder.Property(c => c.DataChiusura);


            //relazione con Categoria e Stato 
            builder.HasOne(t => t.Categoria).WithMany(t =>t.Tickets).HasForeignKey(t => t.IDCategoria);
            builder.HasOne(t=>t.Stato).WithMany(t=>t.Tickets).HasForeignKey(t=>t.IDStato);
            builder.HasData(new Ticket() { Id=1, DataCreazione=new System.DateTime(2022,01,12),Richiedente="Alessia", DescrizioneBreve="descrizione breve 1",DescrizioneLunga="descrizione lunga 1",IDCategoria=1,IDStato=1});
        }
    }
}
