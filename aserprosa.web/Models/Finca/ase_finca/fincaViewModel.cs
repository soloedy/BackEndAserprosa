using aserprosa.web.Models.Finca.ase_productor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace aserprosa.web.Models.Finca.ase_finca
{
    public class fincaViewModel
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
        public int productorId { get; set; }
        [ForeignKey("prod_id")]
        public string productor { get; set; }
        public bool estado { get; set; }
    }
}
