using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SetCoursesAlgo.Models
{   
    public class XMLHandler
    {       
        public static List<Thread> threadList = new List<Thread>();
        public static Thread checkThread = new Thread(new ThreadStart(new CheckThread().run));

       // static XmlSerializer serializer;
        static FileStream stream;                 

        public XMLHandler()
        {

        }

        // Objekt serialisieren
        public static void SerializeObject<T>(object objList, string xmlPath)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                stream = new FileStream(xmlPath, FileMode.Create);
                serializer.Serialize(stream, objList);
                stream.Close();
            }
            catch (IOException)
            {
                Logger.LogMessageToFile("Das XML File kann nicht beschrieben werden, da es von einem anderem Prozess benutzt wird");
            }
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
                if(stream != null)
                    stream.Close();

                Debugger.Log(1, "XML Error", "Cannot Deserialize Object... Maybe no Text in File?!");
               
                return default(T);
            }
            
        }

        public void testSerializer(){
            CoursesList catalog = new CoursesList("Kursliste");

            Course[] courses = new Course[2];

            courses[0] = new Course("WMP1", "Prof1", 45);
            courses[1] = new Course("WMP2", "Prof3", 100);

          //  catalog.Courses = courses;

            XMLHandler.SerializeObject<CoursesList>(catalog, Handler.sCourseXMLPath);
        }
      
    }
}
