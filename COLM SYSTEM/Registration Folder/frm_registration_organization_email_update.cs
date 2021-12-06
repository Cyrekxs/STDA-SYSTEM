﻿using COLM_SYSTEM_LIBRARY.Interfaces;
using COLM_SYSTEM_LIBRARY.model;
using COLM_SYSTEM_LIBRARY.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS.Registration_Folder
{
    public partial class frm_registration_organization_email_update : Form
    {
        private StudentRegistration StudentRegistration { get; }
        IStudentRepository _StudentRepository = new StudentRepository();
        IRegistrationRepository _RegistrationRepository = new RegistrationRepository();

        public frm_registration_organization_email_update(StudentRegistration StudentRegistration)
        {
            InitializeComponent();
            this.StudentRegistration = StudentRegistration;
        }

        private async void frm_registration_organization_email_update_Load(object sender, EventArgs e)
        {
            var info = await _StudentRepository.GetStudentInformation(StudentRegistration.StudentID);
            txtLRN.Text = info.LRN;
            txtStudentName.Text = info.StudentName;
            txtOrganizationEmail.Text = StudentRegistration.OrganizationEmail;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            StudentRegistration.OrganizationEmail = txtOrganizationEmail.Text;
            var result = await _RegistrationRepository.UpdateRegisteredOrganizationEmail(StudentRegistration);
            if (result > 0)
            {
                MessageBox.Show("Email has been successfully updated!", "Organization Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                Dispose();                 
            }
            else
            {
                MessageBox.Show("Unknown error detected", "Organization Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
