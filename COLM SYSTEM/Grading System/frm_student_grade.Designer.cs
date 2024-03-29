﻿namespace SEMS.Grading_System
{
    partial class frm_student_grade
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtYearLevel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLRN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtCourseStrand = new System.Windows.Forms.TextBox();
            this.txtEducationLevel = new System.Windows.Forms.TextBox();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbSchoolSemester = new System.Windows.Forms.ComboBox();
            this.cmbSchoolYear = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTotalUnits = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGWA = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.clmStudentGradeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFacultyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSubjGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGradeAverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Information";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.txtYearLevel);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtLRN);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.txtCourseStrand);
            this.panel1.Controls.Add(this.txtEducationLevel);
            this.panel1.Controls.Add(this.txtStudentName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(15, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 73);
            this.panel1.TabIndex = 1;
            // 
            // txtYearLevel
            // 
            this.txtYearLevel.Location = new System.Drawing.Point(595, 35);
            this.txtYearLevel.Name = "txtYearLevel";
            this.txtYearLevel.ReadOnly = true;
            this.txtYearLevel.Size = new System.Drawing.Size(103, 23);
            this.txtYearLevel.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(592, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Year Level";
            // 
            // txtLRN
            // 
            this.txtLRN.Location = new System.Drawing.Point(23, 35);
            this.txtLRN.Name = "txtLRN";
            this.txtLRN.ReadOnly = true;
            this.txtLRN.Size = new System.Drawing.Size(121, 23);
            this.txtLRN.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "LRN";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(705, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(124, 41);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse Student";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCourseStrand
            // 
            this.txtCourseStrand.Location = new System.Drawing.Point(486, 35);
            this.txtCourseStrand.Name = "txtCourseStrand";
            this.txtCourseStrand.ReadOnly = true;
            this.txtCourseStrand.Size = new System.Drawing.Size(103, 23);
            this.txtCourseStrand.TabIndex = 5;
            // 
            // txtEducationLevel
            // 
            this.txtEducationLevel.Location = new System.Drawing.Point(377, 35);
            this.txtEducationLevel.Name = "txtEducationLevel";
            this.txtEducationLevel.ReadOnly = true;
            this.txtEducationLevel.Size = new System.Drawing.Size(103, 23);
            this.txtEducationLevel.TabIndex = 4;
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(150, 35);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(221, 23);
            this.txtStudentName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(483, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Course / Strand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Education Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.txtGWA);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtTotalUnits);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.cmbSchoolSemester);
            this.panel2.Controls.Add(this.cmbSchoolYear);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(15, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(845, 393);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SEMS.Properties.Resources.buffering;
            this.pictureBox1.Location = new System.Drawing.Point(277, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmStudentGradeID,
            this.clmSubjCode,
            this.clmSubjDesc,
            this.clmSubjUnit,
            this.clmFacultyName,
            this.clmSubjGrade,
            this.clmGradeAverage});
            this.dataGridView1.Location = new System.Drawing.Point(23, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(806, 292);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // cmbSchoolSemester
            // 
            this.cmbSchoolSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchoolSemester.FormattingEnabled = true;
            this.cmbSchoolSemester.Location = new System.Drawing.Point(150, 32);
            this.cmbSchoolSemester.Name = "cmbSchoolSemester";
            this.cmbSchoolSemester.Size = new System.Drawing.Size(121, 23);
            this.cmbSchoolSemester.TabIndex = 3;
            this.cmbSchoolSemester.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolSemester_SelectedIndexChanged);
            // 
            // cmbSchoolYear
            // 
            this.cmbSchoolYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchoolYear.FormattingEnabled = true;
            this.cmbSchoolYear.Location = new System.Drawing.Point(23, 32);
            this.cmbSchoolYear.Name = "cmbSchoolYear";
            this.cmbSchoolYear.Size = new System.Drawing.Size(121, 23);
            this.cmbSchoolYear.TabIndex = 2;
            this.cmbSchoolYear.SelectedIndexChanged += new System.EventHandler(this.cmbSchoolYear_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Semester";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "School Year";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Grades";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(720, 543);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 41);
            this.button1.TabIndex = 7;
            this.button1.Text = "Print Grade";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtTotalUnits
            // 
            this.txtTotalUnits.Location = new System.Drawing.Point(662, 359);
            this.txtTotalUnits.Name = "txtTotalUnits";
            this.txtTotalUnits.ReadOnly = true;
            this.txtTotalUnits.Size = new System.Drawing.Size(61, 23);
            this.txtTotalUnits.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(587, 362);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Total Units:";
            // 
            // txtGWA
            // 
            this.txtGWA.Location = new System.Drawing.Point(768, 359);
            this.txtGWA.Name = "txtGWA";
            this.txtGWA.ReadOnly = true;
            this.txtGWA.Size = new System.Drawing.Size(61, 23);
            this.txtGWA.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(729, 362);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "GWA";
            // 
            // clmStudentGradeID
            // 
            this.clmStudentGradeID.HeaderText = "Student Grade ID";
            this.clmStudentGradeID.Name = "clmStudentGradeID";
            this.clmStudentGradeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmStudentGradeID.Visible = false;
            // 
            // clmSubjCode
            // 
            this.clmSubjCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmSubjCode.HeaderText = "Subject Code";
            this.clmSubjCode.Name = "clmSubjCode";
            this.clmSubjCode.ReadOnly = true;
            this.clmSubjCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSubjCode.Width = 93;
            // 
            // clmSubjDesc
            // 
            this.clmSubjDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmSubjDesc.HeaderText = "Description";
            this.clmSubjDesc.Name = "clmSubjDesc";
            this.clmSubjDesc.ReadOnly = true;
            this.clmSubjDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmSubjUnit
            // 
            this.clmSubjUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmSubjUnit.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmSubjUnit.HeaderText = "Units";
            this.clmSubjUnit.Name = "clmSubjUnit";
            this.clmSubjUnit.ReadOnly = true;
            this.clmSubjUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSubjUnit.Width = 52;
            // 
            // clmFacultyName
            // 
            this.clmFacultyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmFacultyName.HeaderText = "Faculty Name";
            this.clmFacultyName.Name = "clmFacultyName";
            this.clmFacultyName.ReadOnly = true;
            this.clmFacultyName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmFacultyName.Width = 97;
            // 
            // clmSubjGrade
            // 
            this.clmSubjGrade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clmSubjGrade.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmSubjGrade.HeaderText = "Subject Grade";
            this.clmSubjGrade.Name = "clmSubjGrade";
            this.clmSubjGrade.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmSubjGrade.Width = 99;
            // 
            // clmGradeAverage
            // 
            this.clmGradeAverage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmGradeAverage.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmGradeAverage.HeaderText = "Average";
            this.clmGradeAverage.Name = "clmGradeAverage";
            this.clmGradeAverage.Width = 85;
            // 
            // frm_student_grade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 604);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_student_grade";
            this.Text = "Student Grades";
            this.Load += new System.EventHandler(this.frm_student_grade_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCourseStrand;
        private System.Windows.Forms.TextBox txtEducationLevel;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSchoolSemester;
        private System.Windows.Forms.ComboBox cmbSchoolYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLRN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtYearLevel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalUnits;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGWA;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStudentGradeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFacultyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSubjGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGradeAverage;
    }
}