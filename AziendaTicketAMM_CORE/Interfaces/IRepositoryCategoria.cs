using AziendaTicketAMM_CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AziendaTicketAMM_CORE.Interfaces
{
    public interface IRepositoryCategoria : IRepository<Categoria>
    {

        bool Delete(Categoria categoria);
    }
}
