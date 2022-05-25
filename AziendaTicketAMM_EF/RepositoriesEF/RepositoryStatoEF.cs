using AziendaTicketAMM_CORE.Interfaces;
using AziendaTicketAMM_CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AziendaTicketAMM_EF.RepositoriesEF
{
    public class RepositoryStatoEF : IRepositoryStato
    {
        private readonly Context ctx;

        public RepositoryStatoEF() : this(new Context ())
        {

        }

        public RepositoryStatoEF(Context ctx)
        {
            this.ctx = ctx;
        }
        public bool Add(Stato entity)
        {
            try
            {
                ctx.Stati.Add(entity);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

            public bool Delete(Stato stato) //stiamo eliminando lo stato
        {
            try
            {
                var st = ctx.Stati.Find(stato.Id);

                if (st != null)
                    ctx.Stati.Remove(stato);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Stato> GetAll()
        {
            return ctx.Stati;
        }

        public Stato GetById(int id)
        {
            return ctx.Stati.Find(id);
        }

        public bool Update(Stato entity)
        {
            ctx.Stati.Update(entity);
            ctx.SaveChanges();
            return true;
        }
    }
}
