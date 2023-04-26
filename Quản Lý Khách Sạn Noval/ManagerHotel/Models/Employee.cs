using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerHotel.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Tên nhân viên không được để trống")]
        [StringLength(255)]
        public string Name { get; set; }
       
        [StringLength(255)]
        public string Email { get; set; }
   
        [StringLength(10, ErrorMessage = "Số điện thoại không được quá 10 ký tự.")]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        [Required(ErrorMessage = "Lương nhân viên không được để trống")]
        public decimal Salary { get; set; }

        public DateTime HireDate { get; set; }

        [StringLength(255)]
        public string Address { get; set; }
    }

}