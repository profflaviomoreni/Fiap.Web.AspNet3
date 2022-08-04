using AutoMapper;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;
using Fiap.Web.AspNet3.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.AspNet3.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public LoginController(IUsuarioRepository _usuarioRepository, IMapper _mapper)
        {
            usuarioRepository = _usuarioRepository;
            mapper = _mapper;   
        }


        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {

            var usuario = mapper.Map<UsuarioModel>(loginViewModel);

            var usuarioRetorno = usuarioRepository.Login(usuario);

            return View();
        }


    }
}
