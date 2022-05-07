namespace FptBook.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public string BookIsbn { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}