using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet3.Models
{
    [Table("Gerente")]
    public class GerenteModel
    {

        [Key]   
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GerenteId { get; set; }
        
        [Required]
        [StringLength(70)]
        public string Nome { get; set; }


        [Required]
        [StringLength(70)]
        public string Sobrenome { get; set; }

    }
}
