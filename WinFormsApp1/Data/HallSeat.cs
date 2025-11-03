using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Data
{
    internal class HallSeat
    {
        public int HallGroupID { get; private set; }
        public int ShowSeatID { get; private set; }
        public string Color { get; private set; }
        public int SeatRow { get; private set; }
        public char SeatRowLetter { get; private set; }
        public int SeatNumber { get; private set; }
        public char SeatNumberLetter { get; private set; }
        public HallSeat(int hallGroupID, int showSeatID, string color, int seatRow, char seatRowLetter, int seatNumber, char seatNumberLetter)
        {
            HallGroupID = hallGroupID;
            ShowSeatID = showSeatID;
            Color = color;
            SeatRow = seatRow;
            SeatRowLetter = seatRowLetter;
            SeatNumber = seatNumber;
            SeatNumberLetter = seatNumberLetter;
        }
        //tostring method with all the row and number, but also hallname for identification
        public string ToString(string group)
        {
            string str = new string(group + " " + SeatRow.ToString());
            if (SeatRowLetter!=' ') str += "-" + SeatRowLetter;
            str += " " +SeatNumber.ToString();
            if (SeatNumberLetter!= ' ') str += "-" + SeatNumberLetter;
            return str;
        }
    }
}
