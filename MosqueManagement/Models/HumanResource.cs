using System.ComponentModel.DataAnnotations;

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
        public string ? staffImage { get; set; }
    }
}
