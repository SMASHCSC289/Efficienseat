namespace Efficienseat
{
    partial class TableCreateForm
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
            this.cbEndSeats = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudNumSeats = new System.Windows.Forms.NumericUpDown();
            this.cbxTableShape = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumSeats)).BeginInit();
            this.SuspendLayout();
            // 
            // cbEndSeats
            // 
            this.cbEndSeats.AutoSize = true;
            this.cbEndSeats.Checked = true;
            this.cbEndSeats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEndSeats.Enabled = false;
            this.cbEndSeats.Location = new System.Drawing.Point(35, 122);
            this.cbEndSeats.Name = "cbEndSeats";
            this.cbEndSeats.Size = new System.Drawing.Size(81, 17);
            this.cbEndSeats.TabIndex = 15;
            this.cbEndSeats.Text = "End Seats?";
            this.cbEndSeats.UseVisualStyleBackColor = true;
            this.cbEndSeats.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Number of Seats";
            // 
            // nudNumSeats
            // 
            this.nudNumSeats.Location = new System.Drawing.Point(104, 50);
            this.nudNumSeats.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudNumSeats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumSeats.Name = "nudNumSeats";
            this.nudNumSeats.Size = new System.Drawing.Size(107, 20);
            this.nudNumSeats.TabIndex = 1;
            this.nudNumSeats.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumSeats.ValueChanged += new System.EventHandler(this.nudNumSeats_ValueChanged);
            // 
            // cbxTableShape
            // 
            this.cbxTableShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTableShape.Items.AddRange(new object[] {
            "Circle",
            "Square",
            "Rectangle"});
            this.cbxTableShape.Location = new System.Drawing.Point(104, 76);
            this.cbxTableShape.Name = "cbxTableShape";
            this.cbxTableShape.Size = new System.Drawing.Size(107, 21);
            this.cbxTableShape.TabIndex = 2;
            this.cbxTableShape.SelectionChangeCommitted += new System.EventHandler(this.cbxTableShape_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Table Shape";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 24);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(107, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Table Name";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(41, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(122, 116);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TableCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 158);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbEndSeats);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudNumSeats);
            this.Controls.Add(this.cbxTableShape);
            this.Name = "TableCreateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Table";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TableCreateForm_FormClosing);
            this.Shown += new System.EventHandler(this.TableCreateForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudNumSeats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbEndSeats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudNumSeats;
        private System.Windows.Forms.ComboBox cbxTableShape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}