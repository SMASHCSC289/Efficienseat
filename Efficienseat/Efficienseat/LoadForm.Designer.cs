namespace Efficienseat
{
    partial class LoadForm
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
            this.rbtnCreate = new System.Windows.Forms.RadioButton();
            this.rbtnLoad = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.WeddingComboBox = new System.Windows.Forms.ComboBox();
            this.gbCreate = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.gbExisting = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label_Title = new System.Windows.Forms.Label();
            this.gbCreate.SuspendLayout();
            this.gbExisting.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnCreate
            // 
            this.rbtnCreate.AutoSize = true;
            this.rbtnCreate.Location = new System.Drawing.Point(31, 25);
            this.rbtnCreate.Name = "rbtnCreate";
            this.rbtnCreate.Size = new System.Drawing.Size(135, 17);
            this.rbtnCreate.TabIndex = 0;
            this.rbtnCreate.TabStop = true;
            this.rbtnCreate.Text = "Create New Wedding";
            this.rbtnCreate.UseVisualStyleBackColor = true;
            this.rbtnCreate.CheckedChanged += new System.EventHandler(this.CreateRadioButton_CheckedChanged);
            // 
            // rbtnLoad
            // 
            this.rbtnLoad.AutoSize = true;
            this.rbtnLoad.Location = new System.Drawing.Point(19, 33);
            this.rbtnLoad.Name = "rbtnLoad";
            this.rbtnLoad.Size = new System.Drawing.Size(144, 17);
            this.rbtnLoad.TabIndex = 2;
            this.rbtnLoad.TabStop = true;
            this.rbtnLoad.Text = "Load Existing Wedding";
            this.rbtnLoad.UseVisualStyleBackColor = true;
            this.rbtnLoad.CheckedChanged += new System.EventHandler(this.LoadRadioButton_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(138, 300);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(98, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // WeddingComboBox
            // 
            this.WeddingComboBox.Enabled = false;
            this.WeddingComboBox.FormattingEnabled = true;
            this.WeddingComboBox.Location = new System.Drawing.Point(177, 32);
            this.WeddingComboBox.Name = "WeddingComboBox";
            this.WeddingComboBox.Size = new System.Drawing.Size(191, 21);
            this.WeddingComboBox.TabIndex = 4;
            // 
            // gbCreate
            // 
            this.gbCreate.Controls.Add(this.label3);
            this.gbCreate.Controls.Add(this.label2);
            this.gbCreate.Controls.Add(this.label1);
            this.gbCreate.Controls.Add(this.cbYear);
            this.gbCreate.Controls.Add(this.txtPartyName);
            this.gbCreate.Controls.Add(this.cbMonth);
            this.gbCreate.Controls.Add(this.rbtnCreate);
            this.gbCreate.Location = new System.Drawing.Point(13, 33);
            this.gbCreate.Name = "gbCreate";
            this.gbCreate.Size = new System.Drawing.Size(453, 173);
            this.gbCreate.TabIndex = 5;
            this.gbCreate.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Month";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Party Name";
            // 
            // cbYear
            // 
            this.cbYear.Enabled = false;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Items.AddRange(new object[] {
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040"});
            this.cbYear.Location = new System.Drawing.Point(107, 139);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(93, 21);
            this.cbYear.TabIndex = 7;
            // 
            // txtPartyName
            // 
            this.txtPartyName.Enabled = false;
            this.txtPartyName.Location = new System.Drawing.Point(107, 62);
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.Size = new System.Drawing.Size(287, 22);
            this.txtPartyName.TabIndex = 6;
            // 
            // cbMonth
            // 
            this.cbMonth.Enabled = false;
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Items.AddRange(new object[] {
            "JANUARY",
            "FEBRUARY",
            "MARCH",
            "APRIL",
            "MAY",
            "JUNE",
            "JULY",
            "AUGUST",
            "SEPTEMBER",
            "OCTOBER",
            "NOVEMBER",
            "DECEMBER"});
            this.cbMonth.Location = new System.Drawing.Point(107, 100);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(131, 21);
            this.cbMonth.TabIndex = 5;
            // 
            // gbExisting
            // 
            this.gbExisting.Controls.Add(this.WeddingComboBox);
            this.gbExisting.Controls.Add(this.rbtnLoad);
            this.gbExisting.Location = new System.Drawing.Point(13, 212);
            this.gbExisting.Name = "gbExisting";
            this.gbExisting.Size = new System.Drawing.Size(453, 72);
            this.gbExisting.TabIndex = 6;
            this.gbExisting.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(242, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label_Title
            // 
            this.label_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Title.BackColor = System.Drawing.Color.White;
            this.label_Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title.Location = new System.Drawing.Point(1, 1);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(476, 30);
            this.label_Title.TabIndex = 8;
            this.label_Title.Text = "    Welcome to Efficienseat";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 335);
            this.ControlBox = false;
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbExisting);
            this.Controls.Add(this.gbCreate);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Welcome To Efficienseat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoadForm_FormClosing);
            this.Load += new System.EventHandler(this.LoadForm_Load);
            this.Shown += new System.EventHandler(this.LoadForm_Shown);
            this.gbCreate.ResumeLayout(false);
            this.gbCreate.PerformLayout();
            this.gbExisting.ResumeLayout(false);
            this.gbExisting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnCreate;
        private System.Windows.Forms.RadioButton rbtnLoad;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox WeddingComboBox;
        private System.Windows.Forms.GroupBox gbCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.TextBox txtPartyName;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.GroupBox gbExisting;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label_Title;
    }
}