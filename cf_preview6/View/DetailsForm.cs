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
            ReloadClassCb();
            courseCbb.Items.AddRange(BLL.BLL.Instance.GetAllCourse().ToArray());
            totalTb.ReadOnly = true;

            if (_studentid != "" && _courseid != "")
            {
                var st = BLL.BLL.Instance.GetStudentCourse(_studentid, _courseid);

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

        private void ReloadClassCb()
        {
            classCbb.Items.AddRange(new string[]
            {
                "21T_DT",
                "21T_DT2",
                "21TCLC_DT1",
                "21TCLC_DT2",
                "21TCLC_DT3",
                "21TCLC_DT4",
            });
        }

        #region BUTTON HANDLER
        private void OkBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CheckEmptyBox();
                if (_studentid == "") AddHandler();
                else EditHandler();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        #endregion

        #region OKBUTTON HANDLER

        // Them moi StudentCourse (Them sinh vien moi vao hoc phan)
        private void AddHandler()
        {
            try
            {
                // Neu mssv chua co thi them sinh vien moi vao DB
                if (!BLL.BLL.Instance.IsExistStudent(studentidTb.Text))
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
                if (BLL.BLL.Instance.IsExistStudentCourse(studentidTb.Text, ((ItemCBB)courseCbb.SelectedItem).Value))
                {
                    throw new Exception("Sinh vien da co trong hoc phan");
                }

                // Them sinh vien do vao mot hoc phan
                BLL.BLL.Instance.AddStudentCourse(new StudentCourse
                {
                    StudentID = studentidTb.Text,
                    CourseID = ((ItemCBB)courseCbb.SelectedItem).Value,
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
        // Chinh sua StudentCourse & Student
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
                    CourseID = ((ItemCBB)courseCbb.SelectedItem).Value,
                    Grade_ex = Convert.ToDouble(exTb.Text),
                    Grade_mid = Convert.ToDouble(midTb.Text),
                    Grade_final = Convert.ToDouble(finalTb.Text),
                    ExaminationTime = Convert.ToDateTime(examdayDtp.Text)
                };

                // Khong thay doi lop hoc phan
                if (((ItemCBB)courseCbb.SelectedItem).Value == _courseid)
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
                    if (BLL.BLL.Instance.IsExistStudentCourse(studentidTb.Text, ((ItemCBB)courseCbb.SelectedItem).Value))
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

        #endregion

        private void gradeTbs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (exTb.Text.Length > 0 && midTb.Text.Length > 0 && finalTb.Text.Length > 0)
                {
                    double exg = Convert.ToDouble(exTb.Text);
                    double midg = Convert.ToDouble(midTb.Text);
                    double fing = Convert.ToDouble(finalTb.Text);

                    if (exg > 10 || midg > 10 || fing > 10 || exg < 0 || midg < 0 || fing < 0)
                    {
                        throw new Exception("Diem so nhap vao khong hop le");
                    }

                    totalTb.Text = (exg * 0.2 + midg * 0.2 + fing * 0.6).ToString();
                }

                else totalTb.Clear();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ((TextBox)sender).Clear();
            }
        }

        private void studentidTb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_studentid.Length > 0 && _courseid.Length > 0) return;
                if (studentidTb.Text.Length > 0)
                {
                    if (BLL.BLL.Instance.IsExistStudent(studentidTb.Text))
                    {
                        Student student = BLL.BLL.Instance.GetStudentByID(studentidTb.Text);
                        // Set student name
                        nameTb.ReadOnly = true;
                        nameTb.Text = student.StudentName;
                        // Set class name
                        classCbb.Enabled = false;
                        classCbb.Text = student.ClassName;
                        // Set gender
                        groupBox1.Enabled = false;
                        if (student.Gender) maleRadio.Checked = true;
                        else femaleRadio.Checked = true;
                    }

                    else
                    {
                        // Return default value
                        nameTb.ReadOnly = false;
                        nameTb.Clear();
                        classCbb.Enabled = true;
                        classCbb.Text = "";
                        groupBox1.Enabled = true;
                        maleRadio.Checked = false;
                        femaleRadio.Checked = false;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckEmptyBox()
        {
            if (studentidTb.Text == "") throw new Exception("Khong duoc de trong MSSV");
            if (nameTb.Text == "") throw new Exception("Khong duoc de trong ten");
            if (classCbb.Text == "") throw new Exception("Khong duoc de trong ten lop");
            if (courseCbb.Text == "") throw new Exception("Khong duoc de trong hoc phan");
            if (!(maleRadio.Checked || femaleRadio.Checked)) throw new Exception("Khong duoc de trong gioi tinh");
            if (exTb.Text == "") throw new Exception("Khong duoc de trong diem BT");
            if (midTb.Text == "") throw new Exception("Khong duoc de trong diem GK");
            if (finalTb.Text == "") throw new Exception("Khong duoc de trong diem CK");
        }
    }
}
