using ClientOrderTrackingSystem.Models;

namespace ClientOrderTrackingSystem.ViewModels
{
    public class VwOrderClientProductPayment
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<Client> lstClients { get; set; }
        public int ProductId { get; set; }
        public List<Product> lstProducts { get; set; }
        public Product Product { get; set; }
        public int PaymentTypeId { get; set; }
        public List<Payment> lstPayments { get; set; }

        public Payment Payment { get; set; }
    }
}
