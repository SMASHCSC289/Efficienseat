namespace Efficienseat
{
    partial class EditWedding
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
            this.weddingNameTextBox = new System.Windows.Forms.TextBox();
            this.weddingMonthComboBox = new System.Windows.Forms.ComboBox();
            this.weddingYearComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // weddingNameTextBox
            // 
            this.weddingNameTextBox.Location = new System.Drawing.Point(88, 37);
            this.weddingNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.weddingNameTextBox.Name = "weddingNameTextBox";
            this.weddingNameTextBox.Size = new System.Drawing.Size(204, 20);
            this.weddingNameTextBox.TabIndex = 0;
            // 
            // weddingMonthComboBox
            // 
            this.weddingMonthComboBox.FormattingEnabled = true;
            this.weddingMonthComboBox.Items.AddRange(new object[] {
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
            this.weddingMonthComboBox.Location = new System.Drawing.Point(88, 73);
            this.weddingMonthComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.weddingMonthComboBox.Name = "weddingMonthComboBox";
            this.weddingMonthComboBox.Size = new System.Drawing.Size(103, 21);
            this.weddingMonthComboBox.TabIndex = 1;
            // 
            // weddingYearComboBox
            // 
            this.weddingYearComboBox.FormattingEnabled = true;
            this.weddingYearComboBox.Items.AddRange(new object[] {
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
            this.weddingYearComboBox.Location = new System.Drawing.Point(228, 73);
            this.weddingYearComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.weddingYearComboBox.Name = "weddingYearComboBox";
            this.weddingYearComboBox.Size = new System.Drawing.Size(62, 21);
            this.weddingYearComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Party Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Year";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(228, 123);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 25);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Submit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditWedding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 164);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.weddingYearComboBox);
            this.Controls.Add(this.weddingMonthComboBox);
            this.Controls.Add(this.weddingNameTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EditWedding";
            this.Text = "Edit wedding information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox weddingNameTextBox;
        private System.Windows.Forms.ComboBox weddingMonthComboBox;
        private System.Windows.Forms.ComboBox weddingYearComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
    }
}