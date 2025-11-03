using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Data.SqlClient;
using WinFormsApp1.Data;
using WinFormsApp1.Helper;

namespace WinFormsApp1.Database
{
	internal class HallCalls
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
		//Įkelia Hall parametrus į duomenų bazę
		internal static void InsertHall(XmlNode hall)
		{
			SqlCommand hallcommand = new SqlCommand("InsertHall", myConnection);
			hallcommand.CommandType = System.Data.CommandType.StoredProcedure;
			hallcommand.Parameters.Add("@HallID", System.Data.SqlDbType.Int);
			hallcommand.Parameters["@HallID"].Value = Convert.ToInt32(hall.ChildNodes[0].InnerText);
			hallcommand.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 50);
			hallcommand.Parameters["@Name"].Value = hall.ChildNodes[1].InnerText;
			hallcommand.Parameters.Add("@TicketLimit", System.Data.SqlDbType.Int);
			hallcommand.Parameters["@TicketLimit"].Value = Convert.ToInt32(hall.ChildNodes[2].InnerText);
			hallcommand.ExecuteNonQuery();
			AvailabilityCalls.InsertAvailability(DateTime.Now, DateTime.Now.AddYears(20), Convert.ToInt32(hall.ChildNodes[0].InnerText));
		}
		//Iš duomenų bazės paima Hall ir grąžina jų sąrašą
		internal static List<Hall> GetHalls()
		{
			SqlCommand select = new SqlCommand("GetHalls", myConnection);
			select.CommandType = System.Data.CommandType.StoredProcedure;
			IAsyncResult result = select.BeginExecuteReader();
			int count = 0;
			while (!result.IsCompleted)
			{
				count += 1;
				Debug.WriteLine("Waiting ({0})", count);
			}

			using (SqlDataReader reader = select.EndExecuteReader(result))
			{
				return ParsingFunctions.ParseReadHalls(reader);
			}
		}
		// Gauna salės bilietų limitą pagal salės id (kolkas nenaudojama)
		private static int GetTicketLimit(int hallid)
		{
			SqlCommand select = new SqlCommand("GetTicketLimit", myConnection);
			select.CommandType = System.Data.CommandType.StoredProcedure;
			select.Parameters.Add("@HallID", System.Data.SqlDbType.Int);
			select.Parameters["@HallID"].Value = hallid;
			IAsyncResult result = select.BeginExecuteReader();
			int count = 0;
			while (!result.IsCompleted)
			{
				count += 1;
				Debug.WriteLine("Waiting ({0})", count);
			}

			using (SqlDataReader reader = select.EndExecuteReader(result))
			{
				return Convert.ToInt32(reader.GetValue(0));
			}

		}
	}
}
