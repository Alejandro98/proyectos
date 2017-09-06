using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOGroup
    {
        public int Group_Code { get; set; }
        public string Group_Name { get; set; }
        public string Group_Phrase { get; set; }
        public string Group_Development_Fase { get; set; }

        public DTOGroup() { }
        public DTOGroup(int prGroup_Code, string prGroup_Name, string prGroup_Phrase, string prGroup_Development_Fase)
        {
            this.Group_Code = prGroup_Code;
            this.Group_Name = prGroup_Name;
            this.Group_Phrase = prGroup_Phrase;
            this.Group_Development_Fase = prGroup_Development_Fase;
        }
    }
}
