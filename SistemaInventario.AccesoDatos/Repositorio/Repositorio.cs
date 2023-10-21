using Azure.Core;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            this.dbset=_db.Set<T>();
            
        }

        public async Task Agregar(T entidad)
        {
            await dbset.AddAsync(entidad);
        }

        public async Task<T> Obtener(int id)
        {
            return await dbset.FindAsync(id);
        }
        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>> filtro = null, Func<IQueryable, IOrderedQueryable<T>> orderby = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbset;
            if(filtro != null)
            {
                query = query.Where(filtro);
            }

            if(incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }
            if(orderby != null)
            {
                query = orderby(query);
            }
            
            if(!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();


        }

        public async Task<T> ObtenerPrimero(Expression<Func<T, bool>> filtro = null, string incluirPropiedades = null, bool isTracking = true)
        {
            IQueryable<T> query = dbset;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }



        public void Remover(T entidad)
        {
            dbset.Remove(entidad);
        }

        public void RemoverRango(IEnumerable<T> entidad)
        {
            dbset.RemoveRange(entidad);
        }
    }
}
