using MosqueManagement.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MosqueManagement.Models
{
    public class Service
    {
        [Key]
        public int ? serviceId { get; set; }
        public string ? serviceName { get; set; }
        public string ? serviceDescription { get; set; }
        public double ? servicePrice { get; set; }
        public string ? serviceEquipments { get; set; }
        public string? serviceCategory { get; set; }
        public string? serviceImagePath { get; set; }
        [NotMapped]
        public IFormFile? serviceAttachment { get; set; }
        [NotMapped]
        public IFormFile? updatedServiceAttachment { get; set; }

        //Relationships
        public List<Social> ? Socials { get; set; }
        public List<Class> ? Classs { get; set; }
        public List<Rental> ? Rentals { get; set; }
    }
}
