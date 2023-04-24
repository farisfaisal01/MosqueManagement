using System.ComponentModel.DataAnnotations;

namespace MosqueManagement.Models
{
    public class Schedule
    {
        [Key]
        public int ? scheduleId { get; set; }
        public string ? occupied { get; set; }
    }
}
