using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOTask
    {
        public int Task_Code { get; set; }
        public string Task_Description { get; set; }
        public int Task_Duration { get; set; }
        public string Task_Date { get; set; }
        public string Task_FileName { get; set; }

        public DTOTask() { }
        public DTOTask(int prTask_Code, string prTask_Description, int prTask_Duration, string prTask_Date,
            string prTask_FileName)
        {
            this.Task_Code = prTask_Code;
            this.Task_Description = prTask_Description;
            this.Task_Duration = prTask_Duration;
            this.Task_Date = prTask_Date;
            this.Task_FileName = prTask_FileName;
        }
    }
}
