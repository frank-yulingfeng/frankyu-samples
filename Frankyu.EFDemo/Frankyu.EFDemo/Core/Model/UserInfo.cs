using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Frankyu.EFDemo.Core.Model
{
    public class UserInfo : BaseModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
    }
}
