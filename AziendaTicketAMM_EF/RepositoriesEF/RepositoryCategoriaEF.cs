using AziendaTicketAMM_CORE.Interfaces;
using AziendaTicketAMM_CORE.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AziendaTicketAMM_EF.RepositoriesEF
{
    public class RepositoryCategoriaEF : IRepositoryCategoria
    {
        private readonly Context ctx;

        public RepositoryCategoriaEF() : this(new Context())
        {

        }

        public RepositoryCategoriaEF(Context ctx)
        {
            this.ctx = ctx;
        }


        public bool Add(Categoria entity)
        {
            try
            {
                ctx.Categorie.Add(entity);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Categoria categoria)
        {
            try
            {
                var ct = ctx.Categorie.Find(categoria.Id);

                if (ct != null)
                    ctx.Categorie.Remove(categoria);

                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Categoria> GetAll()
        {
            return ctx.Categorie;
        }

        public Categoria GetById(int id)
        {
            return ctx.Categorie.Find(id);
        }

        public bool Update(Categoria entity)
        {
            ctx.Categorie.Update(entity);
            ctx.SaveChanges();
            return true;
        }
    }
}
//aggiunta lista