using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathFightFrontEnd.Helpers
{
    public class UserArgs : EventArgs
    {
        public string Username { get; set; }

        public UserArgs(string username)
            : base()
        {
            this.Username = username;
        }
    }
}
