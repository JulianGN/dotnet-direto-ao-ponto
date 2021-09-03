namespace DevReviews.API.Models
{
    public class ProductViewModel
    {
        // classe criada para controlar o que o usuário vai ver
        public ProductViewModel(int iD, string title, decimal price)
        {
            ID = iD;
            Title = title;
            Price = price;
        }

        public int ID { get; private set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
    }
}