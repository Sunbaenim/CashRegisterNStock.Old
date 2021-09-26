namespace CashRegisterNStock.DAL.Entities.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int TypeProductId { get; set; }
        public TypeProduct TypeProduct { get; set; }
    }
}
