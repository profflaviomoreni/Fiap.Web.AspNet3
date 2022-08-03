using Fiap.Web.AspNet3.Models;

namespace Fiap.Web.AspNet3.Repository.Interface
{
    public interface IUsuarioRepository
    {
        public UsuarioModel Login(UsuarioModel usuarioModel);

    }
}
