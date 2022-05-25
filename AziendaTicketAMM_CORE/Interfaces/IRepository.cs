using System;
using System.Collections.Generic;
using System.Text;

namespace AziendaTicketAMM_CORE.Interfaces
{
    public interface IRepository<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
