namespace Agents2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.branchesList = new System.Windows.Forms.ComboBox();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.goBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.cloiRB = new System.Windows.Forms.RadioButton();
            this.cloiTeenRB = new System.Windows.Forms.RadioButton();
            this.salariesRB = new System.Windows.Forms.RadioButton();
            this.ZirconRB = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 149);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.Size = new System.Drawing.Size(1293, 427);
            this.dataGridView1.TabIndex = 0;
            // 
            // branchesList
            // 
            this.branchesList.DisplayMember = "BLID";
            this.branchesList.FormattingEnabled = true;
            this.branchesList.Location = new System.Drawing.Point(145, 44);
            this.branchesList.Name = "branchesList";
            this.branchesList.Size = new System.Drawing.Size(313, 24);
            this.branchesList.TabIndex = 1;
            this.branchesList.ValueMember = "BLID";
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePicker.Location = new System.Drawing.Point(145, 73);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(313, 24);
            this.fromDatePicker.TabIndex = 3;
            // 
            // toDatePicker
            // 
            this.toDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePicker.Location = new System.Drawing.Point(145, 103);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(313, 24);
            this.toDatePicker.TabIndex = 4;
            // 
            // goBtn
            // 
            this.goBtn.Location = new System.Drawing.Point(477, 103);
            this.goBtn.Name = "goBtn";
            this.goBtn.Size = new System.Drawing.Size(75, 23);
            this.goBtn.TabIndex = 5;
            this.goBtn.Text = "GO";
            this.goBtn.UseVisualStyleBackColor = true;
            this.goBtn.Click += new System.EventHandler(this.goBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Branch";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "From Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "To Date";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 585);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 26;
            this.dataGridView2.Size = new System.Drawing.Size(1293, 89);
            this.dataGridView2.TabIndex = 9;
            // 
            // cloiRB
            // 
            this.cloiRB.AutoSize = true;
            this.cloiRB.Checked = true;
            this.cloiRB.Location = new System.Drawing.Point(584, 30);
            this.cloiRB.Name = "cloiRB";
            this.cloiRB.Size = new System.Drawing.Size(59, 21);
            this.cloiRB.TabIndex = 10;
            this.cloiRB.TabStop = true;
            this.cloiRB.Text = "CLOI";
            this.cloiRB.UseVisualStyleBackColor = true;
            this.cloiRB.CheckedChanged += new System.EventHandler(this.cloiRB_CheckedChanged);
            // 
            // cloiTeenRB
            // 
            this.cloiTeenRB.AutoSize = true;
            this.cloiTeenRB.Location = new System.Drawing.Point(584, 63);
            this.cloiTeenRB.Name = "cloiTeenRB";
            this.cloiTeenRB.Size = new System.Drawing.Size(96, 21);
            this.cloiTeenRB.TabIndex = 11;
            this.cloiTeenRB.Text = "CLOI TEEN";
            this.cloiTeenRB.UseVisualStyleBackColor = true;
            // 
            // salariesRB
            // 
            this.salariesRB.AutoSize = true;
            this.salariesRB.Location = new System.Drawing.Point(584, 96);
            this.salariesRB.Name = "salariesRB";
            this.salariesRB.Size = new System.Drawing.Size(89, 21);
            this.salariesRB.TabIndex = 12;
            this.salariesRB.Text = "SALARIES";
            this.salariesRB.UseVisualStyleBackColor = true;
            // 
            // ZirconRB
            // 
            this.ZirconRB.AutoSize = true;
            this.ZirconRB.Location = new System.Drawing.Point(688, 30);
            this.ZirconRB.Name = "ZirconRB";
            this.ZirconRB.Size = new System.Drawing.Size(67, 21);
            this.ZirconRB.TabIndex = 13;
            this.ZirconRB.Text = "Zircon";
            this.ZirconRB.UseVisualStyleBackColor = true;
            this.ZirconRB.CheckedChanged += new System.EventHandler(this.ZirconRB_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Year";
            // 
            // yearComboBox
            // 
            this.yearComboBox.DisplayMember = "BLID";
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(146, 12);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(313, 24);
            this.yearComboBox.TabIndex = 14;
            this.yearComboBox.ValueMember = "BLID";
            this.yearComboBox.SelectedIndexChanged += new System.EventHandler(this.yearComboBox_SelectedIndexChanged);
            this.yearComboBox.SelectedValueChanged += new System.EventHandler(this.yearComboBox_SelectedValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1317, 686);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.ZirconRB);
            this.Controls.Add(this.salariesRB);
            this.Controls.Add(this.cloiTeenRB);
            this.Controls.Add(this.cloiRB);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.goBtn);
            this.Controls.Add(this.toDatePicker);
            this.Controls.Add(this.fromDatePicker);
            this.Controls.Add(this.branchesList);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Cloi Sales";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox branchesList;
        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.DateTimePicker toDatePicker;
        private System.Windows.Forms.Button goBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.RadioButton cloiRB;
        private System.Windows.Forms.RadioButton cloiTeenRB;
        private System.Windows.Forms.RadioButton salariesRB;
        private System.Windows.Forms.RadioButton ZirconRB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox yearComboBox;
    }
}

