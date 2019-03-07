using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TaskManagement
{
    public class Task
    {
        private string Description;
        public bool isCrossedOut;
        private bool isDotted;
        public static int NumTasks = 0;
        public Task()
        {
            Description = "";
            isCrossedOut = false;
            isDotted = false;
            NumTasks++;
        }
        public Task(string initial, bool CrossedOut = false, bool Dotted = false)
        {
            Description = initial;
            isCrossedOut = CrossedOut;
            isDotted = Dotted;
            NumTasks++;
        }
        public void CrossOut()
        {
            isCrossedOut = true;
        }
        public void Dot()
        {
            isDotted = true;
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
            Console.WriteLine(ToString().Trim('\u200c'));
            Console.ResetColor();
        }
        public override string ToString()
        {
            string flag = "";
            if (isCrossedOut)
            {
                flag += '\u200c';
            }
            string dot = "";
            if (isDotted)
            {
                dot += '\u00B7';
            }
            return dot+Description+flag;
        }
        public void Deconstruct(out string Description, out bool isCrossedOut, out bool isDotted)
        {
            Description = this.Description;
            isCrossedOut = this.isCrossedOut;
            isDotted = this.isDotted;
        }
    }
}