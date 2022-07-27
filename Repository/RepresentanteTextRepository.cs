using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;
using Fiap.Web.AspNet3.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.AspNet3.Repository
{
    public class RepresentanteTextRepository : IRepresentanteRepository
    {
        private readonly DataContext dataContext;

        public RepresentanteTextRepository(DataContext ctx)
        {
            dataContext = ctx;
        }


        public IList<RepresentanteModel> FindAll()
        {
            return dataContext.Representantes.ToList<RepresentanteModel>();
        }

        public RepresentanteModel? FindById(int idRepresentante)
        {
            return dataContext.Representantes.Find(idRepresentante);
        }

        public RepresentanteModel? FindByIdWithClientes(int idRepresentante)
        {
            return dataContext.Representantes
                .Include(r => r.Clientes)
                    .SingleOrDefault(r => r.RepresentanteId == idRepresentante);
        }



        public IList<RepresentanteModel> FindByName(string name)
        {
            return null;
        }

        public void Insert(RepresentanteModel representanteModel)
        {
            dataContext.Representantes.Add(representanteModel);
            dataContext.SaveChanges();
        }

        public void Update(RepresentanteModel representanteModel)
        {
            dataContext.Representantes.Update(representanteModel);
            dataContext.SaveChanges();
        }


        public void Delete(int idRepresentante)
        {
            var representante = FindById(idRepresentante);
            Delete(representante);
        }

        public void Delete(RepresentanteModel representanteModel)
        {
            dataContext.Representantes.Remove(representanteModel);
            dataContext.SaveChanges();
        }


    }
}
