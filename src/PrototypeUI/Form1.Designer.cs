
namespace PrototypeUI
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
            this.Lbl_Judul = new System.Windows.Forms.Label();
            this.Lbl_GraphFile = new System.Windows.Forms.Label();
            this.lbl__Algorithm = new System.Windows.Forms.Label();
            this.btn_browse = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Lbl_ChooseAcc = new System.Windows.Forms.Label();
            this.Lbl_ExploreFriends = new System.Windows.Forms.Label();
            this.Cbb_2 = new System.Windows.Forms.ComboBox();
            this.Cbb_1 = new System.Windows.Forms.ComboBox();
            this.btn_submit = new System.Windows.Forms.Button();
            this.Lbl_FriendsRecom = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelViewer = new System.Windows.Forms.Panel();
            this.lbl_filename = new System.Windows.Forms.Label();
            this.lbl_ChooseFtr = new System.Windows.Forms.Label();
            this.cbb_Feature = new System.Windows.Forms.ComboBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lbl_Judul
            // 
            this.Lbl_Judul.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Judul.Location = new System.Drawing.Point(215, 9);
            this.Lbl_Judul.Name = "Lbl_Judul";
            this.Lbl_Judul.Size = new System.Drawing.Size(318, 39);
            this.Lbl_Judul.TabIndex = 0;
            this.Lbl_Judul.Text = "People You May Know";
            // 
            // Lbl_GraphFile
            // 
            this.Lbl_GraphFile.AutoSize = true;
            this.Lbl_GraphFile.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_GraphFile.Location = new System.Drawing.Point(79, 88);
            this.Lbl_GraphFile.Name = "Lbl_GraphFile";
            this.Lbl_GraphFile.Size = new System.Drawing.Size(103, 22);
            this.Lbl_GraphFile.TabIndex = 1;
            this.Lbl_GraphFile.Text = "Graph File:";
            this.Lbl_GraphFile.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // lbl__Algorithm
            // 
            this.lbl__Algorithm.AutoSize = true;
            this.lbl__Algorithm.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl__Algorithm.Location = new System.Drawing.Point(79, 461);
            this.lbl__Algorithm.Name = "lbl__Algorithm";
            this.lbl__Algorithm.Size = new System.Drawing.Size(95, 22);
            this.lbl__Algorithm.TabIndex = 2;
            this.lbl__Algorithm.Text = "Algorithm:";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(243, 76);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(93, 34);
            this.btn_browse.TabIndex = 3;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(18, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(46, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "DFS";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(70, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(45, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "BFS";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(300, 461);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 30);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // Lbl_ChooseAcc
            // 
            this.Lbl_ChooseAcc.AutoSize = true;
            this.Lbl_ChooseAcc.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ChooseAcc.Location = new System.Drawing.Point(79, 497);
            this.Lbl_ChooseAcc.Name = "Lbl_ChooseAcc";
            this.Lbl_ChooseAcc.Size = new System.Drawing.Size(155, 22);
            this.Lbl_ChooseAcc.TabIndex = 7;
            this.Lbl_ChooseAcc.Text = "Choose Account:";
            this.Lbl_ChooseAcc.Click += new System.EventHandler(this.label4_Click);
            // 
            // Lbl_ExploreFriends
            // 
            this.Lbl_ExploreFriends.AutoSize = true;
            this.Lbl_ExploreFriends.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ExploreFriends.Location = new System.Drawing.Point(79, 534);
            this.Lbl_ExploreFriends.Name = "Lbl_ExploreFriends";
            this.Lbl_ExploreFriends.Size = new System.Drawing.Size(192, 22);
            this.Lbl_ExploreFriends.TabIndex = 8;
            this.Lbl_ExploreFriends.Text = "Explore Friends With:";
            this.Lbl_ExploreFriends.Click += new System.EventHandler(this.label5_Click);
            // 
            // Cbb_2
            // 
            this.Cbb_2.FormattingEnabled = true;
            this.Cbb_2.Location = new System.Drawing.Point(320, 535);
            this.Cbb_2.Name = "Cbb_2";
            this.Cbb_2.Size = new System.Drawing.Size(121, 21);
            this.Cbb_2.TabIndex = 10;
            this.Cbb_2.SelectedIndexChanged += new System.EventHandler(this.Cbb_2_SelectedIndexChanged);
            // 
            // Cbb_1
            // 
            this.Cbb_1.FormattingEnabled = true;
            this.Cbb_1.Location = new System.Drawing.Point(320, 497);
            this.Cbb_1.Name = "Cbb_1";
            this.Cbb_1.Size = new System.Drawing.Size(121, 21);
            this.Cbb_1.TabIndex = 11;
            this.Cbb_1.SelectedIndexChanged += new System.EventHandler(this.Cbb_1_SelectedIndexChanged);
            // 
            // btn_submit
            // 
            this.btn_submit.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.Location = new System.Drawing.Point(83, 562);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(123, 34);
            this.btn_submit.TabIndex = 12;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click_1);
            // 
            // Lbl_FriendsRecom
            // 
            this.Lbl_FriendsRecom.AutoSize = true;
            this.Lbl_FriendsRecom.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_FriendsRecom.Location = new System.Drawing.Point(79, 599);
            this.Lbl_FriendsRecom.Name = "Lbl_FriendsRecom";
            this.Lbl_FriendsRecom.Size = new System.Drawing.Size(138, 22);
            this.Lbl_FriendsRecom.TabIndex = 13;
            this.Lbl_FriendsRecom.Text = "Friends Result:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // panelViewer
            // 
            this.panelViewer.Location = new System.Drawing.Point(83, 162);
            this.panelViewer.Name = "panelViewer";
            this.panelViewer.Size = new System.Drawing.Size(647, 293);
            this.panelViewer.TabIndex = 14;
            this.panelViewer.Paint += new System.Windows.Forms.PaintEventHandler(this.panelViewer_Paint);
            // 
            // lbl_filename
            // 
            this.lbl_filename.AutoSize = true;
            this.lbl_filename.Location = new System.Drawing.Point(355, 88);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(0, 13);
            this.lbl_filename.TabIndex = 15;
            this.lbl_filename.Click += new System.EventHandler(this.lbl_filename_Click);
            // 
            // lbl_ChooseFtr
            // 
            this.lbl_ChooseFtr.AutoSize = true;
            this.lbl_ChooseFtr.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChooseFtr.Location = new System.Drawing.Point(79, 121);
            this.lbl_ChooseFtr.Name = "lbl_ChooseFtr";
            this.lbl_ChooseFtr.Size = new System.Drawing.Size(157, 22);
            this.lbl_ChooseFtr.TabIndex = 16;
            this.lbl_ChooseFtr.Text = "Choose Feature: ";
            // 
            // cbb_Feature
            // 
            this.cbb_Feature.FormattingEnabled = true;
            this.cbb_Feature.Items.AddRange(new object[] {
            "Friends Recommendation",
            "Explore Friends"});
            this.cbb_Feature.Location = new System.Drawing.Point(243, 125);
            this.cbb_Feature.Name = "cbb_Feature";
            this.cbb_Feature.Size = new System.Drawing.Size(121, 21);
            this.cbb_Feature.TabIndex = 17;
            this.cbb_Feature.SelectedIndexChanged += new System.EventHandler(this.cbb_Feature_SelectedIndexChanged);
            // 
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.Location = new System.Drawing.Point(221, 562);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(123, 34);
            this.btn_reset.TabIndex = 18;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(83, 624);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(647, 103);
            this.textBox1.TabIndex = 19;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 784);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.cbb_Feature);
            this.Controls.Add(this.lbl_ChooseFtr);
            this.Controls.Add(this.lbl_filename);
            this.Controls.Add(this.panelViewer);
            this.Controls.Add(this.Lbl_FriendsRecom);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.Cbb_1);
            this.Controls.Add(this.Cbb_2);
            this.Controls.Add(this.Lbl_ExploreFriends);
            this.Controls.Add(this.Lbl_ChooseAcc);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl__Algorithm);
            this.Controls.Add(this.Lbl_GraphFile);
            this.Controls.Add(this.Lbl_Judul);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Judul;
        private System.Windows.Forms.Label Lbl_GraphFile;
        private System.Windows.Forms.Label lbl__Algorithm;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Lbl_ChooseAcc;
        private System.Windows.Forms.Label Lbl_ExploreFriends;
        private System.Windows.Forms.ComboBox Cbb_2;
        private System.Windows.Forms.ComboBox Cbb_1;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Label Lbl_FriendsRecom;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panelViewer;
        private System.Windows.Forms.Label lbl_filename;
        private System.Windows.Forms.Label lbl_ChooseFtr;
        private System.Windows.Forms.ComboBox cbb_Feature;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.TextBox textBox1;
    }
}

