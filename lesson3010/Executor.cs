using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3010
{
    class Executor
    {
        public string name;
        public Mission Thismission
        {
            get; private set;
        }
        public string Name
        {
            get { return name; }
        }
        public Executor(string name)
        {
            this.name = name;
        }
        public static void GiveTask(List<Mission> missions, List<Executor> executors, int Deadline)
        {
            List<Mission> missions1 = new List<Mission>(missions.Count);
            missions1.AddRange(missions);
            int countermissions = 0;
            int countTasks = missions.Count;
            for (int i = 0; i < executors.Count; i++)
            {
                int counter = 0;
                for (int j = 0; j < missions1.Count; j++)
                {

                    Console.WriteLine($"вот столько задач для выбора осталось : {countTasks - countermissions - counter - 1}");
                    Console.WriteLine($"задача {countermissions + 1}");
                    missions1[j].Printim();
                    Console.WriteLine($"готов ли сотрудник {executors[i].name} выполнять ее?");
                    string input = Console.ReadLine().ToLower();
                    if (!input.Equals("нет") || j == missions1.Count - 1)
                    {
                        if (missions.Count - 1 == j)
                        {
                            Console.WriteLine("задачи закончились,вот последняя");
                        }
                        executors[i].Thismission = missions1[j];
                        executors[i].Thismission.AddMission(Deadline);
                        missions1.Remove(missions1[j]);
                        Console.WriteLine("задача передана,кайф");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        counter++;
                    }
                }
                countermissions++;
            }
        }
        public static void SendTask(Executor executor)
        {
            if (executor.Thismission != null && executor.Thismission.StatusofMission == StatusofMission.Towork)
            {
                Mission.Givecheck(executor.Thismission);
            }
        }

    }
}
