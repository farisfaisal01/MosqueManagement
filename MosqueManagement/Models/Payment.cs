using System.ComponentModel.DataAnnotations;

namespace MosqueManagement.Models
{
    public class Payment
    {
        [Key]
        public int ? paymentId { get; set; }
        public string? paymentName { get; set; }
        public string? paymentEmail { get; set; }
        public string? paymentContact { get; set; }
        public string ? paymentAmount { get; set; }
        public string? paymentPurpose { get; set; }
        public string? paymentMethod { get; set; }
        public string? paymentCardNumber { get; set; }
        public string? paymentCardCVC { get; set; }
        public string? paymentCardExpireMonth { get; set; }
        public string? paymentCardExpireYear { get; set; }

        //Relationships
        public List<Social> ? Socials { get; set; }
        public List<Class> ? Classs { get; set; }
        public List<Rental> ? Rentals { get; set; }
    }
}
