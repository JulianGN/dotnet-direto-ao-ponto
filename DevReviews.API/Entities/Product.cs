using System;
using System.Collections.Generic;

namespace DevReviews.API.Entities
{
    public class Product
    {
        public Product(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;

            RegisterdAt = DateTime.Now;
            Reviews = new List<ProductReview>(); // para não gerar um objeto nulo
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime RegisterdAt { get; private set; }
        public List<ProductReview> Reviews { get; private set; }
        public void AddReview(ProductReview review){
            Reviews.Add(review);
        }
        // é necessário criar um método para fazer a atualização de valores privados
        public void Update(string description, decimal price){
            Description = description;
            Price = price;
        }
    }
}