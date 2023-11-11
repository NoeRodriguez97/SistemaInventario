using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public CategoriaRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Actualizar(Categoria categoria)
        {
            var CategoriaBD = _db.Categorias.FirstOrDefault(c => c.Id == categoria.Id);
            if(CategoriaBD != null )
            {
                CategoriaBD.Nombre = categoria.Nombre;
                CategoriaBD.Descripcion = categoria.Descripcion;
                CategoriaBD.Estado = categoria.Estado;
                _db.SaveChanges();
            }

        }
    }
}
