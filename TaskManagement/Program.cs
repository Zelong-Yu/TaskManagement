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
            /*var input = Console.ReadLine();
             var task1 = new Task(input);
             task1.CrossOut();
            var task2 = task1.ReEnter();
             var input2 = Console.ReadLine();
             var task3 = new Task(input2);

             taskList.Add(task1);
             taskList.Add(task2);
             taskList.Add(task3);
             taskList.CrossOut(1);
             taskList.ReEnter(2);
            Console.WriteLine(task1.ToString());
            Console.WriteLine(taskList.taskList[0].ToString());
            foreach (Task task in taskList.taskList)
              { Console.WriteLine(task.ToString()); }*/

            
            do
            {
                Console.Clear();
                taskList.Display();
                switch (AcceptValidInt("Choose an option:\n\t1 Input new tasks\n\t2 CrossOut and Reenter a task\n\t3 Complete a task\n\t4 Write to file\n\t5 Read From file\n\t6 Split List0 Quit\nChoice: ", 0, 6))
                {
                    case 1:
                        taskList.Add(PromptForInput("Type new task and enter: "));
                        break;
                    case 2:
                        taskList.DisplayWithIndex();
                        int taskIndex = AcceptValidInt("Select which task to Reenter : ", 0, taskList.NumberTasks());
                        taskList.DoTask(taskIndex);
                        break;
                    case 3:
                        taskList.DisplayWithIndex();
                        int taskIndex3 = AcceptValidInt("Select which task to Complete : ", 0, taskList.NumberTasks());
                        taskList.DoTask(taskIndex3,false);
                        break;
                    case 4:
                        taskList.WriteToFile();
                        break;
                    case 5:
                        taskList.ReadFromFile();
                        break;
                    case 6:
                        taskList = taskList.SplitList(taskList,10);
                        break;
                    default:
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
