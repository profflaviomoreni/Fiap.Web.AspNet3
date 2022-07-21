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
            //var listaClientes = context.Clientes.ToList<ClienteModel>();
            var listaClientes = context.Clientes.Include( c => c.Representante ).ToList();

            return listaClientes == null ? new List<ClienteModel>() : listaClientes;
        }

        public ClienteModel FindById(int id)
        {
            // var cliente = context.Clientes.Find(id);
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
