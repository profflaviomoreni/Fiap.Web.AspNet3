using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.AspNet3.ViewModel
{
    public class ClientePesquisaViewModel
    {

        private int myVar;

        private string clienteNome;
        public string ClienteNome
        {
            get { return clienteNome == null ? "" : clienteNome; }
            set { clienteNome = value; }
        }

        private string clienteEmail;
        public string ClienteEmail
        {
            get { return clienteEmail == null ? "" : clienteEmail; }
            set { clienteEmail = value; }
        }


        public int RepresentanteId { get; set; }
        public SelectList Representantes { get; set; } // Combo de representante
        public IList<ClienteViewModel> Clientes { get; set; }

    }
}
