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
            this.CreateRadioButton = new System.Windows.Forms.RadioButton();
            this.LoadRadioButton = new System.Windows.Forms.RadioButton();
            this.SelectButton = new System.Windows.Forms.Button();
            this.WeddingComboBox = new System.Windows.Forms.ComboBox();
            this.gbCreate = new System.Windows.Forms.GroupBox();
            this.gbExisting = new System.Windows.Forms.GroupBox();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbCreate.SuspendLayout();
            this.gbExisting.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreateRadioButton
            // 
            this.CreateRadioButton.AutoSize = true;
            this.CreateRadioButton.Location = new System.Drawing.Point(31, 25);
            this.CreateRadioButton.Name = "CreateRadioButton";
            this.CreateRadioButton.Size = new System.Drawing.Size(127, 17);
            this.CreateRadioButton.TabIndex = 0;
            this.CreateRadioButton.TabStop = true;
            this.CreateRadioButton.Text = "Create New Wedding";
            this.CreateRadioButton.UseVisualStyleBackColor = true;
            this.CreateRadioButton.CheckedChanged += new System.EventHandler(this.CreateRadioButton_CheckedChanged);
            // 
            // LoadRadioButton
            // 
            this.LoadRadioButton.AutoSize = true;
            this.LoadRadioButton.Location = new System.Drawing.Point(19, 33);
            this.LoadRadioButton.Name = "LoadRadioButton";
            this.LoadRadioButton.Size = new System.Drawing.Size(134, 17);
            this.LoadRadioButton.TabIndex = 2;
            this.LoadRadioButton.TabStop = true;
            this.LoadRadioButton.Text = "Load Existing Wedding";
            this.LoadRadioButton.UseVisualStyleBackColor = true;
            this.LoadRadioButton.CheckedChanged += new System.EventHandler(this.LoadRadioButton_CheckedChanged);
            // 
            // SelectButton
            // 
            this.SelectButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SelectButton.Location = new System.Drawing.Point(176, 279);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(98, 23);
            this.SelectButton.TabIndex = 3;
            this.SelectButton.Text = "OK";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
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
            this.gbCreate.Controls.Add(this.CreateRadioButton);
            this.gbCreate.Location = new System.Drawing.Point(13, 12);
            this.gbCreate.Name = "gbCreate";
            this.gbCreate.Size = new System.Drawing.Size(453, 173);
            this.gbCreate.TabIndex = 5;
            this.gbCreate.TabStop = false;
            // 
            // gbExisting
            // 
            this.gbExisting.Controls.Add(this.WeddingComboBox);
            this.gbExisting.Controls.Add(this.LoadRadioButton);
            this.gbExisting.Location = new System.Drawing.Point(13, 191);
            this.gbExisting.Name = "gbExisting";
            this.gbExisting.Size = new System.Drawing.Size(453, 72);
            this.gbExisting.TabIndex = 6;
            this.gbExisting.TabStop = false;
            // 
            // cbMonth
            // 
            this.cbMonth.Enabled = false;
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Items.AddRange(new object[] {
            "JANUARY",
            "FEBURARY",
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
            // txtPartyName
            // 
            this.txtPartyName.Enabled = false;
            this.txtPartyName.Location = new System.Drawing.Point(107, 62);
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.Size = new System.Drawing.Size(287, 20);
            this.txtPartyName.TabIndex = 6;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Party Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Year";
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 314);
            this.Controls.Add(this.gbExisting);
            this.Controls.Add(this.gbCreate);
            this.Controls.Add(this.SelectButton);
            this.Name = "LoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Welcome To Efficienseat";
            this.Load += new System.EventHandler(this.LoadForm_Load);
            this.Shown += new System.EventHandler(this.LoadForm_Shown);
            this.gbCreate.ResumeLayout(false);
            this.gbCreate.PerformLayout();
            this.gbExisting.ResumeLayout(false);
            this.gbExisting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton CreateRadioButton;
        private System.Windows.Forms.RadioButton LoadRadioButton;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.ComboBox WeddingComboBox;
        private System.Windows.Forms.GroupBox gbCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.TextBox txtPartyName;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.GroupBox gbExisting;
    }
}