using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;

namespace Fiap.Web.AspNet3.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly DataContext dataContext;

        public UsuarioRepository(DataContext ctx)
        {
            dataContext = ctx;
        }


        public UsuarioModel Login(UsuarioModel usuarioModel)
        {
            /*
            UsuarioModel usuario = dataContext.Usuarios
                            .SingleOrDefault(x => x.UsuarioEmail == usuarioModel.UsuarioEmail &&
                                        x.UsuarioSenha == usuarioModel.UsuarioSenha);
            */
            if ( usuarioModel.UsuarioEmail.Equals("admin@fiap.com.br") && usuarioModel.UsuarioSenha.Equals("12345") )
            {

                return new UsuarioModel()
                {
                    UsuarioNome = "Admin",
                    UsuarioEmail = "admin@fiap.com.br",
                    UsuarioId = 1
                };

            } else
            {
                return null;
            }
        }

    }
}
