using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frankyu.Model
{
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public decimal Height { get; set; }

        public float Weight { get; set; }

        public Gender Gender { get; set; }


        //fully defined relationship
        public int? GradeId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual StudentAddress Address { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
