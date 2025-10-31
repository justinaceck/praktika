﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Data.SqlClient;
using WinFormsApp1.Data;

namespace WinFormsApp1.Database
{
    internal class HallGroupCalls
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
        //Įkelia HallGroup parametrus į duomenų bazę
        internal static void InsertHallGroup(XmlNode group)
        {
            SqlCommand groupcommand = new SqlCommand("InsertHallGroup", myConnection);
            groupcommand.CommandType = System.Data.CommandType.StoredProcedure;
            groupcommand.Parameters.Add("@HallID", System.Data.SqlDbType.Int);
            groupcommand.Parameters["@HallID"].Value = Convert.ToInt32(group.ChildNodes[0].InnerText);
            groupcommand.Parameters.Add("@HallGroupID", System.Data.SqlDbType.Int);
            groupcommand.Parameters["@HallGroupID"].Value = Convert.ToInt32(group.ChildNodes[1].InnerText);
            groupcommand.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 50);
            groupcommand.Parameters["@Name"].Value = group.ChildNodes[2].InnerText;
            groupcommand.Parameters.Add("@AZ", System.Data.SqlDbType.Int);
            groupcommand.Parameters["@AZ"].Value = Convert.ToInt32(group.ChildNodes[3].InnerText);
            groupcommand.ExecuteNonQuery();
        }
        //Iš duomenų bazės paima HallGroup ir grąžina jų sąrašą
        internal static List<HallGroup> GetGroups(int hallid)
        {
            SqlCommand select = new SqlCommand("GetHallGroups", myConnection);
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
                return ParseReadGroups(reader, hallid);
            }
        }
        //Padedančioji funkcija, kuri paima nuskaitytą duomenų bazės informaciją ir ją paverčia į HallGroup struktūros listą
        private static List<HallGroup> ParseReadGroups(SqlDataReader reader, int hallid)
        {
            List<HallGroup> groups = new List<HallGroup>();
            // Display the data within the reader.
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader.GetValue(1));
                string name = reader.GetValue(2).ToString();
                int az = Convert.ToInt32(reader.GetValue(3));
                HallGroup group = new HallGroup(hallid, id, name, az);
                groups.Add(group);
            }
            return groups;
        }
        internal static int GetGroupID(string groupname)
        {
            SqlCommand select = new SqlCommand("GetGroupID", myConnection);
            select.CommandType = System.Data.CommandType.StoredProcedure;
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
                return Convert.ToInt32(reader.GetValue(1));
            }
        }
    }
}
