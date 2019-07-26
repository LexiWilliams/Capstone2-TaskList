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
        private static object allTheInfo;
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
                PrintEachItemInListVoid(task);
                return true;
                
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
            return loopNumber;
        }
        public static void PrintEachItemInListVoid(List<Task> task)
        {
            int loopNumber = 0;
            foreach (Task x in task)
            {
                loopNumber++;
                Console.WriteLine($"\t{loopNumber}:" + x.taskDescription);
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
                    askAgain = true;
                }
                Program.allTheInfo.Add(taskList);
                taskList.PrintTaskInfo();
            }
            return true;
        }
        public static bool DeleteTask(List<Task> task)
        {
            bool askAgain = true;
            while (askAgain)
            {
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
                                //fix here!!!!!
                                Console.WriteLine($"Task {taskToDelete} was deleted.");
                                task.Remove(task[taskIndex]);
                                //   task[taskIndex] = new Task(); //replaces values with null value
                                // Console.WriteLine($"{ task[taskIndex].taskCompleted}+{task[taskIndex].MemberName}+{task[taskIndex].taskDescription}+{task[taskIndex].dueDate.Date}");
                                askAgain = false;
                            }
                            else if (input == "n")
                            {
                                Console.WriteLine($"Task {taskToDelete} was not deleted.");
                                askAgain = false;
                            }
                            else
                            {
                                Console.WriteLine("That is not a valid input.");
                                askAgain = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid task number.");
                        askAgain = true;
                    }
                }
                else
                {
                    Console.WriteLine("That is not a valid task number.");
                    askAgain = true;
                }
            }
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
                            if (Console.ReadLine().ToLower() == "y")
                            {
                                task[taskIndex].taskCompleted = true;
                                Console.WriteLine($"Task {taskToComplete} was marked complete.");
                                task[taskIndex].PrintTaskInfo();
                                askAgain = false;
                            }
                            else if (Console.ReadLine() == "n")
                            {
                                Console.WriteLine($"Task {taskToComplete} was not marked complete.");
                                askAgain = false;
                            }
                            else
                            {
                                Console.WriteLine("That is not a valid input.");
                                askAgain = true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid task number.");
                        askAgain = true;
                    }
                }
                else
                {
                    Console.WriteLine("That is not a valid task number.");
                    askAgain = true;
                }
            }
            return true;
        }
        #endregion


    }
}
