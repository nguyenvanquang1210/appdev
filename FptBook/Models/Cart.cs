using FptBook.Areas.Identity.Data;

namespace FptBook.Models
{
    public class Cart
    {
        public string UId { get; set; }
        public string BookIsbn { get; set; }
        public int Quantity { get; set; }
       
        public double Price { get; set; }
        public FptBookUser? User { get; set; }
        public Book? Book { get; set; }
        public double Total
        {
            get { return Quantity * Price; }
        }
        public Cart()
        {
            Quantity = 1;
        }

    }
}