using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    public class Page
    {
        public static int NumPages = 0;
        private int pageID;
        private int taskPerPage = 25;
        private TaskList taskOnPage;
        public Page()
        {
            NumPages++;
            taskOnPage = new TaskList();
        }
        public Page(TaskList taskList, int startIndex=0)
        {
            NumPages++;
            int totalTaskNum = taskList.NumberTasks();
            int numOfTaskLeft = totalTaskNum - (startIndex + taskPerPage);
            if (numOfTaskLeft > 0)
            {
                taskOnPage = taskList.SplitList(startIndex, taskPerPage);
            }
            else
            {
                taskOnPage = taskList.SplitList(startIndex, totalTaskNum-startIndex);
                
            }
        }
        public void Display()
        {
            taskOnPage.Display();
        }
        public void DisplayWithIndex()
        {
            taskOnPage.DisplayWithIndex();
        }
        public void CrossOut(int n)
        {
            taskOnPage.CrossOut(n);
        }
        public void Dot(int n)
        {
            taskOnPage.Dot(n);
        }
        public string ExtractDescription(int n)
        {
            return taskOnPage.ExtractDescription(n);
        }
        public int NumberTasks()
        {
            return taskOnPage.NumberTasks();
        }
        public void RemoveAt(int n) //Does not work
        {
            taskOnPage.RemoveAt(n);
        }
        public bool IsPageCompleted()
        {
            return taskOnPage.IsTaskListCompleted();
        }
        public void readFromTaskList(TaskList taskList, int startIndex = 0)
        {
            NumPages++;
            int totalTaskNum = taskList.NumberTasks();
            int numOfTaskLeft = totalTaskNum - (startIndex + taskPerPage);
            if (numOfTaskLeft > 0)
            {
                taskOnPage = taskList.SplitList(startIndex, taskPerPage);
            }
            else
            {
                taskOnPage = taskList.SplitList(startIndex, totalTaskNum - startIndex);

            }
        }
    }
}
