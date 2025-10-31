using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DevExpress.Office.Utils;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using WinFormsApp1.Data;

namespace WinFormsApp1.Database
{
    internal class HallSeatCalls
    {
        private static SqlConnection myConnection = new SqlConnection(
    @$"Server=NET155\MSSQLSERVER, 1433;" +
    $"Database=Sale;" +
    $"User Id=Terra ERP;" +
    $"Password=numKvA1s7vGl;" +
    $"TrustServerCertificate=True;" +
    $"Connect Timeout=30;" +
            $"MultipleActiveResultSets=true");
        //Inicializuoja duomenų bazės sujungimą
        internal static void ConnectToDB()
        {
            try
            {
                myConnection.Open();
                Debug.WriteLine("Open");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed: ", ex.ToString());
            }
        }
        //Įkelia HallSeat parametrus į duomenų bazę
        internal static void InsertHallSeat(XmlNode seat)
        {
            SqlCommand seatcommand = new SqlCommand("InsertHallSeat", myConnection);
            seatcommand.CommandType = System.Data.CommandType.StoredProcedure;
            seatcommand.Parameters.Add("@HallGroupID", System.Data.SqlDbType.Int);
            seatcommand.Parameters["@HallGroupID"].Value = Convert.ToInt32(seat.ChildNodes[0].InnerText);
            seatcommand.Parameters.Add("@Color", System.Data.SqlDbType.VarChar, 50);
            seatcommand.Parameters["@Color"].Value = seat.ChildNodes[2].InnerText;
            seatcommand.Parameters.Add("@Price", System.Data.SqlDbType.Real);
            seatcommand.Parameters["@Price"].Value = Convert.ToDouble(seat.ChildNodes[3].InnerText);
            seatcommand.Parameters.Add("@SeatRow", System.Data.SqlDbType.Int);
            seatcommand.Parameters["@SeatRow"].Value = Convert.ToInt32(seat.ChildNodes[4].InnerText);
            seatcommand.Parameters.Add("@SeatRowLetter", System.Data.SqlDbType.VarChar, 1);
            seatcommand.Parameters["@SeatRowLetter"].Value = seat.ChildNodes[5].InnerText;
            seatcommand.Parameters.Add("@SeatNumber", System.Data.SqlDbType.Int);
            seatcommand.Parameters["@SeatNumber"].Value = Convert.ToInt32(seat.ChildNodes[6].InnerText);
            seatcommand.Parameters.Add("@SeatNumberLetter", System.Data.SqlDbType.VarChar, 1);
            seatcommand.Parameters["@SeatNumberLetter"].Value = seat.ChildNodes[7].InnerText;
            seatcommand.ExecuteNonQuery();
        }
        internal static void InsertHallSeat(int hallgroupid, double price, int seatrow, char seatrowletter, int seatnumber, char seatnumberletter)
        {
            SqlCommand seatcommand = new SqlCommand("InsertHallSeat", myConnection);
            seatcommand.CommandType = System.Data.CommandType.StoredProcedure;
            seatcommand.Parameters.Add("@HallGroupID", System.Data.SqlDbType.Int);
            seatcommand.Parameters["@HallGroupID"].Value = hallgroupid;
            seatcommand.Parameters.Add("@Color", System.Data.SqlDbType.VarChar, 50);
            seatcommand.Parameters["@Color"].Value = " ";//to be set when i figure out the color stuff
            seatcommand.Parameters.Add("@Price", System.Data.SqlDbType.Real);
            seatcommand.Parameters["@Price"].Value = price;
            seatcommand.Parameters.Add("@SeatRow", System.Data.SqlDbType.Int);
            seatcommand.Parameters["@SeatRow"].Value = seatrow;
            seatcommand.Parameters.Add("@SeatRowLetter", System.Data.SqlDbType.VarChar, 1);
            seatcommand.Parameters["@SeatRowLetter"].Value = seatrowletter;
            seatcommand.Parameters.Add("@SeatNumber", System.Data.SqlDbType.Int);
            seatcommand.Parameters["@SeatNumber"].Value = seatnumber;
            seatcommand.Parameters.Add("@SeatNumberLetter", System.Data.SqlDbType.VarChar, 1);
            seatcommand.Parameters["@SeatNumberLetter"].Value = seatnumberletter;
            seatcommand.ExecuteNonQuery();
        }
        //Iš duomenų bazės paima HallSeat ir grąžina jų sąrašą
        internal static BindingList<HallSeat> GetSeatsB(int hallgroupid, bool reserved, int eventid)
        {
            SqlCommand select = new SqlCommand("GetSeatsByGroup", myConnection);
            select.CommandType = System.Data.CommandType.StoredProcedure;
            select.Parameters.Add("@HallGroupID", System.Data.SqlDbType.Int);
            select.Parameters["@HallGroupID"].Value = hallgroupid;
            IAsyncResult result = select.BeginExecuteReader();
            int count = 0;
            while (!result.IsCompleted)
            {
                count += 1;
                Debug.WriteLine("Waiting ({0})", count);
            }

            using (SqlDataReader reader = select.EndExecuteReader(result))
            {
                return ParseReadSeatsB(reader, hallgroupid, reserved, eventid);
            }
        }
        internal static List<HallSeat> GetSeats(int hallgroupid, bool reserved, int eventid)
        {
            SqlCommand select = new SqlCommand("GetSeatsByGroup", myConnection);
            select.CommandType = System.Data.CommandType.StoredProcedure;
            select.Parameters.Add("@HallGroupID", System.Data.SqlDbType.Int);
            select.Parameters["@HallGroupID"].Value = hallgroupid;
            IAsyncResult result = select.BeginExecuteReader();
            int count = 0;
            while (!result.IsCompleted)
            {
                count += 1;
                Debug.WriteLine("Waiting ({0})", count);
            }

            using (SqlDataReader reader = select.EndExecuteReader(result))
            {
                return ParseReadSeats(reader, hallgroupid, reserved, eventid);
            }
        }
        internal static List<string> GetSeats(bool reserved, int eventid)
        {
            List < string > seats = new List<string>();
                SqlCommand select = new SqlCommand("GetSeats", myConnection);
            select.CommandType = System.Data.CommandType.StoredProcedure;
            select.Parameters.Add("@eventid", System.Data.SqlDbType.Int);
                select.Parameters["@eventid"].Value = eventid;
                IAsyncResult result = select.BeginExecuteReader();
                int count = 0;
                while (!result.IsCompleted)
                {
                    count += 1;
                    Debug.WriteLine("Waiting ({0})", count);
                }

                using (SqlDataReader reader = select.EndExecuteReader(result))
                {
                return ParseReadSeats(reader, reserved, eventid);
                }
        }
        //Padedančioji funkcija, kuri paima nuskaitytą duomenų bazės informaciją ir ją paverčia į HallSeat struktūros listą
        private static List<HallSeat> ParseReadSeats(SqlDataReader reader, int hallgroupid, bool reserved, int eventid)
        {
            List<HallSeat> seats = new List<HallSeat>();
            // Display the data within the reader.
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader.GetValue(1));
                if (reserved || (!reserved && !SeatReservationCalls.IsReserved(id, eventid)))
                {
                    string color = reader.GetValue(2).ToString();
                    double price = Convert.ToDouble(reader.GetValue(3));
                    int seatrow = Convert.ToInt32(reader.GetValue(4));
                    char seatrowletter = ' ';
                    if (reader.GetValue(5) != string.Empty) seatrowletter = Convert.ToChar(reader.GetValue(5));
                    int seatnumber = Convert.ToInt32(reader.GetValue(6));
                    char seatnumberletter = ' ';
                    if (reader.GetValue(7) != string.Empty) seatnumberletter = Convert.ToChar(reader.GetValue(7));

                    HallSeat seat = new HallSeat(hallgroupid, id, color, price, seatrow, seatrowletter, seatnumber, seatnumberletter);
                    seats.Add(seat);
                }
            }
            return seats;
        }
        //Padedančioji funkcija, kuri paima nuskaitytą duomenų bazės informaciją ir ją paverčia į HallSeat struktūros listą
        private static BindingList<HallSeat> ParseReadSeatsB(SqlDataReader reader, int hallgroupid, bool reserved, int eventid)
        {
            BindingList<HallSeat> seats = new BindingList<HallSeat>();
            // Display the data within the reader.
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader.GetValue(1));
                if (reserved || (!reserved && !SeatReservationCalls.IsReserved(id, eventid)))
                {
                    string color = reader.GetValue(2).ToString();
                    double price = Convert.ToDouble(reader.GetValue(3));
                    int seatrow = Convert.ToInt32(reader.GetValue(4));
                    char seatrowletter = ' ';
                    if (reader.GetValue(5) != string.Empty) seatrowletter = Convert.ToChar(reader.GetValue(5));
                    int seatnumber = Convert.ToInt32(reader.GetValue(6));
                    char seatnumberletter = ' ';
                    if (reader.GetValue(7) != string.Empty) seatnumberletter = Convert.ToChar(reader.GetValue(7));

                    HallSeat seat = new HallSeat(hallgroupid, id, color, price, seatrow, seatrowletter, seatnumber, seatnumberletter);
                    seats.Add(seat);
                }
            }
            return seats;
        }
        private static List<string> ParseReadSeats(SqlDataReader reader, bool reserved, int eventid)
        {
            List<string> seats = new List<string>();
            // Display the data within the reader.
            while (reader.Read())
            {
                string groupname = reader.GetValue(0).ToString();
                var thing = reader.GetValue(5);
                if (thing == DBNull.Value)
                {
                    int seatrow = Convert.ToInt32(reader.GetValue(1));
                    char seatrowletter = ' ';
                    if (reader.GetValue(2) != string.Empty) seatrowletter = Convert.ToChar(reader.GetValue(2));
                    int seatnumber = Convert.ToInt32(reader.GetValue(3));
                    char seatnumberletter = ' ';
                    if (reader.GetValue(4) != string.Empty) seatnumberletter = Convert.ToChar(reader.GetValue(4));

                    string str = new string(groupname + " " + seatrow);
                    if (seatrowletter != ' ') str += "-" + seatrowletter;
                    str += " " + seatnumber;
                    if (seatnumberletter != ' ') str += "-" + seatnumberletter;
                    seats.Add(str);
                }
            }
            return seats;
        }
        //Atnaujina vietos rezervacijos statusą į rezervuotą
        internal static void MarkReserved(string seat, int eventid)
        {
            ParseSeat(seat,out string groupname, out int row, out char rowletter, out int number, out char numberletter);
            int groupid = HallGroupCalls.GetGroupID(groupname);
            SqlCommand select = new SqlCommand("MarkReserved", myConnection);
            select.CommandType = System.Data.CommandType.StoredProcedure;
            select.Parameters.Add("@HallGroupID", System.Data.SqlDbType.Int);
            select.Parameters["@HallGroupID"].Value = groupid;
            select.Parameters.Add("@SeatRow", System.Data.SqlDbType.Int);
            select.Parameters["@SeatRow"].Value = row;
            select.Parameters.Add("@SeatRowLetter", System.Data.SqlDbType.VarChar, 1);
            select.Parameters["@SeatRowLetter"].Value = rowletter;
            select.Parameters.Add("@SeatNumber", System.Data.SqlDbType.Int);
            select.Parameters["@SeatNumber"].Value = number;
            select.Parameters.Add("@SeatNumberLetter", System.Data.SqlDbType.VarChar, 1);
            select.Parameters["@SeatNumberLetter"].Value = numberletter;
            IAsyncResult result = select.BeginExecuteReader();
            int count = 0;
            while (!result.IsCompleted)
            {
                count += 1;
                Debug.WriteLine("Waiting ({0})", count);
            }

            using (SqlDataReader reader = select.EndExecuteReader(result))
            {
                reader.Read();
                SeatReservationCalls.AddReservation(eventid, Convert.ToInt32(reader.GetValue(1)));
            }
        }
        //Iš vietos pavadinimo išrenka SeatRow, SeatRowLetter, SeatNumber ir SeatNumberLetter kintamuosius ir juos grąžina
        internal static void ParseSeat(string seat, out string groupname, out int row, out char rowletter, out int number, out char numberletter)
        {

            string[] subStrings = seat.Split(' ');
                groupname = subStrings[0];
                for(int i = 1; i<subStrings.Length-2;i++)
                groupname += " " + subStrings[i];
                string[] fullrow = subStrings[subStrings.Length - 2].Split('-');
                row = Convert.ToInt32(fullrow[0]);
                try { rowletter = Convert.ToChar(fullrow[1]); }
                catch { rowletter = ' '; }
                string[] fullnumber = subStrings[subStrings.Length-1].Split('-');
                number = Convert.ToInt32(fullnumber[0]);
                try { numberletter = Convert.ToChar(fullnumber[1]); }
                catch { numberletter = ' '; }
        }
        
        internal static List<string> GetSeatNumbers(int hallgroupid)
        {
            SqlCommand select = new SqlCommand("GetDistinctColumnNumbers", myConnection);
            select.CommandType = System.Data.CommandType.StoredProcedure;
            select.Parameters.Add("@groupid", System.Data.SqlDbType.Int);
            select.Parameters["@groupid"].Value = hallgroupid;
            IAsyncResult result = select.BeginExecuteReader();
            int count = 0;
            while (!result.IsCompleted)
            {
                count += 1;
                Debug.WriteLine("Waiting ({0})", count);
            }
            List<string> list = new List<string>();
            using (SqlDataReader reader = select.EndExecuteReader(result))
            {
                while (reader.Read())
                {
                    int seatrow = Convert.ToInt32(reader.GetValue(0));
                    char seatrowletter = ' ';
                    if (reader.GetValue(1) != string.Empty) seatrowletter = Convert.ToChar(reader.GetValue(1));
                    string str = new string(seatrow.ToString());
                    if (seatrowletter != ' ') str += "-" + seatrowletter;
                    list.Add(str);
                }
                return list;
            }
        }

        internal static void GetSeatRows(int hallgroupid, out List<string> rows, out List<string> rowletters)
        {
            SqlCommand select = new SqlCommand("GetDistinctRowNumbers", myConnection);
            select.CommandType = System.Data.CommandType.StoredProcedure;
            select.Parameters.Add("@groupid", System.Data.SqlDbType.Int);
            select.Parameters["@groupid"].Value = hallgroupid;
            IAsyncResult result = select.BeginExecuteReader();
            int count = 0;
            while (!result.IsCompleted)
            {
                count += 1;
                Debug.WriteLine("Waiting ({0})", count);
            }
            rows = new List<string>();
            rowletters = new List<string>();
            using (SqlDataReader reader = select.EndExecuteReader(result))
            {
                while (reader.Read())
                {
                    rows.Add(reader.GetValue(0).ToString());
                    rowletters.Add(reader.GetValue(1).ToString());
                }
            }
        }
        internal static void GetRowData(int hallgroupid, string row, char rowletter, out List<string> columns, out List<double> prices)
        {
            SqlCommand select = new SqlCommand("GetRowData", myConnection);
            select.CommandType = System.Data.CommandType.StoredProcedure;
            select.Parameters.Add("@groupid", System.Data.SqlDbType.Int);
            select.Parameters["@groupid"].Value = hallgroupid;
            select.Parameters.Add("@row", System.Data.SqlDbType.Int);
            select.Parameters["@row"].Value = Convert.ToInt32(row);
            select.Parameters.Add("@rowletter", System.Data.SqlDbType.VarChar, 1);
            select.Parameters["@rowletter"].Value = Convert.ToChar(rowletter);
            IAsyncResult result = select.BeginExecuteReader();
            int count = 0;
            while (!result.IsCompleted)
            {
                count += 1;
                Debug.WriteLine("Waiting ({0})", count);
            }
            columns = new List<string>();
            prices = new List<double>();
            using (SqlDataReader reader = select.EndExecuteReader(result))
            {
                while (reader.Read())
                {
                    int seatrow = Convert.ToInt32(reader.GetValue(0));
                    char seatrowletter = ' ';
                    if (reader.GetValue(1) != string.Empty) seatrowletter = Convert.ToChar(reader.GetValue(1));
                    string str = new string(seatrow.ToString());
                    if (seatrowletter != ' ') str += "-" + seatrowletter;
                    columns.Add(str);
                    prices.Add(Convert.ToDouble(reader.GetValue(2)));
                }
            }
        }
        internal static int FindSeatID(int hallgroupid, int seatrow, char seatrowletter, int seatnumber, char seatnumberletter)
        {
            SqlCommand seatcommand = new SqlCommand("FindSeatID", myConnection);
            seatcommand.CommandType = System.Data.CommandType.StoredProcedure;
            seatcommand.Parameters.Add("@groupid", System.Data.SqlDbType.Int);
            seatcommand.Parameters["@groupid"].Value = hallgroupid;
            seatcommand.Parameters.Add("@row", System.Data.SqlDbType.Int);
            seatcommand.Parameters["@row"].Value = seatrow;
            seatcommand.Parameters.Add("@rowletter", System.Data.SqlDbType.VarChar, 1);
            seatcommand.Parameters["@rowletter"].Value = seatrowletter;
            seatcommand.Parameters.Add("@number", System.Data.SqlDbType.Int);
            seatcommand.Parameters["@number"].Value = seatnumber;
            seatcommand.Parameters.Add("@numberletter", System.Data.SqlDbType.VarChar, 1);
            seatcommand.Parameters["@numberletter"].Value = seatnumberletter;
            IAsyncResult result = seatcommand.BeginExecuteReader();
            int count = 0;
            while (!result.IsCompleted)
            {
                count += 1;
                Debug.WriteLine("Waiting ({0})", count);
            }
            using (SqlDataReader reader = seatcommand.EndExecuteReader(result))
            {
               
                if (reader.Read())
                    return Convert.ToInt32(reader.GetValue(0));
                else return -1;
            }
        }
        internal static void UpdatePrice(int seatid, double price)
        {
            SqlCommand seatcommand = new SqlCommand("UpdatePrice", myConnection);
            seatcommand.CommandType = System.Data.CommandType.StoredProcedure;
            seatcommand.Parameters.Add("@seatid", System.Data.SqlDbType.Int);
            seatcommand.Parameters["@seatid"].Value = seatid;
            seatcommand.Parameters.Add("@price", System.Data.SqlDbType.Real);
            seatcommand.Parameters["@price"].Value = price;
            seatcommand.ExecuteNonQuery();
        }
    }
}
