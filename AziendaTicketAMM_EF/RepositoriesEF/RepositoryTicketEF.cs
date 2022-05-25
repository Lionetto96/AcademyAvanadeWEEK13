using AziendaTicketAMM_CORE.Interfaces;
using AziendaTicketAMM_CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AziendaTicketAMM_EF.RepositoriesEF
{
    public class RepositoryTicketEF : IRepositoryTicket
    {
        private readonly Context ctx;
        public RepositoryTicketEF() : this (new Context())
        {

        }
        public RepositoryTicketEF(Context ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Ticket entity)
        {
            try
            {
                ctx.Tickets.Add(entity);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AssegnazioneTicket(Ticket ticket,Stato stato)
        {
            
            ticket.Assegnatario = "Assegnatario1";
            ticket.IDStato = stato.Id;

            ctx.Tickets.Update(ticket);
            ctx.SaveChanges();
            return true;
        }

        public bool ChiusuraTicket(Ticket ticket, Stato stato)
        {
            ticket.DataChiusura = DateTime.Now;
            ticket.IDStato = stato.Id;

            ctx.Tickets.Update(ticket);
            ctx.SaveChanges ();
            return true;


        }

        public IEnumerable<Ticket> GetAll()
        {
           return ctx.Tickets;
        }

        public Ticket GetById(int id)
        {
            return ctx.Tickets.Find(id);
        }

        public bool Update(Ticket ticket)
        {
            ctx.Tickets.Update(ticket);
            ctx.SaveChanges();
            return true;
        }
    }
}
