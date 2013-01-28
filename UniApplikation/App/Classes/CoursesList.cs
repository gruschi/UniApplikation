using SetCoursesAlgo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniApplikation.App.Classes
{
    [XmlRoot("CoursesList")]
    public class CoursesList : ICoursesList
    {
        [XmlElement("Listenbezeichner")]
        public string Listenname;
        [XmlArray("CoursesArray")]
        [XmlArrayItem("CourseObjekt")]
        public Course[] Courses;
        // Konstruktoren
        public CoursesList() { }

        public CoursesList(string name)
        {         
            this.Listenname = name;            
        }

        /// <summary>
        /// Returns this Class from a Deserialized XML File
        /// </summary>
        /// <returns></returns>
        public static CoursesList getListFromXML()
        {
            string sPath = Properties.Settings.Default.CoursesXMLPath;
            return XMLHandler.DeserializeObject<CoursesList>(sPath);
        }

        /// <summary>
        /// Returns a Datatable of this List
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTable()
        {
            DataTable dtCourses;

            dtCourses = new DataTable();
            dtCourses.Columns.Add("Name");
            dtCourses.Columns.Add("Lecturer");
            dtCourses.Columns.Add("Places");

            foreach (Course tmpCourse in this.Courses)
            {
                dtCourses.Rows.Add(tmpCourse.Name, tmpCourse.Lecturer, tmpCourse.Places);
            }

            return dtCourses;
        }
        
    }
}
