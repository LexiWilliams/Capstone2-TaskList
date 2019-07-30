using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Capstone2_TaskList
{
    class Task
    {
        #region Fields
        private string memberName;
        private string taskDescription;
        private DateTime dueDate;
        private bool taskCompleted;
        #endregion
        #region Properties
        public string MemberName
        {
            get
            {
                return memberName;
            }
            set
            {
                memberName = value;
            }
        }
        public string TaskDescription
        {
            get
            {
                return taskDescription;
            }
            set
            {
                taskDescription = value;
            }
        }
        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }
        public bool TaskCompleted
        {
            get
            {
                return taskCompleted;
            }
            set
            {
                taskCompleted = value;
            }
        }
        #endregion
        #region Constructors
        public Task()
        {

        }
        public Task(string name, string task, DateTime date)
        {
            memberName = name;
            taskDescription = task;
            dueDate = date;
        }
        public Task(string name, string task, DateTime date, bool completion = false)
        {
            memberName = name;
            taskDescription = task;
            dueDate = date;
            taskCompleted = completion;
        }
        #endregion
        #region Methods
        public void PrintTaskInfo()
        {
            Console.WriteLine($"Team member name: {memberName}");
            Console.WriteLine($"Task Description: {taskDescription}");
            Console.WriteLine($"Due Date: {dueDate.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"This task is completed: {taskCompleted}");
            Console.WriteLine("");
        }
        public static bool ChooseTask(int taskNumber, List<Task> task)
        {
            if (taskNumber == 1)
            {
                int num = ChooseTaskList(task);
                if (num == 1)
                {
                    PrintEachItemInListVoid(task);
                    return true;
                }
                else if (num == 2)
                {
                    List<string> memberNames = MakeListMemberNames(task);
                    int indexOfMember = PrintEachMemberNameList(memberNames);
                    PrintAllMemberTasks(memberNames, task, indexOfMember);
                    return true;
                }
                else if (num == 3)
                {
                    PrintTaskByDate(task);
                    return true;
                }
                else
                {
                    Console.WriteLine("That is not a valid input");
                    Console.WriteLine("");
                    return ChooseTask(taskNumber, task);
                }
            }
            else if (taskNumber == 2)
            {
                return AddTask(task);
            }
            else if (taskNumber == 3)
            {
                return DeleteTask(task);
            }
            else if (taskNumber == 4)
            {
                return MarkComplete(task);
            }
            else if (taskNumber == 5)
            {
                Console.WriteLine("Goodbye.");
                return false;
            }
            else
            {
                return ChooseTask(taskNumber, task);
            }
        }
        public static int PrintEachItemInList(List<Task> task)
        {
            int loopNumber = 0;
            foreach (Task x in task)
            {
                loopNumber++;
                Console.WriteLine($"\t{loopNumber}:" + x.taskDescription);
            }
            Console.WriteLine("");
            return loopNumber;
        }
        public static void PrintEachItemInListVoid(List<Task> task)
        {
            int loopNumber = 0;
            foreach (Task x in task)
            {
                loopNumber++;
                Console.WriteLine($"\t{loopNumber}:" + x.TaskDescription+ ", " + x.MemberName + ", " + x.DueDate.ToString("MM/dd/yyyy") + ", " + x.TaskCompleted);
            }
            Console.WriteLine("");
        }
        public static bool AddTask(List<Task> task)
        {
            Task taskList = new Task();

            bool askAgain = true;
            while (askAgain)
            {
                Console.WriteLine("Who's task is this?");
                string name = Console.ReadLine();
                if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    taskList.memberName = name;
                    askAgain = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid name.");
                    Console.WriteLine("");
                    askAgain = true;
                }
            }
            askAgain = true;
            while (askAgain)
            {
                Console.WriteLine("What is the task description?");
                string taskDesc = Console.ReadLine();
                if (Regex.IsMatch(taskDesc, @"^[a-zA-Z]+[ ]*[a-zA-Z]*[ ]*[a-zA-Z]*$"))
                {
                    taskList.taskDescription = taskDesc;
                    askAgain = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid description.");
                    Console.WriteLine("");
                    askAgain = true;
                }
            }
            askAgain = true;
            while (askAgain)
            {
                Console.WriteLine("What is the due date?");
                string newDate = Console.ReadLine();
                if (DateTime.TryParse(newDate, out DateTime date))
                {
                    taskList.dueDate = date;
                    askAgain = false;

                }
                else
                {
                    Console.WriteLine("That is not a valid date.");
                    Console.WriteLine("");
                    askAgain = true;
                }
                Program.allTheInfo.Add(taskList);
                taskList.PrintTaskInfo();
            }
            Console.WriteLine("");
            return true;
        }
        public static bool DeleteTask(List<Task> task)
        {
            bool askAgain = true;
            while (askAgain)
            {
                Console.WriteLine("");
                Console.WriteLine("What task number would you like to delete?");
                int numOfTasks = PrintEachItemInList(task);
                string input1 = Console.ReadLine();
                if (int.TryParse(input1, out int taskToDelete))
                {
                    if (taskToDelete < numOfTasks)
                    {
                        int taskIndex = taskToDelete - 1;
                        {
                            Console.WriteLine($"You have chosen task: {task[taskIndex].taskDescription}");
                            Console.WriteLine($"Are you sure you want to delete task {taskToDelete}? y/n");
                            string input = Console.ReadLine().ToLower();
                            if (input == "y")
                            {
                                Console.WriteLine($"Task {taskToDelete} was deleted.");
                                task.Remove(task[taskIndex]);
                                Console.WriteLine("");
                                askAgain = false;
                            }
                            else if (input == "n")
                            {
                                Console.WriteLine($"Task {taskToDelete} was not deleted.");
                                Console.WriteLine("");
                                askAgain = false;
                            }
                            else
                            {
                                Console.WriteLine("That is not a valid input.");
                                Console.WriteLine("");
                                askAgain = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid task number.");
                        Console.WriteLine("");
                        askAgain = true;
                    }
                }
                else
                {
                    Console.WriteLine("That is not a valid task number.");
                    Console.WriteLine("");
                    askAgain = true;
                }
            }
            Console.WriteLine("");
            return true;
        }
        public static bool MarkComplete(List<Task> task)
        {
            bool askAgain = true;
            while (askAgain)
            {
                Console.WriteLine("What task number would you like to mark complete?");
                int numOfTasks = PrintEachItemInList(task);
                if (int.TryParse(Console.ReadLine(), out int taskToComplete))
                {
                    if (taskToComplete <= numOfTasks)
                    {
                        int taskIndex = taskToComplete - 1;
                        {
                            Console.WriteLine($"You have chosen task: {task[taskIndex].taskDescription}");
                            Console.WriteLine($"Are you sure you want to mark task {taskToComplete} complete? y/n");
                            Console.WriteLine("");
                            if (Console.ReadLine().ToLower() == "y")
                            {
                                task[taskIndex].taskCompleted = true;
                                Console.WriteLine($"Task {taskToComplete} was marked complete.");
                                task[taskIndex].PrintTaskInfo();
                                Console.WriteLine("");
                                askAgain = false;
                            }
                            else if (Console.ReadLine() == "n")
                            {
                                Console.WriteLine($"Task {taskToComplete} was not marked complete.");
                                Console.WriteLine("");
                                askAgain = false;
                            }
                            else
                            {
                                Console.WriteLine("That is not a valid input.");
                                Console.WriteLine("");
                                askAgain = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid task number.");
                        Console.WriteLine("");
                        askAgain = true;
                    }
                }
                else
                {
                    Console.WriteLine("That is not a valid task number.");
                    Console.WriteLine("");
                    askAgain = true;
                }
            }
            Console.WriteLine("");
            return true;
        }
        public static int ChooseTaskList(List<Task> task)
        {
            Console.WriteLine("Which list would you like? \n1.All tasks \n2.All tasks for one team member\n3.Tasks due by a certain date");
            Console.WriteLine("");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int num))
            {
                return num;
            }
            else
            {
                return ChooseTaskList(task);
            }

        }
        public static List<string> MakeListMemberNames(List<Task> task)
        {
            List<string> memberNames = new List<string>();
            foreach (Task x in task)
            {
                if (memberNames.Contains(x.memberName) == false)
                {
                    memberNames.Add(x.memberName);
                }
            }
            return memberNames;
        }
        public static int PrintEachMemberNameList(List<string> list)
        {
            int index = 0;
            foreach (string x in list)
            {
                index++;
                Console.WriteLine($"\tTeam member {index}: {x}");
            }
            Console.WriteLine("");
            Console.WriteLine($"Which team member would you like to list tasks for? 1-{index} ");
            Console.WriteLine("");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int indexOfMember))
            {
                if (indexOfMember <= index)
                {
                    Console.WriteLine("");
                    return indexOfMember - 1;
                }
            }
            else
            {
                return PrintEachMemberNameList(list);
            }
            return PrintEachMemberNameList(list);
        }
        public static void PrintAllMemberTasks(List<string> memberNames, List<Task> task, int indexOfMember)
        {
            foreach (Task t in task)
            {
                if (t.memberName == memberNames[indexOfMember])
                {
                    Console.WriteLine("\t" + t.taskDescription);
                }
            }
            Console.WriteLine("");
        }
        public static void PrintTaskByDate(List<Task> task)
        {
            Console.WriteLine("Enter a date (mm/dd/yyy) to see all tasks due on or before that date.");
            string input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime deadline))
            {
                foreach (Task t in task)
                {
                   int isDue = DateTime.Compare(t.dueDate, deadline);
                    if(isDue <= 0)
                    {
                        Console.WriteLine("\t" + t.taskDescription);
                    }
                }
            }
            else
            {
                Console.WriteLine("That is not a valid date.");
                Console.WriteLine("");
                PrintTaskByDate(task);
            }
            Console.WriteLine("");
        }
        #endregion
    }
}

