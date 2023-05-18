using cf_preview6.DTO;
using cf_preview6.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cf_preview6
{
    public partial class Form1 : Form
    {
        // represent data in db
        private List<dgvItem> dgvItems;
        public Form1()
        {
            InitializeComponent();
            dgv.Columns.Add("#", "STT");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadDgv();
            ReloadCourseCb();
            ReloadSortCb();
        }

        #region BUTTON HANDLER
        private void addBtn_Click(object sender, EventArgs e)
        {
            DetailsForm dform = new DetailsForm();
            dform.ReloadMainform = new DetailsForm.MyDelegate(this.ReloadDgv); // Ham this.Reload() se duoc thuc thi khi MyDelegate DetailsForm duoc goi
            dform.Show();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select one row");
            }

            else
            {
                string sid = dgv.SelectedRows[0].Cells["StudentID"].Value.ToString();
                string cid = dgv.SelectedRows[0].Cells["CourseID"].Value.ToString();
                DetailsForm dform = new DetailsForm(sid, cid);
                dform.ReloadMainform = new DetailsForm.MyDelegate(this.ReloadDgv); // Ham this.Reload() se duoc thuc thi khi MyDelegate DetailsForm duoc goi
                dform.Show();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please selecte one row");
            }

            else
            {
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    string sid = row.Cells["StudentID"].Value.ToString();
                    string cid = row.Cells["CourseID"].Value.ToString();
                    BLL.BLL.Instance.DeleteStudentCourse(sid, cid);
                }
            }

            ReloadDgv();
        }

        private void cbbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dgvItems = BLL.BLL.Instance.GetStudentsInCourse(dgvItems, ((ItemCBB)cbbCourse.SelectedItem).Value);
            //dgv.DataSource = dgvItems;

            dgv.DataSource = BLL.BLL.Instance.GetStudentsInCourse(dgvItems, ((ItemCBB)cbbCourse.SelectedItem).Value);
            RenameColumn();

            tbSearch.Clear();
            cbbSort.Text = "<NONE>";
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            //dgvItems = BLL.BLL.Instance.GetStudentsCoursesBySearch(dgvItems, ((ItemCBB)cbbCourse.SelectedItem).Value, tbSearch.Text);
            //dgv.DataSource = dgvItems;

            dgv.DataSource = BLL.BLL.Instance.GetStudentsCoursesBySearch(dgvItems, ((ItemCBB)cbbCourse.SelectedItem).Value, tbSearch.Text);
            RenameColumn();

            cbbSort.Text = "<NONE>";
        }

        private void sortBtn_Click(object sender, EventArgs e)
        {
            //dgvItems = BLL.BLL.Instance.GetStudentsCoursesBySort(dgvItems, ((ItemCBB)cbbSort.SelectedItem).Value);
            //dgv.DataSource = dgvItems;

            dgv.DataSource = BLL.BLL.Instance.GetStudentsCoursesBySort(dgvItems, ((ItemCBB)cbbCourse.SelectedItem).Value, tbSearch.Text, ((ItemCBB)cbbSort.SelectedItem).Value);
            RenameColumn();
        }

        #endregion

        #region SUPPORTVIEW
        private void ReloadCourseCb()
        {
            cbbCourse.Items.Clear();
            cbbCourse.Items.Add(new ItemCBB
            {
                Text = "All",
                Value = "0",
            });
            cbbCourse.Items.AddRange(BLL.BLL.Instance.GetAllCourse().ToArray());
            cbbCourse.SelectedIndex = 0;
        }

        private void ReloadSortCb()
        {
            cbbSort.Items.Clear();

            cbbSort.Items.AddRange(new ItemCBB[]
            {
                new ItemCBB { Value = "NONE", Text = "<NONE>"},
                new ItemCBB { Value = "StudentName", Text = "Tên SV"},
                new ItemCBB { Value = "ClassName", Text = "Lớp SH"},
                new ItemCBB { Value = "CourseName", Text = "Học phần"},
                new ItemCBB { Value = "Grade_ex", Text = "Điểm BT"},
                new ItemCBB { Value = "Grade_mid", Text = "Điểm GK" },
                new ItemCBB { Value = "Grade_final", Text = "Điểm CK"},
                new ItemCBB { Value = "Grade_total", Text = "Tổng kết"},
                new ItemCBB { Value = "ExamDay", Text = "Ngày thi"},
            });
            cbbSort.SelectedIndex = 0;
        }

        private void ReloadDgv()
        {
            this.dgvItems = BLL.BLL.Instance.GetAllStudentsCourses();
            dgv.DataSource = dgvItems;
            RenameColumn();
        }
        private void RenameColumn()
        {
            // Cac cot khong can hien thi nhung van can de lay thong tin
            dgv.Columns["StudentID"].Visible = false;
            dgv.Columns["CourseID"].Visible = false;
            dgv.Columns["Gender"].Visible = false;

            // Doi ten hien thi cac cot
            dgv.Columns["StudentName"].HeaderText = "Tên SV";
            dgv.Columns["ClassName"].HeaderText = "Lớp SH";
            dgv.Columns["CourseName"].HeaderText = "Học phần";
            dgv.Columns["Grade_ex"].HeaderText = "Điểm BT";
            dgv.Columns["Grade_mid"].HeaderText = "Điểm GK";
            dgv.Columns["Grade_final"].HeaderText = "Điểm CK";
            dgv.Columns["Grade_total"].HeaderText = "Tổng kết";
            dgv.Columns["ExamDay"].HeaderText = "Ngày thi";
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells["#"].Value = (e.RowIndex + 1).ToString();
        }

        #endregion


    }
}
