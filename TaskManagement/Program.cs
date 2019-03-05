using System;
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
            var input = Console.ReadLine();
            var task1 = new Task(input);
            task1.CrossOut();
            var task2 = task1.ReEnter();
            var input2 = Console.ReadLine();
            var task3 = new Task(input2);
            var taskList = new TaskList();
            taskList.Add(task1);
            taskList.Add(task2);
            taskList.Add(task3);
            taskList.CrossOut(1);
            taskList.ReEnter(2);


            do
            {
                Console.Clear();
                taskList.Display();
                switch (AcceptValidInt("Choose an option:\n\t1 Input new tasks\n\t2 Do a task\n\t0 Quit\n\tChoice: ", 0, 2))
                {
                    case 1:
                        taskList.Add(Console.ReadLine());
                        taskList.Display();
                        break;
                    case 2:
                        taskList.DisplayWithIndex();
                        int taskIndex = AcceptValidInt("Select which task to do : ", 0, taskList.NumberOfTasks);
                        taskList.DoTask(taskIndex);
                        break;
                    default:
                        quit = true;
                        break;
                }

                if (!quit)
                {
                    
                    taskList.Display();
                }
            } while (!quit);

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




    class TaskList : List<Task>
    {
        public int NumberOfTasks;
        private List<Task> taskList;
        public TaskList()
        {
            NumberOfTasks = 0;
            taskList = new List<Task>();
        }
        public TaskList(List<Task> readList)
        {
            taskList = readList;
            NumberOfTasks = taskList.Count;
        }
        public void Add(Task newTask)
        {
            taskList.Add(newTask);
            NumberOfTasks++;
        }
        public void Add(string newTask)
        {
            taskList.Add(new Task(newTask));
            NumberOfTasks++;
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
            taskList[n].CrossOut();
        }
        public void ReEnter(int n)
        {
            taskList.Add(taskList[n].ReEnter());
        }
        public void DoTask(int n, bool isReenter = true)
        {
            this.CrossOut(n);
            if (isReenter)
            {
                this.ReEnter(n);
            }
        }
    }

    class Task
    {
        private string Description;
        private bool isCrossedOut;
        public Task()
        {
            Description = "";
            isCrossedOut = false;
        }
        public Task(string initial)
        {
            Description = initial;
            isCrossedOut = false;
        }
        public void CrossOut()
        {
            isCrossedOut = true;
        }
        public Task ReEnter()
        {
            return new Task(Description);
        }
        public void Display()
        {
            if (isCrossedOut)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            Console.WriteLine(Description);
            Console.ResetColor();
        }
        public override string ToString()
        {
            return Description;
        }
        public void Deconstruct(out string Description)
        {
            Description = this.Description;
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
