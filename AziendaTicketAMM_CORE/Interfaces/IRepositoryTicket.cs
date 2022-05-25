using AziendaTicketAMM_CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AziendaTicketAMM_CORE.Interfaces
{
    public interface IRepositoryTicket :IRepository<Ticket>
    {
        bool AssegnazioneTicket(Ticket ticket,Stato stato);
        bool ChiusuraTicket(Ticket ticket,Stato stato);

    }
}
