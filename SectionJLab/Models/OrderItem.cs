namespace SectionJLab.Models
{
    public class OrderItem
    {
        public int ID { get; set; }

        public int OrderID { get; set; }
        public Order Order { get; set; }

        public int MenuItemID { get; set; }
        public MenuItem MenuItem { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice => MenuItem.Price * Quantity;
    }
}
