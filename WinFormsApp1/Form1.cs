using WinFormsApp1.Data;
using WinFormsApp1.Database;
using System.Xml;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using DevExpress.XtraRichEdit.Model;
using System.Text.RegularExpressions;
using DevExpress.XtraScheduler;
using WinFormsApp1.Helper;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using Microsoft.Extensions.Logging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WinFormsApp1
{
	public partial class Form1 : Form
	{
		private DXMenuItem group; //Pagalbinis kintamasis, kuris parodo, kuri grupë pasirinkta vietø pridëjimo lange
		private DXMenuItem eventh; //Pagalbinis kintamasis, kuris parodo, kuris renginys pasirinktas vietø pridëjimo lange
								  //Paleidimo funkcija
		public Form1()
		{
			InitializeComponent();
			HallCalls.ConnectToDB();
			HallGroupCalls.ConnectToDB();
			HallSeatCalls.ConnectToDB();
			EventCalls.ConnectToDB();
			AvailabilityCalls.ConnectToDB();
			SeatReservationCalls.ConnectToDB();
			UpdateFunctions.UpdateHallList(listView1);
			checkedListBox1.CheckOnClick = true;

		}
		//Nuskaito paduotà failà ir pakvieèia funkcijas, kurios sukeliai informacijà á duomenø bazæ
		private void button1_Click(object sender, EventArgs e)
		{
			listView1.Clear();
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "XML files | *.xml"; // file types, that will be allowed to upload
			dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
			if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
			{
				String path = dialog.FileName; // get name of file
				XmlDocument doc = new XmlDocument();
				doc.Load(path);
				foreach (XmlNode hall in doc.DocumentElement.ChildNodes)
				{
					if (hall.Name == "Hall")
					{
						HallCalls.InsertHall(hall);
						foreach (XmlNode group in hall.ChildNodes)
						{
							if (group.Name == "HallGroup")
							{
								HallGroupCalls.InsertHallGroup(group);
								foreach (XmlNode seat in group.ChildNodes)
								{
									if (seat.Name == "HallSeat")
									{
										ParsingFunctions.InsertHallSeat(seat);
									}
								}
							}
						}
					}
				}
				UpdateFunctions.UpdateHallList(listView1);
			}
		}
		//Iðvalo renginio, grupës ir vietø sàraðus ir tada atnaujina grupes ir renginius pagal pasirinktà salæ renginiø lange
		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			listView2.Items.Clear();
			listView3.Items.Clear();
			listView4.Items.Clear();
			if (listView1.SelectedItems.Count == 1)
			{
				ListView.SelectedListViewItemCollection hall = listView1.SelectedItems;
				int hallid = Convert.ToInt32(hall[0].SubItems[1].Text);
				UpdateFunctions.UpdateGroupList(hallid, listView2);
				UpdateFunctions.UpdateEventList(listView4, hallid);
			}
		}
		//Iðvalo vietø sàraðà ir tada atnaujina já pagal pasirinktà grupæ renginiø lange
		private void listView2_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			listView3.Items.Clear();
			if (listView2.SelectedItems.Count == 1 && listView4.SelectedItems.Count == 1)
			{
				ListView.SelectedListViewItemCollection group = listView2.SelectedItems;
				int hallgroupid = Convert.ToInt32(group[0].SubItems[1].Text);
				int eventid = Convert.ToInt32(listView4.SelectedItems[0].SubItems[1].Text);
				UpdateFunctions.UpdateSeatList(hallgroupid, listView3, eventid);
			}

		}
		//Iðvalo vietø sàraðà ir tada atnaujina já pagal pasirinktà grupæ ir renginá renginiø lange
		private void listView4_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			listView3.Items.Clear();
			if (listView2.SelectedItems.Count == 1 && listView4.SelectedItems.Count == 1)
			{
				ListView.SelectedListViewItemCollection group = listView2.SelectedItems;
				int hallgroupid = Convert.ToInt32(group[0].SubItems[1].Text);
				int eventid = Convert.ToInt32(listView4.SelectedItems[0].SubItems[1].Text);
				UpdateFunctions.UpdateSeatList(hallgroupid, listView3, eventid);
			}

		}
		//Iðvalo vietø sàraðà ir tada atnaujina já pagal pasirinktà renginá rezervacijø lange
		private void listView7_SelectedIndexChanged(object sender, EventArgs e)
		{
			checkedListBox1.Items.Clear();
			if (listView7.SelectedItems.Count == 1)
			{
				UpdateFunctions.UpdateSeatList(checkedListBox1, Convert.ToInt32(listView7.SelectedItems[0].SubItems[1].Text));
			}
		}
		//Kai pereinama á kità langà atnaujina ir parodo to lango UI
		private void TabSelected(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab.Text == "Rezervacijos")
			{
				listView7.Items.Clear();
				UpdateFunctions.UpdateEventList(listView7);
			}
			else if (tabControl1.SelectedTab.Text == "Vietø pridëjimas")
			{
				UpdateHallList();
			}
			else if (tabControl1.SelectedTab.Text == "Rezervacijø kalendorius")
			{
				schedulerDataStorage1.Appointments.Clear();
				schedulerDataStorage1.Resources.Clear();
				UpdateFunctions.UpdateEventCalender(schedulerDataStorage1, schedulerControl2);

			}
		}
		//Duomenø bazëje sukuria paþymëtø vietø rezervacijà ir atnaujina rodomà vietø sàraðà
		private void button2_Click(object sender, EventArgs e)
		{
			if (checkedListBox1.CheckedItems.Count != 0 && listView7.SelectedItems.Count == 1)
			{
				for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
				{
					HallSeatCalls.MarkReserved(checkedListBox1.CheckedItems[x].ToString(), Convert.ToInt32(listView7.SelectedItems[0].SubItems[1].Text));
				}
				checkedListBox1.Items.Clear();
				UpdateFunctions.UpdateSeatList(checkedListBox1, Convert.ToInt32(listView7.SelectedItems[0].SubItems[1].Text));
			}
		}
		//Jeigu yra ávestas pavadinimas, pasirinkta salë ir laikas yra teisingas prideda á duomenø bazæ naujà renginá
		private void button3_Click(object sender, EventArgs e)
		{
			if (textBox2.Text != string.Empty && listView1.SelectedItems.Count == 1 && dateTimePicker1.Value < dateTimePicker2.Value && AvailabilityCalls.IsAvailable(Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text), dateTimePicker1.Value, dateTimePicker2.Value) != null)
			{
				EventCalls.InsertEvent(textBox2.Text, dateTimePicker1.Text, dateTimePicker2.Text, Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text));
				int eventid = EventCalls.FindEvent(textBox2.Text, dateTimePicker1.Text, dateTimePicker2.Text, Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text));
				HelperFunctions.AddAllSeatsToEvent(Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text), eventid);
				UpdateFunctions.UpdateAvailabilty(Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text), dateTimePicker1.Value, dateTimePicker2.Value);
				listView4.Items.Clear();
				UpdateFunctions.UpdateEventList(listView4, Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text));
			}
			else
			{
				MessageBox.Show("Patikrinkite ar suvesta informacija teisinga");
			}
		}
		//Ávedus tikslø vietos pavadinimà parodo ar ji yra rezervuota renginyje ar ne
		private void button4_Click(object sender, EventArgs e)
		{
			if (listView7.SelectedItems.Count == 1 && textBox1.Text != string.Empty)
			{
				try
				{
					if (SeatReservationCalls.FindSeat(Convert.ToInt32(listView7.SelectedItems[0].SubItems[1].Text), textBox1.Text) == 1) MessageBox.Show("Vieta yra rezervuota");
					else MessageBox.Show("Vieta nëra rezervuota");
				}
				catch
				{
					MessageBox.Show("Vieta nerasta");
				}
			}
			else MessageBox.Show("Patikrinkite ar teisingai viskà suvedëte");
		}
		//Atnaujina saliø sàraðà vietø pridëjimo lange
		internal void UpdateHallList()
		{
			List<Event> events = EventCalls.GetEvents();
			DXPopupMenu popupMenu = new DXPopupMenu();
			popupMenu.Items.Add(new DXMenuItem() { Caption = "Pasirinkite renginá", Tag = "-1" });
			foreach (Event eventh in events)
			{
				popupMenu.Items.Add(new DXMenuItem() { Caption = eventh.Name, Tag = eventh.EventId });
			}
			dropDownButton1.DropDownControl = popupMenu;
			foreach (DXMenuItem item in popupMenu.Items)
			{

				item.Click += item_Click;
			}
			dropDownButton1.Text = popupMenu.Items[0].Caption;

		}
		//Kai paspaudþiama ant salës pavadinimo atnaujina jos grupiø sàraðà
		internal void item_Click(object sender, EventArgs e)
		{
			dropDownButton1.Text = ((DXMenuItem)sender).Caption;
			gridView1.Columns.Clear();
			eventh = (DXMenuItem)sender;
			UpdateGroupList(Convert.ToInt32(((DXMenuItem)sender).Tag));
		}
		//Atnaujina grupiø sàraðà vietø pridëjimo lange
		internal void UpdateGroupList(int eventid)
		{
			List<HallGroup> groups = HallGroupCalls.GetGroupsByEvent(eventid);
			DXPopupMenu popupMenu = new DXPopupMenu();
			popupMenu.Items.Add(new DXMenuItem() { Caption = "Pasirinkite grupæ", Tag = "-1" });
			foreach (HallGroup group in groups)
			{
				popupMenu.Items.Add(new DXMenuItem() { Caption = group.Name, Tag = group.HallGroupID });
			}
			dropDownButton2.DropDownControl = popupMenu;
			foreach (DXMenuItem item in popupMenu.Items)
			{

				item.Click += item_Click1;
			}
			dropDownButton2.Text = popupMenu.Items[0].Caption;
		}
		//Kai paspaudþiama ant grupës pavadinimo atnaujina vietø sàraðà
		internal void item_Click1(object sender, EventArgs e)
		{
			dropDownButton2.Text = ((DXMenuItem)sender).Caption;
			gridView1.Columns.Clear();
			group = (DXMenuItem)sender;
			UpdateFunctions.UpdateSeatList(Convert.ToInt32(((DXMenuItem)sender).Tag), gridView1, Convert.ToInt32(eventh.Tag));
		}
		//Patikrina ar eilës pavadinimas teisingas, tada prideda eilæ prie vietø sàraðo
		private void button5_Click_1(object sender, EventArgs e)
		{
			var s = new Regex("^\\d+$");
			var r = new Regex("^\\d+[-].$");
			if (int.TryParse(textBox4.Text, out _) || (textBox4.Text.Length >= 3 && r.IsMatch(textBox4.Text)))
			{
				DataTable table = gridControl1.DataSource as DataTable;
				table.Rows.Add(textBox4.Text);
			}
			else MessageBox.Show("Patikrinkite ar viskas ávesta teisingai");
		}
		//Patikrina ar numerio pavadinimas teisingas, tada prideda numerá prie vietø sàraðo
		private void button6_Click(object sender, EventArgs e)
		{
			var s = new Regex("^\\d+$");
			var r = new Regex("^\\d+[-].$");
			if (int.TryParse(textBox3.Text, out _) || (textBox3.Text.Length >= 3 && r.IsMatch(textBox3.Text)))
			{
				DataTable table = gridControl1.DataSource as DataTable;
				table.Columns.Add(textBox3.Text);
				gridView1.Columns.AddVisible(textBox3.Text);
			}
			else MessageBox.Show("Patikrinkite ar viskas ávesta teisingai");
		}
		//Atnaujina pakeisto vietos elemento infromacijà duomenø bazëje arba sukuria naujà vietà
		private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			this.gridView1.CloseEditor();
			GridColumn column = gridView1.FocusedColumn;
			string name = column.FieldName;
			ParsingFunctions.ParseNumberLetter(name, out int number, out char numberletter);
			DataRow datarow = gridView1.GetFocusedDataRow();
			string rowname = datarow[0].ToString();
			ParsingFunctions.ParseNumberLetter(rowname, out int row, out char rowletter);
			double price;
			try
			{
				price = Convert.ToDouble(datarow[name]);
			}
			catch { MessageBox.Show("Patikrinkite ar viskas ávesta teisingai"); return; }
			int seatid;
			if ((seatid = HallSeatCalls.FindSeatID(Convert.ToInt32(group.Tag), row, rowletter, number, numberletter)) < 0)
			{
				HallSeatCalls.InsertHallSeat(Convert.ToInt32(group.Tag), " ", row, rowletter, number, numberletter, price, Convert.ToInt32(eventh.Tag));//to be set when i figure out the color stuff
				seatid = HallSeatCalls.FindSeatID(Convert.ToInt32(group.Tag), row, rowletter, number, numberletter);
				SeatReservationCalls.AddReservation(Convert.ToInt32(eventh.Tag), seatid, 0, DateTime.Now, price);
			}
			else HallSeatCalls.UpdatePrice(seatid, price, Convert.ToInt32(eventh.Tag));
			this.gridView1.UpdateCurrentRow();
		}
		internal void HideUnusedControls(DevExpress.XtraScheduler.UI.AppointmentForm form)
		{
			form.Controls.RemoveAt(0);
			form.Controls.RemoveAt(0);
			form.Controls.RemoveAt(6);
			form.Controls.RemoveAt(7);
			form.Controls.RemoveAt(8);
			form.Controls.RemoveAt(9);
			form.Controls.RemoveAt(9);
			form.Controls.RemoveAt(11);
			form.Controls[0].Controls.RemoveAt(1);
			form.Controls[0].Controls.RemoveAt(2);
			form.Controls[0].Controls.RemoveAt(2);
			form.Controls[0].Controls.RemoveAt(2);
			form.Controls[0].Controls.RemoveAt(2);
			form.Controls[0].Controls[2].Visible= false;
		}
	}
}

