using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOProfession
    {
        public int Profession_Code { get; set; }
        public string Profession_Name { get; set; }
        public string Profession_Description { get; set; }

        public DTOProfession() { }
        public DTOProfession(int prProfession_Code, string prProfession_Name, string prProfession_Description)
        {
            this.Profession_Code = prProfession_Code;
            this.Profession_Name = prProfession_Name;
            this.Profession_Description = prProfession_Description;
        }
    }
}
