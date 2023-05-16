using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf_preview6
{
    public class Student
    {
        [Key]
        [Required]
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public bool Gender { get; set; }
        //public virtual ICollection<Course> Courses { get; set; }
    }
}
