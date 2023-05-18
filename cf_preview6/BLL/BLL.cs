using cf_preview6.DTO;
using cf_preview6.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace cf_preview6.BLL
{
    internal class BLL
    {
        private static BLL _instance;
        public static BLL Instance
        {
            get
            {
                if (_instance == null) _instance = new BLL();
                return _instance;
            }

            private set { }
        }

        public List<dgvItem> GetAllStudentsCourses()
        {
            return DAL.DAL.Instance.GetAllStudentsCourses();
        }

        public List<dgvItem> GetStudentsInCourse(List<dgvItem> list, string courseid = "0")
        {
            return list.Where(sc => sc.CourseID == courseid || courseid == "0").ToList();
        }

        public List<dgvItem> GetStudentsCoursesBySearch(List<dgvItem> list, string courseid = "0", string searchtxt ="")
        {
            return list.Where(sc => (sc.CourseID == courseid || courseid == "0") && (sc.StudentName.Contains(searchtxt) || sc.ClassName.Contains(searchtxt))).ToList();
        }

        public List<dgvItem> GetStudentsCoursesBySort(List<dgvItem> list, string courseid = "0", string searchtxt = "", string sortfield = "NONE")
        {
            if (sortfield == "NONE") 
                return list.Where(sc => (sc.CourseID == courseid || courseid == "0") && (sc.StudentName.Contains(searchtxt) || sc.ClassName.Contains(searchtxt))).ToList();

            PropertyInfo propertyInfo = typeof(dgvItem).GetProperty(sortfield);

            list = list.Where(sc =>
                        (sc.CourseID == courseid || courseid == "0") &&
                        (sc.StudentName.Contains(searchtxt) || sc.ClassName.Contains(searchtxt)))
                    .OrderBy(sc => propertyInfo.GetValue(sc)).ToList();

            return list;
        }

        public dgvItem GetStudentCourse(string studentid, string courseid)
        {
            return DAL.DAL.Instance.GetStudentCourseByPK(studentid, courseid);
        }

        public List<ItemCBB> GetAllCourse()
        {
            return DAL.DAL.Instance.GetCourses();
        }

        public bool IsExistStudentID(string studentid)
        {
            try
            {
                return DAL.DAL.Instance.IsExistStudentID(studentid);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool IsExistStudentCourse(string studentid, string courseid)
        {
            try
            {
                return DAL.DAL.Instance.IsExistStudentCourse(studentid, courseid);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void AddStudent(Student s)
        {
            try
            {
                if (s != null)
                {
                    DAL.DAL.Instance.AddStudent(s);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateStudent(Student s)
        {
            try
            {
                if (s != null)
                {
                    DAL.DAL.Instance.UpdateStudent(s);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddStudentCourse(StudentCourse sc)
        {
            try
            {
                if (sc != null)
                {
                    DAL.DAL.Instance.AddStudentCourse(sc);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateStudentCourse(StudentCourse sc)
        {
            try
            {
                if (sc != null)
                {
                    DAL.DAL.Instance.UpdateStudentCourse(sc);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteStudentCourse(string studentid, string courseid)
        {
            try
            {
                if (this.IsExistStudentCourse(studentid, courseid))
                {
                    DAL.DAL.Instance.DeleteStudentCourse(studentid, courseid);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
