

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatorCQRS.Domain.Entity;

namespace MediatorCQRS.Repository
{
    public class ProdutoRepository : IRepository<Produto>
    {

        private static Dictionary<int, Produto> produtos = new Dictionary<int, Produto>();

        private void populaDictionary()
        {
            produtos.Add(1, new Produto(){Id = 1, Nome = "Whey", Preco = 75.5M});
            produtos.Add(2, new Produto(){Id = 2, Nome = "Creatina", Preco = 30.5M});
        }

        public async Task Add(Produto produto)
        {
            await Task.Run(() => produtos.Add(produto.Id, produto));
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {

            populaDictionary();

            return await Task.Run(() => produtos.Values.ToList());
        }

        public Task<Produto> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Produto item)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}