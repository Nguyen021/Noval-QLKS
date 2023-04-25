using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerHotel.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(255)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(60)]
        public string Address { get; set; }

        [Required]
        [MaxLength(12)]
        [Index(IsUnique = true)]
        public string IdentityCard { get; set; }

        public virtual List<Booking> Bookings { get; set; }

    }
}