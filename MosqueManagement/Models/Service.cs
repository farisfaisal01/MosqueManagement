using MosqueManagement.Data;
using System.ComponentModel.DataAnnotations;

namespace MosqueManagement.Models
{
    public class Service
    {
        [Key]
        public int serviceId { get; set; }
        public string serviceName { get; set; }
        public string serviceDescription { get; set; }
        public double servicePrice { get; set; }
        public string serviceEquipments { get; set; }
        public Category serviceCategory { get; set; }
        //public string serviceAttachment { get; set; }

        //Relationships
        public List<Social> Socials { get; set; }
        public List<Class> Classs { get; set; }
        public List<Rental> Rentals { get; set; }
        public List<HumanResource> HumanResources { get; set; }
    }
}
