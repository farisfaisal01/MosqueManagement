using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? paymentBank { get; set; }
        public string? paymentCardNumber { get; set; }
        public string? paymentCardCVC { get; set; }
        public string? paymentCardExpireMonth { get; set; }
        public string? paymentCardExpireYear { get; set; }
        public string? rentalId { get; set; }
        public string? socialId { get; set; }
        public string? classId { get; set; }
        public string? paymentAttachmentPath { get; set; }
        [NotMapped]
        public IFormFile? paymentAttachment { get; set; }
        [NotMapped]
        public IFormFile? updatedPaymentAttachment { get; set; }
    }
}
