using System.Collections.Generic;
using System.Threading.Tasks;
using DevReviews.API.Entities;

namespace DevReviews.API.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DevReviewsDbContext _dbContext;

        public ProductRepository(DevReviewsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        // public Task async AddAsync(Product procuct)
        // {
        //     // await _dbContext.Products.AddAsync(product);
        //     // await _dbContext.SaveChangesAsync(); //para persistir
        // }

        public Task AddReviewAsync(ProductReview productReview)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Product>> GetAllAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetDetailsByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductReview> GetReviewByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(Product procuct)
        {
            throw new System.NotImplementedException();
        }

        public Task GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}