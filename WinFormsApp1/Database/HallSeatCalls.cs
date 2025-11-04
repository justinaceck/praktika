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
using WinFormsApp1.Helper;

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
		internal static void InsertHallSeat(int hallgroupid, string color, int seatrow, char seatrowletter, int seatnumber, char seatnumberletter, double price, int extra)
		{
			SqlCommand seatcommand = new SqlCommand("InsertHallSeat", myConnection);
			seatcommand.CommandType = System.Data.CommandType.StoredProcedure;
			seatcommand.Parameters.Add("@HallGroupID", System.Data.SqlDbType.Int);
			seatcommand.Parameters["@HallGroupID"].Value = hallgroupid;
			seatcommand.Parameters.Add("@Color", System.Data.SqlDbType.VarChar, 50);
			seatcommand.Parameters["@Color"].Value = color;
			seatcommand.Parameters.Add("@SeatRow", System.Data.SqlDbType.Int);
			seatcommand.Parameters["@SeatRow"].Value = seatrow;
			seatcommand.Parameters.Add("@SeatRowLetter", System.Data.SqlDbType.VarChar, 1);
			seatcommand.Parameters["@SeatRowLetter"].Value = seatrowletter;
			seatcommand.Parameters.Add("@SeatNumber", System.Data.SqlDbType.Int);
			seatcommand.Parameters["@SeatNumber"].Value = seatnumber;
			seatcommand.Parameters.Add("@SeatNumberLetter", System.Data.SqlDbType.VarChar, 1);
			seatcommand.Parameters["@SeatNumberLetter"].Value = seatnumberletter;
			seatcommand.Parameters.Add("@Price", System.Data.SqlDbType.Real);
			seatcommand.Parameters["@Price"].Value = price;
			seatcommand.Parameters.Add("@Extra", System.Data.SqlDbType.Int);
			seatcommand.Parameters["@Extra"].Value = extra;
			seatcommand.ExecuteNonQuery();
		}
		//Iš duomenų bazės paima HallSeat pagal HallGroupID ir grąžina jų sąrašą
		internal static List<HallSeat> GetSeats(int hallgroupid)
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
				return ParsingFunctions.ParseReadSeats(reader);
			}
		}
		//Iš duomenų bazės paima HallSeat pagal EventID ir grąžina jų sąrašą
		internal static List<string> GetSeatsByEvent(int eventid)
		{
			List<string> seats = new List<string>();
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
				return ParsingFunctions.ParseReadSeats(reader, eventid);
			}
		}
		//Atnaujina vietos rezervacijos statusą į rezervuotą
		internal static void MarkReserved(string seat, int eventid)
		{
			ParsingFunctions.ParseSeat(seat, out string groupname, out int row, out char rowletter, out int number, out char numberletter);
			int hallid = EventCalls.GetHallID(eventid);
			int groupid = HallGroupCalls.GetGroupID(groupname, hallid);
			SqlCommand select = new SqlCommand("MarkReserved", myConnection);//Paima iš duomenų bazės vietą su duotais argumantais
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
				SeatReservationCalls.UpdateReservation(eventid, Convert.ToInt32(reader.GetValue(1)), 1, DateTime.Now);
			}
		}
		//Pagal HallGroupID iš duomenų bazės paima visus grupės numerius
		internal static List<string> GetSeatNumbers(int hallgroupid, int eventid)
		{
			SqlCommand select = new SqlCommand("GetDistinctColumnNumbers", myConnection);
			select.CommandType = System.Data.CommandType.StoredProcedure;
			select.Parameters.Add("@groupid", System.Data.SqlDbType.Int);
			select.Parameters["@groupid"].Value = hallgroupid;
			select.Parameters.Add("@eventid", System.Data.SqlDbType.Int);
			select.Parameters["@eventid"].Value = eventid;
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
		//Pagal HallGroupID iš duomenų bazės paima visas grupės eiles
		internal static void GetSeatRows(int hallgroupid, out List<string> rows, out List<string> rowletters, int eventid)
		{
			SqlCommand select = new SqlCommand("GetDistinctRowNumbers", myConnection);
			select.CommandType = System.Data.CommandType.StoredProcedure;
			select.Parameters.Add("@groupid", System.Data.SqlDbType.Int);
			select.Parameters["@groupid"].Value = hallgroupid;
			select.Parameters.Add("@eventid", System.Data.SqlDbType.Int);
			select.Parameters["@eventid"].Value = eventid;
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
		//Iš duomenų bazės paima visos eilės informaciją
		internal static void GetRowData(int hallgroupid, string row, char rowletter, out List<string> columns, out List<double> prices, int eventid)
		{
			SqlCommand select = new SqlCommand("GetRowData", myConnection);
			select.CommandType = System.Data.CommandType.StoredProcedure;
			select.Parameters.Add("@groupid", System.Data.SqlDbType.Int);
			select.Parameters["@groupid"].Value = hallgroupid;
			select.Parameters.Add("@row", System.Data.SqlDbType.Int);
			select.Parameters["@row"].Value = Convert.ToInt32(row);
			select.Parameters.Add("@rowletter", System.Data.SqlDbType.VarChar, 1);
			select.Parameters["@rowletter"].Value = Convert.ToChar(rowletter);
			select.Parameters.Add("@eventid", System.Data.SqlDbType.Int);
			select.Parameters["@eventid"].Value = eventid;
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
		//Gražina vietos id arba -1 jeigu vieta neegzistuoja
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
		//Atnaujina vietos kainą FUCKED
		internal static void UpdatePrice(int seatid, double price, int eventid)
		{
			SqlCommand seatcommand = new SqlCommand("UpdatePrice", myConnection);
			seatcommand.CommandType = System.Data.CommandType.StoredProcedure;
			seatcommand.Parameters.Add("@seatid", System.Data.SqlDbType.Int);
			seatcommand.Parameters["@seatid"].Value = seatid;
			seatcommand.Parameters.Add("@price", System.Data.SqlDbType.Real);
			seatcommand.Parameters["@price"].Value = price;
			seatcommand.Parameters.Add("@eventid", System.Data.SqlDbType.Int);
			seatcommand.Parameters["@eventid"].Value = eventid;
			seatcommand.ExecuteNonQuery();
		}
	}
}
