using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aserprosa.web.Models.Finca.ase_finca
{
    public class actualizarFincaViewModel
    {

        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "Por favor, validar el nombre de la finca.")]
        public string nombre { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "Por favor, validar la descripción de la finca.")]
        public string descripcion { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "Por favor, validar la dirección de la finca.")]
        public string direccion { get; set; }
        [Required]
        public int productorId { get; set; }
        public bool estado { get; set; }
    }
}
