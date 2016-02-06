namespace MySQLDemo
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.txtRSVP = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvGuests = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.cbWeddingParty = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(417, 109);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(98, 23);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update Guest";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(311, 110);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 10;
            this.btnFind.Text = "Get Guest";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(118, 184);
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(155, 20);
            this.txtComments.TabIndex = 15;
            // 
            // txtRSVP
            // 
            this.txtRSVP.Location = new System.Drawing.Point(118, 158);
            this.txtRSVP.Name = "txtRSVP";
            this.txtRSVP.Size = new System.Drawing.Size(155, 20);
            this.txtRSVP.TabIndex = 14;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(118, 132);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(155, 20);
            this.txtLastName.TabIndex = 13;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(118, 106);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(155, 20);
            this.txtFirstName.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Comments";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "RSVP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "First Name";
            // 
            // dgvGuests
            // 
            this.dgvGuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuests.Location = new System.Drawing.Point(26, 224);
            this.dgvGuests.Name = "dgvGuests";
            this.dgvGuests.Size = new System.Drawing.Size(450, 150);
            this.dgvGuests.TabIndex = 20;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(311, 157);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(417, 157);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(98, 23);
            this.btnInsert.TabIndex = 22;
            this.btnInsert.Text = "Insert Guest";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // cbWeddingParty
            // 
            this.cbWeddingParty.DisplayMember = "WED_PARTY_NAME";
            this.cbWeddingParty.FormattingEnabled = true;
            this.cbWeddingParty.Location = new System.Drawing.Point(118, 12);
            this.cbWeddingParty.Name = "cbWeddingParty";
            this.cbWeddingParty.Size = new System.Drawing.Size(155, 21);
            this.cbWeddingParty.TabIndex = 23;
            this.cbWeddingParty.ValueMember = "WED_ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 386);
            this.Controls.Add(this.cbWeddingParty);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvGuests);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.txtRSVP);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnFind);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.TextBox txtRSVP;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvGuests;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.ComboBox cbWeddingParty;
    }
}

