using System.ComponentModel.DataAnnotations;

namespace MosqueManagement.Models
{
    public class User
    {
        [Key]

        public int ? userId { get; set; }
        public string ? name { get; set; }
        public string ? username { get; set; }
        public string ? email { get; set; }
        public string ? phone { get; set; }
        public string ? password { get; set; }
        public string ? role { get; set; }
    }
}
