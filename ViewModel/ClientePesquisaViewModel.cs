using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet3.ViewModel
{
    public class ClientePesquisaViewModel
    {

        public string ClienteNome { get; set; }
        public string ClienteEmail { get; set; }
        public int RepresentanteId { get; set; }
        public SelectList Representantes { get; set; } // Combo de representante
        public IList<ClienteViewModel> Clientes { get; set; }

    }
}
