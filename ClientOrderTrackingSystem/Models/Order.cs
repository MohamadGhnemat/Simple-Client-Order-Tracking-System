namespace ClientOrderTrackingSystem.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int PaymentTypeId { get; set; }
        public Payment Payment { get; set; }
    }
}
