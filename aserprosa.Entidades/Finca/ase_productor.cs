using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace aserprosa.Entidades.Finca
{
    public class ase_productor
    {
        public int prod_id { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Por favor, validar el nombre del productor.")]
        public string prod_nombre { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Por favor, validar la descripción del productor.")]
        public string prod_descripcion { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Por favor, validar el teléfono del productor.")]
        public string prod_telefono { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Por favor, validar el correo del productor.")]
        public string prod_correo { get; set; }
        public bool prod_estado { get; set; }

        public ICollection<ase_finca> finca { get; set; }
    }
}
