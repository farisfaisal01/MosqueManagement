using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosqueManagement.Models
{
    public class Class
    {
        [Key]
        public int ? classId { get; set; }
        public string ? equipment { get; set; }
        public string ? approval { get; set; }
        public string ? approvalMonth { get; set; }
        public string ? approvalYear { get; set; }
        public string ? feedback { get; set; }
        public string ? remarks { get; set; }
        public string ? attachment { get; set; }

        [ForeignKey("Service")]
        public int? serviceId { get; set; }
        public Service? Service { get; set; }

        [ForeignKey("User")]
        public int? userId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Payment")]
        public int? paymentId { get; set; }
        public Payment? Payment { get; set; }

        [ForeignKey("Schedule")]
        public int? scheduleId { get; set; }
        public Schedule? Schedule { get; set; }
    }
}
