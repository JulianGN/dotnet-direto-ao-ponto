using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DevReviews.API.Models;
using DevReviews.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // controller pega o nome do controller sem a palavra controller (nesse caso, products)
    public class ProductsController : ControllerBase
    {
        private readonly DevReviewsDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public ProductsController(DevReviewsDbContext dbContext, IMapper mapper)
        {
            this._mapper = mapper;
            _dbContext = dbContext;
        }
        // GET para api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _dbContext.Products;

            // var productsViewModel = products.Select(produto => new ProductViewModel(produto.Id, produto.Title, produto.Price));
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products); 

            return Ok(productsViewModel); // revelando apenas as o id, title e description
        }
        // api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(produto => produto.Id == id); // o SingleOrDefault busca um elemento (produto), caso não encontre, ele retorna null
            if (product == null)
            {
                // Se não achar, retorna NotFound()
                return NotFound();
            }

            // var reviewsViewModel = product.Reviews.Select(review => new ProductReviewViewModel(
            //     review.Id,
            //     review.Author,
            //     review.Rating,
            //     review.Comments,
            //     review.RegisteredAt
            // )).ToList();
            // // para cada review, vai mapear em um objeto

            // var productDetails = new ProductDetailsViewModel(
            //     product.Id,
            //     product.Title,
            //     product.Description,
            //     product.Price,
            //     product.RegisterdAt,
            //     reviewsViewModel
            // );
            var productDetails = _mapper.Map<ProductDetailsViewModel>(product);

            return Ok(productDetails);
        }
        // POST para api/products
        [HttpPost]
        public IActionResult Post(AddProductInputModel model)
        {
            // Se tiver erros de validação, retornar BadRequest()
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        // PUT para api/products/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProductInputModel model)
        { // o segundo parâmetro vem do corpo da requisição
            // Se tiver erros de validação, retornar BadRequest()
            // Se não existir produto com id especificado, pode retornar NotFound()
            if (model.Description.Length > 50)
            {
                return BadRequest(); // caso a descrição seja muito longa
            }

            var product = _dbContext.Products.SingleOrDefault(produto => produto.Id == id); // verificando se existe produto
            if (product == null)
            {
                return NotFound();
            }

            product.Update(model.Description, model.Price);
            // Se não:
            return NoContent();
        }
    }
}