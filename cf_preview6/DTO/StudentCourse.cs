using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf_preview6
{
    public class StudentCourse
    {
        [Key, Column(Order = 0)]
        public string StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
        [Key, Column(Order = 1)]
        public string CourseID { get; set; }
        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
        public double Grade_ex { get; set; }
        public double Grade_mid { get; set; }
        public double Grade_final { get; set; }
        public DateTime ExaminationTime { get; set; }
    }
}
