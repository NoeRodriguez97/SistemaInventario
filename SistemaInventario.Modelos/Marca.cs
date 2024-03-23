using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class Marca
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        [MaxLength(100,ErrorMessage = "El nombre deber ser menor de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo descripcion es requerido")]
        [MaxLength(100,ErrorMessage ="La descripcion deber ser menor a 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo estado es requierido")]
        public bool Estado { get; set; }
    }
}
