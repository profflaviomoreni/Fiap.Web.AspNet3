using Fiap.Web.AspNet3.Models;

namespace Fiap.Web.AspNet3.Repository.Interface
{
    public interface IClienteRepository
    {

        public IList<ClienteModel> FindAll();

        public IList<ClienteModel> FindAllOrderByNomeAsc();

        public IList<ClienteModel> FindAllOrderByNomeDesc();

        public IList<ClienteModel> FindByNome(string nome);

        public IList<ClienteModel> FindByNomeAndEmail(string nome, string email);

        public IList<ClienteModel> FindByNomeAndEmailAndRepresentante(string nome, string email, int idRepresentante);

        public ClienteModel FindById(int id);

        public void Insert(ClienteModel ClienteModel);

        public void Update(ClienteModel ClienteModel);

        public void Delete(int id);

        public void Delete(ClienteModel ClienteModel);

    }
}
