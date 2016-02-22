namespace Efficienseat
{
    partial class DataEntryForm
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
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.cbFoodAllergy = new System.Windows.Forms.ComboBox();
            this.lblFoodAllergy = new System.Windows.Forms.Label();
            this.cbRSVP = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(12, 14);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(63, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name :";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(10, 40);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(64, 13);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name :";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Location = new System.Drawing.Point(111, 12);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(146, 20);
            this.txtFirstName.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Location = new System.Drawing.Point(111, 38);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(146, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // cbFoodAllergy
            // 
            this.cbFoodAllergy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFoodAllergy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFoodAllergy.FormattingEnabled = true;
            this.cbFoodAllergy.Items.AddRange(new object[] {
            "Y",
            "N"});
            this.cbFoodAllergy.Location = new System.Drawing.Point(111, 69);
            this.cbFoodAllergy.Name = "cbFoodAllergy";
            this.cbFoodAllergy.Size = new System.Drawing.Size(49, 21);
            this.cbFoodAllergy.TabIndex = 11;
            // 
            // lblFoodAllergy
            // 
            this.lblFoodAllergy.AutoSize = true;
            this.lblFoodAllergy.Location = new System.Drawing.Point(12, 72);
            this.lblFoodAllergy.Name = "lblFoodAllergy";
            this.lblFoodAllergy.Size = new System.Drawing.Size(68, 13);
            this.lblFoodAllergy.TabIndex = 12;
            this.lblFoodAllergy.Text = "Food Allergy:";
            // 
            // cbRSVP
            // 
            this.cbRSVP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRSVP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRSVP.FormattingEnabled = true;
            this.cbRSVP.Items.AddRange(new object[] {
            "Accept",
            "Decline"});
            this.cbRSVP.Location = new System.Drawing.Point(111, 105);
            this.cbRSVP.Name = "cbRSVP";
            this.cbRSVP.Size = new System.Drawing.Size(146, 21);
            this.cbRSVP.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "RSVP Response :";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(136, 259);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(41, 259);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(15, 171);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(245, 70);
            this.txtComments.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Comments : ";
            // 
            // DataEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 294);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbRSVP);
            this.Controls.Add(this.lblFoodAllergy);
            this.Controls.Add(this.cbFoodAllergy);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DataEntryForm";
            this.Text = "DataEntryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.ComboBox cbFoodAllergy;
        private System.Windows.Forms.Label lblFoodAllergy;
        private System.Windows.Forms.ComboBox cbRSVP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label1;
    }
}