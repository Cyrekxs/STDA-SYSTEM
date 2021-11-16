﻿using COLM_SYSTEM.Assessment_Folder;
using COLM_SYSTEM.Curriculum_Folder;
using COLM_SYSTEM.Discounts;
using COLM_SYSTEM.Faculty_Folder;
using COLM_SYSTEM.Fees_Folder;
using COLM_SYSTEM.Payment_Folder;
using COLM_SYSTEM.Registration_Folder;
using COLM_SYSTEM.Reports_Folder;
using COLM_SYSTEM.Section_Folder;
using COLM_SYSTEM.Settings_Folder;
using COLM_SYSTEM.student_information;
using COLM_SYSTEM.Student_Information_Folder;
using COLM_SYSTEM.subject;
using COLM_SYSTEM.User_Folder;
using COLM_SYSTEM_LIBRARY.model;
using SEMS;
using SEMS.Faculty_Folder;
using SEMS.Reports_Folder;
using SEMS.Settings_Folder;
using SEMS.Student_Information_Folder;
using System;
using System.Deployment.Application;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM
{
    public partial class frm_main : Form
    {
        //#FF004000 metro studio color use for green

        public frm_main()
        {
            InitializeComponent();

            lblAccountName.Text = Utilties.user.AccountName;
            lblPosition.Text = Utilties.user.UserRole.RoleName;
            lblSchoolYear.Text = Utilties.GetActiveSchoolYearInfo().ToUpper();
            lblSemester.Text = Utilties.GetActiveSchoolSemesterInfo().ToUpper();


            string GetVersion = ApplicationDeployment.IsNetworkDeployed ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() : Application.ProductVersion;
            lblVersion.Text = string.Concat("version ", GetVersion);


            string role = Utilties.user.UserRole.RoleName.ToLower();
            if (role.Equals("information"))
            {
                HideAllMi();
                //transaction
                miStudentApplicants.Visible = true;
                miStudentInformation.Visible = true;
                //reports
                miReports.Visible = true;
                miCollectionReport.Visible = false;
                miMasterList.Visible = true;
            }

            else if (role.Equals("assessor"))
            {
                HideAllMi();
                //transaction
                miStudentApplicants.Visible = true;
                miStudentInformation.Visible = true;
                miStudentRegistration.Visible = true;
                miStudentAssessment.Visible = true;
                //reports
                miReports.Visible = true;
                miCollectionReport.Visible = false;
                miMasterList.Visible = true;
            }

            else if (role.Equals("registrar"))
            {
                HideAllMi();
                //transaction
                miStudentApplicants.Visible = true;
                miStudentInformation.Visible = true;
                miStudentRegistration.Visible = true;
                miStudentAssessment.Visible = true;
                //settings
                miSettings.Visible = true;
                miSchoolData.Visible = true;
                //reports
                miReports.Visible = true;
                miCollectionReport.Visible = false;
                miMasterList.Visible = true;
            }

            else if (role.Equals("cashier"))
            {
                HideAllMi();
                //transaction
                miStudentPayment.Visible = true;
                miReports.Visible = true;
                miCollectionReport.Visible = true;
                miMasterList.Visible = false;
            }
            DisplayControl(new UC_DashBoard());
        }

        private void HideAllMi()
        {
            HideAllMiTransactions();

            miSettings.Visible = false;
            HideAllMiSettings();

            miReports.Visible = false;
            HideAllMiReports();
        }

        private void HideAllMiTransactions()
        {
            foreach (ToolStripMenuItem item in miTransactions.DropDownItems)
            {
                item.Visible = false;
            }
        }

        private void HideAllMiSettings()
        {
            foreach (ToolStripMenuItem item in miSettings.DropDownItems)
            {
                item.Visible = false;
            }
        }

        private void HideAllMiReports()
        {
            foreach (ToolStripMenuItem item in miReports.DropDownItems)
            {
                item.Visible = false;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("mmm MM-dd-yyyy hh:mm tt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                Close();
                Dispose();
            }
        }


        private async void frm_main_Load_1(object sender, EventArgs e)
        {
            string ApplicantCount = await CheckNotifications();
            lblNotificationCount.Text = ApplicantCount;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            frm_user_settings frm = new frm_user_settings();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }


        private async Task<string> CheckNotifications()
        {
            try
            {
                return await Task.Run(() => StudentInfoOnline.GetOnlineApplications().Count.ToString());
            }
            catch (Exception)
            {
                return await Task.Run(() => { return 0.ToString(); });
            }
        }

        private async void ApplicationsTimer_Tick(object sender, EventArgs e)
        {
            string ApplicantCount = await CheckNotifications();
            lblNotificationCount.Text = ApplicantCount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_student_information_list_online());
        }


        private void DisplayControl(UserControl uc)
        {
            ClearUserControls();
            uc.Dock = DockStyle.Fill;
            PanelMain.Controls.Add(uc);
        }

        private void ClearUserControls()
        {
            //remove all user controls in panel main first before display new user control
            foreach (UserControl item in PanelMain.Controls)
            {
                PanelMain.Controls.Remove(item);
            }
        }

        private void dASHBOARDToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DisplayControl(new UC_DashBoard());
        }

        private void paymentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DisplayControl(new uc_payers());
        }

        private void registrationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DisplayControl(new uc_registered_students_list());
        }

        private void informationToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DisplayControl(new uc_student_information_list());
        }

        private void tuitionFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_tuition_list());
        }

        private void onlineApplicantsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void assessmentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DisplayControl(new uc_assessment_list());
        }

        private void additionalFeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_addtional_fee_entry frm = new frm_addtional_fee_entry();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void defaultFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_default_fees frm = new frm_default_fees();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void discountsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_discount_list());
        }

        private void assessmentPaymentModesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_assessment_payment_mode_list frm = new frm_assessment_payment_mode_list();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void collectionReportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frm_collection_report_v2 frm = new frm_collection_report_v2();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_user_lists frm = new frm_user_lists();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_subject_list());
        }

        private void curriculumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_curriculum_list());
        }

        private void sectionAndSchedulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_section_lists frm = new frm_section_lists();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void facultiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_faculty_list frm = new frm_faculty_list();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void loginWallpaperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_system_settings frm = new frm_system_settings();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void schoolInformationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_settings frm = new frm_settings(new uc_settings_school_information());
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void assessmentReportSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frm_settings frm = new frm_settings(new uc_settings_assessment());
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void targetStudentSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_settings frm = new frm_settings(new uc_settings_target());
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void cLOSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearUserControls();
        }

        private void emailerAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_settings frm = new frm_settings(new uc_settings_mail());
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void messageTemplatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_settings frm = new frm_settings(new uc_settings_mail_template_lists());
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void studentRequirementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_settings frm = new frm_settings(new uc_requirement_lists());
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_online_importer_processor frm = new frm_online_importer_processor();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void onlineApplicantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_student_information_list_online());
        }

        private void unregisteredOnlineApplicantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_student_applicants_unregistered());
        }

        private void uPDATESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_whatsnew frm = new frm_whatsnew();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void transactionDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayControl(new uc_transaction_dashboard());
        }

        private void perSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_subject_master_list frm = new frm_subject_master_list();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void eLReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_enrollment_list frm = new frm_enrollment_list();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }
    }
}
