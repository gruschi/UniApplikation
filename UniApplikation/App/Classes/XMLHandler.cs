using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UniApplikation.App.Classes
{   
    class XMLHandler
    {       
       // static XmlSerializer serializer;
        static FileStream stream;
        
        private IXMLList courselist;
        

        public XMLHandler()
        {

        }

        // Objekt serialisieren
        public static void SerializeObject<T>(IXMLList objCoursesList, string xmlPath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                stream = new FileStream(xmlPath, FileMode.Create);
                serializer.Serialize(stream, objCoursesList);
                stream.Close();
            }
            catch (IOException)
            {
                MessageBox.Show("Das XML File kann nicht beschrieben werden, da es von einem anderem Prozess benutzt wird",
                "Anwendungsmeldung",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
        }

        // Objekt serialisieren
        public static void SerializeObject<T>(DataTable objDataTable)
        {
            Course[] courses = new Course[objDataTable.Rows.Count];
            
            //TODO für StudentsList auch machen!
            if (objDataTable.Columns.Contains("Name") && objDataTable.Columns.Contains("Lecturer") && objDataTable.Columns.Contains("Places"))
            {
                for(int i = 0; i < objDataTable.Rows.Count; i++){
                    courses[i] = new Course(objDataTable.Rows[i]["Name"].ToString(), objDataTable.Rows[i]["Lecturer"].ToString(), Convert.ToInt32(objDataTable.Rows[i]["Places"]));
                }

                CoursesList objCourseList = new CoursesList("Kursliste");
                objCourseList.Courses = courses;

                XMLHandler.SerializeObject<T>(objCourseList, Properties.Settings.Default.CoursesXMLPath);//TODO VARIABLE!
            }

            Console.WriteLine("Keine DT!! XMLHANDLER!");
        }
        
        /// <summary>
        /// Deserializes Objects depending from the given Generic Class, should return a IXMLList Object
        /// </summary>
        /// <typeparam name="T">IXMLList Object</typeparam>
        /// <param name="sSettingsPath">Properties.Settings.Default. {X}</param>
        /// <returns>IXMLList Object</returns>
        public static T DeserializeObject<T>(string sSettingsPath)
        {
            try
            {
                XmlSerializer serializer;

                serializer = new XmlSerializer(typeof(T));
                stream = new FileStream(sSettingsPath, FileMode.Open);

                T catalog = (T)serializer.Deserialize(stream);
                //serializer.Serialize(Console.Out, catalog);
                stream.Close();

                return catalog;
            }catch(InvalidOperationException){
                stream.Close();
                Debugger.Log(1, "XML Error", "Cannot Deserialize Object...");
               
                return default(T);
            }
            
        }

        public void testSerializer(){
            CoursesList catalog = new CoursesList("Kursliste");

            Course[] courses = new Course[2];

            courses[0] = new Course("WMP1", "Prof1", 45);
            courses[1] = new Course("WMP2", "Prof3", 100);

            catalog.Courses = courses;

            XMLHandler.SerializeObject<CoursesList>(catalog, Properties.Settings.Default.CoursesXMLPath);
        }
      
    }
}
