using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTORole
    {
        public int Role_Code { get; set; }
        public string Role_Name { get; set; }
        public string Role_Description{ get; set; }

        public DTORole() { }
        public DTORole(int prRole_Code, string prRole_Name, string prRole_Description)
        {
            this.Role_Code = prRole_Code;
            this.Role_Name = prRole_Name;
            this.Role_Description = prRole_Description;
        }
    }
}
