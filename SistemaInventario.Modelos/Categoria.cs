using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El Nombre es requerido")]
        [MaxLength(100,ErrorMessage ="El Nombre debe ser menor a 100 caracteres")]
        public string ? Nombre { get; set; }

        [Required(ErrorMessage = "La Descripcion es requerida")]
        [MaxLength(100,ErrorMessage ="La Descripcion debe ser menor a 100 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El Estado es requerido")]
        public bool Estado { get; set; }
    }
}
