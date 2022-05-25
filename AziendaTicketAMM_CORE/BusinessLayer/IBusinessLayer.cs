using AziendaTicketAMM_CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AziendaTicketAMM_CORE.BusinessLayer
{
    public interface IBusinessLayer
    {
        #region Ticket
        bool CreateTicket(Ticket newTicket);

        IEnumerable<Ticket> FetchAllTicket();
        Ticket FetchTicketById(int id);

        bool Assegnazioneticket(Ticket ticket,Stato stato);

        bool UpdateTicket(Ticket ticket);
        bool ChiusuraTicket(Ticket ticket,Stato stato);
        #endregion

        #region Categoria
        IEnumerable<Categoria> FetchAllCategorie();
        Categoria FetchCategoriaById(int id);
        bool CreateCategoria(Categoria newCategoria);
        bool DeleteCategoriaById(int idCategoria);
        bool UpdateCategoriaById(int idCategoria);
        #endregion

        #region Stato
        IEnumerable<Stato> FetchAllStati();
        Stato FetchStatoById(int id);
        bool CreateStato(Stato newStato);
        bool DeleteStatoById(int idStato);
        bool UpdateStatoById(int idStato);
        #endregion
    }
}
