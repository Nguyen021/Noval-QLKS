using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerHotel.Models
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        public DateTime? CheckInDate { get; set; }

        public DateTime? CheckOutDate { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Range(0, 3, ErrorMessage = "Status chỉ có thể là 0 mới đặt, 1 checkin, 2 checkout, 3 hủy")]
        public int Status { get; set; }
        //[Required]
        //public bool IsCheckedIn { get; set; }

        //[Required]
        //public bool IsCheckedOut { get; set; }

        //public int UserId { get; set; }
        //public virtual User User { get; set; }
        [Range(1, 2, ErrorMessage = "Type chỉ có thể là  1 nhân viên đặt, 2 khách đặt online")]
        public int Type { get; set; }

        [Required]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

    }
}