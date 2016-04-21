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
            System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("Awaiting Response", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup15 = new System.Windows.Forms.ListViewGroup("Declined", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup16 = new System.Windows.Forms.ListViewGroup("Accepted", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup17 = new System.Windows.Forms.ListViewGroup("Table 1", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup18 = new System.Windows.Forms.ListViewGroup("Table 2", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup19 = new System.Windows.Forms.ListViewGroup("Table 3", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup20 = new System.Windows.Forms.ListViewGroup("Table 4", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup21 = new System.Windows.Forms.ListViewGroup("Table 5", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup22 = new System.Windows.Forms.ListViewGroup("Table 6", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup23 = new System.Windows.Forms.ListViewGroup("Table 7", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup24 = new System.Windows.Forms.ListViewGroup("Table 8", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup25 = new System.Windows.Forms.ListViewGroup("Table 9", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup26 = new System.Windows.Forms.ListViewGroup("Table 10", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendee_List));
            this.lvwAttendee = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colResponse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGuestID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAllergy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colComments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsAttendee = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmiRemoveAttendee = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.importExcelFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imlTableNumbers = new System.Windows.Forms.ImageList(this.components);
            this.pnlGuestCount = new System.Windows.Forms.Panel();
            this.lblGuestCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChangeView = new System.Windows.Forms.Button();
            this.btnEditEntry = new System.Windows.Forms.Button();
            this.btnRemoveAttendee = new System.Windows.Forms.Button();
            this.btnAddAtendee = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmsAttendee.SuspendLayout();
            this.pnlGuestCount.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwAttendee
            // 
            this.lvwAttendee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAttendee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwAttendee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colResponse,
            this.colGuestID,
            this.colAllergy,
            this.colComments});
            this.lvwAttendee.ContextMenuStrip = this.cmsAttendee;
            this.lvwAttendee.FullRowSelect = true;
            this.lvwAttendee.GridLines = true;
            listViewGroup14.Header = "Awaiting Response";
            listViewGroup14.Name = "noresponse";
            listViewGroup15.Header = "Declined";
            listViewGroup15.Name = "decline";
            listViewGroup16.Header = "Accepted";
            listViewGroup16.Name = "unassigned";
            listViewGroup17.Header = "Table 1";
            listViewGroup17.Name = "table1";
            listViewGroup18.Header = "Table 2";
            listViewGroup18.Name = "table2";
            listViewGroup19.Header = "Table 3";
            listViewGroup19.Name = "table3";
            listViewGroup20.Header = "Table 4";
            listViewGroup20.Name = "table4";
            listViewGroup21.Header = "Table 5";
            listViewGroup21.Name = "table5";
            listViewGroup22.Header = "Table 6";
            listViewGroup22.Name = "table6";
            listViewGroup23.Header = "Table 7";
            listViewGroup23.Name = "table7";
            listViewGroup24.Header = "Table 8";
            listViewGroup24.Name = "table8";
            listViewGroup25.Header = "Table 9";
            listViewGroup25.Name = "table9";
            listViewGroup26.Header = "Table 10";
            listViewGroup26.Name = "table10";
            this.lvwAttendee.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup14,
            listViewGroup15,
            listViewGroup16,
            listViewGroup17,
            listViewGroup18,
            listViewGroup19,
            listViewGroup20,
            listViewGroup21,
            listViewGroup22,
            listViewGroup23,
            listViewGroup24,
            listViewGroup25,
            listViewGroup26});
            this.lvwAttendee.Location = new System.Drawing.Point(1, 34);
            this.lvwAttendee.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lvwAttendee.Name = "lvwAttendee";
            this.lvwAttendee.Size = new System.Drawing.Size(506, 426);
            this.lvwAttendee.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwAttendee.TabIndex = 0;
            this.lvwAttendee.UseCompatibleStateImageBehavior = false;
            this.lvwAttendee.View = System.Windows.Forms.View.Tile;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            // 
            // colResponse
            // 
            this.colResponse.Text = "Response";
            this.colResponse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colGuestID
            // 
            this.colGuestID.Text = "Guest ID";
            this.colGuestID.Width = 0;
            // 
            // colAllergy
            // 
            this.colAllergy.Text = "Allergy";
            this.colAllergy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colComments
            // 
            this.colComments.Text = "Comments";
            this.colComments.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmsAttendee
            // 
            this.cmsAttendee.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmiRemoveAttendee,
            this.tmiEdit,
            this.tmiImport,
            this.importExcelFileToolStripMenuItem});
            this.cmsAttendee.Name = "contextMenuStrip1";
            this.cmsAttendee.Size = new System.Drawing.Size(154, 92);
            // 
            // tmiRemoveAttendee
            // 
            this.tmiRemoveAttendee.Name = "tmiRemoveAttendee";
            this.tmiRemoveAttendee.Size = new System.Drawing.Size(153, 22);
            this.tmiRemoveAttendee.Text = "Remove";
            this.tmiRemoveAttendee.Click += new System.EventHandler(this.tmiRemoveAttendee_Click);
            // 
            // tmiEdit
            // 
            this.tmiEdit.Name = "tmiEdit";
            this.tmiEdit.Size = new System.Drawing.Size(153, 22);
            this.tmiEdit.Text = "Edit";
            this.tmiEdit.Click += new System.EventHandler(this.tmiEdit_Click);
            // 
            // tmiImport
            // 
            this.tmiImport.Name = "tmiImport";
            this.tmiImport.Size = new System.Drawing.Size(153, 22);
            this.tmiImport.Text = "Import Text File";
            this.tmiImport.Click += new System.EventHandler(this.tmiImport_Click);
            // 
            // importExcelFileToolStripMenuItem
            // 
            this.importExcelFileToolStripMenuItem.Name = "importExcelFileToolStripMenuItem";
            this.importExcelFileToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.importExcelFileToolStripMenuItem.Text = "Import Excel File";
            this.importExcelFileToolStripMenuItem.Click += new System.EventHandler(this.importExcelFileToolStripMenuItem_Click);
            // 
            // imlTableNumbers
            // 
            this.imlTableNumbers.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlTableNumbers.ImageStream")));
            this.imlTableNumbers.TransparentColor = System.Drawing.Color.Transparent;
            this.imlTableNumbers.Images.SetKeyName(0, "TNno.png");
            this.imlTableNumbers.Images.SetKeyName(1, "TN1.png");
            this.imlTableNumbers.Images.SetKeyName(2, "tn2.png");
            // 
            // pnlGuestCount
            // 
            this.pnlGuestCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGuestCount.Controls.Add(this.lblGuestCount);
            this.pnlGuestCount.Controls.Add(this.label1);
            this.pnlGuestCount.Location = new System.Drawing.Point(1, 460);
            this.pnlGuestCount.Name = "pnlGuestCount";
            this.pnlGuestCount.Size = new System.Drawing.Size(506, 27);
            this.pnlGuestCount.TabIndex = 7;
            // 
            // lblGuestCount
            // 
            this.lblGuestCount.AutoSize = true;
            this.lblGuestCount.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestCount.Location = new System.Drawing.Point(115, 6);
            this.lblGuestCount.Name = "lblGuestCount";
            this.lblGuestCount.Size = new System.Drawing.Size(13, 13);
            this.lblGuestCount.TabIndex = 1;
            this.lblGuestCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Guest Count :";
            // 
            // btnChangeView
            // 
            this.btnChangeView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnChangeView.Enabled = false;
            this.btnChangeView.Location = new System.Drawing.Point(381, 3);
            this.btnChangeView.Name = "btnChangeView";
            this.btnChangeView.Size = new System.Drawing.Size(120, 23);
            this.btnChangeView.TabIndex = 3;
            this.btnChangeView.Text = "Change View";
            this.btnChangeView.UseVisualStyleBackColor = true;
            this.btnChangeView.Click += new System.EventHandler(this.btnChangeView_Click);
            // 
            // btnEditEntry
            // 
            this.btnEditEntry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditEntry.Location = new System.Drawing.Point(255, 3);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnAddAtendee);
            this.flowLayoutPanel1.Controls.Add(this.btnRemoveAttendee);
            this.flowLayoutPanel1.Controls.Add(this.btnEditEntry);
            this.flowLayoutPanel1.Controls.Add(this.btnChangeView);
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
            this.Controls.Add(this.pnlGuestCount);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lvwAttendee);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(508, 9999);
            this.MinimumSize = new System.Drawing.Size(292, 0);
            this.Name = "Attendee_List";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Resize += new System.EventHandler(this.Attendee_List_Resize);
            this.cmsAttendee.ResumeLayout(false);
            this.pnlGuestCount.ResumeLayout(false);
            this.pnlGuestCount.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwAttendee;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ImageList imlTableNumbers;
        private System.Windows.Forms.ContextMenuStrip cmsAttendee;
        private System.Windows.Forms.ToolStripMenuItem tmiRemoveAttendee;
        private System.Windows.Forms.ToolStripMenuItem tmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tmiImport;
        private System.Windows.Forms.ColumnHeader colResponse;
        private System.Windows.Forms.ColumnHeader colGuestID;
        private System.Windows.Forms.ColumnHeader colAllergy;
        private System.Windows.Forms.ColumnHeader colComments;
        private System.Windows.Forms.ToolStripMenuItem importExcelFileToolStripMenuItem;
        private System.Windows.Forms.Panel pnlGuestCount;
        private System.Windows.Forms.Label lblGuestCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChangeView;
        private System.Windows.Forms.Button btnEditEntry;
        private System.Windows.Forms.Button btnRemoveAttendee;
        private System.Windows.Forms.Button btnAddAtendee;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}