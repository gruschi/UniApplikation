using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UniApplikation.App.Classes
{   
    class XMLHandler
    {       
       // static XmlSerializer serializer;
        static FileStream stream;

        private DataTable dtCourses;
        private CoursesList courselist;

        public XMLHandler()
        {
          //  throw new NotImplementedException();
        }

        public XMLHandler(string ListName)
        {
            this.courselist = XMLHandler.DeserializeObject();            
        }        
        
        // Objekt serialisieren
        public static void SerializeObject(CoursesList objCoursesList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CoursesList));
            stream = new FileStream(Properties.Settings.Default.CoursesXMLPath, FileMode.Create);
            serializer.Serialize(stream, objCoursesList);
            stream.Close();         
        }

        // Objekt serialisieren
        public static void SerializeObject(DataTable objDataTable)
        {
            Course[] courses = new Course[objDataTable.Rows.Count];
            
            if (objDataTable.Columns.Contains("Name") && objDataTable.Columns.Contains("Lecturer") && objDataTable.Columns.Contains("Places"))
            {
                for(int i = 0; i < objDataTable.Rows.Count; i++){
                    courses[i] = new Course(objDataTable.Rows[i]["Name"].ToString(), objDataTable.Rows[i]["Lecturer"].ToString(), Convert.ToInt32(objDataTable.Rows[i]["Places"]));
                }

                CoursesList objCourseList = new CoursesList("Kursliste");
                objCourseList.Courses = courses;

                XMLHandler.SerializeObject(objCourseList);
            }

            Console.WriteLine("Keine DT!! XMLHANDLER!");
        }

        // Objekt deserialisieren
        public static CoursesList DeserializeObject()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CoursesList));
            stream = new FileStream(Properties.Settings.Default.CoursesXMLPath, FileMode.Open);
            CoursesList catalog = (CoursesList)serializer.Deserialize(stream);
            //serializer.Serialize(Console.Out, catalog);
            stream.Close();
            return catalog;
        }

        public void testSerializer(){
            CoursesList catalog = new CoursesList("Kursliste");

            Course[] courses = new Course[2];

            courses[0] = new Course("WMP1", "Prof1", 45);
            courses[1] = new Course("WMP2", "Prof3", 100);

            catalog.Courses = courses;

            XMLHandler.SerializeObject(catalog);
        }

        internal object getDataTable()
        {


            this.dtCourses = new DataTable();
            this.dtCourses.Columns.Add("Name");
            this.dtCourses.Columns.Add("Lecturer");
            this.dtCourses.Columns.Add("Places");

            foreach (Course tmpCourse in this.courselist.Courses)
            {
                this.dtCourses.Rows.Add(tmpCourse.Name, tmpCourse.Lecturer, tmpCourse.Places);
            }

            return this.dtCourses;
        }
        
    }
}
