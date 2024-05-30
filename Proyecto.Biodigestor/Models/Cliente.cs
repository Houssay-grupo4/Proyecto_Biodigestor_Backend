using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Biodigestor.Models
{
    public class Cliente
    {
        [Key]
        [Column("IdCliente")]
        public int IdCliente { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Nombre { get; set; } = null!;

        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Apellido { get; set; } = null!;
    }
}
