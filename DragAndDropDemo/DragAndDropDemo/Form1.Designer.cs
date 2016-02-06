namespace DragAndDropDemo
{
    partial class Form1
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
            this.lbGuest = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbNumOfSeats = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbGuest
            // 
            this.lbGuest.FormattingEnabled = true;
            this.lbGuest.ItemHeight = 25;
            this.lbGuest.Items.AddRange(new object[] {
            "Jim Holt",
            "Marge Holt",
            "Mark Harriett",
            "Lisa Gray"});
            this.lbGuest.Location = new System.Drawing.Point(1058, 23);
            this.lbGuest.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lbGuest.Name = "lbGuest";
            this.lbGuest.Size = new System.Drawing.Size(236, 454);
            this.lbGuest.TabIndex = 0;
            this.lbGuest.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbGuest_MouseDown);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Location = new System.Drawing.Point(24, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 577);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // cbNumOfSeats
            // 
            this.cbNumOfSeats.FormattingEnabled = true;
            this.cbNumOfSeats.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbNumOfSeats.Location = new System.Drawing.Point(1058, 519);
            this.cbNumOfSeats.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbNumOfSeats.Name = "cbNumOfSeats";
            this.cbNumOfSeats.Size = new System.Drawing.Size(238, 33);
            this.cbNumOfSeats.TabIndex = 2;
            this.cbNumOfSeats.SelectedIndexChanged += new System.EventHandler(this.cbNumOfSeats_SelectedIndexChanged);
            this.cbNumOfSeats.Enter += new System.EventHandler(this.cbNumOfSeats_Enter);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1096, 586);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 673);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbNumOfSeats);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbGuest);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbGuest;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbNumOfSeats;
        private System.Windows.Forms.Button button1;
    }
}

