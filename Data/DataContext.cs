using Fiap.Web.AspNet3.Models;
using Microsoft.EntityFrameworkCore;
using Fiap.Web.AspNet3.ViewModel;

namespace Fiap.Web.AspNet3.Data
{
    public class DataContext : DbContext
    {

        public DataContext()
        {

        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<RepresentanteModel> Representantes { get; set; }

        public DbSet<GerenteModel> Gerentes { get; set; }

        public DbSet<FornecedorModel> Fornecedores { get; set; }

        public DbSet<ClienteModel> Clientes { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }

        public DbSet<LojaModel> Lojas { get; set; }

        public DbSet<ProdutoLojaModel> ProdutosLojas { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<Fiap.Web.AspNet3.ViewModel.LoginViewModel>? LoginViewModel { get; set; }


    }
}
