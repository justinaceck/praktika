using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using WinFormsApp1.Data;
using WinFormsApp1.Helper;

namespace WinFormsApp1.Database
{
    internal class SeatReservationCalls
    {
        private static SqlConnection myConnection = new SqlConnection(
  @$"Server=NET155\MSSQLSERVER, 1433;" +
  $"Database=Sale;" +
  $"User Id=Terra ERP;" +
  $"Password=numKvA1s7vGl;" +
  $"TrustServerCertificate=True;" +
  $"Connect Timeout=30;");
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
        //Patikrina ar vieta rezervuota renginyje
        internal static int Exists(int seatid, int eventid)
        {
            SqlCommand select = new SqlCommand("IsReserved", myConnection);
            select.CommandType = System.Data.CommandType.StoredProcedure;
            select.Parameters.Add("@seatid", System.Data.SqlDbType.Int);
            select.Parameters["@seatid"].Value = seatid;
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
                    
                try
                {
					reader.Read();
                    
                    return Convert.ToInt32(reader.GetValue(0));
				}
                catch { return -1; }
            }
        }
        //Sukuria naują vietos rezervaciją
        internal static void AddReservation(int eventid, int seatid, int reserved, DateTime time, double price)
        {
            SqlCommand select = new SqlCommand("InsertReservation", myConnection);
            select.CommandType = System.Data.CommandType.StoredProcedure;
            select.Parameters.Add("@seatid", System.Data.SqlDbType.Int);
            select.Parameters["@seatid"].Value = seatid;
            select.Parameters.Add("@eventid", System.Data.SqlDbType.Int);
            select.Parameters["@eventid"].Value = eventid;
			select.Parameters.Add("@reserved", System.Data.SqlDbType.Bit);
			select.Parameters["@reserved"].Value = reserved;
			select.Parameters.Add("@time", System.Data.SqlDbType.DateTime);
			select.Parameters["@time"].Value = time;
			select.Parameters.Add("@price", System.Data.SqlDbType.Real);
			select.Parameters["@price"].Value = price;
			select.ExecuteNonQuery();
        }
		internal static void UpdateReservation(int eventid, int seatid, int reserved, DateTime time)
		{
			SqlCommand select = new SqlCommand("UpdateReservation", myConnection);
			select.CommandType = System.Data.CommandType.StoredProcedure;
			select.Parameters.Add("@seatid", System.Data.SqlDbType.Int);
			select.Parameters["@seatid"].Value = seatid;
			select.Parameters.Add("@eventid", System.Data.SqlDbType.Int);
			select.Parameters["@eventid"].Value = eventid;
			select.Parameters.Add("@reserved", System.Data.SqlDbType.Bit);
			select.Parameters["@reserved"].Value = reserved;
			select.Parameters.Add("@time", System.Data.SqlDbType.DateTime);
			select.Parameters["@time"].Value = time;
			select.ExecuteNonQuery();
		}
		//Jeigu vieta rezervuota gražina 1, jeigu ne 0
		internal static int FindSeat(int eventid, string seat)
        {
			ParsingFunctions.ParseSeat(seat, out string groupname, out int row, out char rowletter, out int number, out char numberletter);
            SqlCommand select = new SqlCommand("FindSeat", myConnection);
            select.CommandType = System.Data.CommandType.StoredProcedure;
            select.Parameters.Add("@eventid", System.Data.SqlDbType.Int);
            select.Parameters["@eventid"].Value = eventid;
            select.Parameters.Add("@row", System.Data.SqlDbType.Int);
            select.Parameters["@row"].Value = row;
            select.Parameters.Add("@rowletter", System.Data.SqlDbType.VarChar, 1);
            select.Parameters["@rowletter"].Value = rowletter;
            select.Parameters.Add("@number", System.Data.SqlDbType.Int);
            select.Parameters["@number"].Value = number;
            select.Parameters.Add("@numberletter", System.Data.SqlDbType.VarChar, 1);
            select.Parameters["@numberletter"].Value = numberletter;
            select.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 50);
            select.Parameters["@name"].Value = groupname;
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
                try
                {
                    if (reader.GetValue(0) == DBNull.Value) return 0;
                    else return Convert.ToInt32(reader.GetValue(0));
                }
                catch { return 0; }
            }
        }
		internal static void GetReserved(out List<int> ids, out List<DateTime> times, out List<string> names)
		{
			SqlCommand select = new SqlCommand("GetReserved", myConnection);
			IAsyncResult result = select.BeginExecuteReader();
			int count = 0;
			while (!result.IsCompleted)
			{
				count += 1;
				Debug.WriteLine("Waiting ({0})", count);
			}

			using (SqlDataReader reader = select.EndExecuteReader(result))
			{
                ParsingFunctions.ParseReserved(reader, out ids, out times, out names);
			}
		}
		internal static void DeleteReservation(int eventid, int seatid)
		{
			SqlCommand select = new SqlCommand("DeleteSeat", myConnection);
			select.CommandType = System.Data.CommandType.StoredProcedure;
			select.Parameters.Add("@seatid", System.Data.SqlDbType.Int);
			select.Parameters["@seatid"].Value = seatid;
			select.Parameters.Add("@eventid", System.Data.SqlDbType.Int);
			select.Parameters["@eventid"].Value = eventid;
			select.ExecuteNonQuery();
		}
	}
}
