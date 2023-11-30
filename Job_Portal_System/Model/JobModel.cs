using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Job_Portal_System.Model
{
    public class JobModel
    {
        [Key]
        //public long Job_ID { get; set; }
        public long HR_ID { get; set; }
        public string Title { get; set;}

        public string JobCode { get; set; }
        public string Description { get; set;}
        public string Req_Skills { get; set; }
        public string Location { get; set; }
        public float Salary { get; set; }
        public string Type { get; set; }
        public string Role { get; set; }
        public int vacancy { get; set; }

        public DateTime Opening { get; set; }
        public DateTime Deadline { get; set; }





    }
}
