namespace FormPratice
{
    partial class InputForm
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
            this.addButton = new System.Windows.Forms.Button();
            this.salaryTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioFemale = new System.Windows.Forms.RadioButton();
            this.radioMale = new System.Windows.Forms.RadioButton();
            this.phoneMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.qualificationTextBox = new System.Windows.Forms.ComboBox();
            this.datePickerBirth = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.addressRichText = new System.Windows.Forms.Label();
            this.Phone = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addressrichTextBox = new System.Windows.Forms.RichTextBox();
            this.nationalcomboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(101, 320);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 42;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // salaryTextBox
            // 
            this.salaryTextBox.Location = new System.Drawing.Point(82, 276);
            this.salaryTextBox.Name = "salaryTextBox";
            this.salaryTextBox.Size = new System.Drawing.Size(220, 20);
            this.salaryTextBox.TabIndex = 41;
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.radioFemale);
            this.groupBox1.Controls.Add(this.radioMale);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(83, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 35);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            // 
            // radioFemale
            // 
            this.radioFemale.AutoSize = true;
            this.radioFemale.Checked = true;
            this.radioFemale.Location = new System.Drawing.Point(61, 12);
            this.radioFemale.Name = "radioFemale";
            this.radioFemale.Size = new System.Drawing.Size(59, 17);
            this.radioFemale.TabIndex = 1;
            this.radioFemale.TabStop = true;
            this.radioFemale.Text = "Female";
            this.radioFemale.UseVisualStyleBackColor = true;
            // 
            // radioMale
            // 
            this.radioMale.AutoSize = true;
            this.radioMale.Location = new System.Drawing.Point(7, 12);
            this.radioMale.Name = "radioMale";
            this.radioMale.Size = new System.Drawing.Size(48, 17);
            this.radioMale.TabIndex = 0;
            this.radioMale.Text = "Male";
            this.radioMale.UseVisualStyleBackColor = true;
            // 
            // phoneMaskedTextBox
            // 
            this.phoneMaskedTextBox.Location = new System.Drawing.Point(82, 138);
            this.phoneMaskedTextBox.Mask = "(+900) 000-000-000";
            this.phoneMaskedTextBox.Name = "phoneMaskedTextBox";
            this.phoneMaskedTextBox.Size = new System.Drawing.Size(220, 20);
            this.phoneMaskedTextBox.TabIndex = 39;
            // 
            // qualificationTextBox
            // 
            this.qualificationTextBox.FormattingEnabled = true;
            this.qualificationTextBox.Location = new System.Drawing.Point(83, 246);
            this.qualificationTextBox.Name = "qualificationTextBox";
            this.qualificationTextBox.Size = new System.Drawing.Size(219, 21);
            this.qualificationTextBox.TabIndex = 38;
            // 
            // datePickerBirth
            // 
            this.datePickerBirth.CustomFormat = "dd/MM/yyyy";
            this.datePickerBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerBirth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.datePickerBirth.Location = new System.Drawing.Point(83, 37);
            this.datePickerBirth.Name = "datePickerBirth";
            this.datePickerBirth.Size = new System.Drawing.Size(219, 20);
            this.datePickerBirth.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Salary";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Qualification";
            // 
            // addressRichText
            // 
            this.addressRichText.AutoSize = true;
            this.addressRichText.Location = new System.Drawing.Point(11, 195);
            this.addressRichText.Name = "addressRichText";
            this.addressRichText.Size = new System.Drawing.Size(45, 13);
            this.addressRichText.TabIndex = 34;
            this.addressRichText.Text = "Address";
            // 
            // Phone
            // 
            this.Phone.AutoSize = true;
            this.Phone.Location = new System.Drawing.Point(11, 141);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(38, 13);
            this.Phone.TabIndex = 33;
            this.Phone.Text = "Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "National";
            // 
            // addressrichTextBox
            // 
            this.addressrichTextBox.Location = new System.Drawing.Point(82, 167);
            this.addressrichTextBox.Name = "addressrichTextBox";
            this.addressrichTextBox.Size = new System.Drawing.Size(220, 72);
            this.addressrichTextBox.TabIndex = 31;
            this.addressrichTextBox.Text = "";
            // 
            // nationalcomboBox
            // 
            this.nationalcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nationalcomboBox.FormattingEnabled = true;
            this.nationalcomboBox.Location = new System.Drawing.Point(82, 103);
            this.nationalcomboBox.Name = "nationalcomboBox";
            this.nationalcomboBox.Size = new System.Drawing.Size(220, 21);
            this.nationalcomboBox.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Gender";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(82, 6);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(220, 20);
            this.nameTextBox.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Date of birth";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Full name";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 355);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.salaryTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.phoneMaskedTextBox);
            this.Controls.Add(this.qualificationTextBox);
            this.Controls.Add(this.datePickerBirth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addressRichText);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addressrichTextBox);
            this.Controls.Add(this.nationalcomboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "InputForm";
            this.ShowIcon = false;
            this.Text = "InputForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox salaryTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioFemale;
        private System.Windows.Forms.RadioButton radioMale;
        private System.Windows.Forms.MaskedTextBox phoneMaskedTextBox;
        private System.Windows.Forms.ComboBox qualificationTextBox;
        private System.Windows.Forms.DateTimePicker datePickerBirth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label addressRichText;
        private System.Windows.Forms.Label Phone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox addressrichTextBox;
        private System.Windows.Forms.ComboBox nationalcomboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}