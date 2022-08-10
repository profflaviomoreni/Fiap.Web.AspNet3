using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;

namespace Fiap.Web.AspNet3.Repository
{
    public class LojaRepository : ILojaRepository
    {

        private readonly DataContext dataContext;

        public LojaRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }



        public IList<LojaModel> FindAll()
        {
            return dataContext.Lojas.ToList();
        }



    }
}
