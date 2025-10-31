using System;
using System.Globalization;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraGrid;
using WinFormsApp1.Data;
using WinFormsApp1.Database;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler.Drawing;
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Label label1;
            Label label2;
            Label label3;
            Label label4;
            Label label5;
            Label label6;
            GridFormatRule gridFormatRule1 = new GridFormatRule();
            FormatConditionRule3ColorScale formatConditionRule3ColorScale1 = new FormatConditionRule3ColorScale();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler4 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler5 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler6 = new DevExpress.XtraScheduler.TimeRuler();
            button1 = new Button();
            listView1 = new ListView();
            listView2 = new ListView();
            listView3 = new ListView();
            listView4 = new ListView();
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            dateTimePicker2 = new DateTimePicker();
            textBox2 = new TextBox();
            button3 = new Button();
            dateTimePicker1 = new DateTimePicker();
            tabPage1 = new TabPage();
            button4 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            checkedListBox1 = new CheckedListBox();
            listView7 = new ListView();
            tabPage3 = new TabPage();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            button6 = new Button();
            button5 = new Button();
            gridControl1 = new GridControl();
            gridView1 = new GridView();
            dropDownButton2 = new DropDownButton();
            dropDownButton1 = new DropDownButton();
            tabPage4 = new TabPage();
            schedulerControl2 = new DevExpress.XtraScheduler.SchedulerControl();
            schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(components);
            schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            calendarControl1 = new DevExpress.XtraEditors.Controls.CalendarControl();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)schedulerControl2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schedulerDataStorage1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)schedulerControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calendarControl1.CalendarTimeProperties).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(289, 31);
            label1.Name = "label1";
            label1.Size = new Size(115, 28);
            label1.TabIndex = 2;
            label1.Text = "Įkeltos salės";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(446, 31);
            label2.Name = "label2";
            label2.Size = new Size(121, 28);
            label2.TabIndex = 4;
            label2.Text = "Salės grupės";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(632, 31);
            label3.Name = "label3";
            label3.Size = new Size(131, 28);
            label3.TabIndex = 5;
            label3.Text = "Grupės vietos";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(94, 31);
            label4.Name = "label4";
            label4.Size = new Size(92, 28);
            label4.TabIndex = 8;
            label4.Text = "Renginiai";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(104, 15);
            label5.Name = "label5";
            label5.Size = new Size(92, 28);
            label5.TabIndex = 15;
            label5.Text = "Renginiai";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(475, 15);
            label6.Name = "label6";
            label6.Size = new Size(131, 28);
            label6.TabIndex = 13;
            label6.Text = "Grupės vietos";
            // 
            // button1
            // 
            button1.Location = new Point(668, 6);
            button1.Name = "button1";
            button1.Size = new Size(115, 23);
            button1.TabIndex = 0;
            button1.Text = "Įkelti salę";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Font = new Font("Segoe UI", 12F);
            listView1.LabelWrap = false;
            listView1.Location = new Point(277, 60);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(150, 360);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // listView2
            // 
            listView2.Font = new Font("Segoe UI", 12F);
            listView2.LabelWrap = false;
            listView2.Location = new Point(433, 60);
            listView2.MultiSelect = false;
            listView2.Name = "listView2";
            listView2.Size = new Size(150, 360);
            listView2.TabIndex = 3;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.List;
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged_1;
            // 
            // listView3
            // 
            listView3.Location = new Point(589, 60);
            listView3.Name = "listView3";
            listView3.Size = new Size(200, 360);
            listView3.TabIndex = 6;
            listView3.UseCompatibleStateImageBehavior = false;
            listView3.View = View.List;
            // 
            // listView4
            // 
            listView4.Font = new Font("Segoe UI", 12F);
            listView4.LabelWrap = false;
            listView4.Location = new Point(15, 60);
            listView4.MultiSelect = false;
            listView4.Name = "listView4";
            listView4.Size = new Size(250, 360);
            listView4.TabIndex = 7;
            listView4.UseCompatibleStateImageBehavior = false;
            listView4.View = View.List;
            listView4.SelectedIndexChanged += listView4_SelectedIndexChanged_1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(-5, -1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(803, 454);
            tabControl1.TabIndex = 9;
            tabControl1.Selected += TabSelected;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(calendarControl1);
            tabPage2.Controls.Add(dateTimePicker2);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(dateTimePicker1);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(listView4);
            tabPage2.Controls.Add(listView3);
            tabPage2.Controls.Add(listView1);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(listView2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(795, 426);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Renginiai";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CustomFormat = "yyyy-M-d, H:m";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Location = new Point(424, 6);
            dateTimePicker2.MinDate = new DateTime(2025, 10, 27, 11, 42, 4, 826);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(134, 23);
            dateTimePicker2.TabIndex = 12;
            dateTimePicker2.Value = new DateTime(2025, 10, 27, 11, 42, 4, 826);
            // 
            // textBox2
            // 
            textBox2.Location = new Point(15, 9);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(268, 23);
            textBox2.TabIndex = 11;
            // 
            // button3
            // 
            button3.Location = new Point(564, 5);
            button3.Name = "button3";
            button3.Size = new Size(98, 23);
            button3.TabIndex = 10;
            button3.Text = "Įkelti renginį";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd, HH:mm:ss";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(289, 6);
            dateTimePicker1.MinDate = new DateTime(2025, 10, 27, 11, 42, 4, 831);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(129, 23);
            dateTimePicker1.TabIndex = 9;
            dateTimePicker1.Value = new DateTime(2025, 10, 27, 11, 42, 4, 831);
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(checkedListBox1);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(listView7);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(192, 72);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Rezervacijos";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(612, 398);
            button4.Name = "button4";
            button4.Size = new Size(87, 23);
            button4.TabIndex = 19;
            button4.Text = "Ieškoti vietos";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.ForeColor = Color.Red;
            textBox1.Location = new Point(13, 397);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(593, 23);
            textBox1.TabIndex = 18;
            // 
            // button2
            // 
            button2.Location = new Point(705, 398);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 17;
            button2.Text = "Rezervuoti";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(330, 46);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(450, 346);
            checkedListBox1.TabIndex = 16;
            // 
            // listView7
            // 
            listView7.Font = new Font("Segoe UI", 12F);
            listView7.LabelWrap = false;
            listView7.Location = new Point(13, 46);
            listView7.MultiSelect = false;
            listView7.Name = "listView7";
            listView7.Size = new Size(300, 346);
            listView7.TabIndex = 11;
            listView7.UseCompatibleStateImageBehavior = false;
            listView7.View = View.List;
            listView7.SelectedIndexChanged += listView7_SelectedIndexChanged;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(textBox4);
            tabPage3.Controls.Add(textBox3);
            tabPage3.Controls.Add(button6);
            tabPage3.Controls.Add(button5);
            tabPage3.Controls.Add(gridControl1);
            tabPage3.Controls.Add(dropDownButton2);
            tabPage3.Controls.Add(dropDownButton1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(192, 72);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Vietų pridėjimas";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(295, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(158, 23);
            textBox4.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(540, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(148, 23);
            textBox3.TabIndex = 6;
            // 
            // button6
            // 
            button6.Location = new Point(692, 3);
            button6.Name = "button6";
            button6.Size = new Size(97, 23);
            button6.TabIndex = 4;
            button6.Text = "Pridėti numerį";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.Location = new Point(459, 3);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 3;
            button5.Text = "Pridėti eilę";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // gridControl1
            // 
            gridControl1.Location = new Point(13, 32);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new Size(776, 383);
            gridControl1.TabIndex = 2;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Name = "Format0";
            gridFormatRule1.Rule = formatConditionRule3ColorScale1;
            gridView1.FormatRules.Add(gridFormatRule1);
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsMenu.ShowConditionalFormattingItem = true;
            gridView1.InitNewRow += GridView1_InitNewRow;
            gridView1.CellValueChanged += GridView1_CellValueChanged;
            // 
            // dropDownButton2
            // 
            dropDownButton2.Location = new Point(154, 3);
            dropDownButton2.Name = "dropDownButton2";
            dropDownButton2.Size = new Size(135, 23);
            dropDownButton2.TabIndex = 1;
            dropDownButton2.Text = "dropDownButton2";
            // 
            // dropDownButton1
            // 
            dropDownButton1.Location = new Point(13, 3);
            dropDownButton1.Name = "dropDownButton1";
            dropDownButton1.Size = new Size(135, 23);
            dropDownButton1.TabIndex = 0;
            dropDownButton1.Text = "dropDownButton1";
            // 
            // tabPage4
            // 
            tabPage4.AccessibleName = "Rezervacijų kalendorius";
            tabPage4.Controls.Add(schedulerControl2);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(795, 426);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Rezervacijų kalendorius";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // schedulerControl2
            // 
            schedulerControl2.DataStorage = schedulerDataStorage1;
            schedulerControl2.Location = new Point(3, 3);
            schedulerControl2.Name = "schedulerControl2";
            schedulerControl2.Size = new Size(786, 412);
            schedulerControl2.Start = new DateTime(2025, 10, 31, 0, 0, 0, 0);
            schedulerControl2.TabIndex = 0;
            schedulerControl2.Text = "schedulerControl2";
            schedulerControl2.Views.DayView.TimeRulers.Add(timeRuler1);
            schedulerControl2.Views.FullWeekView.Enabled = true;
            schedulerControl2.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            schedulerControl2.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            schedulerControl2.Views.YearView.UseOptimizedScrolling = false;
            // 
            // schedulerDataStorage1
            // 
            // 
            // 
            // 
            schedulerDataStorage1.AppointmentDependencies.AutoReload = false;
            // 
            // 
            // 
            schedulerDataStorage1.Appointments.Labels.CreateNewLabel(0, "None", "&None", SystemColors.Window);
            schedulerDataStorage1.Appointments.Labels.CreateNewLabel(1, "Important", "&Important", Color.FromArgb(255, 194, 190));
            schedulerDataStorage1.Appointments.Labels.CreateNewLabel(2, "Business", "&Business", Color.FromArgb(168, 213, 255));
            schedulerDataStorage1.Appointments.Labels.CreateNewLabel(3, "Personal", "&Personal", Color.FromArgb(193, 244, 156));
            schedulerDataStorage1.Appointments.Labels.CreateNewLabel(4, "Vacation", "&Vacation", Color.FromArgb(243, 228, 199));
            schedulerDataStorage1.Appointments.Labels.CreateNewLabel(5, "Must Attend", "Must &Attend", Color.FromArgb(244, 206, 147));
            schedulerDataStorage1.Appointments.Labels.CreateNewLabel(6, "Travel Required", "&Travel Required", Color.FromArgb(199, 244, 255));
            schedulerDataStorage1.Appointments.Labels.CreateNewLabel(7, "Needs Preparation", "&Needs Preparation", Color.FromArgb(207, 219, 152));
            schedulerDataStorage1.Appointments.Labels.CreateNewLabel(8, "Birthday", "&Birthday", Color.FromArgb(224, 207, 233));
            schedulerDataStorage1.Appointments.Labels.CreateNewLabel(9, "Anniversary", "&Anniversary", Color.FromArgb(141, 233, 223));
            schedulerDataStorage1.Appointments.Labels.CreateNewLabel(10, "Phone Call", "Phone &Call", Color.FromArgb(255, 247, 165));
            // 
            // schedulerControl1
            // 
            schedulerControl1.Location = new Point(0, 0);
            schedulerControl1.Name = "schedulerControl1";
            schedulerControl1.Size = new Size(400, 200);
            schedulerControl1.Start = new DateTime(2025, 10, 31, 0, 0, 0, 0);
            schedulerControl1.TabIndex = 0;
            schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler4);
            schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler5);
            schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler6);
            schedulerControl1.Views.YearView.UseOptimizedScrolling = false;
            // 
            // calendarControl1
            // 
            calendarControl1.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            calendarControl1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            calendarControl1.Location = new Point(305, 35);
            calendarControl1.Name = "calendarControl1";
            calendarControl1.Size = new Size(352, 235);
            calendarControl1.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)schedulerControl2).EndInit();
            ((System.ComponentModel.ISupportInitialize)schedulerDataStorage1).EndInit();
            ((System.ComponentModel.ISupportInitialize)schedulerControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)calendarControl1.CalendarTimeProperties).EndInit();
            ResumeLayout(false);
        }

        private void GridView1_InitNewRow1(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        private Button button1;
        private ListView listView1;
        private Label label1;
        private ListView listView2;
        private ListView listView3;
        private ListView listView4;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListView listView7;
        private CheckedListBox checkedListBox1;
        private TextBox textBox1;
        private Button button2;
        private Button button3;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox2;
        private DateTimePicker dateTimePicker2;
        private Button button4;
        private TabPage tabPage3;
        private DevExpress.XtraEditors.DropDownButton dropDownButton2;
        private DevExpress.XtraEditors.DropDownButton dropDownButton1;
        private GridControl gridControl1;
        private GridView gridView1;
        private Button button5;
        private Button button6;
        private TextBox textBox3;
        private TextBox textBox4;
        private TabPage tabPage4;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl2;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage1;
        private DevExpress.XtraEditors.Controls.CalendarControl calendarControl1;
    }
}
