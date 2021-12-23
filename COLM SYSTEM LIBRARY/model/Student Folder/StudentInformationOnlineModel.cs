﻿using COLM_SYSTEM_LIBRARY.datasource;
using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class StudentInformationOnlineModel
    {
        public int ApplicationID { get; set; }
        public string LRN { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Street { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }
        public string StudentName { get { return string.Concat(Lastname, " ", Firstname, " ", Middlename); } } //for displaying purposes only

        public string MotherName { get; set; }
        public string MotherMobile { get; set; }
        public string FatherName { get; set; }
        public string FatherMobile { get; set; }
        public string GuardianName { get; set; }
        public string GuardianMobile { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyRelation { get; set; }
        public string EmergencyMobile { get; set; }

        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolStatus { get; set; }
        public string ESCGuarantee { get; set; }

        public string StudentStatus { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public string YearLevel { get; set; }
        public DateTime ApplicationDate { get; set; }
    }


}
