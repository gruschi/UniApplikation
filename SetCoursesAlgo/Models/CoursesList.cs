using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SetCoursesAlgo.Models
{
    [XmlRoot("CoursesList")]
    public class CoursesList
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
            string sPath = Handler.sCourseXMLPath;
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

        internal Course getCourse(string p)
        {
            foreach (Course tmpCourse in this.Courses)
            {
                if (tmpCourse.Name == p)
                {
                    return tmpCourse;
                }
            }

            return new Course(p, "UNKNOWN", 1000);
        }

        /// <summary>
        /// Sets the iMaxPLaces if they arent set
        /// </summary>
        internal void repair()
        {
            foreach (Course tmpCourse in this.Courses)
            {
                if (tmpCourse.iMaxPlaces <= 0)
                {
                    tmpCourse.iMaxPlaces = tmpCourse.Places;
                }
            }

        }
    }
}
