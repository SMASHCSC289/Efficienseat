namespace Efficienseat
{
    partial class Attendee_List
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Unassigned", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Table 1", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Table 2", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Table 3", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Table 4", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Table 5", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Table 6", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Table 7", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Table 8", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Table 9", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("Table 10", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendee_List));
            this.lvwAttendee = new System.Windows.Forms.ListView();
            this.First_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Last_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Guest_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Response = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FoodAllergy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Comments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsAttendee = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiRemoveAttendee = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddAtendee = new System.Windows.Forms.Button();
            this.btnChangeView = new System.Windows.Forms.Button();
            this.imlTableNumbers = new System.Windows.Forms.ImageList(this.components);
            this.btnEditEntry = new System.Windows.Forms.Button();
            this.btnRemoveAttendee = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmsAttendee.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwAttendee
            // 
            this.lvwAttendee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAttendee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwAttendee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.First_Name,
            this.Last_Name,
            this.Guest_ID,
            this.Response,
            this.FoodAllergy,
            this.Comments});
            this.lvwAttendee.ContextMenuStrip = this.cmsAttendee;
            this.lvwAttendee.FullRowSelect = true;
            this.lvwAttendee.GridLines = true;
            listViewGroup1.Header = "Unassigned";
            listViewGroup1.Name = "unassigned";
            listViewGroup2.Header = "Table 1";
            listViewGroup2.Name = "table1";
            listViewGroup3.Header = "Table 2";
            listViewGroup3.Name = "table2";
            listViewGroup4.Header = "Table 3";
            listViewGroup4.Name = "table3";
            listViewGroup5.Header = "Table 4";
            listViewGroup5.Name = "table4";
            listViewGroup6.Header = "Table 5";
            listViewGroup6.Name = "table5";
            listViewGroup7.Header = "Table 6";
            listViewGroup7.Name = "table6";
            listViewGroup8.Header = "Table 7";
            listViewGroup8.Name = "table7";
            listViewGroup9.Header = "Table 8";
            listViewGroup9.Name = "table8";
            listViewGroup10.Header = "Table 9";
            listViewGroup10.Name = "table9";
            listViewGroup11.Header = "Table 10";
            listViewGroup11.Name = "table10";
            this.lvwAttendee.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10,
            listViewGroup11});
            this.lvwAttendee.Location = new System.Drawing.Point(1, 34);
            this.lvwAttendee.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lvwAttendee.Name = "lvwAttendee";
            this.lvwAttendee.Size = new System.Drawing.Size(506, 453);
            this.lvwAttendee.TabIndex = 0;
            this.lvwAttendee.UseCompatibleStateImageBehavior = false;
            this.lvwAttendee.View = System.Windows.Forms.View.Tile;
            // 
            // First_Name
            // 
            this.First_Name.Text = "First_Name";
            // 
            // Last_Name
            // 
            this.Last_Name.Text = "Last Name";
            // 
            // Guest_ID
            // 
            this.Guest_ID.Text = "Guest_ID";
            // 
            // Response
            // 
            this.Response.Text = "Response";
            // 
            // FoodAllergy
            // 
            this.FoodAllergy.Text = "Food Allergy";
            // 
            // Comments
            // 
            this.Comments.Text = "Comments";
            // 
            // cmsAttendee
            // 
            this.cmsAttendee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiRemoveAttendee,
            this.tmiEdit,
            this.tmiImport});
            this.cmsAttendee.Name = "contextMenuStrip1";
            this.cmsAttendee.Size = new System.Drawing.Size(118, 70);
            // 
            // tmiRemoveAttendee
            // 
            this.tmiRemoveAttendee.Name = "tmiRemoveAttendee";
            this.tmiRemoveAttendee.Size = new System.Drawing.Size(117, 22);
            this.tmiRemoveAttendee.Text = "Remove";
            this.tmiRemoveAttendee.Click += new System.EventHandler(this.tmiRemoveAttendee_Click);
            // 
            // tmiEdit
            // 
            this.tmiEdit.Name = "tmiEdit";
            this.tmiEdit.Size = new System.Drawing.Size(117, 22);
            this.tmiEdit.Text = "Edit";
            this.tmiEdit.Click += new System.EventHandler(this.tmiEdit_Click);
            // 
            // tmiImport
            // 
            this.tmiImport.Name = "tmiImport";
            this.tmiImport.Size = new System.Drawing.Size(117, 22);
            this.tmiImport.Text = "Import";
            this.tmiImport.Click += new System.EventHandler(this.tmiImport_Click);
            // 
            // btnAddAtendee
            // 
            this.btnAddAtendee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddAtendee.Location = new System.Drawing.Point(3, 3);
            this.btnAddAtendee.Name = "btnAddAtendee";
            this.btnAddAtendee.Size = new System.Drawing.Size(120, 23);
            this.btnAddAtendee.TabIndex = 1;
            this.btnAddAtendee.Text = "Add Attendee";
            this.btnAddAtendee.UseVisualStyleBackColor = true;
            this.btnAddAtendee.Click += new System.EventHandler(this.btnAddAttendee_Click);
            // 
            // btnChangeView
            // 
            this.btnChangeView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChangeView.Location = new System.Drawing.Point(255, 3);
            this.btnChangeView.Name = "btnChangeView";
            this.btnChangeView.Size = new System.Drawing.Size(120, 23);
            this.btnChangeView.TabIndex = 3;
            this.btnChangeView.Text = "Change View";
            this.btnChangeView.UseVisualStyleBackColor = true;
            this.btnChangeView.Click += new System.EventHandler(this.btnChangeView_Click);
            // 
            // imlTableNumbers
            // 
            this.imlTableNumbers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTableNumbers.ImageStream")));
            this.imlTableNumbers.TransparentColor = System.Drawing.Color.Transparent;
            this.imlTableNumbers.Images.SetKeyName(0, "TNno.png");
            this.imlTableNumbers.Images.SetKeyName(1, "TN1.png");
            this.imlTableNumbers.Images.SetKeyName(2, "tn2.png");
            // 
            // btnEditEntry
            // 
            this.btnEditEntry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditEntry.Location = new System.Drawing.Point(381, 3);
            this.btnEditEntry.Name = "btnEditEntry";
            this.btnEditEntry.Size = new System.Drawing.Size(120, 23);
            this.btnEditEntry.TabIndex = 4;
            this.btnEditEntry.Text = "Edit Entry";
            this.btnEditEntry.UseVisualStyleBackColor = true;
            this.btnEditEntry.Click += new System.EventHandler(this.btnEditEntry_Click);
            // 
            // btnRemoveAttendee
            // 
            this.btnRemoveAttendee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRemoveAttendee.Location = new System.Drawing.Point(129, 3);
            this.btnRemoveAttendee.Name = "btnRemoveAttendee";
            this.btnRemoveAttendee.Size = new System.Drawing.Size(120, 23);
            this.btnRemoveAttendee.TabIndex = 5;
            this.btnRemoveAttendee.Text = "Remove Attendee";
            this.btnRemoveAttendee.UseVisualStyleBackColor = true;
            this.btnRemoveAttendee.Click += new System.EventHandler(this.btnRemoveAttendee_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnAddAtendee);
            this.flowLayoutPanel1.Controls.Add(this.btnRemoveAttendee);
            this.flowLayoutPanel1.Controls.Add(this.btnChangeView);
            this.flowLayoutPanel1.Controls.Add(this.btnEditEntry);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(506, 32);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // Attendee_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 488);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lvwAttendee);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(508, 9999);
            this.MinimumSize = new System.Drawing.Size(292, 0);
            this.Name = "Attendee_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Attendee_List_Load);
            this.Resize += new System.EventHandler(this.Attendee_List_Resize);
            this.cmsAttendee.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwAttendee;
        private System.Windows.Forms.Button btnAddAtendee;
        private System.Windows.Forms.ColumnHeader First_Name;
        private System.Windows.Forms.ColumnHeader Response;
        private System.Windows.Forms.ColumnHeader FoodAllergy;
        private System.Windows.Forms.ColumnHeader Comments;
        private System.Windows.Forms.Button btnChangeView;
        private System.Windows.Forms.ImageList imlTableNumbers;
        private System.Windows.Forms.Button btnEditEntry;
        private System.Windows.Forms.Button btnRemoveAttendee;
        private System.Windows.Forms.ContextMenuStrip cmsAttendee;
        private System.Windows.Forms.ToolStripMenuItem tmiRemoveAttendee;
        private System.Windows.Forms.ToolStripMenuItem tmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tmiImport;
        private System.Windows.Forms.ColumnHeader Last_Name;
        private System.Windows.Forms.ColumnHeader Guest_ID;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}