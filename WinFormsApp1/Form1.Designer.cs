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
using DevExpress.XtraScheduler;
using WinFormsApp1.Helper;
//using System.Windows.Controls;
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
			ListViewGroup listViewGroup1 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
			ListViewGroup listViewGroup2 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
			ListViewGroup listViewGroup3 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
			TimeRuler timeRuler1 = new TimeRuler();
			TimeRuler timeRuler2 = new TimeRuler();
			TimeRuler timeRuler3 = new TimeRuler();
			TimeRuler timeRuler4 = new TimeRuler();
			TimeRuler timeRuler5 = new TimeRuler();
			TimeRuler timeRuler6 = new TimeRuler();
			button1 = new Button();
			listView1 = new ListView();
			listView2 = new ListView();
			listView3 = new ListView();
			listView4 = new ListView();
			tabControl1 = new TabControl();
			tabPage2 = new TabPage();
			layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
			layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
			layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem14 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem15 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem16 = new DevExpress.XtraLayout.LayoutControlItem();
			tabPage1 = new TabPage();
			layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
			checkedListBox1 = new CheckedListBox();
			button2 = new Button();
			textBox1 = new TextBox();
			button4 = new Button();
			listView7 = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			columnHeader3 = new ColumnHeader();
			Root = new DevExpress.XtraLayout.LayoutControlGroup();
			layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
			layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
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
			schedulerControl2 = new SchedulerControl();
			schedulerDataStorage1 = new SchedulerDataStorage(components);
			tabPage5 = new TabPage();
			schedulerControl4 = new SchedulerControl();
			schedulerDataStorage2 = new SchedulerDataStorage(components);
			tabPage6 = new TabPage();
			dropDownButton3 = new DropDownButton();
			gridControl2 = new GridControl();
			gridView2 = new GridView();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			tabControl1.SuspendLayout();
			tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)layoutControl2).BeginInit();
			layoutControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)layoutControlGroup1).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem8).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem9).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem10).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem11).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem12).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem13).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem14).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem15).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem16).BeginInit();
			tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)layoutControl1).BeginInit();
			layoutControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)Root).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem1).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem6).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem2).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem4).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem3).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem5).BeginInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem7).BeginInit();
			tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
			((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
			tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)schedulerControl2).BeginInit();
			((System.ComponentModel.ISupportInitialize)schedulerDataStorage1).BeginInit();
			tabPage5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)schedulerControl4).BeginInit();
			((System.ComponentModel.ISupportInitialize)schedulerDataStorage2).BeginInit();
			tabPage6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)gridControl2).BeginInit();
			((System.ComponentModel.ISupportInitialize)gridView2).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			label1.Font = new Font("Segoe UI", 15F);
			label1.Location = new Point(12, 147);
			label1.Margin = new Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new Size(136, 104);
			label1.TabIndex = 1;
			label1.Text = "Įkeltos salės";
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			label2.Font = new Font("Segoe UI", 15F);
			label2.Location = new Point(12, 255);
			label2.Margin = new Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new Size(136, 100);
			label2.TabIndex = 1;
			label2.Text = "Salės grupės";
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			label3.Font = new Font("Segoe UI", 15F);
			label3.Location = new Point(12, 359);
			label3.Margin = new Padding(4, 0, 4, 0);
			label3.MaximumSize = new Size(150, 0);
			label3.Name = "label3";
			label3.Size = new Size(136, 94);
			label3.TabIndex = 1;
			label3.Text = "Grupės vietos";
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			label4.Font = new Font("Segoe UI", 15F);
			label4.Location = new Point(12, 12);
			label4.Margin = new Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new Size(136, 131);
			label4.TabIndex = 1;
			label4.Text = "Renginiai";
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			label5.Font = new Font("Segoe UI", 15F);
			label5.Location = new Point(12, 12);
			label5.Margin = new Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new Size(905, 33);
			label5.TabIndex = 1;
			label5.Text = "Renginiai";
			// 
			// label6
			// 
			label6.Font = new Font("Segoe UI", 15F);
			label6.Location = new Point(12, 245);
			label6.Margin = new Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new Size(905, 31);
			label6.TabIndex = 1;
			label6.Text = "Grupės vietos";
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.Top;
			button1.Location = new Point(12, 457);
			button1.Margin = new Padding(4, 3, 4, 3);
			button1.MaximumSize = new Size(0, 50);
			button1.Name = "button1";
			button1.Size = new Size(905, 23);
			button1.TabIndex = 5;
			button1.Text = "Įkelti salę";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// listView1
			// 
			listView1.Anchor = AnchorStyles.None;
			listView1.Font = new Font("Segoe UI", 12F);
			listView1.LabelWrap = false;
			listView1.Location = new Point(152, 147);
			listView1.Margin = new Padding(20);
			listView1.MultiSelect = false;
			listView1.Name = "listView1";
			listView1.Size = new Size(765, 104);
			listView1.TabIndex = 2;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.List;
			listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
			// 
			// listView2
			// 
			listView2.Anchor = AnchorStyles.None;
			listView2.Font = new Font("Segoe UI", 12F);
			listView2.LabelWrap = false;
			listView2.Location = new Point(152, 255);
			listView2.Margin = new Padding(20);
			listView2.MultiSelect = false;
			listView2.Name = "listView2";
			listView2.Size = new Size(765, 100);
			listView2.TabIndex = 3;
			listView2.UseCompatibleStateImageBehavior = false;
			listView2.View = View.List;
			listView2.SelectedIndexChanged += listView2_SelectedIndexChanged_1;
			// 
			// listView3
			// 
			listView3.Anchor = AnchorStyles.None;
			listView3.Location = new Point(152, 359);
			listView3.Margin = new Padding(20);
			listView3.Name = "listView3";
			listView3.Size = new Size(765, 94);
			listView3.TabIndex = 4;
			listView3.UseCompatibleStateImageBehavior = false;
			listView3.View = View.List;
			// 
			// listView4
			// 
			listView4.Anchor = AnchorStyles.None;
			listView4.Font = new Font("Segoe UI", 12F);
			listView4.LabelWrap = false;
			listView4.Location = new Point(152, 12);
			listView4.Margin = new Padding(20);
			listView4.MultiSelect = false;
			listView4.Name = "listView4";
			listView4.Size = new Size(765, 131);
			listView4.TabIndex = 0;
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
			tabControl1.Controls.Add(tabPage5);
			tabControl1.Controls.Add(tabPage6);
			tabControl1.Dock = DockStyle.Fill;
			tabControl1.Location = new Point(0, 0);
			tabControl1.Margin = new Padding(4, 3, 4, 3);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(945, 526);
			tabControl1.SizeMode = TabSizeMode.FillToRight;
			tabControl1.TabIndex = 9;
			tabControl1.Selected += TabSelected;
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(layoutControl2);
			tabPage2.Location = new Point(4, 24);
			tabPage2.Margin = new Padding(4, 3, 4, 3);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(4, 3, 4, 3);
			tabPage2.Size = new Size(937, 498);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Renginiai";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// layoutControl2
			// 
			layoutControl2.Controls.Add(button1);
			layoutControl2.Controls.Add(listView3);
			layoutControl2.Controls.Add(label3);
			layoutControl2.Controls.Add(listView2);
			layoutControl2.Controls.Add(listView1);
			layoutControl2.Controls.Add(label2);
			layoutControl2.Controls.Add(listView4);
			layoutControl2.Controls.Add(label4);
			layoutControl2.Controls.Add(label1);
			layoutControl2.Dock = DockStyle.Fill;
			layoutControl2.Location = new Point(4, 3);
			layoutControl2.Name = "layoutControl2";
			layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(371, 173, 650, 400);
			layoutControl2.Root = layoutControlGroup1;
			layoutControl2.Size = new Size(929, 492);
			layoutControl2.TabIndex = 9;
			layoutControl2.Text = "layoutControl2";
			// 
			// layoutControlGroup1
			// 
			layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			layoutControlGroup1.GroupBordersVisible = false;
			layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem8, layoutControlItem9, layoutControlItem10, layoutControlItem11, layoutControlItem12, layoutControlItem13, layoutControlItem14, layoutControlItem15, layoutControlItem16 });
			layoutControlGroup1.Name = "Root";
			layoutControlGroup1.Size = new Size(929, 492);
			layoutControlGroup1.TextVisible = false;
			// 
			// layoutControlItem8
			// 
			layoutControlItem8.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
			layoutControlItem8.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
			layoutControlItem8.Control = label4;
			layoutControlItem8.Location = new Point(0, 0);
			layoutControlItem8.MaxSize = new Size(140, 0);
			layoutControlItem8.MinSize = new Size(140, 24);
			layoutControlItem8.Name = "layoutControlItem8";
			layoutControlItem8.Size = new Size(140, 135);
			layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			layoutControlItem8.TextVisible = false;
			// 
			// layoutControlItem9
			// 
			layoutControlItem9.Control = listView4;
			layoutControlItem9.Location = new Point(140, 0);
			layoutControlItem9.Name = "layoutControlItem9";
			layoutControlItem9.OptionsTableLayoutItem.ColumnIndex = 1;
			layoutControlItem9.Size = new Size(769, 135);
			layoutControlItem9.TextVisible = false;
			// 
			// layoutControlItem10
			// 
			layoutControlItem10.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
			layoutControlItem10.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
			layoutControlItem10.Control = label1;
			layoutControlItem10.Location = new Point(0, 135);
			layoutControlItem10.MaxSize = new Size(140, 0);
			layoutControlItem10.MinSize = new Size(140, 24);
			layoutControlItem10.Name = "layoutControlItem10";
			layoutControlItem10.OptionsTableLayoutItem.RowIndex = 1;
			layoutControlItem10.Size = new Size(140, 108);
			layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			layoutControlItem10.TextVisible = false;
			// 
			// layoutControlItem11
			// 
			layoutControlItem11.Control = listView1;
			layoutControlItem11.Location = new Point(140, 135);
			layoutControlItem11.Name = "layoutControlItem11";
			layoutControlItem11.OptionsTableLayoutItem.ColumnIndex = 1;
			layoutControlItem11.OptionsTableLayoutItem.RowIndex = 1;
			layoutControlItem11.Size = new Size(769, 108);
			layoutControlItem11.TextVisible = false;
			// 
			// layoutControlItem12
			// 
			layoutControlItem12.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
			layoutControlItem12.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
			layoutControlItem12.Control = label2;
			layoutControlItem12.Location = new Point(0, 243);
			layoutControlItem12.MaxSize = new Size(140, 0);
			layoutControlItem12.MinSize = new Size(140, 24);
			layoutControlItem12.Name = "layoutControlItem12";
			layoutControlItem12.OptionsTableLayoutItem.RowIndex = 2;
			layoutControlItem12.Size = new Size(140, 104);
			layoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			layoutControlItem12.TextVisible = false;
			// 
			// layoutControlItem13
			// 
			layoutControlItem13.Control = listView2;
			layoutControlItem13.Location = new Point(140, 243);
			layoutControlItem13.Name = "layoutControlItem13";
			layoutControlItem13.OptionsTableLayoutItem.ColumnIndex = 1;
			layoutControlItem13.OptionsTableLayoutItem.RowIndex = 2;
			layoutControlItem13.Size = new Size(769, 104);
			layoutControlItem13.TextVisible = false;
			// 
			// layoutControlItem14
			// 
			layoutControlItem14.ContentHorzAlignment = DevExpress.Utils.HorzAlignment.Center;
			layoutControlItem14.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
			layoutControlItem14.Control = label3;
			layoutControlItem14.Location = new Point(0, 347);
			layoutControlItem14.MaxSize = new Size(140, 0);
			layoutControlItem14.MinSize = new Size(140, 24);
			layoutControlItem14.Name = "layoutControlItem14";
			layoutControlItem14.OptionsTableLayoutItem.RowIndex = 3;
			layoutControlItem14.Size = new Size(140, 98);
			layoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			layoutControlItem14.TextVisible = false;
			// 
			// layoutControlItem15
			// 
			layoutControlItem15.Control = listView3;
			layoutControlItem15.Location = new Point(140, 347);
			layoutControlItem15.Name = "layoutControlItem15";
			layoutControlItem15.OptionsTableLayoutItem.ColumnIndex = 1;
			layoutControlItem15.OptionsTableLayoutItem.RowIndex = 3;
			layoutControlItem15.Size = new Size(769, 98);
			layoutControlItem15.TextVisible = false;
			// 
			// layoutControlItem16
			// 
			layoutControlItem16.Control = button1;
			layoutControlItem16.Location = new Point(0, 445);
			layoutControlItem16.MaxSize = new Size(0, 27);
			layoutControlItem16.MinSize = new Size(24, 27);
			layoutControlItem16.Name = "layoutControlItem16";
			layoutControlItem16.OptionsTableLayoutItem.RowIndex = 4;
			layoutControlItem16.Size = new Size(909, 27);
			layoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			layoutControlItem16.TextVisible = false;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(layoutControl1);
			tabPage1.Location = new Point(4, 24);
			tabPage1.Margin = new Padding(4, 3, 4, 3);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(4, 3, 4, 3);
			tabPage1.Size = new Size(937, 498);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Rezervacijos";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// layoutControl1
			// 
			layoutControl1.Controls.Add(checkedListBox1);
			layoutControl1.Controls.Add(label6);
			layoutControl1.Controls.Add(button2);
			layoutControl1.Controls.Add(textBox1);
			layoutControl1.Controls.Add(button4);
			layoutControl1.Controls.Add(listView7);
			layoutControl1.Controls.Add(label5);
			layoutControl1.Dock = DockStyle.Fill;
			layoutControl1.Location = new Point(4, 3);
			layoutControl1.Name = "layoutControl1";
			layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new Rectangle(593, 0, 650, 400);
			layoutControl1.Root = Root;
			layoutControl1.Size = new Size(929, 492);
			layoutControl1.TabIndex = 20;
			layoutControl1.Text = "layoutControl1";
			// 
			// checkedListBox1
			// 
			checkedListBox1.Anchor = AnchorStyles.None;
			checkedListBox1.Location = new Point(12, 280);
			checkedListBox1.Name = "checkedListBox1";
			checkedListBox1.Size = new Size(905, 166);
			checkedListBox1.TabIndex = 2;
			// 
			// button2
			// 
			button2.Location = new Point(12, 460);
			button2.Margin = new Padding(4, 3, 4, 3);
			button2.Name = "button2";
			button2.Size = new Size(205, 20);
			button2.TabIndex = 3;
			button2.Text = "Rezervuoti";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// textBox1
			// 
			textBox1.ForeColor = Color.Red;
			textBox1.Location = new Point(414, 460);
			textBox1.Margin = new Padding(4, 3, 4, 3);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(503, 20);
			textBox1.TabIndex = 5;
			// 
			// button4
			// 
			button4.Location = new Point(221, 460);
			button4.Margin = new Padding(4, 3, 4, 3);
			button4.Name = "button4";
			button4.Size = new Size(189, 20);
			button4.TabIndex = 4;
			button4.Text = "Ieškoti vietos";
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// listView7
			// 
			listView7.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
			listView7.Font = new Font("Segoe UI", 12F);
			listViewGroup1.Header = "ListViewGroup";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "ListViewGroup";
			listViewGroup2.Name = "listViewGroup2";
			listViewGroup3.Header = "ListViewGroup";
			listViewGroup3.Name = "listViewGroup3";
			listView7.Groups.AddRange(new ListViewGroup[] { listViewGroup1, listViewGroup2, listViewGroup3 });
			listView7.Location = new Point(12, 49);
			listView7.Margin = new Padding(4, 3, 4, 3);
			listView7.MultiSelect = false;
			listView7.Name = "listView7";
			listView7.Size = new Size(905, 192);
			listView7.TabIndex = 0;
			listView7.UseCompatibleStateImageBehavior = false;
			listView7.View = View.Tile;
			listView7.SelectedIndexChanged += listView7_SelectedIndexChanged;
			// 
			// Root
			// 
			Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
			Root.GroupBordersVisible = false;
			Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] { layoutControlItem1, layoutControlItem6, layoutControlItem2, layoutControlItem4, layoutControlItem3, layoutControlItem5, layoutControlItem7 });
			Root.Name = "Root";
			Root.Size = new Size(929, 492);
			Root.TextVisible = false;
			// 
			// layoutControlItem1
			// 
			layoutControlItem1.Control = label5;
			layoutControlItem1.Location = new Point(0, 0);
			layoutControlItem1.MaxSize = new Size(0, 37);
			layoutControlItem1.MinSize = new Size(24, 37);
			layoutControlItem1.Name = "layoutControlItem1";
			layoutControlItem1.Size = new Size(909, 37);
			layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			layoutControlItem1.TextVisible = false;
			// 
			// layoutControlItem6
			// 
			layoutControlItem6.Control = label6;
			layoutControlItem6.Location = new Point(0, 233);
			layoutControlItem6.MaxSize = new Size(0, 35);
			layoutControlItem6.MinSize = new Size(24, 35);
			layoutControlItem6.Name = "layoutControlItem6";
			layoutControlItem6.OptionsTableLayoutItem.RowIndex = 2;
			layoutControlItem6.Size = new Size(909, 35);
			layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			layoutControlItem6.TextVisible = false;
			// 
			// layoutControlItem2
			// 
			layoutControlItem2.Control = listView7;
			layoutControlItem2.Location = new Point(0, 37);
			layoutControlItem2.Name = "layoutControlItem2";
			layoutControlItem2.OptionsTableLayoutItem.ColumnIndex = 1;
			layoutControlItem2.OptionsTableLayoutItem.RowIndex = 2;
			layoutControlItem2.Size = new Size(909, 196);
			layoutControlItem2.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
			layoutControlItem2.TextToControlDistance = 0;
			layoutControlItem2.TextVisible = false;
			// 
			// layoutControlItem4
			// 
			layoutControlItem4.Control = button2;
			layoutControlItem4.Location = new Point(0, 448);
			layoutControlItem4.Name = "layoutControlItem4";
			layoutControlItem4.OptionsTableLayoutItem.RowIndex = 1;
			layoutControlItem4.Size = new Size(209, 24);
			layoutControlItem4.TextVisible = false;
			// 
			// layoutControlItem3
			// 
			layoutControlItem3.Control = button4;
			layoutControlItem3.Location = new Point(209, 448);
			layoutControlItem3.Name = "layoutControlItem3";
			layoutControlItem3.OptionsTableLayoutItem.ColumnIndex = 1;
			layoutControlItem3.Size = new Size(193, 24);
			layoutControlItem3.TextVisible = false;
			// 
			// layoutControlItem5
			// 
			layoutControlItem5.Control = textBox1;
			layoutControlItem5.Location = new Point(402, 448);
			layoutControlItem5.Name = "layoutControlItem5";
			layoutControlItem5.OptionsTableLayoutItem.ColumnIndex = 1;
			layoutControlItem5.OptionsTableLayoutItem.RowIndex = 1;
			layoutControlItem5.Size = new Size(507, 24);
			layoutControlItem5.TextVisible = false;
			// 
			// layoutControlItem7
			// 
			layoutControlItem7.Control = checkedListBox1;
			layoutControlItem7.Location = new Point(0, 268);
			layoutControlItem7.Name = "layoutControlItem7";
			layoutControlItem7.OptionsTableLayoutItem.RowIndex = 3;
			layoutControlItem7.Size = new Size(909, 180);
			layoutControlItem7.TextVisible = false;
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
			tabPage3.Margin = new Padding(4, 3, 4, 3);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new Size(937, 498);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Vietų pridėjimas";
			tabPage3.UseVisualStyleBackColor = true;
			// 
			// textBox4
			// 
			textBox4.Location = new Point(295, 3);
			textBox4.Margin = new Padding(4, 3, 4, 3);
			textBox4.Name = "textBox4";
			textBox4.Size = new Size(158, 23);
			textBox4.TabIndex = 7;
			// 
			// textBox3
			// 
			textBox3.Location = new Point(540, 3);
			textBox3.Margin = new Padding(4, 3, 4, 3);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(148, 23);
			textBox3.TabIndex = 6;
			// 
			// button6
			// 
			button6.Location = new Point(692, 3);
			button6.Margin = new Padding(4, 3, 4, 3);
			button6.Name = "button6";
			button6.Size = new Size(97, 23);
			button6.TabIndex = 4;
			button6.Text = "Pridėti numerį";
			button6.UseVisualStyleBackColor = true;
			button6.Click += button6_Click;
			// 
			// button5
			// 
			button5.Location = new Point(458, 3);
			button5.Margin = new Padding(4, 3, 4, 3);
			button5.Name = "button5";
			button5.Size = new Size(75, 23);
			button5.TabIndex = 3;
			button5.Text = "Pridėti eilę";
			button5.UseVisualStyleBackColor = true;
			button5.Click += button5_Click_1;
			// 
			// gridControl1
			// 
			gridControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			gridControl1.EmbeddedNavigator.Margin = new Padding(4, 3, 4, 3);
			gridControl1.Location = new Point(13, 32);
			gridControl1.MainView = gridView1;
			gridControl1.Margin = new Padding(4, 3, 4, 3);
			gridControl1.Name = "gridControl1";
			gridControl1.Size = new Size(921, 457);
			gridControl1.TabIndex = 2;
			gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
			// 
			// gridView1
			// 
			gridView1.GridControl = gridControl1;
			gridView1.Name = "gridView1";
			gridView1.OptionsMenu.ShowConditionalFormattingItem = true;
			gridView1.CellValueChanged += GridView1_CellValueChanged;
			// 
			// dropDownButton2
			// 
			dropDownButton2.Location = new Point(154, 3);
			dropDownButton2.Margin = new Padding(4, 3, 4, 3);
			dropDownButton2.Name = "dropDownButton2";
			dropDownButton2.Size = new Size(135, 23);
			dropDownButton2.TabIndex = 1;
			dropDownButton2.Text = "dropDownButton2";
			// 
			// dropDownButton1
			// 
			dropDownButton1.Location = new Point(13, 3);
			dropDownButton1.Margin = new Padding(4, 3, 4, 3);
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
			tabPage4.Margin = new Padding(4, 3, 4, 3);
			tabPage4.Name = "tabPage4";
			tabPage4.Padding = new Padding(4, 3, 4, 3);
			tabPage4.Size = new Size(937, 498);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "Rezervacijų kalendorius";
			tabPage4.UseVisualStyleBackColor = true;
			// 
			// schedulerControl2
			// 
			schedulerControl2.AllowDrop = false;
			schedulerControl2.DataStorage = schedulerDataStorage1;
			schedulerControl2.Dock = DockStyle.Fill;
			schedulerControl2.Location = new Point(4, 3);
			schedulerControl2.Margin = new Padding(4, 3, 4, 3);
			schedulerControl2.Name = "schedulerControl2";
			schedulerControl2.OptionsCustomization.AllowAppointmentConflicts = AppointmentConflictsMode.Forbidden;
			schedulerControl2.OptionsCustomization.AllowAppointmentCopy = UsedAppointmentType.None;
			schedulerControl2.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.None;
			schedulerControl2.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.None;
			schedulerControl2.OptionsCustomization.AllowAppointmentDragBetweenResources = UsedAppointmentType.None;
			schedulerControl2.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.None;
			schedulerControl2.OptionsCustomization.AllowAppointmentMultiSelect = false;
			schedulerControl2.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.None;
			schedulerControl2.OptionsCustomization.AllowInplaceEditor = UsedAppointmentType.None;
			schedulerControl2.Size = new Size(929, 492);
			schedulerControl2.Start = new DateTime(2025, 11, 3, 0, 0, 0, 0);
			schedulerControl2.TabIndex = 0;
			schedulerControl2.Text = "schedulerControl2";
			schedulerControl2.Views.DayView.TimeRulers.Add(timeRuler1);
			schedulerControl2.Views.FullWeekView.Enabled = true;
			schedulerControl2.Views.FullWeekView.TimeRulers.Add(timeRuler2);
			schedulerControl2.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
			schedulerControl2.Views.YearView.UseOptimizedScrolling = false;
			schedulerControl2.EditAppointmentFormShowing += SchedulerControl2_EditAppointmentFormShowing;
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
			schedulerDataStorage1.AppointmentInserting += SchedulerDataStorage1_AppointmentInserting;
			// 
			// tabPage5
			// 
			tabPage5.Controls.Add(schedulerControl4);
			tabPage5.Location = new Point(4, 24);
			tabPage5.Margin = new Padding(4, 3, 4, 3);
			tabPage5.Name = "tabPage5";
			tabPage5.Padding = new Padding(4, 3, 4, 3);
			tabPage5.Size = new Size(937, 498);
			tabPage5.TabIndex = 4;
			tabPage5.Text = "Vietų rezervacijos kalendorius";
			tabPage5.UseVisualStyleBackColor = true;
			// 
			// schedulerControl4
			// 
			schedulerControl4.DataStorage = schedulerDataStorage2;
			schedulerControl4.Dock = DockStyle.Fill;
			schedulerControl4.Location = new Point(4, 3);
			schedulerControl4.Margin = new Padding(4, 3, 4, 3);
			schedulerControl4.Name = "schedulerControl4";
			schedulerControl4.OptionsCustomization.AllowAppointmentDelete = UsedAppointmentType.Custom;
			schedulerControl4.Size = new Size(929, 492);
			schedulerControl4.Start = new DateTime(2025, 11, 4, 0, 0, 0, 0);
			schedulerControl4.TabIndex = 0;
			schedulerControl4.Text = "schedulerControl4";
			schedulerControl4.Views.DayView.TimeRulers.Add(timeRuler4);
			schedulerControl4.Views.FullWeekView.Enabled = true;
			schedulerControl4.Views.FullWeekView.TimeRulers.Add(timeRuler5);
			schedulerControl4.Views.WeekView.Enabled = false;
			schedulerControl4.Views.WorkWeekView.TimeRulers.Add(timeRuler6);
			schedulerControl4.Views.YearView.UseOptimizedScrolling = false;
			// 
			// schedulerDataStorage2
			// 
			// 
			// 
			// 
			schedulerDataStorage2.AppointmentDependencies.AutoReload = false;
			// 
			// 
			// 
			schedulerDataStorage2.Appointments.Labels.CreateNewLabel(0, "None", "&None", SystemColors.Window);
			schedulerDataStorage2.Appointments.Labels.CreateNewLabel(1, "Important", "&Important", Color.FromArgb(255, 194, 190));
			schedulerDataStorage2.Appointments.Labels.CreateNewLabel(2, "Business", "&Business", Color.FromArgb(168, 213, 255));
			schedulerDataStorage2.Appointments.Labels.CreateNewLabel(3, "Personal", "&Personal", Color.FromArgb(193, 244, 156));
			schedulerDataStorage2.Appointments.Labels.CreateNewLabel(4, "Vacation", "&Vacation", Color.FromArgb(243, 228, 199));
			schedulerDataStorage2.Appointments.Labels.CreateNewLabel(5, "Must Attend", "Must &Attend", Color.FromArgb(244, 206, 147));
			schedulerDataStorage2.Appointments.Labels.CreateNewLabel(6, "Travel Required", "&Travel Required", Color.FromArgb(199, 244, 255));
			schedulerDataStorage2.Appointments.Labels.CreateNewLabel(7, "Needs Preparation", "&Needs Preparation", Color.FromArgb(207, 219, 152));
			schedulerDataStorage2.Appointments.Labels.CreateNewLabel(8, "Birthday", "&Birthday", Color.FromArgb(224, 207, 233));
			schedulerDataStorage2.Appointments.Labels.CreateNewLabel(9, "Anniversary", "&Anniversary", Color.FromArgb(141, 233, 223));
			schedulerDataStorage2.Appointments.Labels.CreateNewLabel(10, "Phone Call", "Phone &Call", Color.FromArgb(255, 247, 165));
			schedulerDataStorage2.AppointmentDeleting += SchedulerDataStorage2_AppointmentDeleting;
			// 
			// tabPage6
			// 
			tabPage6.Controls.Add(dropDownButton3);
			tabPage6.Controls.Add(gridControl2);
			tabPage6.Location = new Point(4, 24);
			tabPage6.Name = "tabPage6";
			tabPage6.Padding = new Padding(3);
			tabPage6.Size = new Size(937, 498);
			tabPage6.TabIndex = 5;
			tabPage6.Text = "Kitas vietų pridėjimas";
			tabPage6.UseVisualStyleBackColor = true;
			// 
			// dropDownButton3
			// 
			dropDownButton3.Location = new Point(4, 3);
			dropDownButton3.Margin = new Padding(4, 3, 4, 3);
			dropDownButton3.Name = "dropDownButton3";
			dropDownButton3.Size = new Size(135, 23);
			dropDownButton3.TabIndex = 1;
			dropDownButton3.Text = "dropDownButton3";
			// 
			// gridControl2
			// 
			gridControl2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			gridControl2.Location = new Point(3, 32);
			gridControl2.MainView = gridView2;
			gridControl2.Name = "gridControl2";
			gridControl2.Size = new Size(931, 463);
			gridControl2.TabIndex = 0;
			gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView2 });
			// 
			// gridView2
			// 
			gridView2.GridControl = gridControl2;
			gridView2.Name = "gridView2";
			gridView2.CellValueChanged += GridView2_CellValueChanged;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSize = true;
			ClientSize = new Size(945, 526);
			Controls.Add(tabControl1);
			Margin = new Padding(4, 3, 4, 3);
			Name = "Form1";
			Text = "Form1";
			tabControl1.ResumeLayout(false);
			tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)layoutControl2).EndInit();
			layoutControl2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)layoutControlGroup1).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem8).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem9).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem10).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem11).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem12).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem13).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem14).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem15).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem16).EndInit();
			tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)layoutControl1).EndInit();
			layoutControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)Root).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem1).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem6).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem2).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem4).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem3).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem5).EndInit();
			((System.ComponentModel.ISupportInitialize)layoutControlItem7).EndInit();
			tabPage3.ResumeLayout(false);
			tabPage3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
			((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
			tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)schedulerControl2).EndInit();
			((System.ComponentModel.ISupportInitialize)schedulerDataStorage1).EndInit();
			tabPage5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)schedulerControl4).EndInit();
			((System.ComponentModel.ISupportInitialize)schedulerDataStorage2).EndInit();
			tabPage6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)gridControl2).EndInit();
			((System.ComponentModel.ISupportInitialize)gridView2).EndInit();
			ResumeLayout(false);
		}

		private void SchedulerDataStorage1_AppointmentInserting(object sender, PersistentObjectCancelEventArgs e)
		{
			SchedulerDataStorage store = (SchedulerDataStorage)sender;
			Appointment app = (Appointment)e.Object;
			try{ int hallid = Convert.ToInt32(app.ResourceId); }
			catch
			{
				MessageBox.Show("Pasirinkite salę");
				e.Cancel = true;
				return;
			}
			if (app.Subject != string.Empty)
			{
				if (AvailabilityCalls.IsAvailable(Convert.ToInt32(app.ResourceId), app.Start, app.End) != null)
				{
					EventCalls.InsertEvent(app.Subject, app.Start.ToString(), app.End.ToString(), Convert.ToInt32(app.ResourceId));
					int eventid = EventCalls.FindEvent(app.Subject, app.Start.ToString(), app.End.ToString(), Convert.ToInt32(app.ResourceId));
					HelperFunctions.AddAllSeatsToEvent(Convert.ToInt32(app.ResourceId), eventid);
					UpdateFunctions.UpdateAvailabilty(Convert.ToInt32(app.ResourceId), app.Start, app.End);
					listView4.Items.Clear();
					UpdateFunctions.UpdateEventList(listView4, Convert.ToInt32(app.ResourceId));
				}
			}
			else
			{
				MessageBox.Show("Patikrinkite ar suvesta informacija teisinga");
				e.Cancel = true;
				return;
			}
		}

		private void SchedulerDataStorage2_AppointmentDeleting(object sender, PersistentObjectCancelEventArgs e)
		{
			SchedulerDataStorage store = (SchedulerDataStorage)sender;
			Appointment app = (Appointment)e.Object;
				int seatid = SeatReservationCalls.FindSeat(Convert.ToInt32(app.ResourceId), app.Subject);
				SeatReservationCalls.UpdateReservation(Convert.ToInt32(app.ResourceId), seatid, 0, DateTime.Now);
		}

		private void SchedulerControl2_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
		{
			var scheduler = (SchedulerControl)sender;
			DevExpress.XtraScheduler.UI.AppointmentForm form = new DevExpress.XtraScheduler.UI.AppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm);
			HideUnusedControls(form);
			e.Handled = true;
			form.ShowDialog();
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
        private TextBox textBox1;
        private Button button2;
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
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl2;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage1;
		private TabPage tabPage5;
		private SchedulerControl schedulerControl4;
		private SchedulerDataStorage schedulerDataStorage2;
		private TabPage tabPage6;
		private GridControl gridControl2;
		private GridView gridView2;
		private DropDownButton dropDownButton3;
		private DevExpress.XtraLayout.LayoutControl layoutControl1;
		private DevExpress.XtraLayout.LayoutControlGroup Root;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
		private CheckedListBox checkedListBox1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
		private DevExpress.XtraLayout.LayoutControl layoutControl2;
		private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem14;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem15;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem16;
	}
}
