using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnityApp6.Repositories
{
    public class MyTasks
    {


        public static List<MyTask> GetAllTasks()
        {
            List<MyTask> fooTasks = new List<MyTask>();
            for (int i = 0; i < 50; i++)
            {
                var fooAtask = new MyTask
                {
                    Name = "Task Name " + i.ToString(),
                    Status = "Status " + (i % 3).ToString(),
                    Date = DateTime.Now,
                };
                fooTasks.Add(fooAtask);
            }
            return fooTasks;
        }
    }

    public class MyTask
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }

}
