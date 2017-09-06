using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOProject
    {
        public int Project_Code { get; set; }
        public string Project_Name { get; set; }
        public string Project_Description { get; set; }

        public DTOProject() { }
        public DTOProject(int prProject_Code, string prProject_Name, string prProject_Description)
        {
            this.Project_Code = prProject_Code;
            this.Project_Name = prProject_Name;
            this.Project_Description = prProject_Description;
        }
    }
}
