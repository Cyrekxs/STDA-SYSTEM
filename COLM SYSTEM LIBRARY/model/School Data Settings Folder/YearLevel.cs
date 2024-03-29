﻿using COLM_SYSTEM_LIBRARY.datasource;
using COLM_SYSTEM_LIBRARY.helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLM_SYSTEM_LIBRARY.model
{
    public class YearLevel
    {
        public int YearLevelID { get; set; }
        public string EducationLevel { get; set; }
        public string CourseStrand { get; set; }
        public string YearLvl { get; set; }
        public int NextYearLvlID { get; set; }
        public int DepartmentID { get; set; }

        /// <summary>
        /// Get a list of yearlevels
        /// </summary>
        /// <returns></returns>
        public static List<YearLevel> GetYearLevels()
        {
            return YearLevel_DS.GetYearLevels();
        }

        /// <summary>
        /// Get available yearlevels in specific education level and course strand
        /// </summary>
        /// <param name="EducationLevel"></param>
        /// <param name="CourseStrand"></param>
        /// <returns></returns>
        public static List<YearLevel> GetYearLevels(string EducationLevel, string CourseStrand)
        {
            List<YearLevel> yearLevels = (from r in GetYearLevels()
                    where r.EducationLevel.ToLower() == EducationLevel.ToLower() && r.CourseStrand.ToLower() == CourseStrand.ToLower()
                    select r).ToList();

            return yearLevels;
        }

        /// <summary>
        /// Get a specific yearlevel by supplying education level and yearlevel string
        /// </summary>
        /// <param name="EducationLevel"></param>
        /// <param name="YearLevel"></param>
        /// <returns></returns>
        public static YearLevel GetYearLevel(string EducationLevel,string CourseStrand, string YearLevel)
        {
            return YearLevel_DS.GetYearLevel(EducationLevel,CourseStrand, YearLevel);
        }

        /// <summary>
        /// Get a specific yearlevel by supplying yearlevel id
        /// </summary>
        /// <param name="YearLevelID"></param>
        /// <returns></returns>
        public static YearLevel GetYearLevel(int YearLevelID)
        {
            return YearLevel_DS.GetYearLevel(YearLevelID);
        }

        /// <summary>
        /// Getting the yearlevels by education level by supplying education level only
        /// Connected to the database
        /// </summary>
        /// <param name="EducationLevel"></param>
        /// <returns></returns>
        public static List<YearLevel> GetYearLevelsByEducationLevel(string EducationLevel,string CourseStrand)
        {
            return (from r in YearLevel_DS.GetYearLevels()
                    where r.EducationLevel.ToLower() == EducationLevel.ToLower() && r.CourseStrand.ToLower() == CourseStrand.ToLower()
                    select r).Distinct().ToList();
        }

        /// <summary>
        /// Get the yearlevel id by supplying a list of yearlevels a specific education level and specific yearlevel
        /// Disconnected from the database
        /// </summary>
        /// <param name="yearLevels"></param>
        /// <param name="EducationLevel"></param>
        /// <param name="YearLevel"></param>
        /// <returns></returns>
        public static int GetYearLevelID(List<YearLevel> yearLevels, string EducationLevel,string YearLevel)
        {
            return (from r in yearLevels
                    where r.EducationLevel.ToLower() == EducationLevel.ToLower() && r.YearLvl.ToLower() == YearLevel.ToLower()
                    select r.YearLevelID).FirstOrDefault();
        }

        /// <summary>
        /// Getting the yearlevels by education level by supplying a list of year level and a specific education level
        /// Disconnected from the database
        /// </summary>
        /// <param name="yearLevels"></param>
        /// <param name="EducationLevel"></param>
        /// <returns></returns>
        public static List<string> GetCourseStrandByEducationLevel(string EducationLevel)
        {
            return (from r in GetYearLevels()
                    where r.EducationLevel.ToLower() == EducationLevel.ToLower()
                    select r.CourseStrand).Distinct().ToList();
        }

        public static List<string> GetCourseStrandByCurriculum(string CurriculumCode)
        {
            List<string> CourseStrands = new List<string>();
            using (SqlConnection conn = new SqlConnection(Connection.LStringConnection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand("SELECT * FROM settings.curriculum WHERE Code = @CurriculumCode", conn))
                {
                    comm.Parameters.AddWithValue("@CurriculumCode", CurriculumCode);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CourseStrands.Add(Convert.ToString(reader["CourseStrand"]));
                        }
                    }
                }
            }
            return CourseStrands;
        }
    }
}
