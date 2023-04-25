using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerHotel.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string IsAvailable { get; set; } 

        public int ServiceTypeId { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public Receipt Receipt { get; set; }
    }
}