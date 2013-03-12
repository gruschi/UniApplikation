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
        public List<Course> Courses;
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
        public static CoursesList getListFromXML(string sPath)
        {            
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

            if (this.Courses != null && this.Courses.Count > 0)
            {
                foreach (Course tmpCourse in this.Courses)
                {
                    dtCourses.Rows.Add(tmpCourse.Name, tmpCourse.Lecturer, tmpCourse.Places);
                }
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

        public static List<Course> ConvertDTtoCourseList(DataTable objDT)
        {        
            List<Course> tmpCourseList = new List<Course>();


            foreach(DataRow tmpRow in objDT.Rows){
                try
                {
                    tmpCourseList.Add(new Course(tmpRow["Name"].ToString(), tmpRow["Lecturer"].ToString(), Convert.ToInt32(tmpRow["Places"])));
                }
                catch (InvalidCastException)
                {

                }
            }

            return tmpCourseList;
        }

        public List<string> findCoursesFromStudent(string sStudentID)
        {
            List<string> objCourseList = new List<string>();

            foreach (Course tmpCourse in this.Courses)
            {
                foreach (Student tmpStudent in tmpCourse.objStudents)
                {
                    if (tmpStudent.ID == sStudentID)
                    {
                        objCourseList.Add(tmpCourse.Name);
                    }
                }
            }

            return objCourseList;
        }
    }
}
