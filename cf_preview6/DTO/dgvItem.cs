using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cf_preview6.DTO
{
    internal class dgvItem
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public bool Gender { get; set; }
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public double Grade_ex { get; set; }
        public double Grade_mid { get; set; }
        public double Grade_final { get; set; }
        public double Grade_total { get; set; }
        public DateTime ExamDay { get; set; }
    }
}
