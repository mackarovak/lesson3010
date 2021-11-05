using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3010
{
    public enum StatusofProject
    {
        TheProject=0,
        Execution,
        IsClosed
    }
    class Project
    {
        public string ProjectDescription;
        public DateTime Deadlinesforimplementation;
        public Customer Executor;
        public string name;
        public List<Mission> Projecttasks = new List<Mission>();
        public StatusofProject Status { get; private set; }
        public Project(string name, string ProjectDescription, DateTime Deadlinesforimplementation, Customer Teamleader, List<Mission> Projecttasks)
        {
            this.name = name;
            this.ProjectDescription = ProjectDescription;
            this.Deadlinesforimplementation = Deadlinesforimplementation;
            Executor = Teamleader;
            this.Projecttasks = Projecttasks;
            Status = StatusofProject.TheProject;
        }
        public void GiveProject(List<Executor> executors)
        {
            bool Projectavailability = true;
            for (int i = 0; i < executors.Count; i++)
            {
                if (executors[i] == null)
                {
                    Console.WriteLine("не круто,не у всех работничков есть проект");
                    Projectavailability = false;
                }
            }
            if (Projectavailability)
            {
                this.Status = StatusofProject.Execution;
                Console.WriteLine("шикардос,проект взяли на исполнение");
            }
        }
        public void CloseProject()
        {
            if (Status == StatusofProject.Execution && this != null)
            {
                Status = StatusofProject.IsClosed;
            }
            if (Deadlinesforimplementation >= DateTime.Now)
            {
                Console.WriteLine("ура,супер,проект сдали до/или дедллайн(а)");
            }
            else
            {
                Console.WriteLine("идем плакатц,не доделали в срок(((");
            }
        }
    }
}
