using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3010
{
    public enum StatusofMission
    {
        Assigned=0,
        Towork,
        Onverification,
        Completed
    }
    class Mission
    {
        public string DescriptionofMission;
        public DateTime Deadlines=new DateTime();
        public Customer customer;
        public string name;
        public StatusofMission StatusofMission { get; private set; }
        public List<Report> reports = new List<Report>();
        public DateTime DateDeadline
        {
            get { return Deadlines; }
        }
        public Mission(string name, string DescriptionofMission, Customer Teamlead)
        {
            this.DescriptionofMission = DescriptionofMission;
            customer = Teamlead;
            this.name = name;
            StatusofMission = StatusofMission.Assigned;
        }
        public void AddMission(int Deadline)
        {
            this.Deadlines = DateTime.Now.AddDays(Deadline);
            StatusofMission = StatusofMission.Towork;
        }
        public void Printim()
        {
            Console.WriteLine($"задача: {0}, описание: {1}", name, DescriptionofMission);
        }
        public static void Givecheck(Mission mission)
        {
            if (mission != null && mission.StatusofMission == StatusofMission.Towork)
            {
                mission.StatusofMission = StatusofMission.Towork;
            }
        }
    }
}
