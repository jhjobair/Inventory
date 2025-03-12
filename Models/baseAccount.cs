using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory.Models
{
    public class BaseAccount
    {

        public string Username { get; set; }
        public string Email { get; set; }
        public int Passward { get; set; }

        public bool VarifyLogin()
        {
            if (this.Username == "jobair" && this.Email == "jobair@gmail.com" && this.Passward == 123456)
            {
              return true;
            }
            return false;
        }
    }
}