using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosqueManagement.Models
{
    public class HumanResource
    {
        [Key]
        public int ? positionId { get; set; }
        public string ? positionTitle { get; set; }
        public string ? positionDescription { get; set; }
        public string ? staffName { get; set; }
        public string ? staffContact{ get; set; }
        public string? staffImagePath { get; set; }
        [NotMapped]
        public IFormFile? staffImage { get; set; }
        [NotMapped]
        public IFormFile? updatedStaffImage { get; set; }
    }
}
