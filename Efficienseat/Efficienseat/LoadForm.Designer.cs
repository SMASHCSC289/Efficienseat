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
            this.SuspendLayout();
            // 
            // CreateRadioButton
            // 
            this.CreateRadioButton.AutoSize = true;
            this.CreateRadioButton.Location = new System.Drawing.Point(44, 37);
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
            this.LoadRadioButton.Location = new System.Drawing.Point(44, 133);
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
            this.SelectButton.Location = new System.Drawing.Point(166, 184);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(75, 23);
            this.SelectButton.TabIndex = 3;
            this.SelectButton.Text = "OK";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // WeddingComboBox
            // 
            this.WeddingComboBox.Enabled = false;
            this.WeddingComboBox.FormattingEnabled = true;
            this.WeddingComboBox.Location = new System.Drawing.Point(202, 132);
            this.WeddingComboBox.Name = "WeddingComboBox";
            this.WeddingComboBox.Size = new System.Drawing.Size(191, 21);
            this.WeddingComboBox.TabIndex = 4;
            this.WeddingComboBox.SelectedIndexChanged += new System.EventHandler(this.WeddingComboBox_SelectedIndexChanged);
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 229);
            this.Controls.Add(this.WeddingComboBox);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.LoadRadioButton);
            this.Controls.Add(this.CreateRadioButton);
            this.Name = "LoadForm";
            this.Text = "Welcome To Efficienseat";
            this.Load += new System.EventHandler(this.LoadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton CreateRadioButton;
        private System.Windows.Forms.RadioButton LoadRadioButton;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.ComboBox WeddingComboBox;
    }
}