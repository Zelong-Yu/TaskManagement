Simple Scanning and FVP Task Management Console App
===============================================
### Zelong Yu

[Cosole App Github folder](https://github.com/himoyu/TaskManagement)

[Web version of Simple Scanning App](https://github.com/himoyu/TaskManagementWeb)

[**Simple Scanning** original documentation by _Mark Foster_](http://markforster.squarespace.com/blog/2017/12/2/simple-scanning-the-rules.html)
![Alt text](SampleFiles/SimpleScanning.gif?raw=true "SimpleScanning")





[**FVP** Original documentation by _Mark Foster_](http://markforster.squarespace.com/blog/2015/5/21/the-final-version-perfected-fvp.html)
![Alt text](SampleFiles/FVP.gif?raw=true "FVP")

Introduction
------------
**Simple Scanning** is an intuitive yet powerful task management method to finish a _long list_ of tasks. The aim is to write (add) everything down that you
have to do, want to do or think you might do **without** any attempt to categorise, prioritise or emphasise any particular task in any
way. When start working, scan down the list and start working on any one task you want to work on as long as you like. If it is not finished,
cross out the original and reenter the task to the end of the list. If it is completed, simply cross it out for good. 

As time goes by, lingering uncompleted task will simply start to _stand out_ among completed tasks. Time to rethink/ reevaluate the task if 
it lingers too long. 

For suggestions refer to [**Simple Scanning** original documentation by _Mark Foster_](http://markforster.squarespace.com/blog/2017/12/2/simple-scanning-the-rules.html)


**FVP(The Final Version Profected)** is a similar but slight different task management method bases on the question _“What do I want to do more than x?_
Instrution from _Mark Foster_

>The chain always starts with the first unactioned task on the list. Mark this task with a dot to show that it’s now been preselected. Don’t take any action on the task at this stage.This task then becomes the benchmark from which the next task is selected. For example, if the first task on the list is “Write Report”, the question becomes “What do I want to do more than write the report?” You move through the list in order until you come to a task which you want to do more than write the report. This task is now selected by marking it with a dot and it becomes the benchmark for the next task. If the first task you come to which you want to do before writing the report is “Check Email”, then that becomes the benchmark. The question therefore changes to “What do I want to do more than check email?”As you continue through the list you might come to “Tidy Desk” and decide you want to do that more than checking email. Select this in the same way by marking it with a dot, and change the question to “What do I want to do more than tidying my desk?”. The answer to this is probably “nothing”, so you have now finished your preselection.The preselected tasks in the example are:

>>Write report

>>Check email

>>Tidy desk

>At this point “Tidy Desk” represents the task you most want to do at the moment. Do it.
>Note that as in all my systems, you don’t have to finish the task - only do some work on it. Of course if you do finish the task that’s great, but if you don’t then all you have to do is re-enter the task at the end of the list.

>Now what are you going to do next? “Check email” is the previous task you selected, but that isn’t necessarily the task you most want to do. What you can say though is that it was the task you most wanted to do up until you selected “Tidy Desk”. This means that you only need to check the tasks that come after “Tidy Desk” in the list.

>So what you do next is to ask yourself “What do I want to do more than check email?” again, but you check only the tasks which come after the task you have just done (Tidy Desk).

>Once you have worked your way back to the first task on the list and done it (this may never happen!), you take the next unactioned task as your root task.

>That’s it! You’re now ready to go. Everything else is further examples and explanation.

For longer example refer to [**FVP** Original documentation by _Mark Foster_](http://markforster.squarespace.com/blog/2015/5/21/the-final-version-perfected-fvp.html)



Installation
------------
1. Clone/Download the git folder to a local directory.
2. **Simple Scanning** console app source code is in `TaskManagement/TaskManagement` folder. Compile and run `TaskManagement.exe`. 

A sample list of 
tasks is in SampleFiles folder as `Tasks.txt`. If user put it in the same folder of `TaskManagement.exe` the program will load it automatically. 
Otherwise user can create a task list and save.

3. **FVP** console app source code is in `TaskManagement/FVP` folder. Compile and run `FVP.exe`. Notice that FVP app relies on the same class files in
`TaskManagement/TaskManagement` folder so make sure to unzip the entire file tree when compiling.

A sample FVP list of tasks is in SampleFiles folder as `FVPList.txt`. If user put it in the same folder of `FVP.exe` and the program will load it automatically. 
Otherwise user can create a task list and save.



**Simple Scanning** Use
-----
 `TaskManagement.exe` :
If `Tasks.txt` is present, the program will load and start display with _first page containing incomplete(uncrossed out)_ tasks.\
_Crossed out_ tasks will display in _DarkGray_ while incomplete task in _Gray_.

Menu is inuitive. Noted that if user choose `4 Write to file` or `0 Save and Quit`, `Tasks.txt` will be created if it does not exist or overwriiten if exists.

`7 Trim top completed tasks` will remove all the completed tasks before first incomplete task.

`6 Next Page` will bring you back to 1st page if you reached last page.

>Choose an option:
>
>        1 Input new tasks
>
>        2 CrossOut and Reenter a task
>
>        3 Complete a task
>
>        4 Write to file (Warning: Task file will be overwritten)
>
>        5 Read From file (Warning: Inputed tasks will be overwritten)
>
>        6 Next Page
>
>        7 Trim top completed tasks
>
>        0 Save and Quit

**FVP** Use
-----
`FPV.exe`: If `FVPList.txt` is present, the program will load and start display with _first page containing incomplete(uncrossed out)_ tasks.\
_Crossed out_ tasks will display in _DarkGray_ while incomplete task in _Gray_.

Menu is inuitive. Noted that if user choose `5 Write to file` or `0 Save and Quit`, `Tasks.txt` will be created if it does not exist or overwriiten if exists.

`8 Trim top completed tasks` will remove all the completed tasks before first incomplete task.

`7 Next Page` will bring you back to 1st page if you reached last page.

>Choose an option:
>
>        1 Input new tasks
>
>        2 Dot a task
>
>        3 CrossOut and Reenter a task
>
>        4 Complete a task
>
>        5 Write to file (Warning: Task file will be overwritten)
>
>        6 Read From file (Warning: Inputed tasks will be overwritten)
>
>        7 Next Page
>
>        8 Trim top completed tasks
>
>        0 Save and Quit

References
----------
* [**Simple Scanning** original documentation by _Mark Foster_](http://markforster.squarespace.com/blog/2017/12/2/simple-scanning-the-rules.html)

* [**FVP** Original documentation by _Mark Foster_](http://markforster.squarespace.com/blog/2015/5/21/the-final-version-perfected-fvp.html)


