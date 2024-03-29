﻿using COLM_SYSTEM.Reports_Folder;
using COLM_SYSTEM_LIBRARY.model.Reports_Folder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace COLM_SYSTEM
{
    public partial class UC_DashBoard : UserControl
    {
        List<Enrollees> enrolledCounts;
        string SelectedEducationLevel = string.Empty;
        private List<Target> targets { get; set; } = Target.GetTargets(Program.user.SchoolYearID, Program.user.SemesterID);
        public UC_DashBoard()
        {
            InitializeComponent();
            //this.ClientSize.Height / 4 - panelEnrolled.Size.Height / 4
            panelEnrolled.Location = new Point(this.ClientSize.Width / 2 - panelEnrolled.Size.Width / 2, 0);
            panelEnrolled.Anchor = AnchorStyles.None;

            //this.ClientSize.Height / 2 - panelGender.Size.Height / 2
            panelBreakdown.Location = new Point(this.ClientSize.Width / 2 - panelBreakdown.Size.Width / 2, 280);
            panelBreakdown.Anchor = AnchorStyles.None;
            LoadCharts();
        }

        private int CheckTarget(string EducationLevel)
        {
            if (targets.Count() > 0)
            {
                var result = targets.FirstOrDefault(r => r.EducationLevel.ToLower() == EducationLevel.ToLower()).TargetCount;
                if (result > 0)
                    return result;
                else
                    return 1;
            }
            else
            {
                return 1;
            }
        }

        private void LoadCharts()
        {
            try
            {
                enrolledCounts = Enrollees.GetEnrollees(Program.user.SchoolYearID, Program.user.SemesterID);

                int EnrolledPreElem = 0;
                int EnrolledElem = 0;
                int EnrolledJHS = 0;
                int EnrolledSHS = 0;
                int EnrolledCollege = 0;
                int TotalEnrolled = 0;

                int PendingPreElem = 0;
                int PendingElem = 0;
                int PendingJHS = 0;
                int PendingSHS = 0;
                int PendingCollege = 0;
                int TotalPending = 0;

                int TargetPreElem = CheckTarget("pre elementary");
                int TargetElem = CheckTarget("elementary");
                int TargetJHS = CheckTarget("junior high");
                int TargetSHS = CheckTarget("senior high");
                int TargetCollege = CheckTarget("college");

                int TargetTotal = TargetPreElem + TargetElem + TargetJHS + TargetSHS + TargetCollege;

                //enrolled charts
                EnrolledPreElem = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Pre Elementary" && r.EnrollmentStatus == "Enrolled").Sum(r => r.ResultCount));
                EnrolledElem = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Elementary" && r.EnrollmentStatus == "Enrolled").Sum(r => r.ResultCount));
                EnrolledJHS = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Junior High" && r.EnrollmentStatus == "Enrolled").Sum(r => r.ResultCount));
                EnrolledSHS = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Senior High" && r.EnrollmentStatus == "Enrolled").Sum(r => r.ResultCount));
                EnrolledCollege = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "College" && r.EnrollmentStatus == "Enrolled").Sum(r => r.ResultCount));
                TotalEnrolled = EnrolledPreElem + EnrolledElem + EnrolledJHS + EnrolledSHS + EnrolledCollege;

                //pendings charts
                PendingPreElem = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Pre Elementary" && r.EnrollmentStatus == "Not Enrolled").Sum(r => r.ResultCount));
                PendingElem = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Elementary" && r.EnrollmentStatus == "Not Enrolled").Sum(r => r.ResultCount));
                PendingJHS = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Junior High" && r.EnrollmentStatus == "Not Enrolled").Sum(r => r.ResultCount));
                PendingSHS = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "Senior High" && r.EnrollmentStatus == "Not Enrolled").Sum(r => r.ResultCount));
                PendingCollege = Convert.ToInt16(enrolledCounts.Where(r => r.EducationLevel == "College" && r.EnrollmentStatus == "Not Enrolled").Sum(r => r.ResultCount));
                TotalPending = PendingPreElem + PendingElem + PendingJHS + PendingSHS + PendingCollege;


                TargetPreElem = (EnrolledPreElem / TargetPreElem) * 100;
                TargetElem = (EnrolledElem / TargetElem) * 100;
                TargetJHS = (EnrolledJHS / TargetJHS) * 100;
                TargetSHS = (EnrolledSHS / TargetSHS) * 100;
                TargetCollege = (EnrolledCollege / TargetCollege) * 100;


                //display enrolled charts
                lblEnrolledPreElementary.Text = EnrolledPreElem.ToString();
                lblEnrolledElementary.Text = EnrolledElem.ToString();
                lblEnrolledJHS.Text = EnrolledJHS.ToString();
                lblEnrolledSHS.Text = EnrolledSHS.ToString();
                lblEnrolledCollege.Text = EnrolledCollege.ToString();


                //dispaly pendings charts
                lblPendingPreElementary.Text = PendingPreElem.ToString();
                lblPendingElementary.Text = PendingElem.ToString();
                lblPendingJHS.Text = PendingJHS.ToString();
                lblPendingSHS.Text = PendingSHS.ToString();
                lblPendingCollege.Text = PendingCollege.ToString();


                //display target
                lblTargetPreElem.Text = TargetPreElem.ToString("0.##") + "%";
                lblTargetElem.Text = TargetElem.ToString("0.##") + "%";
                lblTargetJHS.Text = TargetJHS.ToString("0.##") + "%";
                lblTargetSHS.Text = TargetSHS.ToString("0.##") + "%";
                lblTargetCollege.Text = TargetCollege.ToString("0.##") + "%";


                //double TotalStudents = TotalEnrolled + TotalPending;
                lblTotalEnrolled.Text = TotalEnrolled.ToString();
                lblTotalPending.Text = TotalPending.ToString();
                lblTotalTarget.Text = TargetTotal.ToString();
                double TotalPendingPercent = 0;// (TotalPending / TargetTotal) * 100;
                double TotalEnrolledPercent = 0;// (TotalEnrolled / TargetTotal) * 100;
                double TotalTargetPercent = 100 - (TotalEnrolledPercent);

                TotalPendingPercent = Math.Round(TotalPendingPercent, MidpointRounding.AwayFromZero);
                TotalEnrolledPercent = Math.Round(TotalEnrolledPercent, MidpointRounding.AwayFromZero);
                TotalTargetPercent = Math.Round(TotalTargetPercent, MidpointRounding.AwayFromZero);

                //target
                chartEnrolled.Series["s1"].Points.AddXY(string.Concat("Target", Environment.NewLine, TotalTargetPercent.ToString("0.##"), "%"), TargetTotal / 3);
                int chartpoint = chartEnrolled.Series["s1"].Points.Count - 1;
                chartEnrolled.Series["s1"].Points[chartpoint].LabelForeColor = Color.Black;
                chartEnrolled.Series["s1"].Points[chartpoint].Color = Color.Gainsboro;

                //enrolled
                chartEnrolled.Series["s1"].Points.AddXY(string.Concat("Enrolled", Environment.NewLine, TotalEnrolledPercent.ToString("0.##"), "%"), TotalEnrolled);
                chartpoint = chartEnrolled.Series["s1"].Points.Count - 1;
                chartEnrolled.Series["s1"].Points[chartpoint].LabelForeColor = Color.White;
                chartEnrolled.Series["s1"].Points[chartpoint].Color = Color.DarkSlateGray;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void LoadChartBreakdown(string EducationLevel)
        {
            try
            {
                List<Enrollees> enrollees = Enrollees.GetEnrollees(Program.user.SchoolYearID,Program.user.SemesterID);

                enrollees = enrollees.Where(model => model.EducationLevel.ToLower() == EducationLevel.ToLower()).ToList();

                List<string> Departments = enrolledCounts.Where(r =>r.EducationLevel == "College").Select(r => r.DepartmentCode).Distinct().ToList();
                List<string> CourseStrands = enrollees.Select(r => r.CourseStrand).Distinct().ToList();
                List<string> YearLevels = enrollees.Select(r => r.YearLevel).Distinct().ToList();

                chart1.Series["Enrolled"].Points.Clear();
                chart1.Series["Pending"].Points.Clear();

                int s1 = 0;
                switch (EducationLevel)
                {
                    case "College":

                        foreach (var dept in Departments)
                        {
                            int EnrolledCount = enrollees.Where(r => r.DepartmentCode == dept && r.EnrollmentStatus.ToLower() == "enrolled").Sum(r => r.ResultCount);
                            int PendingCount = enrollees.Where(r => r.DepartmentCode == dept && r.EnrollmentStatus.ToLower() == "not enrolled").Sum(r => r.ResultCount);

                            chart1.Series["Enrolled"].Points.AddXY(dept, EnrolledCount);
                            chart1.Series["Enrolled"].Points[s1].Tag = dept;

                            chart1.Series["Pending"].Points.AddXY(dept, PendingCount);
                            chart1.Series["Pending"].Points[s1].Tag = dept;
                            s1++;
                        }
                        break;
                    default:
                        
                        foreach (var cs in CourseStrands)
                        {
                            foreach (var yl in YearLevels)
                            {
                                int EnrolledCount = enrollees.Where(r => r.CourseStrand == cs && r.YearLevel == yl && r.EnrollmentStatus.ToLower() == "enrolled").Select(r => r.ResultCount).FirstOrDefault();
                                int PendingCount = enrollees.Where(r => r.CourseStrand == cs && r.YearLevel == yl && r.EnrollmentStatus.ToLower() == "not enrolled").Select(r => r.ResultCount).FirstOrDefault();

                                string pname = string.Empty;
                                if (cs.ToLower() == "junior high" || cs.ToLower() == "elementary" || cs.ToLower() == "pre elementary")
                                    pname = yl;
                                else
                                    pname = string.Concat(cs, " ", yl.Replace("Year", ""));


                                chart1.Series["Enrolled"].Points.AddXY(pname, EnrolledCount);
                                chart1.Series["Enrolled"].Points[s1].Tag = cs;


                                chart1.Series["Pending"].Points.AddXY(pname, PendingCount);
                                chart1.Series["Pending"].Points[s1].Tag = yl;
                                s1++;
                            }
                        }
                        break;
                }                            
            }
            catch
            {

            }
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult hit = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            if (hit.PointIndex >= 0 && hit.Series != null)
            {
                DataPoint enrolled = chart1.Series["Enrolled"].Points[hit.PointIndex];
                DataPoint pending = chart1.Series["Pending"].Points[hit.PointIndex];
                switch (SelectedEducationLevel)
                {
                    case "College":

                        List<Enrollees> enrollees = Enrollees.GetEnrollees(Program.user.SchoolYearID,Program.user.SemesterID);

                        enrollees = enrollees.Where(model => model.EducationLevel.ToLower() == "college" && model.DepartmentCode == enrolled.Tag.ToString()).ToList();

                        List<string> CourseStrands = enrollees.Where(r=> r.DepartmentCode == enrolled.Tag.ToString()).Select(r => r.CourseStrand).Distinct().ToList();
                        List<string> YearLevels = enrollees.Select(r => r.YearLevel).Distinct().ToList();

                        chart1.Series["Enrolled"].Points.Clear();
                        chart1.Series["Pending"].Points.Clear();

                        int s1 = 0;
                        foreach (var cs in CourseStrands)
                        {
                            foreach (var yl in YearLevels)
                            {
                                int EnrolledCount = enrollees.Where(r => r.CourseStrand == cs && r.YearLevel == yl && r.EnrollmentStatus.ToLower() == "enrolled").Select(r => r.ResultCount).FirstOrDefault();
                                int PendingCount = enrollees.Where(r => r.CourseStrand == cs && r.YearLevel == yl && r.EnrollmentStatus.ToLower() == "not enrolled").Select(r => r.ResultCount).FirstOrDefault();

                                string pname = string.Empty;
                                if (cs.ToLower() == "junior high" || cs.ToLower() == "elementary" || cs.ToLower() == "pre elementary")
                                    pname = yl;
                                else
                                    pname = string.Concat(cs, " ", yl.Replace("Year", ""));


                                chart1.Series["Enrolled"].Points.AddXY(pname, EnrolledCount);
                                chart1.Series["Enrolled"].Points[s1].Tag = cs;


                                chart1.Series["Pending"].Points.AddXY(pname, PendingCount);
                                chart1.Series["Pending"].Points[s1].Tag = yl;
                                s1++;
                            }
                        }

                        lblActive.Text = string.Concat("College", " ", enrolled.Tag.ToString());
                        //reset selected education level to do not satisfy the switch condition in case "college"
                        SelectedEducationLevel = string.Empty;
                        break;

                    case "" :
                        frm_enrollees_masterlist frm = new frm_enrollees_masterlist("College", enrolled.Tag.ToString(), pending.Tag.ToString());
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                        break;

                    default:
                        frm = new frm_enrollees_masterlist(SelectedEducationLevel, enrolled.Tag.ToString(), pending.Tag.ToString());
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                        break;
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lblActive.Text = "Pre Elementary";
            LoadChartBreakdown("Pre Elementary");
            SelectedEducationLevel = "Pre Elementary";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            lblActive.Text = "Elementary";
            LoadChartBreakdown("Elementary");
            SelectedEducationLevel = "Elementary";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            lblActive.Text = "Junior High";
            LoadChartBreakdown("Junior High");
            SelectedEducationLevel = "Junior High";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            lblActive.Text = "Senior High";
            LoadChartBreakdown("Senior High");
            SelectedEducationLevel = "Senior High";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            lblActive.Text = "College";
            LoadChartBreakdown("College");
            SelectedEducationLevel = "College";
        }
    }
}
