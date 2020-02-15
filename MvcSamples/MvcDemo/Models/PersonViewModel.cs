using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcDemo.Models
{
    public class PersonViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [Range(0, 130)]
        public int Age { get; set; }

        public string EmailAddress { get; set; }

    }
    
    /// <summary>
    /// 性别
    /// </summary>
    public enum Gender
    {
        Female,
        Male
    }
}