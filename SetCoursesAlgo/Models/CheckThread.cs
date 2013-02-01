using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SetCoursesAlgo.Models
{
    class CheckThread
    {
        public void run()
        {
            List<Thread> tmpThreadList = XMLHandler.threadList;

            for(int i = 0; i < XMLHandler.threadList.Count; i++){
                while (XMLHandler.threadList[i].IsAlive != false)
                {
                    tmpThreadList.RemoveAt(i);
                    ++i;                    
                }
            }

            XMLHandler.threadList = tmpThreadList;
                        
            Logger.LogMessageToFile("Finished Threads!");//TODO
        }
    }
}
