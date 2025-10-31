using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.SpreadsheetSource.Implementation;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit.Model.History;
using DevExpress.XtraScheduler;
using WinFormsApp1.Data;
using WinFormsApp1.Database;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;

namespace WinFormsApp1
{
    internal class HelperFunctions
    {
        //Atnaujina rodomą salių sąrašą
        internal static void UpdateHallList(ListView view)
        {
            List<Hall> halls = HallCalls.GetHalls();

            foreach (Hall hall in halls)
            {
                ListViewItem item = new ListViewItem(hall.Name);
                item.SubItems.Add(hall.HallID.ToString());
                view.Items.Add(item);
            }
        }

        //Atnaujina rodomą grupių sąrašą
        internal static void UpdateGroupList(int hallid, ListView view)
        {
            List<HallGroup> groups = HallGroupCalls.GetGroups(hallid);
            foreach (HallGroup group in groups)
            {
                ListViewItem item = new ListViewItem(group.Name);
                item.SubItems.Add(group.HallGroupID.ToString());
                view.Items.Add(item);
            }
        }
        //Atnaujina rodomą renginių sąrašą
        internal static void UpdateEventList(ListView view)
        {
            List<Event> events = EventCalls.GetEvents();
            foreach (Event eventh in events)
            {
                ListViewItem item = new ListViewItem(new string(eventh.Name + " " + eventh.StartTime));
                item.SubItems.Add(eventh.EventId.ToString());
                item.SubItems.Add(eventh.HallId.ToString());
                view.Items.Add(item);
            }
        }
        internal static void UpdateEventList(ListView view, int Hallid)
        {
            List<Event> events = EventCalls.GetEventsByHallID(Hallid);
            foreach (Event eventh in events)
            {
                ListViewItem item = new ListViewItem(new string(eventh.Name + " " + eventh.StartTime));
                item.SubItems.Add(eventh.EventId.ToString());
                item.SubItems.Add(eventh.HallId.ToString());
                view.Items.Add(item);
            }
        }
        //Atnaujina rodomą renginių sąrašą
        internal static void UpdateEventCalender(SchedulerDataStorage storage, SchedulerControl control)
        {
            List<Event> events = EventCalls.GetEvents();
            List<Hall> halls = HallCalls.GetHalls();
            foreach (Hall hall in halls)
            {
                Resource resource = storage.CreateResource(hall.HallID);
                resource.Caption = hall.Name;
                storage.Resources.Add(resource);
            }
            control.GroupType = SchedulerGroupType.Resource;

            foreach (Event eventh in events)
            {
                Appointment newApp = storage.CreateAppointment(DevExpress.XtraScheduler.AppointmentType.Normal, Convert.ToDateTime(eventh.StartTime), Convert.ToDateTime(eventh.EndTime), eventh.Name);
                newApp.ResourceId = eventh.HallId;
                storage.Appointments.Add(newApp);
            }
        }
        //Atnaujina rodomą vietų sąrašą renginių lange
        internal static void UpdateSeatList(int hallgroupid, ListView view, int eventid)
        {
            List<HallSeat> seats = HallSeatCalls.GetSeats(hallgroupid, true, eventid);
            foreach (HallSeat seat in seats)
            {
                //string seatstr = new String(seat.SeatRow + seat.SeatRowLetter.ToString() + " " + seat.SeatNumber + seat.SeatNumberLetter);
                string seatrow = seat.SeatRow.ToString();
                char seatrowletter = ' ';
                if (seat.SeatRowLetter != ' ') seatrowletter = Convert.ToChar(seat.SeatRowLetter);
                string seatstr = new string(seatrow.ToString());
                if (seatrowletter != ' ') seatstr += "-" + seatrowletter;
                string seatnum = seat.SeatNumber.ToString();
                char seatnumletter = ' ';
                if (seat.SeatNumberLetter != ' ') seatnumletter = Convert.ToChar(seat.SeatNumberLetter);
                seatstr += " " + seatnum;
                if (seatnumletter != ' ') seatstr += "-" + seatnumletter;
                ListViewItem item = new ListViewItem(seatstr);
                view.Items.Add(seatstr);
            }
        }
        //Atnaujina rodomą vietų sąrašą renginių lange
        internal static void UpdateSeatList(int hallgroupid, GridView view)
        {
            BindingList<HallSeat> seats = HallSeatCalls.GetSeatsB(hallgroupid, true, -1);
            DataTable table = new DataTable();
            AddColumns(hallgroupid, table);
            
            AddRows(hallgroupid, table);
            view.GridControl.DataSource = table;
            view.Columns[0].OptionsColumn.AllowEdit = false;

        }
        private static void AddRows(int hallgroupid, DataTable table)
        {
            HallSeatCalls.GetSeatRows(hallgroupid, out List<string> row, out List<string> rowletters);
            DataRow tablerow;
            for (int i=0; i<row.Count; i++)
            {
                string seatrow = row[i];
                char seatrowletter = ' ';
                if (rowletters[i] != string.Empty) seatrowletter = Convert.ToChar(rowletters[i]);
                string str = new string(seatrow.ToString());
                if (seatrowletter != ' ') str += "-" + seatrowletter;
                tablerow = table.NewRow();
                tablerow["Eilė"] = str;
                HallSeatCalls.GetRowData(hallgroupid, seatrow, seatrowletter, out List<string> columns, out List<double> prices);
                for (int j = 0; j < columns.Count; j++)
                {
                    tablerow[columns[j]] = prices[j];
                }
                table.Rows.Add(tablerow);
                }
            //table.Rows.Add(new Button());
            
        }
        private static void AddColumns(int hallgroupid, DataTable table)
        {
            table.Columns.Add("Eilė");
            List<string> columns = HallSeatCalls.GetSeatNumbers(hallgroupid);
            foreach (string seat in columns)
            {
                    table.Columns.Add(seat);
            }
        }
        //Atnaujina rodomą vietų sąrašą rezervacijų lange
        internal static void UpdateSeatList(CheckedListBox box, int eventid)
        {
            List<string> seats = HallSeatCalls.GetSeats(false, eventid);
            foreach (string seat in seats)
            {
                box.Items.Add(seat);
            }
        }

    }
}
