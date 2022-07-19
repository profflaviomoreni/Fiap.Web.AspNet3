using Fiap.Web.AspNet3.Data;
using Fiap.Web.AspNet3.Models;

namespace Fiap.Web.AspNet3.Repository
{
    public class FornecedorRepository
    {

        private readonly DataContext dataContext;

        public FornecedorRepository(DataContext context)
        {
            dataContext = context;
        }


        public List<FornecedorModel> FindAll()
        {
            return dataContext.Fornecedores.ToList<FornecedorModel>();
        }

        public FornecedorModel FindById(int id)
        {
            return dataContext.Fornecedores.Find(id);
        }

        public void Insert(FornecedorModel fornecedorModel)
        {
            dataContext.Fornecedores.Add(fornecedorModel);
            dataContext.SaveChanges();
        }

        public void Update(FornecedorModel fornecedorModel)
        {
            dataContext.Fornecedores.Update(fornecedorModel);
            dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var fornecedor = new FornecedorModel();
            fornecedor.FornecedorId = id;
            Delete(fornecedor);
        }

        public void Delete(FornecedorModel fornecedorModel)
        {
            //dataContext.Historico.Add(fornecedorModel);
            dataContext.Fornecedores.Remove(fornecedorModel);
            dataContext.SaveChanges();
        }

    }
}
