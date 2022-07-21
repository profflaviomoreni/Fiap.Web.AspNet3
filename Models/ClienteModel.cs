using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Web.AspNet3.Models
{
    [Table("Cliente")]
    public class ClienteModel
    {

        [Display(Name = "Id do Cliente")]
        [HiddenInput]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }

        [Display(Name = "Nome do cliente")]
        [Required(ErrorMessage = "Nome do cliente é obrigatório")]
        [MaxLength(70, ErrorMessage = "O tamanho máximo do nome é de 70 caracteres!")]
        [MinLength(2, ErrorMessage = "Digite um nome com mais de dois caracteres")]
        public string Nome { get; set; }

        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage = "Digite corretamente o e-mail")]
        [Required(ErrorMessage = "Digite o e-mail do cliente")]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Selecione a data de nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Observação")]
        public string? Observacao { get; set; }


        public int RepresentanteId { get; set; }

        [ForeignKey("RepresentanteId")]
        public RepresentanteModel? Representante { get; set; }

    }
}
