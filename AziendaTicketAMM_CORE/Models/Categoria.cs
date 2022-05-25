using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AziendaTicketAMM_CORE.Models
{
    [DataContract]
    public class Categoria
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string NomeCategoria { get; set; }
        [DataMember]
        public string Descrizione { get; set; }

        public List<Ticket> Tickets { get; set; }= new List<Ticket>();
    }
}
