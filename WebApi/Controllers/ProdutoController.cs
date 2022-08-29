using Data.Model;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private ProdutoRepository repo;

        public ProdutoController()
        {
            this.repo = new ProdutoRepository();
        }

        [HttpGet]
        public List<Produto> GetAll()
        {
            return repo.GetAll();
        }
        [HttpPost]
        public string Post(Produto produto)
        {
            return repo.Create(produto);
        }
    }
}
