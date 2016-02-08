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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendee_List));
            this.lvwAttendee = new System.Windows.Forms.ListView();
            this.Guest_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Response = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Comments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsAttendee = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiRemoveAttendee = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddAtendee = new System.Windows.Forms.Button();
            this.btnChangeView = new System.Windows.Forms.Button();
            this.imlTableNumbers = new System.Windows.Forms.ImageList(this.components);
            this.btnEditEntry = new System.Windows.Forms.Button();
            this.btnRemoveAttendee = new System.Windows.Forms.Button();
            this.cmsAttendee.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwAttendee
            // 
            this.lvwAttendee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAttendee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwAttendee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Guest_Name,
            this.Response,
            this.Address,
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
            this.lvwAttendee.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.lvwAttendee.Location = new System.Drawing.Point(12, 41);
            this.lvwAttendee.Name = "lvwAttendee";
            this.lvwAttendee.Size = new System.Drawing.Size(483, 466);
            this.lvwAttendee.TabIndex = 0;
            this.lvwAttendee.UseCompatibleStateImageBehavior = false;
            this.lvwAttendee.View = System.Windows.Forms.View.Tile;
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
            // cmsAttendee
            // 
            this.cmsAttendee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiRemoveAttendee,
            this.tmiEdit});
            this.cmsAttendee.Name = "contextMenuStrip1";
            this.cmsAttendee.Size = new System.Drawing.Size(153, 70);
            // 
            // tmiRemoveAttendee
            // 
            this.tmiRemoveAttendee.Name = "tmiRemoveAttendee";
            this.tmiRemoveAttendee.Size = new System.Drawing.Size(152, 22);
            this.tmiRemoveAttendee.Text = "Remove";
            this.tmiRemoveAttendee.Click += new System.EventHandler(this.tmiRemoveAttendee_Click);
            // 
            // tmiEdit
            // 
            this.tmiEdit.Name = "tmiEdit";
            this.tmiEdit.Size = new System.Drawing.Size(152, 22);
            this.tmiEdit.Text = "Edit";
            this.tmiEdit.Click += new System.EventHandler(this.tmiEdit_Click);
            // 
            // btnAddAtendee
            // 
            this.btnAddAtendee.Location = new System.Drawing.Point(12, 12);
            this.btnAddAtendee.Name = "btnAddAtendee";
            this.btnAddAtendee.Size = new System.Drawing.Size(120, 23);
            this.btnAddAtendee.TabIndex = 1;
            this.btnAddAtendee.Text = "Add Attendee";
            this.btnAddAtendee.UseVisualStyleBackColor = true;
            this.btnAddAtendee.Click += new System.EventHandler(this.btnAddAttendee_Click);
            // 
            // btnChangeView
            // 
            this.btnChangeView.Location = new System.Drawing.Point(249, 12);
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
            this.btnEditEntry.Location = new System.Drawing.Point(375, 12);
            this.btnEditEntry.Name = "btnEditEntry";
            this.btnEditEntry.Size = new System.Drawing.Size(120, 23);
            this.btnEditEntry.TabIndex = 4;
            this.btnEditEntry.Text = "Edit Entry";
            this.btnEditEntry.UseVisualStyleBackColor = true;
            this.btnEditEntry.Click += new System.EventHandler(this.btnEditEntry_Click);
            // 
            // btnRemoveAttendee
            // 
            this.btnRemoveAttendee.Location = new System.Drawing.Point(138, 12);
            this.btnRemoveAttendee.Name = "btnRemoveAttendee";
            this.btnRemoveAttendee.Size = new System.Drawing.Size(105, 23);
            this.btnRemoveAttendee.TabIndex = 5;
            this.btnRemoveAttendee.Text = "Remove Attendee";
            this.btnRemoveAttendee.UseVisualStyleBackColor = true;
            this.btnRemoveAttendee.Click += new System.EventHandler(this.btnRemoveAttendee_Click);
            // 
            // Attendee_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 519);
            this.Controls.Add(this.btnRemoveAttendee);
            this.Controls.Add(this.btnEditEntry);
            this.Controls.Add(this.btnChangeView);
            this.Controls.Add(this.btnAddAtendee);
            this.Controls.Add(this.lvwAttendee);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Attendee_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attendee List";
            this.Load += new System.EventHandler(this.Attendee_List_Load);
            this.cmsAttendee.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwAttendee;
        private System.Windows.Forms.Button btnAddAtendee;
        private System.Windows.Forms.ColumnHeader Guest_Name;
        private System.Windows.Forms.ColumnHeader Response;
        private System.Windows.Forms.ColumnHeader Address;
        private System.Windows.Forms.ColumnHeader Comments;
        private System.Windows.Forms.Button btnChangeView;
        private System.Windows.Forms.ImageList imlTableNumbers;
        private System.Windows.Forms.Button btnEditEntry;
        private System.Windows.Forms.Button btnRemoveAttendee;
        private System.Windows.Forms.ContextMenuStrip cmsAttendee;
        private System.Windows.Forms.ToolStripMenuItem tmiRemoveAttendee;
        private System.Windows.Forms.ToolStripMenuItem tmiEdit;
    }
}