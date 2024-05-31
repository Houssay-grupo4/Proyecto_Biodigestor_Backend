using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Biodigestor.Models
{
    public class Provision
    {
        [Key]
        [Column("IdProvision")]
        public int IdProvision { get; set; }


        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }

        public int CantidadGas { get; set; } = 0;

        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Descripcion { get; set; } = null!;
    }
}