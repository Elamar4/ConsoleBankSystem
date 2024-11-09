using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLabTask.Models
{
    internal class Bank1
    {
        public Bank1()
        {
            users = new List<User>();
        }

        public int Id { get; set; } = 1;
        public List<User> users { get; set; }

    }
}
