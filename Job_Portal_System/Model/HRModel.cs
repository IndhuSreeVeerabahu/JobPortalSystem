using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Job_Portal_System.Model
{
    public class HRModel
    {
        [Key]
        //public long HR_ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public  string Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public  string Email { get; set; }
        [Required(ErrorMessage = "Enter the username")]
        public  string Username { get; set; }
       
        [Required(ErrorMessage = "Enter a password")]
        public  string Password { get; set; }
        [Required(ErrorMessage = "Invalid phone number")]
        [DataType(DataType.PhoneNumber)]
        public  string Mob_No { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
        public string Company_Name { get; set; }
        [Required(ErrorMessage = "Official Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public  string Company_Email { get; set; }
        [Required(ErrorMessage = "Enter the phone number")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public  string Company_Mob_No { get; set; }
        [Required(ErrorMessage = "Enter the url ")]
        [Url(ErrorMessage = "Invalid Website URL")]
        public  string Company_Website { get; set; }
        public  byte[] Company_Logo { get; set; }
        public  string CreatedBy { get; set; }
        public  DateTime CreatedOn { get; set; }
        public  string UpdatedBy { get; set; }
        public  DateTime UpdatedOn { get; set; }
    }
}
