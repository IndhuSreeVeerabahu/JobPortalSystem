using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Job_Portal_System.Model
{
    public class UserModel
    {
        [Key]
       //public long UserID { get; set; }

        [Required(ErrorMessage = "Enter the first name")]
        public  string FirstName { get; set; }
        [Required(ErrorMessage = "Enter the last name")]
        public  string LastName { get; set; }
        [Required(ErrorMessage = "Select the date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Enter the email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please select a gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Invalid phone number")]
        [DataType(DataType.PhoneNumber)]
        public string MobNo { get; set; }
        [Required(ErrorMessage = "Enter the username")]
        public  string Username { get; set; }
        [Required(ErrorMessage = "Enter a password")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public float Experience { get; set; }
        [Required(ErrorMessage = "Select a state")]
        public string State { get; set; }
        [Required(ErrorMessage = "Select a city")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter the address")]
        public  string Address { get; set; }
        [Required(ErrorMessage = "Enter the CGPA ")]
        public  float CGPA { get; set; }
        [Required(ErrorMessage = "Enter your major ")]
        public string Major { get; set; }
        [Required(ErrorMessage = "Enter your highest qualifictaion ")]
        public  string Degree { get; set; }
        [Required(ErrorMessage = "Enter the University Name ")]
        public  string University { get; set; }
        [Required(ErrorMessage = "Enter your passing-out/passed-out year ")]
        public  string Graduation { get; set; }
        [Required(ErrorMessage = "Enter the skill ")]
        public string Skills { get; set; }
       public byte[] ProfilePic { get; set; }
       public  byte[] Resume { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
