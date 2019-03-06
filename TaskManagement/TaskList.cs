using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TaskManagement
{
    class TaskList
    {
        private List<Task> taskList;
        // string path = @"C:\Users\yuzel\OneDrive\Documents\MSSA\ISTA220\TaskManagement\TaskList.txt";
        public TaskList()
        {
 
            taskList = new List<Task>();
        }
        public TaskList(List<Task> readList)
        {
            taskList = readList;
 
        }
        public TaskList SplitList(int startIndex = 0, int count = 25)
        {
            return new TaskList(taskList.GetRange(startIndex,count));
        }
        public int numPageNeeded(int numLinePerPage = 25)
        {
            return taskList.Count / numLinePerPage +1;
        }
        public int numTaskOnLastPage(int numLinePerPage = 25)
        {
            return taskList.Count % numLinePerPage;
        }
        public int NumberTasks()
        {
            return taskList.Count;
        }
        public void Add(Task newTask)
        {
            taskList.Add(newTask);

        }
        public void Add(string newTask)
        {
            taskList.Add(new Task(newTask));
 
        }
        public void Display()
        {
            foreach (var item in taskList)
            {
                item.Display();
            }
        }
        public void DisplayWithIndex()
        {
            int i = 0;
            foreach (var item in taskList)
            {
                Console.Write($"{i}. ");
                item.Display();
                i++;
            }
        }
        public void CrossOut(int n)
        {
            try
            {
                taskList[n].CrossOut();
            }
            catch (IndexOutOfRangeException ie)
            {
                Console.WriteLine("Invalid index. Task list may be empty");
            }
        }
        public void ReEnter(int n)
        {
            taskList.Add(taskList[n].ReEnter());
        }
        public void DoTask(int n, bool isReenter = true)
        {
            CrossOut(n);
            if (isReenter)
            {
                ReEnter(n);
            }
        }
        public string ExtractDescription(int n)
        {
            return taskList[n].ToString().Trim(('\u200c'));
        }
        public void RemoveAt(int n)
        {
            taskList.RemoveAt(n);
        }
        public void trimTaskList()
        {
            //Trims top completed tasks from the tasklist 
            while (taskList[0].isCrossedOut == true)
            {
                taskList.RemoveAt(0);
                trimTaskList();
            }

        }
        public bool IsTaskListCompleted()
        {
            bool istaskListCompleted = true;
            foreach (Task t in taskList)
            {
                if (!t.isCrossedOut)
                {
                    istaskListCompleted = false;
                    break;
                }
            }
            return istaskListCompleted;
        }
        public void WriteToFile()
        {
            // Create a string array with the lines of text
            string[] taskStringArray = Array.ConvertAll(taskList.ToArray(), x => x.ToString());
            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Tasks.txt")))
            {
                foreach (string line in taskStringArray)
                    outputFile.WriteLine(line);
            }
        }
        public void ReadFromFile()
        {
            List<string> fileLines = new List<string>();
            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            try
            {
                using (var r = new StreamReader(docPath + "\\Tasks.txt"))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        fileLines.Add(line);
                    }
                }
                taskList = fileLines.ConvertAll(new Converter<string, Task>(stringToTask));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}: If files does not exist, choose 4 to create a file first.",e.GetType().Name);
            }
        }

        private Task stringToTask(string input)
        {
            if (input.Contains('\u200c'))
                return new Task(input.Trim('\u200c'), true);
            else return new Task(input);
        }
    }
}