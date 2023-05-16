using cf_preview6.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cf_preview6.View
{
    public partial class DetailsForm : Form
    {
        public delegate void MyDelegate();
        public MyDelegate ReloadMainform { get; set; }

        private readonly string _studentid;
        private readonly string _courseid;

        public DetailsForm(string studentid = "", string courseid = "")
        {
            InitializeComponent();

            _studentid = studentid;
            _courseid = courseid;
        }
        private void DetailsForm_Load(object sender, EventArgs e)
        {
            courseCbb.Items.AddRange(BLL.BLL.Instance.GetListCourse().ToArray());
            totalTb.ReadOnly = true;

            if (_studentid != "" && _courseid != "")
            {
                var st = BLL.BLL.Instance.GetStudentCourseByID(_studentid, _courseid);

                studentidTb.Text = st.StudentID;
                studentidTb.ReadOnly = true;
                nameTb.Text = st.StudentName;
                classCbb.Text = st.ClassName;
                courseCbb.Text = st.CourseName;
                if (st.Gender == true) maleRadio.Checked = true;
                else femaleRadio.Checked = true;
                examdayDtp.Text = st.ExamDay.ToString();
                exTb.Text = st.Grade_ex.ToString();
                midTb.Text = st.Grade_mid.ToString();
                finalTb.Text = st.Grade_final.ToString();
                totalTb.Text = st.Grade_total.ToString();
            }
        }

        // Them moi StudentCourse (Them sinh vien moi vao hoc phan)
        private void AddHandler()
        {
            try
            {
                // Neu mssv chua co thi them sinh vien moi vao DB
                if(!BLL.BLL.Instance.IsExistStudentID(studentidTb.Text))
                {
                    BLL.BLL.Instance.AddStudent(new Student
                    {
                        StudentID = studentidTb.Text,
                        StudentName = nameTb.Text,
                        ClassName = classCbb.Text,
                        Gender = maleRadio.Checked,
                    });
                }

                // Kiem tra sinh vien co trong lop hoc do chua
                if (BLL.BLL.Instance.IsExistStudentCourse(studentidTb.Text, ((CourseCBB)courseCbb.SelectedItem).Value))
                {
                    throw new Exception("Sinh vien da co trong hoc phan");
                }

                // Them sinh vien do vao mot hoc phan
                BLL.BLL.Instance.AddStudentCourse(new StudentCourse
                {
                    StudentID = studentidTb.Text,
                    CourseID = ((CourseCBB)courseCbb.SelectedItem).Value,
                    Grade_ex = Convert.ToDouble(exTb.Text),
                    Grade_mid = Convert.ToDouble(midTb.Text),
                    Grade_final = Convert.ToDouble(finalTb.Text),
                    ExaminationTime = Convert.ToDateTime(examdayDtp.Text),
                });

                ReloadMainform();
                this.Dispose();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void EditHandler()
        {
            try
            {
                Student s = new Student
                {
                    StudentID = studentidTb.Text,
                    StudentName = nameTb.Text,
                    ClassName = classCbb.Text,
                    Gender = maleRadio.Checked,
                };
                // Cap nhat thong tin sinh vien
                BLL.BLL.Instance.UpdateStudent(s);

                StudentCourse sc = new StudentCourse
                {
                    StudentID = _studentid,
                    CourseID = ((CourseCBB)courseCbb.SelectedItem).Value,
                    Grade_ex = Convert.ToDouble(exTb.Text),
                    Grade_mid = Convert.ToDouble(midTb.Text),
                    Grade_final = Convert.ToDouble(finalTb.Text),
                    ExaminationTime = Convert.ToDateTime(examdayDtp.Text)
                };

                // Khong thay doi lop hoc phan
                if (((CourseCBB)courseCbb.SelectedItem).Value == _courseid)
                {
                    // Cap nhat lai cac thong tin
                    BLL.BLL.Instance.UpdateStudentCourse(sc);
                }

                // Chuyen lop
                else
                {
                    // Xoa StudentCourse cu (Xoa sinh vien khoi lop hoc)
                    BLL.BLL.Instance.DeleteStudentCourse(_studentid, _courseid);

                    // Kiem tra sinh vien co trong lop hoc do chua
                    if (BLL.BLL.Instance.IsExistStudentCourse(studentidTb.Text, ((CourseCBB)courseCbb.SelectedItem).Value))
                    {
                        throw new Exception("Sinh vien da co trong hoc phan");
                    }

                    // Them StudentCourse moi (Them sinh vien moi vao lop hoc khac)
                    BLL.BLL.Instance.AddStudentCourse(sc);
                }

                ReloadMainform();
                this.Dispose();
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (_studentid == "") AddHandler();
            else EditHandler();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
