using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frankyu.EFDemo.Core.Model
{
    public class BaseModel
    {
        /// <summary>
        /// Primary Key default auto increase
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
