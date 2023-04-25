using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerHotel.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        [Required]
        [StringLength(10)]
        public string RoomNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int FloorNumber { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        public bool IsActive { get; set; }

        public bool IsAvailable { get; set; } 
        [Required]
        public int RoomTypeId { get; set; }

        public virtual RoomType RoomType { get; set; }

    }
}