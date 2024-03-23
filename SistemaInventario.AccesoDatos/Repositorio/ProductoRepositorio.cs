using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventario.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio.IRepositorio;
using SistemaInventario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Producto producto)
        {
            var productoBD = _db.Productos.FirstOrDefault(c => c.Id == producto.Id);
            if (productoBD != null)
            {
                if(productoBD.ImagenUrl != null)
                {
                    productoBD.ImagenUrl = producto.ImagenUrl;
                }

                productoBD.Codigo= producto.Codigo;
                productoBD.Descripcion = producto.Descripcion;
                productoBD.Precio = producto.Precio;
                productoBD.Costo = producto.Costo;
                productoBD.Estado = producto.Estado;
                productoBD.CategoriaId = producto.CategoriaId;
                productoBD.MarcaId = producto.MarcaId;
                productoBD.PadreId = producto.PadreId;


                _db.SaveChanges();
            }

        }

        public IEnumerable<SelectListItem> ObtenerTodosDropDown(string obj)
        {
            if(obj == "Categoria")
            {
                return _db.Categorias.Where(x => x.Estado == true)
                    .Select(x => new SelectListItem
                    {
                        Text = x.Nombre,
                        Value = x.Id.ToString()
                    });
            }

            if (obj == "Marca")
            {
                return _db.Marcas.Where(x => x.Estado == true)
                    .Select(x => new SelectListItem
                    {
                        Text = x.Nombre,
                        Value = x.id.ToString()
                    });
            }
            if(obj == "Producto")
            {
                return _db.Productos.Where(x => x.Estado == true).Select(x => new SelectListItem
                {
                    Text=x.Descripcion,
                    Value=x.Id.ToString()
                });
            }

            return null;

        }
    }
}
