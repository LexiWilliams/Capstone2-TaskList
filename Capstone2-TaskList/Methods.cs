using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone2_TaskList
{
    class Methods
    {
        public static void PrintTaskList()
        {
            Console.WriteLine("1.List Tasks\n2.Add Task\n3.Delete Task\n4.Mark Task Complete\n5.Quit\n");
        }

        public static int GetTaskNumber()
        {
            Console.WriteLine("What would you like to do?");
            if (int.TryParse(Console.ReadLine(), out int taskNumber))
            {
                if (taskNumber == 1 || taskNumber == 2 || taskNumber == 3 || taskNumber == 4 || taskNumber == 5)
                {
                    return taskNumber;
                }
                else
                {
                    Console.WriteLine("That isn't an option.");
                    PrintTaskList();
                    return GetTaskNumber();
                }
            }
            else
            {
                Console.WriteLine("That isn't an option.");
                PrintTaskList();
                return GetTaskNumber();
            }
        }

      
    }
}
