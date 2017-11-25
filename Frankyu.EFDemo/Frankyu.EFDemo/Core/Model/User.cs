using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frankyu.EFDemo.Core.Model
{
    public class User : BaseModel
    {
        [Required]
        public string Email { get; set; }

        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public int Age { get; set; }
    }
}
