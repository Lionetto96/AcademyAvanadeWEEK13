using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace AziendaTicketAMM_CORE.Models
{
    [DataContract]
    public class Ticket
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime DataCreazione{ get; set; }
        [DataMember]
        public string Richiedente{ get; set; }
        [DataMember]
        public string DescrizioneBreve{ get; set; }
        [DataMember]
        public string DescrizioneLunga{ get; set; }
        [DataMember]
        public string Assegnatario{ get; set; }
        [DataMember]
        public DateTime? DataChiusura{ get; set; }

        public int IDCategoria { get; set; }
        public int IDStato { get; set; }

        public Categoria Categoria { get; set; }
        public Stato Stato { get; set; }
    }
}
