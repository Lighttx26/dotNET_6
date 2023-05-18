using cf_preview6.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace cf_preview6.DAL
{
    internal class DAL
    {
        private static DAL _instance;
        public static DAL Instance 
        { 
            get 
            {
                if (_instance == null) _instance = new DAL();
                return _instance;
            }

            private set { }
        }
        private double Total(double BT, double GK, double CK)
        {
            return 0.2 * BT + 0.2 * GK + 0.6 * CK;
        }

        public List<Student> GetStudents()
        {
            List<Student> list = new List<Student>();

            using (Model model = new Model())
            {
                var dblist = model.Students.ToList();
                list = dblist;
            }

            return list;
        }

        //public List<dgvItem> GetStudentsCoursesFilter(string courseid = "0", string searchtxt = "", string sortField = "StudentID")
        //{
        //    List<dgvItem> list = new List<dgvItem>();

        //    using (Model model = new Model())
        //    {
        //        var dblist = model.StudentsCourses.Join(model.Students, sc => sc.StudentID, s => s.StudentID, (sc, s) => new
        //        {
        //            sc,
        //            s
        //        }).Join(model.Courses, sc2 => sc2.sc.CourseID, c => c.CourseID, (sc2, c) => new
        //        {
        //            sc2.sc,
        //            sc2.s,
        //            c
        //        }).Select(x => new
        //        {
        //            StudentID = x.s.StudentID,
        //            StudentName = x.s.StudentName,
        //            ClassName = x.s.ClassName,
        //            Gender = x.s.Gender,
        //            CourseID = x.c.CourseID,
        //            CourseName = x.c.CourseName,
        //            Grade_ex = x.sc.Grade_ex,
        //            Grade_mid = x.sc.Grade_mid,
        //            Grade_final = x.sc.Grade_final,
        //            ExamDay = x.sc.ExaminationTime,
        //        }).Where(x => (x.CourseID == courseid || courseid == "0") && (x.StudentName.Contains(searchtxt) || x.ClassName.Contains(searchtxt))
        //        ).OrderBy(sortField);

        //        foreach (var st in dblist)
        //        {
        //            list.Add(new dgvItem
        //            {
        //                StudentID = st.StudentID,
        //                StudentName = st.StudentName,
        //                ClassName = st.ClassName,
        //                Gender = st.Gender,
        //                CourseID = st.CourseID,
        //                CourseName = st.CourseName,
        //                Grade_ex = st.Grade_ex,
        //                Grade_mid = st.Grade_mid,
        //                Grade_final = st.Grade_final,
        //                Grade_total = Total(st.Grade_ex, st.Grade_mid, st.Grade_final),
        //                ExamDay = st.ExamDay
        //            });
        //        }
        //    }

        //    return list;
        //}

        public List<dgvItem> GetAllStudentsCourses()
        {
            List<dgvItem> list = new List<dgvItem>();

            using (Model model = new Model())
            {
                var dblist = model.StudentsCourses.Join(model.Students, sc => sc.StudentID, s => s.StudentID, (sc, s) => new
                {
                    sc,
                    s
                }).Join(model.Courses, sc2 => sc2.sc.CourseID, c => c.CourseID, (sc2, c) => new
                {
                    sc2.sc,
                    sc2.s,
                    c
                }).Select(x => new
                {
                    StudentID = x.s.StudentID,
                    StudentName = x.s.StudentName,
                    ClassName = x.s.ClassName,
                    Gender = x.s.Gender,
                    CourseID = x.c.CourseID,
                    CourseName = x.c.CourseName,
                    Grade_ex = x.sc.Grade_ex,
                    Grade_mid = x.sc.Grade_mid,
                    Grade_final = x.sc.Grade_final,
                    ExamDay = x.sc.ExaminationTime,
                });

                foreach (var st in dblist)
                {
                    list.Add(new dgvItem
                    {
                        StudentID = st.StudentID,
                        StudentName = st.StudentName,
                        ClassName = st.ClassName,
                        Gender = st.Gender,
                        CourseID = st.CourseID,
                        CourseName = st.CourseName,
                        Grade_ex = st.Grade_ex,
                        Grade_mid = st.Grade_mid,
                        Grade_final = st.Grade_final,
                        Grade_total = Total(st.Grade_ex, st.Grade_mid, st.Grade_final),
                        ExamDay = st.ExamDay
                    });
                }
            }

            return list;
        }

        public List<ItemCBB> GetCourses()
        {
            List<ItemCBB> list = new List<ItemCBB>();

            using (Model model = new Model())
            {
                var list1 = model.Courses.Select(c => new { c.CourseID, c.CourseName });

                foreach (var c in list1)
                {
                    list.Add(new ItemCBB
                    {
                        Value = c.CourseID,
                        Text = c.CourseName,
                    });
                }
            }

            return list;
        }

        public dgvItem GetStudentCourseByPK(string studentid, string courseid)
        {
            dgvItem di;
            using (Model model = new Model())
            {
                var st = model.StudentsCourses.Join(model.Students, sc => sc.StudentID, s => s.StudentID, (sc, s) => new
                {
                    sc,
                    s
                }).Join(model.Courses, sc2 => sc2.sc.CourseID, c => c.CourseID, (sc2, c) => new
                {
                    sc2.sc,
                    sc2.s,
                    c
                }).Where(x => x.s.StudentID == studentid && x.c.CourseID == courseid).Select(x => new
                {
                    StudentID = x.s.StudentID,
                    StudentName = x.s.StudentName,
                    ClassName = x.s.ClassName,
                    Gender = x.s.Gender,
                    CourseID = x.c.CourseID,
                    CourseName = x.c.CourseName,
                    Grade_ex = x.sc.Grade_ex,
                    Grade_mid = x.sc.Grade_mid,
                    Grade_final = x.sc.Grade_final,
                    ExamDay = x.sc.ExaminationTime,
                }).First();

                di = new dgvItem
                {
                    StudentID = st.StudentID,
                    StudentName = st.StudentName,
                    ClassName = st.ClassName,
                    Gender = st.Gender,
                    CourseID = st.CourseID,
                    CourseName = st.CourseName,
                    Grade_ex = st.Grade_ex,
                    Grade_mid = st.Grade_mid,
                    Grade_final = st.Grade_final,
                    Grade_total = Total(st.Grade_ex, st.Grade_mid, st.Grade_final),
                    ExamDay = st.ExamDay
                };
            }
            return di;
        }

        public bool IsExistStudentID(string studentid)
        {
            bool result;
            using (Model model = new Model())
            {
                bool st = model.Students.Any(s => s.StudentID == studentid);
                result = st;
            }
            return result;
        }

        public bool IsExistStudentCourse(string studentid, string courseid)
        {
            bool result;
            using (Model model = new Model())
            {
                bool st = model.StudentsCourses.Any(sc => sc.StudentID == studentid && sc.CourseID == courseid);
                result = st;
            }
            return result;
        }
        public void AddStudent(Student s)
        {
            using (Model model = new Model())
            {
                model.Students.Add(s);
                model.SaveChanges();
            }
        }

        public void UpdateStudent(Student s)
        {
            using (Model model = new Model())
            {
                var _student = model.Students.Single(st => st.StudentID == s.StudentID);
                _student.StudentName = s.StudentName;
                _student.ClassName = s.ClassName;
                _student.Gender = s.Gender;

                model.SaveChanges();
            }
        }

        public void AddStudentCourse(StudentCourse sc)
        {
            using (Model model = new Model())
            {
                model.StudentsCourses.Add(sc);
                model.SaveChanges();
            }
        }

        public void UpdateStudentCourse(StudentCourse sc)
        {
            using (Model model = new Model())
            {
                var _sc = model.StudentsCourses.Single(stc => stc.StudentID == sc.StudentID && stc.CourseID == sc.CourseID);
                _sc.StudentID = sc.StudentID;
                _sc.CourseID = sc.CourseID;
                _sc.Grade_ex = sc.Grade_ex;
                _sc.Grade_mid = sc.Grade_mid;
                _sc.Grade_final = sc.Grade_final;
                _sc.ExaminationTime = sc.ExaminationTime;
                model.SaveChanges();
            }
        }

        public void DeleteStudentCourse(string studentid, string courseid)
        {
            using (Model model = new Model())
            {
                var _sc = model.StudentsCourses.Single(sc => sc.CourseID == courseid && sc.StudentID == studentid);
                model.StudentsCourses.Remove(_sc);
                model.SaveChanges();
            }
        }
    }
}
