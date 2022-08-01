using Fiap.Web.AspNet3.Models;

namespace Fiap.Web.AspNet3.Repository.Interface
{
    public interface IGerenteRepository
    {

        public List<GerenteModel> FindAll();

        public GerenteModel FindById(int idRepresentante);

        public void Insert(GerenteModel GerenteModel);

        public void Update(GerenteModel GerenteModel);


        public void Delete(int idRepresentante);

        public void Delete(GerenteModel GerenteModel);

    }
}
