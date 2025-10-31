using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Data
{
    internal class Hall
    {
        public int HallID { get; private set; }
        public string Name { get; private set; }
        public int TicketLimit { get; private set; }

        public Hall(int id, string name, int limit)
        {
            HallID = id;
            Name = name;
            TicketLimit = limit;
        }
    }
}
