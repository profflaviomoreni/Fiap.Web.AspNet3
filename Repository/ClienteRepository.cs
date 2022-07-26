using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet3.Repository
{
    public class ClienteRepository
    {
        public DataContext context { get; set; }

        public ClienteRepository(DataContext ctx)
        {
            context = ctx;
        }


        public List<ClienteModel> FindAll()
        {
            var listaClientes = context.Clientes.Include( c => c.Representante ).ToList();

            return listaClientes == null ? new List<ClienteModel>() : listaClientes;
        }


        public List<ClienteModel> FindAllOrderByNomeAsc()
        {
            var listaClientes = 
                context.Clientes
                    .Include(c => c.Representante)
                    .OrderBy(c => c.Nome)
                    .ToList();

            return listaClientes == null ? new List<ClienteModel>() : listaClientes;
        }


        public List<ClienteModel> FindAllOrderByNomeDesc()
        {
            var listaClientes =
                context.Clientes
                    .Include(c => c.Representante)
                    .OrderByDescending(c => c.Nome)
                    .ToList();

            return listaClientes == null ? new List<ClienteModel>() : listaClientes;
        }



        public List<ClienteModel> FindByNome(string nome)
        {
            var listaClientes =
                context.Clientes
                    .Include(c => c.Representante)
                    .Where(c => c.Nome.Contains(nome) )
                        .OrderBy(c => c.Nome)
                            .ToList();

            return listaClientes == null ? new List<ClienteModel>() : listaClientes;

        }


        public List<ClienteModel> FindByNomeAndEmail(string nome, string email)
        {

            var listaClientes =
                context.Clientes
                    .Include(c => c.Representante)
                    .Where( c => c.Nome.Contains(nome) && 
                                 c.Email.Contains(email)   )
                        .OrderBy(c => c.Nome)
                            .ToList();

            return listaClientes == null ? new List<ClienteModel>() : listaClientes;

        }



        public List<ClienteModel> FindByNomeAndEmailAndRepresentante(string nome, string email, int idRepresentante)
        {

            var listaClientes =
                context.Clientes
                    .Include(c => c.Representante)
                    .Where(c => c.Nome.Contains(nome)   &&
                                c.Email.Contains(email) &&
                                ( 0 == idRepresentante || c.RepresentanteId == idRepresentante ) )
                        .OrderBy(c => c.Nome)
                            .ToList();


            return listaClientes == null ? new List<ClienteModel>() : listaClientes;

        }


        public ClienteModel FindById(int id)
        {
            var cliente =
                context.Clientes // SELECT campos
                    .Include(c => c.Representante) // Inner Join
                        .SingleOrDefault(c => c.ClienteId == id); // WHERE

            return cliente;
        }

        public void Insert(ClienteModel ClienteModel)
        {
            context.Clientes.Add(ClienteModel);
            context.SaveChanges();
        }

        public void Update(ClienteModel ClienteModel)
        {
            context.Clientes.Update(ClienteModel);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            ClienteModel clienteModel = new ClienteModel();
            clienteModel.ClienteId = 1;
            Delete(clienteModel);
        }


        public void Delete(ClienteModel ClienteModel)
        {
            context.Clientes.Remove(ClienteModel);
            context.SaveChanges();
        }

    }
}
