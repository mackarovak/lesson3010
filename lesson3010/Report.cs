using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson3010
{
    class Report
    {
        public string ReportText;
        public DateTime Deadline = new DateTime();
        public Executor executor;
        public DateTime DateDelivery
        {
            get { return Deadline; }
        }
        public Report(string ReportText,Executor executor)
        {
            this.ReportText = ReportText;
            this.executor = executor;
        }
        public static Report TakeReport(Executor executor)
        {
            Console.WriteLine("Отчет сотрудника");
            string ReportText = Console.ReadLine();
            return new Report(ReportText, executor);
        }
    }
}
