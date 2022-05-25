using AziendaTicketAMM_CORE.Interfaces;
using AziendaTicketAMM_CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AziendaTicketAMM_CORE.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryTicket ticketRepo;
        private readonly IRepositoryStato statoRepo;
        private readonly IRepositoryCategoria categoriaRepo;

        public BusinessLayer(IRepositoryTicket ticketRepo)
        {
            this.ticketRepo = ticketRepo;
        }
        public BusinessLayer(IRepositoryStato statoRepo)
        {
            this.statoRepo = statoRepo;
        }
        public BusinessLayer(IRepositoryTicket ticketRepo, IRepositoryStato statoRepo, IRepositoryCategoria categoriaRepo)
        {
            this.ticketRepo = ticketRepo;
            this.statoRepo = statoRepo;
            this.categoriaRepo = categoriaRepo;
        }

        public bool Assegnazioneticket(Ticket ticket,Stato stato)
        {
            if(ticket == null && stato == null)
                return false;
            
            return ticketRepo.Update(ticket);
        }

        public bool ChiusuraTicket(Ticket ticket, Stato stato)
        {
            if (ticket == null && stato == null)
                return false;

            return ticketRepo.Update(ticket);
        }

        public bool CreateCategoria(Categoria newCategoria)
        {
            if (newCategoria == null)
                return false;

            return categoriaRepo.Add(newCategoria);
        }

        public bool CreateStato(Stato newStato)
        {
            if (newStato == null)
                return false;

            return statoRepo.Add(newStato);
        }

        public bool CreateTicket(Ticket newTicket)
        {
            if (newTicket == null)
                return false;

            return ticketRepo.Add(newTicket);
        }

        public bool DeleteCategoriaById(int idCategoria)
        {
            if (idCategoria <= 0)
                return false;



            Categoria categoriaToBeDeleted = this.categoriaRepo.GetById(idCategoria);



            if (categoriaToBeDeleted != null)
                return categoriaRepo.Delete(categoriaToBeDeleted);



            return false;
        }

        public bool DeleteStatoById(int idStato)
        {
            if(idStato <= 0)
            return false;



            Stato statoToBeDeleted = this.statoRepo.GetById(idStato);



            if (statoToBeDeleted != null)
                return statoRepo.Delete(statoToBeDeleted);



            return false;
        }

        public IEnumerable<Categoria> FetchAllCategorie()
        {
            return categoriaRepo.GetAll();
        }

        public IEnumerable<Stato> FetchAllStati()
        {
            return statoRepo.GetAll();
        }
    

        public IEnumerable<Ticket> FetchAllTicket()
        {
            return ticketRepo.GetAll();
        }

        public Categoria FetchCategoriaById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid id ");
            }
            return categoriaRepo.GetById(id);
        }

        public Stato FetchStatoById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid id ");
            }
            return statoRepo.GetById(id);
        }

        public Ticket FetchTicketById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid id ");
            }
            return ticketRepo.GetById(id);
            
        }

        public bool UpdateCategoriaById(int idCategoria)
        {
            if(idCategoria <= 0)
                return false;
            var categoria = categoriaRepo.GetById(idCategoria);
            if(categoria == null)
                return false;
            return categoriaRepo.Update(categoria);
        }

        public bool UpdateStatoById(int idStato)
        {
            if (idStato <= 0)
                return false;
            var stato = statoRepo.GetById(idStato);
            if (stato == null)
                return false;
            return statoRepo.Update(stato);
        }

        public bool UpdateTicket(Ticket ticket)
        {
            if (ticket == null)
                return false;
            return ticketRepo.Update(ticket);
        }
    }
}
