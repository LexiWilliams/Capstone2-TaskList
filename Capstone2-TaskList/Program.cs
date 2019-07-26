using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone2_TaskList
{
    class Program
    {
       public static List<Task> allTheInfo = new List<Task>
            {
            new Task("Phillip","Alphabetize Files",new DateTime(2019,09,20), false),
            new Task("Angela","Print Document", new DateTime(2019, 08,01), false),
            new Task("David","Clean Computer", new DateTime(2019, 12,15), false),
            new Task("Benji","Make Coffee", new DateTime(2019,07,30), false),
            new Task("Gerard","Send Email", new DateTime(2019, 08, 12), false)
            };
        static void Main(string[] args)
        {
            bool runAgain = true;
            while (runAgain)
            {
                Console.WriteLine("Welcome to the Task Manager!");
                Console.WriteLine("");
                Methods.PrintTaskList();
                int taskNumber = Methods.GetTaskNumber();
                runAgain = Task.ChooseTask(taskNumber, allTheInfo);
            }
        }
    }
}
