using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.Xml;
using DevExpress.CodeParser;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using WinFormsApp1.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1.Database
{
	internal class AvailabilityCalls
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
		//Patikrina ar galima salėje yra renginys duotame laiko tarpe
		internal static Availability IsAvailable(int hallid, DateTime eventStart, DateTime eventEnd)
		{
			SqlCommand select = new SqlCommand("IsAvailable", myConnection);
			select.CommandType = System.Data.CommandType.StoredProcedure;
			select.Parameters.Add("@EventStart", System.Data.SqlDbType.DateTime);
			select.Parameters["@EventStart"].Value = eventStart;
			select.Parameters.Add("@EventEnd", System.Data.SqlDbType.DateTime);
			select.Parameters["@EventEnd"].Value = eventEnd;
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
				try
				{
					reader.Read();
					DateTime start = Convert.ToDateTime(reader.GetValue(0));
					DateTime end = Convert.ToDateTime(reader.GetValue(1));
					int id = Convert.ToInt32(reader.GetValue(2));
					return new Availability(id, start, end);
				}
				catch
				{
					return null;
				}
			}
		}
		//Atnaujina Availability AvailStart ir AvailEnd kintamuosius
		internal static void Update(int hallid, DateTime eventstart, DateTime eventend)
		{
			SqlCommand select = new SqlCommand("UpdateAvailability", myConnection);
			select.CommandType = System.Data.CommandType.StoredProcedure;
			select.Parameters.Add("@EventStart", System.Data.SqlDbType.DateTime);
			select.Parameters["@EventStart"].Value = eventstart;
			select.Parameters.Add("@EventEnd", System.Data.SqlDbType.DateTime);
			select.Parameters["@EventEnd"].Value = eventend;
			select.Parameters.Add("@HallID", System.Data.SqlDbType.Int);
			select.Parameters["@HallID"].Value = hallid;
			select.ExecuteNonQuery();
		}
		//Ištrina Availability
		internal static void Delete(int hallid, DateTime eventstart, DateTime eventend)
		{
			SqlCommand deleteold = new SqlCommand("DeleteAvailability", myConnection);
			deleteold.CommandType = System.Data.CommandType.StoredProcedure;
			deleteold.Parameters.Add("@Start", System.Data.SqlDbType.DateTime);
			deleteold.Parameters["@Start"].Value = eventstart;
			deleteold.Parameters.Add("@End", System.Data.SqlDbType.DateTime);
			deleteold.Parameters["@End"].Value = eventend;
			deleteold.Parameters.Add("@HallID", System.Data.SqlDbType.Int);
			deleteold.Parameters["@HallID"].Value = hallid;
			deleteold.ExecuteNonQuery();
		}
		//Sukuria naują Availability 
		internal static void InsertAvailability(DateTime start, DateTime end, int HallID)
		{
			SqlCommand insertend = new SqlCommand("InsertAvailability", myConnection);
			insertend.CommandType = System.Data.CommandType.StoredProcedure;
			insertend.Parameters.Add("@End", System.Data.SqlDbType.DateTime);
			insertend.Parameters["@End"].Value = end;
			insertend.Parameters.Add("@Start", System.Data.SqlDbType.DateTime);
			insertend.Parameters["@Start"].Value = start;
			insertend.Parameters.Add("@HallID", System.Data.SqlDbType.Int);
			insertend.Parameters["@HallID"].Value = HallID;
			insertend.ExecuteNonQuery();
		}
	}
}
