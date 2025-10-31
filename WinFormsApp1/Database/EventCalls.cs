using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using WinFormsApp1.Data;

namespace WinFormsApp1.Database
{
    internal class EventCalls
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
        //Iš duomenų bazės paima Event ir grąžina jų sąrašą
        internal static List<Event> GetEvents()
        {
            SqlCommand select = new SqlCommand("GetEvents", myConnection);
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
                return ParseReadEvents(reader);
            }
        }
        //Padedančioji funkcija, kuri paima nuskaitytą duomenų bazės informaciją ir ją paverčia į Event struktūros listą
        private static List<Event> ParseReadEvents(SqlDataReader reader)
        {
            List<Event> events = new List<Event>();
            // Display the data within the reader.
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader.GetValue(0));
                string name = reader.GetValue(1).ToString();
                int hallid = Convert.ToInt32(reader.GetValue(2).ToString());
                string starttime = reader.GetValue(3).ToString();
                string endtime = reader.GetValue(4).ToString();
                Event eventh = new Event(id, name, hallid, starttime, endtime);
                events.Add(eventh);
            }
            return events;
        }
        //Į duomenų bazę įkelia naują Event
        internal static void InsertEvent(string name, string start, string end, int hallid)
        {
            SqlCommand select = new SqlCommand("InsertEvent", myConnection);
            select.CommandType = System.Data.CommandType.StoredProcedure;
            select.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 50);
            select.Parameters["@Name"].Value = name;
            select.Parameters.Add("@HallID", System.Data.SqlDbType.Int);
            select.Parameters["@HallID"].Value = hallid;
            select.Parameters.Add("@StartTime", System.Data.SqlDbType.DateTime);
            select.Parameters["@StartTime"].Value = start;
            select.Parameters.Add("@EndTime", System.Data.SqlDbType.DateTime);
            select.Parameters["@EndTime"].Value = end;
            select.ExecuteNonQuery();
        }
        internal static int GetHallID(int eventid)
        {
            SqlCommand select = new SqlCommand("GetHallID", myConnection);
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
                reader.Read();
                return Convert.ToInt32(reader.GetValue(2));
            }
        }
    }
}
