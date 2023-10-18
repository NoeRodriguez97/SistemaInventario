using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class Bodega
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(60,ErrorMessage = "El Nombre debe ser maximo a 60 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La Descripcion es requerido")]
        [MaxLength(60, ErrorMessage = "La descripcion debe ser maximo a 100 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El estado es requerido")]
        public bool Estado { get; set; }
    }
}
