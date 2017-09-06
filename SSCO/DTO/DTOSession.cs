using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOSession
    {
        public long User { get; set; }
        public string Password { get; set; }

        public DTOSession() { }

        public DTOSession(long prUser, string prPassword)
        {
            this.User = prUser;
            this.Password = prPassword;
        }
    }
}
