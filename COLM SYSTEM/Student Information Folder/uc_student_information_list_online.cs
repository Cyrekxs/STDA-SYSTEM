﻿using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using SEMS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Student_Information_Folder
{
    public partial class uc_student_information_list_online : UserControl
    {
        IStudentApplicantRepository _StudentApplicantRepository = new StudentApplicantRepository();

        List<StudentInfoOnline> applicants = new List<StudentInfoOnline>();
        private int SelectedRow;

        public uc_student_information_list_online()
        {
            InitializeComponent();
        }

        private void DisplayOnlineApplications(List<StudentInfoOnline> Applicants)
        {
            dataGridView1.Rows.Clear();
            foreach (var applicant in Applicants)
            {
                string gender = applicant.Gender.Substring(0, 1);
                dataGridView1.Rows.Add(applicant.ApplicationID, applicant.StudentStatus, applicant.LRN, applicant.StudentName, gender, applicant.EmailAddress, applicant.MobileNo, applicant.EducationLevel, applicant.CourseStrand, applicant.YearLevel, applicant.ApplicationDate.ToString("MM-dd-yyyy hh:mm tt"));
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = applicant;
            }
        }

        private async Task LoadApplicants()
        {
            var result = await _StudentApplicantRepository.GetOnlineApplicants();
            applicants = result.ToList();

            //try
            //{
            //    Task<List<StudentInfoOnline>> task = new Task<List<StudentInfoOnline>>(StudentInfoOnline.GetOnlineApplications);
            //    task.Start();
            //    using (frm_loading frm = new frm_loading(task))
            //    {
            //        frm.StartPosition = FormStartPosition.CenterScreen;
            //        frm.ShowDialog();
            //    }

            //    applicants = task.Result;

            //    if (string.IsNullOrEmpty(txtSearch.Text) == false)
            //    {
            //        applicants = applicants.Where(r => r.StudentName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            //    }

            //    dataGridView1.Rows.Clear();
            //    foreach (var item in applicants)
            //    {
            //        string gender = item.Gender.Substring(0, 1);
            //        dataGridView1.Rows.Add(item.ApplicationID, item.StudentStatus, item.LRN, item.StudentName, gender, item.EmailAddress, item.MobileNo, item.EducationLevel, item.CourseStrand, item.YearLevel, item.ApplicationDate.ToString("MM-dd-yyyy hh:mm tt"));
            //        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = item;
            //    }
            //    lblCount.Text = string.Concat("Record Count(s):", dataGridView1.Rows.Count);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("It seems that your internet connection is lost or not available right now to fetch online applicants!", "Error Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clmAction.Index)
            {
                SelectedRow = e.RowIndex;
                contextMenuStrip1.Show(new Point(Cursor.Position.X, Cursor.Position.Y));
            }
        }

        private async void processApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_student_information_online_entry_1 frm = new frm_student_information_online_entry_1(dataGridView1.Rows[SelectedRow].Tag as StudentInfoOnline);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            await LoadApplicants();
            DisplayOnlineApplications(applicants);
        }

        private async void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = Convert.ToInt16(dataGridView1.Rows[SelectedRow].Cells["clmApplicationID"].Value);
            if (MessageBox.Show("Are you sure you want to delete this online application? this transaction cannot be reverted", "Delete Online Application?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int result = StudentInfoOnline.RemoveOnlineApplication(ApplicationID);
                if (result > 0)
                {
                    await LoadApplicants();
                    DisplayOnlineApplications(applicants);
                }

            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<StudentInfoOnline> SearchedResult = new List<StudentInfoOnline>();
                SearchedResult = applicants.Where(r => string.Concat(r.Lastname, " ", r.Firstname, " ",r.Middlename).ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                DisplayOnlineApplications(SearchedResult);
            }
        }

        private async void uc_student_information_list_online_Load(object sender, EventArgs e)
        {
            await LoadApplicants();
            DisplayOnlineApplications(applicants);
        }
    }
}
