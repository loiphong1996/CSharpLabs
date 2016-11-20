namespace Lab3
{
    partial class AddNewForm
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
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.albumTextBox = new System.Windows.Forms.TextBox();
            this.singerTextBox = new System.Windows.Forms.TextBox();
            this.singLabel = new System.Windows.Forms.Label();
            this.durationTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.songListView = new System.Windows.Forms.ListView();
            this.songTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteSongBtn = new System.Windows.Forms.Button();
            this.addSongBtn = new System.Windows.Forms.Button();
            this.genreCombobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.actionBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(66, 11);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(196, 20);
            this.idTextBox.TabIndex = 0;
            this.idTextBox.TextChanged += new System.EventHandler(this.idTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Album";
            // 
            // albumTextBox
            // 
            this.albumTextBox.Location = new System.Drawing.Point(66, 37);
            this.albumTextBox.Name = "albumTextBox";
            this.albumTextBox.Size = new System.Drawing.Size(196, 20);
            this.albumTextBox.TabIndex = 3;
            this.albumTextBox.TextChanged += new System.EventHandler(this.albumTextBox_TextChanged);
            // 
            // singerTextBox
            // 
            this.singerTextBox.Location = new System.Drawing.Point(66, 64);
            this.singerTextBox.Name = "singerTextBox";
            this.singerTextBox.Size = new System.Drawing.Size(196, 20);
            this.singerTextBox.TabIndex = 4;
            this.singerTextBox.TextChanged += new System.EventHandler(this.singerTextBox_TextChanged);
            // 
            // singLabel
            // 
            this.singLabel.AutoSize = true;
            this.singLabel.Location = new System.Drawing.Point(13, 67);
            this.singLabel.Name = "singLabel";
            this.singLabel.Size = new System.Drawing.Size(37, 13);
            this.singLabel.TabIndex = 5;
            this.singLabel.Text = "Singer";
            // 
            // durationTextBox
            // 
            this.durationTextBox.Location = new System.Drawing.Point(66, 90);
            this.durationTextBox.Name = "durationTextBox";
            this.durationTextBox.Size = new System.Drawing.Size(196, 20);
            this.durationTextBox.TabIndex = 6;
            this.durationTextBox.TextChanged += new System.EventHandler(this.durationTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Duration";
            // 
            // songListView
            // 
            this.songListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.songListView.FullRowSelect = true;
            this.songListView.GridLines = true;
            this.songListView.Location = new System.Drawing.Point(6, 78);
            this.songListView.MultiSelect = false;
            this.songListView.Name = "songListView";
            this.songListView.Size = new System.Drawing.Size(244, 70);
            this.songListView.TabIndex = 8;
            this.songListView.UseCompatibleStateImageBehavior = false;
            this.songListView.SelectedIndexChanged += new System.EventHandler(this.songListView_SelectedIndexChanged);
            // 
            // songTextBox
            // 
            this.songTextBox.Location = new System.Drawing.Point(6, 19);
            this.songTextBox.Name = "songTextBox";
            this.songTextBox.Size = new System.Drawing.Size(244, 20);
            this.songTextBox.TabIndex = 9;
            this.songTextBox.TextChanged += new System.EventHandler(this.songTextBox_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteSongBtn);
            this.groupBox1.Controls.Add(this.addSongBtn);
            this.groupBox1.Controls.Add(this.songTextBox);
            this.groupBox1.Controls.Add(this.songListView);
            this.groupBox1.Location = new System.Drawing.Point(12, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 154);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Songs";
            // 
            // deleteSongBtn
            // 
            this.deleteSongBtn.Location = new System.Drawing.Point(175, 49);
            this.deleteSongBtn.Name = "deleteSongBtn";
            this.deleteSongBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteSongBtn.TabIndex = 11;
            this.deleteSongBtn.Text = "Delete";
            this.deleteSongBtn.UseVisualStyleBackColor = true;
            this.deleteSongBtn.Click += new System.EventHandler(this.deleteSongBtn_Click);
            // 
            // addSongBtn
            // 
            this.addSongBtn.Location = new System.Drawing.Point(6, 49);
            this.addSongBtn.Name = "addSongBtn";
            this.addSongBtn.Size = new System.Drawing.Size(75, 23);
            this.addSongBtn.TabIndex = 10;
            this.addSongBtn.Text = "Add";
            this.addSongBtn.UseVisualStyleBackColor = true;
            this.addSongBtn.Click += new System.EventHandler(this.addSongBtn_Click);
            // 
            // genreCombobox
            // 
            this.genreCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreCombobox.FormattingEnabled = true;
            this.genreCombobox.Items.AddRange(new object[] {
            "Blue",
            "Country",
            "Dance",
            "Jazz",
            "Rap",
            "Rock"});
            this.genreCombobox.Location = new System.Drawing.Point(66, 276);
            this.genreCombobox.Name = "genreCombobox";
            this.genreCombobox.Size = new System.Drawing.Size(196, 21);
            this.genreCombobox.TabIndex = 11;
            this.genreCombobox.SelectedIndexChanged += new System.EventHandler(this.genreCombobox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Genre";
            // 
            // actionBtn
            // 
            this.actionBtn.Location = new System.Drawing.Point(97, 303);
            this.actionBtn.Name = "actionBtn";
            this.actionBtn.Size = new System.Drawing.Size(75, 23);
            this.actionBtn.TabIndex = 13;
            this.actionBtn.Text = "Add";
            this.actionBtn.UseVisualStyleBackColor = true;
            this.actionBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 338);
            this.Controls.Add(this.actionBtn);
            this.Controls.Add(this.genreCombobox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.durationTextBox);
            this.Controls.Add(this.singLabel);
            this.Controls.Add(this.singerTextBox);
            this.Controls.Add(this.albumTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idTextBox);
            this.Name = "AddNewForm";
            this.Text = "New";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox albumTextBox;
        private System.Windows.Forms.TextBox singerTextBox;
        private System.Windows.Forms.Label singLabel;
        private System.Windows.Forms.TextBox durationTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView songListView;
        private System.Windows.Forms.TextBox songTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox genreCombobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button actionBtn;
        private System.Windows.Forms.Button deleteSongBtn;
        private System.Windows.Forms.Button addSongBtn;
    }
}