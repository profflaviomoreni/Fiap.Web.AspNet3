using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;
using Fiap.Web.AspNet3.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet3.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepository usuarioRepository;

        public LoginController(IUsuarioRepository _usuarioRepository)
        {
            usuarioRepository = _usuarioRepository;
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var usuario = new UsuarioModel();
            usuario.UsuarioEmail = loginViewModel.UsuarioEmail;
            usuario.UsuarioSenha = loginViewModel.UsuarioSenha;

            var usuarioRetorno = usuarioRepository.Login(usuario);

            return View();
        }


    }
}
