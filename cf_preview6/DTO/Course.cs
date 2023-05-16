using cf_preview6.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf_preview6
{
    public class Course
    {
        [Key]
        [Required]
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        //public virtual ICollection<Student> Students { get; set; }
    }
}
