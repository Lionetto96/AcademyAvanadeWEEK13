using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AziendaTicketAMM_CORE.Models
{    
    [DataContract]
    public class Stato
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string NomeStato { get; set; }

        public List<Ticket> Tickets { get; set; }=new List<Ticket>();
    }
}
