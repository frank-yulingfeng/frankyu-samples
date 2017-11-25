using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Frankyu.EFDemo.Core.Model
{
    public class Admin : BaseModel
    {
        [Required]
        public string AdminName { get; set; }

        [Required]
        public string Password { get; set; }

        public AdminType Type { get; set; }
    }

    /// <summary>
    /// the type of amdin
    /// </summary>
    public enum AdminType
    {
        /// <summary>
        /// normal admin can manage user infomation
        /// </summary>
        Normal,

        /// <summary>
        /// superior admin can manage normal admin infomation and user infomation 
        /// </summary>
        Superior
    }
}
