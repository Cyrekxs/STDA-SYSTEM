﻿using COLM_SYSTEM_LIBRARY.datasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model.Assessment_Folder
{
    public class Assessment
    {
        public AssessmentSummaryEntity Summary { get; set; }
        public List<AssessmentSubject> Subjects { get; set; }
        public List<AssessmentFee> Fees { get; set; }
        public List<AssessmentDiscount> Discounts { get; set; }
        public List<AssessmentBreakdown> Breakdown { get; set; }

        public static List<AssessmentSummaryEntity> GetAssessments(string EducationLevel = "")
        {
            return Assessment_DS.GetAssessmentLists(EducationLevel);
        }

        public static Assessment GetAssessment(int AssessmentID)
        {
            return Assessment_DS.GetAssessment(AssessmentID);
        }

        public static int InsertAssessment(Assessment entry)
        {
            return Assessment_DS.InsertAssessment(entry.Summary, entry.Subjects, entry.Fees, entry.Discounts, entry.Breakdown);
        }

        public static int DeactivateAssessment(int AssessmentID)
        {
            return Assessment_DS.DeactivateAssessment(AssessmentID);
        }

    }
}
