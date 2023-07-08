using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosqueManagement.Models
{
    public class Social
    {
        [Key]
        public int ? socialId { get; set; }
        public string ? eventDate { get; set; }
        public string ? eventTime { get; set; }
        public string ? approval { get; set; }
        public string ? remarks { get; set; }
        public string? socialAttachmentPath { get; set; }
        [NotMapped]
        public IFormFile? socialAttachment { get; set; }


        [ForeignKey("Service")]
        public int? serviceId { get; set; }
        public Service? Service { get; set; }

        [ForeignKey("User")]
        public int? userId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Payment")]
        public int? paymentId { get; set; }
        public Payment? Payment { get; set; }
    }
}
