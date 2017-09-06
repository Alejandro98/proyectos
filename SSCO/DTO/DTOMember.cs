using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOMember
    {
        public int Member_Doc { get; set; }
        public int Member_Group { get; set; }
        public string Member_Nick { get; set; }

        public DTOMember() { }
        public DTOMember(int prMember_Doc, int prMember_Group, string prMember_Nick)
        {
            this.Member_Doc = prMember_Doc;
            this.Member_Group = prMember_Group;
            this.Member_Nick = prMember_Nick;
        }
    }
}
