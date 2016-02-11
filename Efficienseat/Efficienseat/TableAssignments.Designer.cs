namespace Efficienseat
{
    partial class TableAssignments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableAssignments));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.imageList_32 = new System.Windows.Forms.ImageList(this.components);
            this.imageList_16 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lvwUnseated = new System.Windows.Forms.ListView();
            this.Guest_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Response = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Comments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Guest_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvwSeat7 = new System.Windows.Forms.ListView();
            this.lvwSeat8 = new System.Windows.Forms.ListView();
            this.lvwSeat9 = new System.Windows.Forms.ListView();
            this.lvwSeat10 = new System.Windows.Forms.ListView();
            this.lvwSeat4 = new System.Windows.Forms.ListView();
            this.lvwSeat5 = new System.Windows.Forms.ListView();
            this.lvwSeat6 = new System.Windows.Forms.ListView();
            this.lvwSeat3 = new System.Windows.Forms.ListView();
            this.lvwSeat2 = new System.Windows.Forms.ListView();
            this.lvwSeat1 = new System.Windows.Forms.ListView();
            this.imageList_Seat_32 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Items.AddRange(new object[] {
            "Table 1",
            "Table 2",
            "Table 3",
            "Table 4",
            "Table 5"});
            this.comboBox1.Location = new System.Drawing.Point(11, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Items.AddRange(new object[] {
            "Circle",
            "Square",
            "Rectangle"});
            this.comboBox2.Location = new System.Drawing.Point(217, 28);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 21);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectionChangeCommitted);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(423, 29);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(86, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // imageList_32
            // 
            this.imageList_32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_32.ImageStream")));
            this.imageList_32.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_32.Images.SetKeyName(0, "jumping28_Blk_32.png");
            this.imageList_32.Images.SetKeyName(1, "jumping28_Red_32.png");
            this.imageList_32.Images.SetKeyName(2, "dining5_Blk.png");
            // 
            // imageList_16
            // 
            this.imageList_16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_16.ImageStream")));
            this.imageList_16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_16.Images.SetKeyName(0, "jumping28_Blk_16.png");
            this.imageList_16.Images.SetKeyName(1, "jumping28_Red_16.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Guest Table";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Table Shape";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of Seats";
            // 
            // lvwUnseated
            // 
            this.lvwUnseated.AllowDrop = true;
            this.lvwUnseated.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwUnseated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwUnseated.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Guest_Name,
            this.Response,
            this.Address,
            this.Comments,
            this.Guest_ID});
            this.lvwUnseated.FullRowSelect = true;
            this.lvwUnseated.GridLines = true;
            this.lvwUnseated.LargeImageList = this.imageList_32;
            this.lvwUnseated.Location = new System.Drawing.Point(386, 64);
            this.lvwUnseated.MultiSelect = false;
            this.lvwUnseated.Name = "lvwUnseated";
            this.lvwUnseated.ShowItemToolTips = true;
            this.lvwUnseated.Size = new System.Drawing.Size(124, 446);
            this.lvwUnseated.SmallImageList = this.imageList_16;
            this.lvwUnseated.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwUnseated.TabIndex = 8;
            this.lvwUnseated.UseCompatibleStateImageBehavior = false;
            this.lvwUnseated.View = System.Windows.Forms.View.SmallIcon;
            this.lvwUnseated.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.lvwUnseated.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.lvwUnseated.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.lvwUnseated.DragLeave += new System.EventHandler(this.listView_DragLeave);
            // 
            // Guest_Name
            // 
            this.Guest_Name.Text = "Guest Name";
            // 
            // Response
            // 
            this.Response.Text = "Response";
            // 
            // Address
            // 
            this.Address.Text = "Address";
            // 
            // Comments
            // 
            this.Comments.Text = "Comments";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lvwSeat7);
            this.panel1.Controls.Add(this.lvwSeat8);
            this.panel1.Controls.Add(this.lvwSeat9);
            this.panel1.Controls.Add(this.lvwSeat10);
            this.panel1.Controls.Add(this.lvwSeat4);
            this.panel1.Controls.Add(this.lvwSeat5);
            this.panel1.Controls.Add(this.lvwSeat6);
            this.panel1.Controls.Add(this.lvwSeat3);
            this.panel1.Controls.Add(this.lvwSeat2);
            this.panel1.Controls.Add(this.lvwSeat1);
            this.panel1.Location = new System.Drawing.Point(12, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 446);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lvwSeat7
            // 
            this.lvwSeat7.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvwSeat7.AllowDrop = true;
            this.lvwSeat7.BackColor = System.Drawing.Color.White;
            this.lvwSeat7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwSeat7.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwSeat7.LargeImageList = this.imageList_Seat_32;
            this.lvwSeat7.Location = new System.Drawing.Point(79, 3);
            this.lvwSeat7.MultiSelect = false;
            this.lvwSeat7.Name = "lvwSeat7";
            this.lvwSeat7.Scrollable = false;
            this.lvwSeat7.ShowItemToolTips = true;
            this.lvwSeat7.Size = new System.Drawing.Size(70, 65);
            this.lvwSeat7.SmallImageList = this.imageList_16;
            this.lvwSeat7.TabIndex = 9;
            this.lvwSeat7.UseCompatibleStateImageBehavior = false;
            this.lvwSeat7.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.lvwSeat7.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.lvwSeat7.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.lvwSeat7.DragLeave += new System.EventHandler(this.listView_DragLeave);
            // 
            // lvwSeat8
            // 
            this.lvwSeat8.AllowDrop = true;
            this.lvwSeat8.BackColor = System.Drawing.Color.White;
            this.lvwSeat8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwSeat8.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwSeat8.LargeImageList = this.imageList_Seat_32;
            this.lvwSeat8.Location = new System.Drawing.Point(79, 74);
            this.lvwSeat8.MultiSelect = false;
            this.lvwSeat8.Name = "lvwSeat8";
            this.lvwSeat8.Scrollable = false;
            this.lvwSeat8.ShowItemToolTips = true;
            this.lvwSeat8.Size = new System.Drawing.Size(70, 65);
            this.lvwSeat8.SmallImageList = this.imageList_16;
            this.lvwSeat8.TabIndex = 8;
            this.lvwSeat8.UseCompatibleStateImageBehavior = false;
            this.lvwSeat8.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.lvwSeat8.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.lvwSeat8.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.lvwSeat8.DragLeave += new System.EventHandler(this.listView_DragLeave);
            // 
            // lvwSeat9
            // 
            this.lvwSeat9.AllowDrop = true;
            this.lvwSeat9.BackColor = System.Drawing.Color.White;
            this.lvwSeat9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwSeat9.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwSeat9.LargeImageList = this.imageList_Seat_32;
            this.lvwSeat9.Location = new System.Drawing.Point(79, 145);
            this.lvwSeat9.MultiSelect = false;
            this.lvwSeat9.Name = "lvwSeat9";
            this.lvwSeat9.Scrollable = false;
            this.lvwSeat9.ShowItemToolTips = true;
            this.lvwSeat9.Size = new System.Drawing.Size(70, 65);
            this.lvwSeat9.SmallImageList = this.imageList_16;
            this.lvwSeat9.TabIndex = 7;
            this.lvwSeat9.UseCompatibleStateImageBehavior = false;
            this.lvwSeat9.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.lvwSeat9.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.lvwSeat9.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.lvwSeat9.DragLeave += new System.EventHandler(this.listView_DragLeave);
            // 
            // lvwSeat10
            // 
            this.lvwSeat10.AllowDrop = true;
            this.lvwSeat10.BackColor = System.Drawing.Color.White;
            this.lvwSeat10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwSeat10.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwSeat10.LargeImageList = this.imageList_Seat_32;
            this.lvwSeat10.Location = new System.Drawing.Point(79, 216);
            this.lvwSeat10.MultiSelect = false;
            this.lvwSeat10.Name = "lvwSeat10";
            this.lvwSeat10.Scrollable = false;
            this.lvwSeat10.ShowItemToolTips = true;
            this.lvwSeat10.Size = new System.Drawing.Size(70, 65);
            this.lvwSeat10.SmallImageList = this.imageList_16;
            this.lvwSeat10.TabIndex = 6;
            this.lvwSeat10.UseCompatibleStateImageBehavior = false;
            this.lvwSeat10.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.lvwSeat10.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.lvwSeat10.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.lvwSeat10.DragLeave += new System.EventHandler(this.listView_DragLeave);
            // 
            // lvwSeat4
            // 
            this.lvwSeat4.AllowDrop = true;
            this.lvwSeat4.BackColor = System.Drawing.Color.White;
            this.lvwSeat4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwSeat4.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwSeat4.LargeImageList = this.imageList_Seat_32;
            this.lvwSeat4.Location = new System.Drawing.Point(3, 216);
            this.lvwSeat4.MultiSelect = false;
            this.lvwSeat4.Name = "lvwSeat4";
            this.lvwSeat4.Scrollable = false;
            this.lvwSeat4.ShowItemToolTips = true;
            this.lvwSeat4.Size = new System.Drawing.Size(70, 65);
            this.lvwSeat4.SmallImageList = this.imageList_16;
            this.lvwSeat4.TabIndex = 5;
            this.lvwSeat4.UseCompatibleStateImageBehavior = false;
            this.lvwSeat4.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.lvwSeat4.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.lvwSeat4.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.lvwSeat4.DragLeave += new System.EventHandler(this.listView_DragLeave);
            // 
            // lvwSeat5
            // 
            this.lvwSeat5.AllowDrop = true;
            this.lvwSeat5.BackColor = System.Drawing.Color.White;
            this.lvwSeat5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwSeat5.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwSeat5.LargeImageList = this.imageList_Seat_32;
            this.lvwSeat5.Location = new System.Drawing.Point(3, 287);
            this.lvwSeat5.MultiSelect = false;
            this.lvwSeat5.Name = "lvwSeat5";
            this.lvwSeat5.Scrollable = false;
            this.lvwSeat5.ShowItemToolTips = true;
            this.lvwSeat5.Size = new System.Drawing.Size(71, 65);
            this.lvwSeat5.SmallImageList = this.imageList_16;
            this.lvwSeat5.TabIndex = 4;
            this.lvwSeat5.UseCompatibleStateImageBehavior = false;
            this.lvwSeat5.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.lvwSeat5.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.lvwSeat5.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.lvwSeat5.DragLeave += new System.EventHandler(this.listView_DragLeave);
            // 
            // lvwSeat6
            // 
            this.lvwSeat6.AllowDrop = true;
            this.lvwSeat6.BackColor = System.Drawing.Color.White;
            this.lvwSeat6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwSeat6.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwSeat6.LargeImageList = this.imageList_Seat_32;
            this.lvwSeat6.Location = new System.Drawing.Point(4, 358);
            this.lvwSeat6.MultiSelect = false;
            this.lvwSeat6.Name = "lvwSeat6";
            this.lvwSeat6.Scrollable = false;
            this.lvwSeat6.ShowItemToolTips = true;
            this.lvwSeat6.Size = new System.Drawing.Size(70, 65);
            this.lvwSeat6.SmallImageList = this.imageList_16;
            this.lvwSeat6.TabIndex = 3;
            this.lvwSeat6.UseCompatibleStateImageBehavior = false;
            this.lvwSeat6.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.lvwSeat6.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.lvwSeat6.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.lvwSeat6.DragLeave += new System.EventHandler(this.listView_DragLeave);
            // 
            // lvwSeat3
            // 
            this.lvwSeat3.AllowDrop = true;
            this.lvwSeat3.BackColor = System.Drawing.Color.White;
            this.lvwSeat3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwSeat3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwSeat3.LargeImageList = this.imageList_Seat_32;
            this.lvwSeat3.Location = new System.Drawing.Point(3, 145);
            this.lvwSeat3.MultiSelect = false;
            this.lvwSeat3.Name = "lvwSeat3";
            this.lvwSeat3.Scrollable = false;
            this.lvwSeat3.ShowItemToolTips = true;
            this.lvwSeat3.Size = new System.Drawing.Size(70, 65);
            this.lvwSeat3.SmallImageList = this.imageList_16;
            this.lvwSeat3.TabIndex = 2;
            this.lvwSeat3.UseCompatibleStateImageBehavior = false;
            this.lvwSeat3.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.lvwSeat3.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.lvwSeat3.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.lvwSeat3.DragLeave += new System.EventHandler(this.listView_DragLeave);
            // 
            // lvwSeat2
            // 
            this.lvwSeat2.AllowDrop = true;
            this.lvwSeat2.BackColor = System.Drawing.Color.White;
            this.lvwSeat2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwSeat2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwSeat2.LargeImageList = this.imageList_Seat_32;
            this.lvwSeat2.Location = new System.Drawing.Point(3, 74);
            this.lvwSeat2.MultiSelect = false;
            this.lvwSeat2.Name = "lvwSeat2";
            this.lvwSeat2.Scrollable = false;
            this.lvwSeat2.ShowItemToolTips = true;
            this.lvwSeat2.Size = new System.Drawing.Size(70, 65);
            this.lvwSeat2.SmallImageList = this.imageList_16;
            this.lvwSeat2.TabIndex = 1;
            this.lvwSeat2.UseCompatibleStateImageBehavior = false;
            this.lvwSeat2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.lvwSeat2.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.lvwSeat2.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.lvwSeat2.DragLeave += new System.EventHandler(this.listView_DragLeave);
            // 
            // lvwSeat1
            // 
            this.lvwSeat1.AllowDrop = true;
            this.lvwSeat1.BackColor = System.Drawing.Color.White;
            this.lvwSeat1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwSeat1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvwSeat1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwSeat1.LargeImageList = this.imageList_Seat_32;
            this.lvwSeat1.Location = new System.Drawing.Point(3, 3);
            this.lvwSeat1.MultiSelect = false;
            this.lvwSeat1.Name = "lvwSeat1";
            this.lvwSeat1.Scrollable = false;
            this.lvwSeat1.ShowItemToolTips = true;
            this.lvwSeat1.Size = new System.Drawing.Size(70, 65);
            this.lvwSeat1.SmallImageList = this.imageList_16;
            this.lvwSeat1.TabIndex = 0;
            this.lvwSeat1.UseCompatibleStateImageBehavior = false;
            this.lvwSeat1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView_ItemDrag);
            this.lvwSeat1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.lvwSeat1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_DragEnter);
            this.lvwSeat1.DragLeave += new System.EventHandler(this.listView_DragLeave);
            // 
            // imageList_Seat_32
            // 
            this.imageList_Seat_32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_Seat_32.ImageStream")));
            this.imageList_Seat_32.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_Seat_32.Images.SetKeyName(0, "seated_32_blk.png");
            this.imageList_Seat_32.Images.SetKeyName(1, "seated_32_red.png");
            this.imageList_Seat_32.Images.SetKeyName(2, "chair_32_blk.png");
            // 
            // TableAssignments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 519);
            this.Controls.Add(this.lvwUnseated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "TableAssignments";
            this.Text = "Table Assignments";
            this.Load += new System.EventHandler(this.TableAssignments_Load);
            this.Resize += new System.EventHandler(this.TableAssignments_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvwUnseated;
        private System.Windows.Forms.ColumnHeader Guest_Name;
        private System.Windows.Forms.ColumnHeader Response;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.ColumnHeader Comments;
        private System.Windows.Forms.ImageList imageList_32;
        private System.Windows.Forms.ImageList imageList_16;
        private System.Windows.Forms.ColumnHeader Guest_ID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvwSeat3;
        private System.Windows.Forms.ListView lvwSeat2;
        private System.Windows.Forms.ListView lvwSeat1;
        private System.Windows.Forms.ListView lvwSeat7;
        private System.Windows.Forms.ListView lvwSeat8;
        private System.Windows.Forms.ListView lvwSeat9;
        private System.Windows.Forms.ListView lvwSeat10;
        private System.Windows.Forms.ListView lvwSeat4;
        private System.Windows.Forms.ListView lvwSeat5;
        private System.Windows.Forms.ListView lvwSeat6;
        private System.Windows.Forms.ImageList imageList_Seat_32;
    }
}