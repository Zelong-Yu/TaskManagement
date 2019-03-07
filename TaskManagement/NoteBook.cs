using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    public class NoteBook
    {
        private LinkedList<Page> pageList;
        private int taskPerPage = 25;
        LinkedListNode<Page> currentPageNode;
        public NoteBook()
        {
            pageList = new LinkedList<Page>();
        }
        public NoteBook(TaskList taskList)
        {
            pageList = new LinkedList<Page>();
            int numOfPageNeeded = taskList.numPageNeeded();
            int numTaskOnLastPage = taskList.numTaskOnLastPage();
            for (int i=0; i < numOfPageNeeded; i++)
            {
                pageList.AddLast(new Page(taskList, i * taskPerPage));
            }
            currentPageNode = pageList.First;
        }

        public int TotalPageNum()
        {
            return pageList.Count;
        }
        public Page GetFirstPage()
        {
            currentPageNode = pageList.First;
            return currentPageNode.Value;
        }
        public Page GetFirstUncompletedPage()
        {
            currentPageNode = pageList.First;
            while (currentPageNode.Value.IsPageCompleted())
            {
                currentPageNode = currentPageNode.Next;
            }
            return currentPageNode.Value;
        }
        public Page GetLastPage()
        {
            currentPageNode = pageList.Last;
            return currentPageNode.Value;
        }
        public Page GetNextPage()
        {
            if (currentPageNode.Next != null)
            {
                currentPageNode = currentPageNode.Next;
            }
            else
            {
                currentPageNode = pageList.First;
            }
            return currentPageNode.Value;
        }
        public Page GetPreviousPage()
        {
            if (currentPageNode.Previous != null)
            {
                currentPageNode = currentPageNode.Previous;
            }
            else
            {
                currentPageNode = pageList.Last;
            }
            return currentPageNode.Value;
        }
        public Page GetCurrentPage()
        {
            return currentPageNode.Value;
        }
        public void TrimCompletedPage()
        {
            //Trims top completed tasks from the tasklist 
            while (GetFirstPage().IsPageCompleted())
            {
                pageList.RemoveFirst();
                TrimCompletedPage();
            }
        }

    }
}
