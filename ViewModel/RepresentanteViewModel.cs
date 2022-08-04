using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.AspNet3.ViewModel
{
    public class RepresentanteViewModel
    {

        [Key]
        public int RepresentanteId { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeRepresentante { get; set; }


        public string? Token { get; set; }

    }
}
