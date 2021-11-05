using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3010
{
    class Program
    {
        static void Shuffle(ref List <Executor> indices)
        {
            Random random = new Random();
            for (int i = indices.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = indices[j];
                indices[j] = indices[i];
                indices[i] = temp;
            }
        }
        static void Main(string[] args)
        {
            Customer TeamLead = new Customer("Фара Даулинг");
            Console.WriteLine("На сколько рассчитана задача?");
            int DeadLine;
            while (!int.TryParse(Console.ReadLine(), out DeadLine) || DeadLine < 0)
            {
                Console.WriteLine("Ты вводишь что-то не то");
            }
            DateTime date = DateTime.Now.AddDays(DeadLine);
            Console.Clear();
            int countexecutors = 10;
            int countmissions = 10;
            List <Executor> executors = new List <Executor> (countexecutors);
            executors.Add(new Executor("Блум"));
            executors.Add(new Executor("Стелла"));
            executors.Add(new Executor("Флора"));
            executors.Add(new Executor("Муза"));
            executors.Add(new Executor("Текна"));
            executors.Add(new Executor("Ривен"));
            executors.Add(new Executor("Скай"));
            executors.Add(new Executor("Брендон"));
            executors.Add(new Executor("Гелия"));
            executors.Add(new Executor("Тимми"));
            Shuffle(ref executors);
            List<Mission> missions = new List<Mission>(countmissions);
            missions.Add(new Mission("Валтор", "Победить Валтора", TeamLead));
            missions.Add(new Mission("Трикс", "Победить Трикс", TeamLead));
            missions.Add(new Mission("Тританнус", "Победить Тританнуса", TeamLead));
            missions.Add(new Mission("Черный круг", "Победить магов Черного круга", TeamLead));
            missions.Add(new Mission("Диаспро", "Победить Диаспро", TeamLead));
            missions.Add(new Mission("Древние ведьмы", "Победить Древних ведьм", TeamLead));
            missions.Add(new Mission("Охотники на фей", "Победить охотников на фей", TeamLead));
            missions.Add(new Mission("Касандра и Химера", "Победить Касандру и Химеру", TeamLead));
            missions.Add(new Mission("Даркар", "Победить Даркара", TeamLead));
            missions.Add(new Mission("Митси", "Победить Митси", TeamLead));
            Project project = new Project("Миссия", "Победить врага", date, TeamLead, missions);
            if (project.Status.Equals(StatusofProject.TheProject))
            {
                project.GiveProject(executors);
                Executor.GiveTask(missions, executors, DeadLine);
                {
                    string letter = "все задачи переданы";
                    Console.WriteLine(letter);
                }
            }
            while (executors.Count > 0)
            {
                Console.WriteLine("номер сотрудника,которому надо сдать отчет");

                for (int i = 0; i < executors.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {executors[i].name}");
                }
                int tmp;
                while (!int.TryParse(Console.ReadLine(), out tmp) || tmp < 1 || tmp > executors.Count)
                {
                    Console.WriteLine("ты что-то делаешь не так");
                }
                Report report = Report.TakeReport(executors[tmp - 1]);
                Executor.SendTask(executors[tmp - 1]);
                Console.WriteLine("проверка прошла успешна?");
                bool input = Console.ReadLine().ToLower().Equals("да");
                if (input)
                {
                    Console.WriteLine("работчничек супер крутой,все сдал");
                    executors.Remove(executors[tmp - 1]);
                    report = null;
                }
                else
                {
                    Console.WriteLine("доработочка,чек");
                    report = null;
                }
            }
            project.CloseProject();
        }
    }
}
