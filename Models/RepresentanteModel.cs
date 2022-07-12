using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet3.Models
{

    [Table("Representante")]
    public class RepresentanteModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RepresentanteId")]
        public int RepresentanteId { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeRepresentante { get; set; }

        [NotMapped]
        public string Token { get; set; }



        public RepresentanteModel()
        {

        }

        public RepresentanteModel(int representanteId, string nomeRepresentante)
        {
            RepresentanteId = representanteId;
            NomeRepresentante = nomeRepresentante;
        }

        
    }
}
