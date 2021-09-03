using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aserprosa.web.Models.Finca.ase_productor
{
    public class productorViewModel
    {
        public int productorId { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Por favor, validar el nombre del productor.")]
        public string nombre { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Por favor, validar la descripción del productor.")]
        public string descripcion { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Por favor, validar el teléfono del productor.")]
        public string telefono { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Por favor, validar el correo del productor.")]
        public string correo { get; set; }
        public bool estado { get; set; }
    }
}
