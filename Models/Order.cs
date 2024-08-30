namespace BarApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int CocktailId { get; set; }
        public int Quantity { get; set; }
        public string OrderStatus { get; set; }
        public Cocktail Cocktail { get; set; }
    }
}
