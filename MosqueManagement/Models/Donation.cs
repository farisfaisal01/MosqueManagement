using System.ComponentModel.DataAnnotations;

namespace MosqueManagement.Models
{
    public class Donation
    {
        [Key]
        public int donationId { get; set; }
        public string donationSuccess { get; set; }
        public double donationAmount { get; set; }
    }
}
