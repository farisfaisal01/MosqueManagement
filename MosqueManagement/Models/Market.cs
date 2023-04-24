using System.ComponentModel.DataAnnotations;

namespace MosqueManagement.Models
{
    public class Market
    {
        [Key]
        public int ? marketId { get; set; }
        public string ? marketName { get; set; }
        public string ? marketDescription { get; set; }
        public string ? marketContact { get; set; }
        //public string marketAttachment { get; set; }
    }
}
