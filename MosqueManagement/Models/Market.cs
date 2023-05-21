using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosqueManagement.Models
{
    public class Market
    {
        [Key]
        public int ? marketId { get; set; }
        public string ? marketName { get; set; }
        public string ? marketDescription { get; set; }
        public string ? marketContact { get; set; }
        public string ? marketImagePath { get; set; }
        [NotMapped]
        public IFormFile marketAttachment { get; set; }
    }
}
