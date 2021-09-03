using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aserprosa.Entidades.Finca
{
    public class ase_finca
    {
        [Key]
        public int finc_id { get; set; }
        [Required]
        [StringLength(250, MinimumLength =10, ErrorMessage ="Por favor, validar el nombre de la finca.")]
        public string finc_nombre { get; set; }
        [Required]
        [StringLength(500, MinimumLength =20, ErrorMessage ="Por favor, validar la descripción de la finca.")]
        public string finc_descripcion { get; set; }
        [Required]
        [StringLength(250, MinimumLength =5, ErrorMessage ="Por favor, validar la dirección de la finca.")]
        public string finc_direccion { get; set; }
        [ForeignKey("productor")]
        public int prod_id { get; set; }
        public bool finc_estado { get; set; }

        public ase_productor productor { get; set; }
    }
}
