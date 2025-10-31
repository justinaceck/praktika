using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Data
{
    internal class HallGroup
    {
        public int HallID {  get; private set; }
        public int HallGroupID { get; private set; }
        public string Name { get; private set; }
        public int AZ { get; private set; }
        public HallGroup(int hallID, int groupID, string name, int az)
        {
            HallID = hallID;
            HallGroupID = groupID;
            Name = name;
            AZ = az;
        }
    }
}
