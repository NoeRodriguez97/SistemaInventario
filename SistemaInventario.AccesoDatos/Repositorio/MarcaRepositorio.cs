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
    public class MarcaRepositorio : Repositorio<Marca>, IMarcaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public MarcaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Marca marca)
        {
            var marcasBD = _db.Marcas.FirstOrDefault(c => c.id == marca.id);
            if (marcasBD != null)
            {
                marcasBD.Nombre = marca.Nombre;
                marcasBD.Descripcion = marca.Descripcion;
                marcasBD.Estado = marca.Estado;
                _db.SaveChanges();
            }

        }
    }
}
