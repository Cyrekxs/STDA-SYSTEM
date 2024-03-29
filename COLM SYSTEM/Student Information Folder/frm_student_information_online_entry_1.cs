﻿using COLM_SYSTEM_LIBRARY.Controller;
using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COLM_SYSTEM.Student_Information_Folder
{
    public partial class frm_student_information_online_entry_1 : Form
    {
        IStudentRepository _StudentRepository = new StudentRepository();

        StudentController controller = new StudentController();
        List<Address> addresses = Address.GetAddresses();
        List<string> Schools = new List<string>();
        List<string> SchoolAddresses = new List<string>();
        private int ApplicationID { get; set; } = 0;
        private StudentInfo StudentInformation { get; set; } = new StudentInfo();
        public StudentInformationOnlineModel OnlineInfoModel { get; }

        private SavingOptions SavingStatus;

        enum SavingOptions
        {
            INSERT,
            UPDATE,
            ONLINE
        }

        //ADD NEW STUDENT
        public frm_student_information_online_entry_1()
        {
            InitializeComponent();
            SavingStatus = SavingOptions.INSERT;
            StudentInformation = new StudentInfo();
        }
        //UPDATE STUDENT INFORMATION
        public frm_student_information_online_entry_1(int StudentID)
        {
            InitializeComponent();
            SavingStatus = SavingOptions.UPDATE;
            StudentInformation.StudentID = StudentID;
        }

        //IMPORT ONLINE APPLICANT TO CREATE NEW STUDENT
        public frm_student_information_online_entry_1(StudentInformationOnlineModel onlineInfoModel)
        {
            InitializeComponent();
            SavingStatus = SavingOptions.ONLINE;
            ApplicationID = onlineInfoModel.ApplicationID;
            OnlineInfoModel = onlineInfoModel;
        }

        private async Task LoadSchoolsandSchoolAddress()
        {
            Schools = await controller.GetSchools();
            SchoolAddresses = await controller.GetSchoolAddresses();
        }

        private void DisplayStudentInfo()
        {
            try
            {
                txtLRN.Text = StudentInformation.LRN;
                txtFirstname.Text = StudentInformation.Firstname;
                txtMiddlename.Text = StudentInformation.Middlename;
                txtLastname.Text = StudentInformation.Lastname;
                txtBirthDate.Text = StudentInformation.BirthDate.ToString();
                cmbGender.Text = StudentInformation.Gender;

                txtStreet.Text = StudentInformation.Street;
                txtProvince.Text = StudentInformation.Province;
                txtCity.Text = StudentInformation.City;
                txtBarangay.Text = StudentInformation.Barangay;

                txtMobileNo.Text = StudentInformation.MobileNo;
                txtEmailAddress.Text = StudentInformation.EmailAddress;

                txtMotherName.Text = StudentInformation.MotherName;
                txtMotherMobile.Text = StudentInformation.MobileNo;
                txtFatherName.Text = StudentInformation.FatherName;
                txtFatherMobile.Text = StudentInformation.FatherMobile;
                txtGuardianName.Text = StudentInformation.GuardianName;
                txtGuardianMobile.Text = StudentInformation.GuardianMobile;
                txtEmergencyName.Text = StudentInformation.EmergencyName;
                txtEmergencyRelation.Text = StudentInformation.EmergencyRelation;
                txtEmergencyMobile.Text = StudentInformation.EmergencyMobile;

                txtSchoolName.Text = StudentInformation.SchoolName;
                txtSchoolAddress.Text = StudentInformation.SchoolAddress;
                cmbSchoolStatus.Text = StudentInformation.SchoolStatus;
                cmbESCGuarantee.Text = StudentInformation.ESCGuarantee;

                cmbStudentStatus.Text = StudentInformation.StudentStatus;
                txtEducationLevel.Text = StudentInformation.EducationLevel;
                txtCourseStrand.Text = StudentInformation.CourseStrand;
                txtYearLevel.Text = StudentInformation.YearLevel;


                if (txtEmergencyName.Text == txtMotherName.Text)
                    checkBox1.Checked = true;
                else if (txtEmergencyName.Text == txtFatherName.Text)
                    checkBox2.Checked = true;
                else if (txtEmergencyName.Text == txtGuardianName.Text)
                    checkBox3.Checked = true;
            }
            catch (Exception)
            {

            }

        }

        private void DisplayStudentInfoOnline()
        {
            txtLRN.Text = OnlineInfoModel.LRN;
            txtFirstname.Text = OnlineInfoModel.Firstname;
            txtMiddlename.Text = OnlineInfoModel.Middlename;
            txtLastname.Text = OnlineInfoModel.Lastname;
            txtBirthDate.Text = OnlineInfoModel.BirthDate.ToString();
            cmbGender.Text = OnlineInfoModel.Gender;

            txtStreet.Text = OnlineInfoModel.Street;
            txtProvince.Text = OnlineInfoModel.Province;
            txtCity.Text = OnlineInfoModel.City;
            txtBarangay.Text = OnlineInfoModel.Barangay;

            txtMobileNo.Text = OnlineInfoModel.MobileNo;
            txtEmailAddress.Text = OnlineInfoModel.EmailAddress;

            txtMotherName.Text = OnlineInfoModel.MotherName;
            txtMotherMobile.Text = OnlineInfoModel.MobileNo;
            txtFatherName.Text = OnlineInfoModel.FatherName;
            txtFatherMobile.Text = OnlineInfoModel.FatherMobile;
            txtGuardianName.Text = OnlineInfoModel.GuardianName;
            txtGuardianMobile.Text = OnlineInfoModel.GuardianMobile;
            txtEmergencyName.Text = OnlineInfoModel.EmergencyName;
            txtEmergencyRelation.Text = OnlineInfoModel.EmergencyRelation;
            txtEmergencyMobile.Text = OnlineInfoModel.EmergencyMobile;

            txtSchoolName.Text = OnlineInfoModel.SchoolName;
            txtSchoolAddress.Text = OnlineInfoModel.SchoolAddress;
            cmbSchoolStatus.Text = OnlineInfoModel.SchoolStatus;
            cmbESCGuarantee.Text = OnlineInfoModel.ESCGuarantee;

            cmbStudentStatus.Text = OnlineInfoModel.StudentStatus;
            txtEducationLevel.Text = OnlineInfoModel.EducationLevel;
            txtCourseStrand.Text = OnlineInfoModel.CourseStrand;
            txtYearLevel.Text = OnlineInfoModel.YearLevel;


            if (txtEmergencyName.Text == txtMotherName.Text)
                checkBox1.Checked = true;
            else if (txtEmergencyName.Text == txtFatherName.Text)
                checkBox2.Checked = true;
            else if (txtEmergencyName.Text == txtGuardianName.Text)
                checkBox3.Checked = true;
        }

        private bool IsValidForm()
        {
            if (string.IsNullOrEmpty(txtLastname.Text))
            {
                MessageBox.Show("Last Name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtFirstname.Text))
            {
                MessageBox.Show("First Name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(cmbGender.Text))
            {
                MessageBox.Show("Gender is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtMobileNo.Text))
            {
                MessageBox.Show("Mobile No is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtEmailAddress.Text))
            {
                MessageBox.Show("Email Address is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtMotherName.Text))
            {
                MessageBox.Show("Mother Name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtFatherName.Text))
            {
                MessageBox.Show("Father Name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtEmergencyName.Text))
            {
                MessageBox.Show("Emergency Name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtEmergencyMobile.Text))
            {
                MessageBox.Show("Emergency Mobile is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtSchoolName.Text))
            {
                MessageBox.Show("School Name is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtSchoolAddress.Text))
            {
                MessageBox.Show("School Address is required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void LoadSuggestionSchools()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(Schools.ToArray());
            txtSchoolName.AutoCompleteCustomSource = collection;
        }

        private void LoadSuggestionSchoolAddresses()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(SchoolAddresses.ToArray());
            txtSchoolAddress.AutoCompleteCustomSource = collection;
        }

        private void LoadSuggestionProvince()
        {
            List<string> Provinces = addresses.Select(r => r.Province).Distinct().ToList();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(addresses.Select(r => r.Province).Distinct().ToList().ToArray());
            txtProvince.AutoCompleteCustomSource = collection;
        }

        private void LoadSuggestionCities()
        {
            List<string> Cities = addresses.Where(r => r.Province.ToLower() == txtProvince.Text.ToLower()).Select(r => r.City).Distinct().ToList();
            foreach (var item in Cities)
            {
                txtCity.AutoCompleteCustomSource.Add(item);
            }
        }

        private void LoadSuggestionBarangay()
        {
            List<string> Barangays = addresses.Where(r => r.Province.ToLower() == txtProvince.Text.ToLower() && r.City.ToLower() == txtCity.Text.ToLower()).Select(r => r.Barangay).Distinct().ToList();
            foreach (var item in Barangays)
            {
                txtBarangay.AutoCompleteCustomSource.Add(item);
            }
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            //validate form
            if (IsValidForm() == false)
                return;

            StudentInformation.LRN = txtLRN.Text;
            StudentInformation.Lastname = txtLastname.Text;
            StudentInformation.Firstname = txtFirstname.Text;
            StudentInformation.Middlename = txtMiddlename.Text;
            StudentInformation.BirthDate = txtBirthDate.Value;
            StudentInformation.Gender = cmbGender.Text;
            StudentInformation.Street = txtStreet.Text;
            StudentInformation.Barangay = txtBarangay.Text;
            StudentInformation.City = txtCity.Text;
            StudentInformation.Province = txtProvince.Text;
            StudentInformation.MobileNo = txtMobileNo.Text;
            StudentInformation.EmailAddress = txtEmailAddress.Text;

            StudentInformation.MotherName = txtMotherName.Text;
            StudentInformation.MotherMobile = txtMotherMobile.Text;
            StudentInformation.FatherName = txtFatherName.Text;
            StudentInformation.FatherMobile = txtFatherMobile.Text;
            StudentInformation.GuardianName = txtGuardianName.Text;
            StudentInformation.GuardianMobile = txtGuardianMobile.Text;
            StudentInformation.EmergencyName = txtEmergencyName.Text;
            StudentInformation.EmergencyRelation = txtEmergencyRelation.Text;
            StudentInformation.EmergencyMobile = txtEmergencyMobile.Text;

            StudentInformation.SchoolName = txtSchoolName.Text;
            StudentInformation.SchoolAddress = txtSchoolAddress.Text;
            StudentInformation.SchoolStatus = cmbSchoolStatus.Text;
            StudentInformation.ESCGuarantee = cmbESCGuarantee.Text;
            StudentInformation.StudentStatus = cmbStudentStatus.Text;
            StudentInformation.EducationLevel = txtEducationLevel.Text;
            StudentInformation.CourseStrand = txtCourseStrand.Text;
            StudentInformation.YearLevel = txtYearLevel.Text;


            //verify if the student is existing
            StudentInfo student_existing = await _StudentRepository.IsStudentExists(txtLastname.Text, txtFirstname.Text, txtMiddlename.Text);

            //ask user if want to proceed
            if (MessageBox.Show("Are you sure you want to process this application?", "Online Student Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            //verify saving status
            switch (SavingStatus)
            {
                case SavingOptions.INSERT:
                    //Program detected existing student
                    if (student_existing != null)
                    {
                        MessageBox.Show("Program Detected that there was an existing student information in the database", "Duplicate Data Detected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        await _StudentRepository.InsertStudentInformation(StudentInformation);
                        MessageBox.Show("Student information has been successully saved!", "Student Information Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                        Dispose();

                        break;
                    }
                case SavingOptions.UPDATE:
                    int UpdateResult = await _StudentRepository.UpdateStudentInformation(StudentInformation);
                    if (UpdateResult > 0)
                    {
                        MessageBox.Show("Student information has been successully saved!", "Student Information Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        Close();
                        Dispose();
                    }
                    break;
                case SavingOptions.ONLINE:

                    int StudentIDResult = 0;
                    //verify the the student information is existing
                    if (student_existing.StudentID == 0)
                        //insert new student information if not existing
                        StudentIDResult = await _StudentRepository.InsertStudentInformation(StudentInformation);
                    else
                    {
                        StudentInformation.StudentID = student_existing.StudentID;
                        if (MessageBox.Show("Program Detected that this applicant is already in the database records do you want to update his/her information with the current info provided?", "Data Information Detected in Records", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            return;
                        else
                            //update student information is existing
                            StudentIDResult = await _StudentRepository.UpdateStudentInformation(StudentInformation);
                    }


                    //identify if the insert or update is sucessfull;
                    if (StudentIDResult > 0)
                    {
                        var ActiveSchoolYear = await Utilties.GetActiveSchoolYear();
                        var ActiveSemester = await Utilties.GetActiveSemester();

                        int result = await _StudentRepository.UpdateOnlineApplicantToProcessed(ApplicationID, StudentIDResult, ActiveSchoolYear.SchoolYearID, ActiveSemester.SemesterID);
                        if (result > 0)
                        {
                            MessageBox.Show("Student Information has been successfully saved and marked as processed! you can now proceed to registration", "Information Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                            Close();
                            Dispose();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtEmergencyName.Text = txtMotherName.Text;
                txtEmergencyMobile.Text = txtMotherMobile.Text;
                txtEmergencyRelation.Text = "Mother";
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
            else
            {
                txtEmergencyName.Text = "";
                txtEmergencyMobile.Text = "";
                txtEmergencyRelation.Text = "";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                txtEmergencyName.Text = txtFatherName.Text;
                txtEmergencyMobile.Text = txtFatherMobile.Text;
                txtEmergencyRelation.Text = "Father";
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
            else
            {
                txtEmergencyName.Text = "";
                txtEmergencyMobile.Text = "";
                txtEmergencyRelation.Text = "";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                txtEmergencyName.Text = txtGuardianName.Text;
                txtEmergencyMobile.Text = txtGuardianMobile.Text;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                txtEmergencyName.Text = "";
                txtEmergencyMobile.Text = "";
                txtEmergencyRelation.Text = "";
            }
        }

        private async void frm_student_information_online_entry_1_Load(object sender, EventArgs e)
        {
            LoadSuggestionProvince();
            LoadSuggestionSchools();
            LoadSuggestionSchoolAddresses();
            await LoadSchoolsandSchoolAddress();

            switch (SavingStatus)
            {
                case SavingOptions.INSERT:
                    btnProcess.Text = "Save Information";
                    break;
                case SavingOptions.UPDATE:
                    //get student information
                    btnProcess.Text = "Update Information";
                    StudentInformation = await _StudentRepository.GetStudentInformation(StudentInformation.StudentID);

                    DisplayStudentInfo();
                    break;
                case SavingOptions.ONLINE:
                    btnProcess.Text = "Process Information";
                    DisplayStudentInfoOnline();
                    break;
                default:
                    break;
            }




        }

        private void txtProvince_Leave(object sender, EventArgs e)
        {
            LoadSuggestionCities();
        }

        private void txtCity_Leave(object sender, EventArgs e)
        {
            LoadSuggestionBarangay();
        }
    }
}
