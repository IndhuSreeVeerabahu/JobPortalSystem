using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace Job_Portal_System.Model
{
    public class AdminModel
    {
        public long Admin_Id { get; set; }
        [Required(ErrorMessage = "Enter the username")]
        public required string UserName { get; set;}
        [Required(ErrorMessage = "Enter a password")]
        public required string Password { get; set;}
    }
}
