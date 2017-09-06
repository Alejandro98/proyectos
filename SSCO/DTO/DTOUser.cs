using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOUser
    {
        public long User_Doc { get; set; }
        public string User_Name { get; set; }
        public string User_Lastname { get; set; }
        public string User_Email { get; set; }
        public string User_Cellphone { get; set; }
        public string User_Profession { get; set; }
        public string User_Role { get; set; }

        public DTOUser() { }
        public DTOUser(long prUser_Doc, string prUser_Name, string prUser_Lastname, string prUser_Email,
            string prUser_Cellphone, string prUser_Profession, string prUser_Role)
        {
            this.User_Doc = prUser_Doc;
            this.User_Name = prUser_Name;
            this.User_Lastname = prUser_Lastname;
            this.User_Email = prUser_Email;
            this.User_Cellphone = prUser_Email;
            this.User_Profession = prUser_Profession;
            this.User_Role = prUser_Role;
        }
    }
}
