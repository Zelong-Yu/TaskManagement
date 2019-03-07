using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.WindowWidth,Console.LargestWindowHeight);
            bool quit = false;
            var taskList = new TaskList();
            var noteBook = new NoteBook(taskList);
            var currentPage = noteBook.GetFirstPage();

            do
            {
                Console.Clear();
                Console.WriteLine("Simple Scanning: Tasks on current page\n---------------------");
                Console.ResetColor();
                currentPage.Display();
                Console.WriteLine("---------------------\nYou have {0} pages of tasks. Will display from first page containing uncrossed out task after each action.", noteBook.TotalPageNum());
                switch (AcceptValidInt("Choose an option:\n\t1 Input new tasks\n\t2 CrossOut and Reenter a task\n\t3 Complete a task\n\t" +
                    "4 Write to file (Warning: Task file will be overwritten)\n\t5 Read From file (Warning: Inputed tasks will be overwritten)\n\t" +
                    "6 Next Page\n\t7 Trim top completed tasks\n\t0 Save and Quit\nChoice: ", 0, 7))
                {
                    case 1:
                        string input = PromptForInput("Type new task and enter (hit Enter to abort): ");
                        if (input.Trim()=="")
                        {
                            break;
                        }

                        taskList.Add(input);
                        noteBook = new NoteBook(taskList);
                        currentPage = noteBook.GetFirstUncompletedPage();
                        break;
                    case 2:
                        if (taskList.NumberTasks() == 0)
                        {
                            Console.WriteLine("No Task Entered Yet.");
                            Console.ReadKey();
                            break;
                        }
                        currentPage.DisplayWithIndex();
                        int taskIndex = AcceptValidInt("Select which task to Reenter (-1 to quit): ", -1, currentPage.NumberTasks()-1);
                        if (taskIndex == -1) break; 
                        taskList.Add(currentPage.ExtractDescription(taskIndex));
                        currentPage.CrossOut(taskIndex);
                        noteBook = new NoteBook(taskList);
                        currentPage = noteBook.GetFirstUncompletedPage();
                        break;
                    case 3:
                        if (taskList.NumberTasks() == 0)
                        {
                            Console.WriteLine("No Task Entered Yet.");
                            Console.ReadKey();
                            break;
                        }
                        currentPage.DisplayWithIndex();
                        int taskIndex3 = AcceptValidInt("Select which task to Complete (-1 to quit): ", -1, currentPage.NumberTasks()-1);
                        if (taskIndex3 == -1) break;
                        currentPage.CrossOut(taskIndex3);
                        noteBook = new NoteBook(taskList);
                        currentPage = noteBook.GetFirstUncompletedPage();
                        break;
                    case 4:
                        if (taskList.NumberTasks() == 0)
                        {
                            Console.WriteLine("No Task Entered Yet.");
                            Console.ReadKey();
                            break;
                        }
                        taskList.WriteToFile();
                        break;
                    case 5:
                        taskList.ReadFromFile();
                        if (taskList.NumberTasks() == 0)
                        {
                            Console.WriteLine("No Task Read From File");
                            Console.ReadKey();
                            break;
                        }
                        noteBook = new NoteBook(taskList);
                        currentPage = noteBook.GetFirstUncompletedPage();
                        break;
                    case 6:
                        currentPage = noteBook.GetNextPage();
                        break;
                    case 7:
                        taskList.trimTaskList();
                        noteBook = new NoteBook(taskList);
                        currentPage = noteBook.GetFirstUncompletedPage();
                        break;

                    default:
                        taskList.WriteToFile();
                        quit = true;
                        break;
                }
               
                if (!quit)
                {
                    

                }
            } while (!quit);

        }

        private static string PromptForInput(string prompt)
        {
            Console.Write(prompt);

            return Console.ReadLine();
        }

        private static int AcceptValidInt(string prompt,
                                          int minValue = int.MinValue,
                                          int maxValue = int.MaxValue)
        {
            var value = 0;
            var validInput = false;

            do
            {
                Console.Write(prompt);

                var input = Console.ReadLine();

                try
                {
                    value = int.Parse(input);

                    if ((value >= minValue) && (value <= maxValue))
                    {
                        validInput = true;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input.\n");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"{input} is not a valid value.");
                    Console.WriteLine($"Valid range is ({minValue}, {maxValue})\n");
                }
            } while (!validInput);

            return value;
        }
    }

}
