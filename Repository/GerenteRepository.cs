using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;

namespace Fiap.Web.AspNet3.Repository
{
    public class GerenteRepository : IGerenteRepository
    {

        private readonly DataContext dataContext;

        public GerenteRepository(DataContext ctx)
        {
            dataContext = ctx;
        }


        public List<GerenteModel> FindAll()
        {
            return dataContext.Gerentes.ToList<GerenteModel>();
        }

        public GerenteModel FindById(int idRepresentante)
        {
            return dataContext.Gerentes.Find(idRepresentante);
        }

        public void Insert(GerenteModel GerenteModel)
        {
            dataContext.Gerentes.Add(GerenteModel);
            dataContext.SaveChanges();
        }

        public void Update(GerenteModel GerenteModel)
        {
            dataContext.Gerentes.Update(GerenteModel);
            dataContext.SaveChanges();
        }


        public void Delete(int idRepresentante)
        {
            var representante = FindById(idRepresentante);
            Delete(representante);
        }

        public void Delete(GerenteModel GerenteModel)
        {
            dataContext.Gerentes.Remove(GerenteModel);
            dataContext.SaveChanges();
        }

    }
}
