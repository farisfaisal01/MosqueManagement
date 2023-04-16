using System.ComponentModel.DataAnnotations;

namespace MosqueManagement.Models
{
    public class Payment
    {
        [Key]
        public int paymentId { get; set; }
        public string paymentSuccess { get; set; }
        public double amount { get; set; }

        //Relationships
        public List<Social> Socials { get; set; }
        public List<Class> Classs { get; set; }
        public List<Rental> Rentals { get; set; }
    }
}
