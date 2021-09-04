using System;

namespace DevReviews.API.Entities
{
    public class ProductReview
    {
        // construtor criado com o Ctrl + . ao selecionar as propriedades abaixo
        public ProductReview(string author, int rating, string comments, int productId)
        {
            Author = author;
            Rating = rating;
            Comments = comments;
            ProductId = productId;

            RegisteredAt = DateTime.Now;
        }

        public int Id { get; private set; } // com o set privado, outras classes não conseguem alterar as informações
        public string Author { get; private set; }
        public int Rating { get; private set; }
        public string Comments { get; private set; }
        public DateTime RegisteredAt { get; set; }
        public int ProductId { get; private set; } 
        // public Product Product { get; private set; }        
    }
}