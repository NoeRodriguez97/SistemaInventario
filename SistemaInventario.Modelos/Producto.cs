using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El codigo es requerido")]
        [MaxLength(100, ErrorMessage = "Solo es permitido hasta 100 caracters")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(100, ErrorMessage = "Solo es permitido hasta 100 caracters")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage ="El precio es requerido")]
        public double Precio { get; set; }
        [Required(ErrorMessage = "El costo es requerido")]
        public double Costo { get; set; }
        public string ImagenUrl { get; set; }
        [Required(ErrorMessage = "El estado es requerido")]

        public bool Estado { get; set; }
        [Required(ErrorMessage = "La categoria es requerida")]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set;}
        [Required(ErrorMessage = "La marca es requerida")]
        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }
        public int? PadreId { get; set; }
        public virtual Producto Padre { get; set; }
    }
}
