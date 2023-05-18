namespace cf_preview6.View
{
    partial class DetailsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CancelBtn = new System.Windows.Forms.Button();
            this.femaleRadio = new System.Windows.Forms.RadioButton();
            this.maleRadio = new System.Windows.Forms.RadioButton();
            this.OkBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.totalTb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.finalTb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.midTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.exTb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.examdayDtp = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.courseCbb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.classCbb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.studentidTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(495, 394);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 41;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // femaleRadio
            // 
            this.femaleRadio.AutoSize = true;
            this.femaleRadio.Location = new System.Drawing.Point(144, 34);
            this.femaleRadio.Name = "femaleRadio";
            this.femaleRadio.Size = new System.Drawing.Size(74, 20);
            this.femaleRadio.TabIndex = 1;
            this.femaleRadio.TabStop = true;
            this.femaleRadio.Text = "Female";
            this.femaleRadio.UseVisualStyleBackColor = true;
            // 
            // maleRadio
            // 
            this.maleRadio.AutoSize = true;
            this.maleRadio.Location = new System.Drawing.Point(6, 34);
            this.maleRadio.Name = "maleRadio";
            this.maleRadio.Size = new System.Drawing.Size(58, 20);
            this.maleRadio.TabIndex = 0;
            this.maleRadio.TabStop = true;
            this.maleRadio.Text = "Male";
            this.maleRadio.UseVisualStyleBackColor = true;
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(167, 394);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 40;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.femaleRadio);
            this.groupBox1.Controls.Add(this.maleRadio);
            this.groupBox1.Location = new System.Drawing.Point(23, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 71);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gender";
            // 
            // totalTb
            // 
            this.totalTb.Location = new System.Drawing.Point(495, 262);
            this.totalTb.Name = "totalTb";
            this.totalTb.Size = new System.Drawing.Size(163, 22);
            this.totalTb.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(411, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 16);
            this.label9.TabIndex = 37;
            this.label9.Text = "Total";
            // 
            // finalTb
            // 
            this.finalTb.Location = new System.Drawing.Point(495, 195);
            this.finalTb.Name = "finalTb";
            this.finalTb.Size = new System.Drawing.Size(163, 22);
            this.finalTb.TabIndex = 36;
            this.finalTb.TextChanged += new System.EventHandler(this.gradeTbs_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(411, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "Final";
            // 
            // midTb
            // 
            this.midTb.Location = new System.Drawing.Point(495, 144);
            this.midTb.Name = "midTb";
            this.midTb.Size = new System.Drawing.Size(163, 22);
            this.midTb.TabIndex = 34;
            this.midTb.TextChanged += new System.EventHandler(this.gradeTbs_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(411, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "Mid-term";
            // 
            // exTb
            // 
            this.exTb.Location = new System.Drawing.Point(495, 88);
            this.exTb.Name = "exTb";
            this.exTb.Size = new System.Drawing.Size(163, 22);
            this.exTb.TabIndex = 32;
            this.exTb.TextChanged += new System.EventHandler(this.gradeTbs_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(411, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Assignment";
            // 
            // examdayDtp
            // 
            this.examdayDtp.Location = new System.Drawing.Point(495, 40);
            this.examdayDtp.Name = "examdayDtp";
            this.examdayDtp.Size = new System.Drawing.Size(285, 22);
            this.examdayDtp.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(411, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Exam day";
            // 
            // courseCbb
            // 
            this.courseCbb.FormattingEnabled = true;
            this.courseCbb.Location = new System.Drawing.Point(113, 195);
            this.courseCbb.Name = "courseCbb";
            this.courseCbb.Size = new System.Drawing.Size(163, 24);
            this.courseCbb.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Course";
            // 
            // classCbb
            // 
            this.classCbb.FormattingEnabled = true;
            this.classCbb.Location = new System.Drawing.Point(113, 136);
            this.classCbb.Name = "classCbb";
            this.classCbb.Size = new System.Drawing.Size(163, 24);
            this.classCbb.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "Class";
            // 
            // nameTb
            // 
            this.nameTb.Location = new System.Drawing.Point(113, 85);
            this.nameTb.Name = "nameTb";
            this.nameTb.Size = new System.Drawing.Size(163, 22);
            this.nameTb.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Name";
            // 
            // studentidTb
            // 
            this.studentidTb.Location = new System.Drawing.Point(113, 34);
            this.studentidTb.Name = "studentidTb";
            this.studentidTb.Size = new System.Drawing.Size(163, 22);
            this.studentidTb.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "StudentID";
            // 
            // DetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.totalTb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.finalTb);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.midTb);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.exTb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.examdayDtp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.courseCbb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.classCbb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.studentidTb);
            this.Controls.Add(this.label1);
            this.Name = "DetailsForm";
            this.Text = "DetailsForm";
            this.Load += new System.EventHandler(this.DetailsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.RadioButton femaleRadio;
        private System.Windows.Forms.RadioButton maleRadio;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox totalTb;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox finalTb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox midTb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox exTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker examdayDtp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox courseCbb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox classCbb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox studentidTb;
        private System.Windows.Forms.Label label1;
    }
}