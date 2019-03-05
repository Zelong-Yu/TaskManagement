using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    class Page
    {
        public static int NumPages = 0;
        private int pageID;
        private int taskPerPage = 25;
        private TaskList taskOnPage;
        public bool PageCompleted = false;
        public Page()
        {
            NumPages++;
        }
        public Page(TaskList taskList, int startIndex=0)
        {
            NumPages++;
            int totalTaskNum = taskList.NumberTasks();
            int numOfTaskLeft = totalTaskNum - (startIndex + taskPerPage);
            if (numOfTaskLeft > 0)
            {
                taskOnPage = taskList.SplitList(taskList, startIndex, taskPerPage);
            }
            else
            {
                taskOnPage = taskList.SplitList(taskList, startIndex, totalTaskNum-startIndex);
            }
        }
    }
}
