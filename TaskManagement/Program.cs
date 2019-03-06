using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.ConsoleUI;

namespace TaskManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            var taskList = new TaskList();
            taskList.ReadFromFile();
            var noteBook = new NoteBook(taskList);
            var currentPage = noteBook.GetFirstUncompletedPage();
            
            do
            {
                Console.Clear();
                Console.WriteLine("Simple Scanning: Tasks on current page\n---------------------");
                Console.ResetColor();
                currentPage.Display();
                Console.WriteLine("---------------------\nYou have {0} pages of tasks. Will display from first page containing uncrossed out task after each action.", noteBook.TotalPageNum());
                switch (AcceptValidInt("Choose an option:\n\t1 Input new tasks\n\t2 CrossOut and Reenter a task\n\t3 Complete a task\n\t" +
                    "4 Write to file (Warning: Task file will be overwritten)\n\t5 Read From file (Warning: Inputed tasks will be overwritten)\n\t" +
                    "6 Next Page\n\t7 Trim top completed tasks\n\t0 Save and Quit\nChoice: ", 0, 8))
                {
                    case 1:
                        taskList.Add(PromptForInput("Type new task and enter: "));
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
                        int taskIndex = AcceptValidInt("Select which task to Reenter : ", 0, currentPage.NumberTasks()-1);
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
                        int taskIndex3 = AcceptValidInt("Select which task to Complete : ", 0, currentPage.NumberTasks()-1);
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
               
                //Console.WriteLine(noteBook.TotalPageNum());
               //currentPage = noteBook.GetNextPage();
                //currentPage.DisplayWithIndex();
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




    

    
    public class ConsoleHelper
    {
        public static int MultipleChoice(bool canCancel, params string[] options)
        {
            const int startX = 0;
            const int startY = 0;
            const int optionsPerLine = 1;
            const int spacingPerLine = 14;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.Clear();

                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(options[i]);

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Length)
                                currentSelection += optionsPerLine;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection;
        }
    }
}
