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

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
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
            HelperFunctions.UpdateHallList(listView1);
            checkedListBox1.CheckOnClick = true;

        }
        void GridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var view = sender as GridView;
            //your code  
            view.SetRowCellValue(e.RowHandle, "Eilë", "sdasafa");
        }
        //Nuskaito paduotà failà ir pakvieèia funkcijas, kurios sukeliai informacijà á duomenø bazæ
        private void button1_Click(object sender, EventArgs e)
        {
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
                                        HallSeatCalls.InsertHallSeat(seat);
                                    }
                                }
                            }
                        }
                    }
                }
                HelperFunctions.UpdateHallList(listView1);
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
                HelperFunctions.UpdateGroupList(hallid, listView2);
                HelperFunctions.UpdateEventList(listView4);
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
                HelperFunctions.UpdateSeatList(hallgroupid, listView3, eventid);
            }

        }
        //Iðvalo vietø sàraðà ir tada atnaujina já pagal pasirinktà grupæ renginiø lange
        private void listView4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            if (listView2.SelectedItems.Count == 1 && listView4.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection group = listView2.SelectedItems;
                int hallgroupid = Convert.ToInt32(group[0].SubItems[1].Text);
                int eventid = Convert.ToInt32(listView4.SelectedItems[0].SubItems[1].Text);
                HelperFunctions.UpdateSeatList(hallgroupid, listView3, eventid);
            }

        }
        //Iðvalo vietø sàraðà ir tada atnaujina já pagal pasirinktà grupæ rezervacijø lange
        private void listView7_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            if (listView7.SelectedItems.Count == 1)
            {
                HelperFunctions.UpdateSeatList(checkedListBox1, Convert.ToInt32(listView7.SelectedItems[0].SubItems[1].Text));
            }
        }
        //Kai pereinama á rezervacijø langà atnaujina ir parodo saliø sàraðà
        private void TabSelected(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Rezervacijos")
            {
                listView7.Items.Clear();
                HelperFunctions.UpdateEventList(listView7);
            }
            else if (tabControl1.SelectedTab.Text == "Vietø pridëjimas")
            {
                UpdateHallList();
            }
        }
        //Duomenø bazëje paþymëtø vietø IsReserved kintamàjá pakeièia á 1 (vieta rezervuota) ir atnaujina rodomà vietø sàraðà
        private void button2_Click(object sender, EventArgs e)
        {

            // Determine if there are any items checked.
            if (checkedListBox1.CheckedItems.Count != 0 && listView7.SelectedItems.Count == 1)
            {
                for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                {
                    HallSeatCalls.MarkReserved(checkedListBox1.CheckedItems[x].ToString(), Convert.ToInt32(listView7.SelectedItems[0].SubItems[1].Text));
                }
                checkedListBox1.Items.Clear();
                HelperFunctions.UpdateSeatList(checkedListBox1, Convert.ToInt32(listView7.SelectedItems[0].SubItems[1].Text));
            }
        }
        //Jeigu yra ávestas pavadinimas, pasirinkta salë ir laikas yra teisingas prideda á duomenø bazæ naujà renginá
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty && listView1.SelectedItems.Count == 1 && dateTimePicker1.Value < dateTimePicker2.Value && AvailabilityCalls.IsAvailable(Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text), dateTimePicker1.Value, dateTimePicker2.Value))
            {
                EventCalls.InsertEvent(textBox2.Text, dateTimePicker1.Text, dateTimePicker2.Text, Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text));
                AvailabilityCalls.UpdateAvailabilty(Convert.ToInt32(listView1.SelectedItems[0].SubItems[1].Text), dateTimePicker1.Value, dateTimePicker2.Value);
                listView4.Items.Clear();
                HelperFunctions.UpdateEventList(listView4);
            }
            else
            {
                MessageBox.Show("Patikrinkite ar suvesta informacija teisinga");
            }
        }

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
        internal void UpdateHallList()
        {
            List<Hall> halls = HallCalls.GetHalls();
            DXPopupMenu popupMenu = new DXPopupMenu();
            popupMenu.Items.Add(new DXMenuItem() { Caption = "Pasirinkite salæ", Tag = "-1" });
            foreach (Hall hall in halls)
            {
                popupMenu.Items.Add(new DXMenuItem() { Caption = hall.Name, Tag = hall.HallID });
            }
            dropDownButton1.DropDownControl = popupMenu;
            foreach (DXMenuItem item in popupMenu.Items)
            {

                item.Click += item_Click;
            }
            dropDownButton1.Text = popupMenu.Items[0].Caption;

        }
        internal void item_Click(object sender, EventArgs e)
        {
            // synchronize selection
            dropDownButton1.Text = ((DXMenuItem)sender).Caption;
            
            UpdateGroupList(Convert.ToInt32(((DXMenuItem)sender).Tag));
            // ... do something specific
        }
        internal void UpdateGroupList(int hallid)
        {
            List<HallGroup> groups = HallGroupCalls.GetGroups(hallid);
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
        internal void item_Click1(object sender, EventArgs e)
        {
            // synchronize selection
            dropDownButton2.Text = ((DXMenuItem)sender).Caption;
            gridView1.Columns.Clear();
            group = (DXMenuItem)sender;
            HelperFunctions.UpdateSeatList(Convert.ToInt32(((DXMenuItem)sender).Tag), gridView1);
            // ... do something specific
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            gridView1.CloseEditor();
        }

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
        private DXMenuItem group; 
        private void GridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.gridView1.CloseEditor();
            GridColumn column = gridView1.FocusedColumn;
            string name = column.FieldName;
            int number;
            char numberletter = ' ';
            if (name.Contains('-'))
            {
                string[] parts = name.Split('-');
                number = Convert.ToInt32(parts[0]);
                numberletter = Convert.ToChar(parts[1]);
            }
            else
            {
                number = Convert.ToInt32(name);
            }
            DataRow datarow = gridView1.GetFocusedDataRow();
            string rowname = datarow[0].ToString();
            int row;
            char rowletter = ' ';
            if (rowname.Contains('-'))
            {
                string[] parts = rowname.Split('-');
                row = Convert.ToInt32(parts[0]);
                rowletter = Convert.ToChar(parts[1]);
            }
            else
            {
                row = Convert.ToInt32(rowname);
            }
            double price;
            try
            {
                price = Convert.ToDouble(datarow[name]); ///make a check if seat exists if yes then just update price
            }
            catch { MessageBox.Show("Patikrinkite ar viskas ávesta teisingai"); return; }
            int seatid;
            if ((seatid = HallSeatCalls.FindSeatID(Convert.ToInt32(group.Tag), row, rowletter, number, numberletter)) < 0)
                HallSeatCalls.InsertHallSeat(Convert.ToInt32(group.Tag), price, row, rowletter, number, numberletter);
            else HallSeatCalls.UpdatePrice(seatid, price);
                this.gridView1.UpdateCurrentRow();
            //this.ServiceStatusTableAdapter.Update(this.adventureWorks2012DataSet.AssetManagerDatabaseDataSet);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}

