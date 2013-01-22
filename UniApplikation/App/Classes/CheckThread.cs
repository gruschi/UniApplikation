using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UniApplikation.App.Classes
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
                        
            MessageBox.Show("Finished Threads!");//TODO
        }
    }
}
