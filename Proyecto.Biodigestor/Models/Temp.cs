using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.Biodigestor.Models
{
    public class Temp
    {
    
        [Column("IdTemp")]
        public int IdTemp { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public decimal Temperatura { get; set; } = 0!;
    }
}