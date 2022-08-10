using Fiap.Web.AspNet3.Models;



namespace Fiap.Web.AspNet3.Repository
{
    public interface ILojaRepository
    {
        public IList<LojaModel> FindAll();
        
    }
}