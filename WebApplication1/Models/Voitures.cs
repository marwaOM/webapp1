using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Voitures
    {
       
           public int Id { get; set; }
            public string Nom { get; set; }
            public string Marque { get; set; }
            [Column(TypeName = "decimal(18, 2)")]
            public decimal Prix { get; set; }
            [Display(Name = "Date de fabrication")]
            [DataType(DataType.Date)]
            public DateTime DateFabrication { get; set; }
        public string? Rating { get; set; }

    }
}


