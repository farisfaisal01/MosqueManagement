using System.ComponentModel.DataAnnotations;

namespace MosqueManagement.Models
{
    public class Rental
    {
        [Key]
        public int ? formId { get; set; }
        public string ? eventName { get; set; }
        public string ? eventDescription { get; set; }
        public string ? startDate { get; set; }
        public string ? endDate { get; set; }
        public string ? approval { get; set; }
        public string ? approvalMonth { get; set; }
        public string ? approvalYear { get; set; }
        public string ? feedback { get; set; }
        public string ? package { get; set; }
        public string ? remarks { get; set; }
        public string attachment { get; set; }

        //Relationships
        public List<Schedule> ? Schedules { get; set; }
    }
}
