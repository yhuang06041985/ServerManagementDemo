using Microsoft.AspNetCore.Antiforgery;
using System.ComponentModel.DataAnnotations;

namespace ServerManagement.Models
{
    public class Server
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public int CityId { get; set; }

        public City City { get; set; }

        public bool IsOnline { get; set; }
    }
}
