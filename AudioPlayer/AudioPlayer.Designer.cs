namespace AudioPlayer
{
    partial class AudioPlayer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnPause = new Button();
            btnStop = new Button();
            btnPlay = new Button();
            btnAddTrack = new Button();
            lblTime = new Label();
            progressBar1 = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            btnOpenFolder = new Button();
            listBoxPlaylist = new ListBox();
            btnPrevious = new Button();
            btnNext = new Button();
            lblTrackName = new Label();
            comboBoxRepeat = new ComboBox();
            btnSavePlaylist = new Button();
            btnLoadPlaylist = new Button();
            SuspendLayout();
            // 
            // btnPause
            // 
            btnPause.Location = new Point(316, 212);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(138, 35);
            btnPause.TabIndex = 1;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(604, 212);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(138, 35);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(28, 212);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(138, 35);
            btnPlay.TabIndex = 3;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnAddTrack
            // 
            btnAddTrack.Location = new Point(28, 29);
            btnAddTrack.Name = "btnAddTrack";
            btnAddTrack.Size = new Size(138, 35);
            btnAddTrack.TabIndex = 4;
            btnAddTrack.Text = "Add Track";
            btnAddTrack.UseVisualStyleBackColor = true;
            btnAddTrack.Click += btnAddTrack_Click;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 16F);
            lblTime.Location = new Point(542, 19);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(200, 45);
            lblTime.TabIndex = 5;
            lblTime.Text = "00:00 / 00:00";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(28, 149);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(714, 25);
            progressBar1.TabIndex = 6;
            progressBar1.MouseDown += progressBar1_MouseDown;
            // 
            // timer1
            // 
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.Location = new Point(172, 29);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new Size(138, 35);
            btnOpenFolder.TabIndex = 7;
            btnOpenFolder.Text = "Open Folder";
            btnOpenFolder.UseVisualStyleBackColor = true;
            btnOpenFolder.Click += btnOpenFolder_Click;
            // 
            // listBoxPlaylist
            // 
            listBoxPlaylist.FormattingEnabled = true;
            listBoxPlaylist.ItemHeight = 25;
            listBoxPlaylist.Location = new Point(28, 282);
            listBoxPlaylist.Name = "listBoxPlaylist";
            listBoxPlaylist.Size = new Size(714, 279);
            listBoxPlaylist.TabIndex = 8;
            listBoxPlaylist.SelectedIndexChanged += listBoxPlaylist_DoubleClick;
            // 
            // btnPrevious
            // 
            btnPrevious.Location = new Point(172, 212);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(138, 35);
            btnPrevious.TabIndex = 9;
            btnPrevious.Text = "Previous";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(460, 212);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(138, 35);
            btnNext.TabIndex = 10;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblTrackName
            // 
            lblTrackName.Font = new Font("Segoe UI", 10F);
            lblTrackName.Location = new Point(28, 93);
            lblTrackName.Name = "lblTrackName";
            lblTrackName.Size = new Size(714, 25);
            lblTrackName.TabIndex = 11;
            lblTrackName.TextAlign = ContentAlignment.MiddleLeft;
            lblTrackName.Click += lblTrackName_Click;
            // 
            // comboBoxRepeat
            // 
            comboBoxRepeat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRepeat.FormattingEnabled = true;
            comboBoxRepeat.Location = new Point(28, 602);
            comboBoxRepeat.Name = "comboBoxRepeat";
            comboBoxRepeat.Size = new Size(138, 33);
            comboBoxRepeat.TabIndex = 12;
            comboBoxRepeat.SelectedIndexChanged += comboBoxRepeat_SelectedIndexChanged;
            // 
            // btnSavePlaylist
            // 
            btnSavePlaylist.Location = new Point(460, 600);
            btnSavePlaylist.Name = "btnSavePlaylist";
            btnSavePlaylist.Size = new Size(138, 35);
            btnSavePlaylist.TabIndex = 13;
            btnSavePlaylist.Text = "Save Playlist";
            btnSavePlaylist.UseVisualStyleBackColor = true;
            btnSavePlaylist.Click += btnSavePlaylist_Click;
            // 
            // btnLoadPlaylist
            // 
            btnLoadPlaylist.Location = new Point(604, 600);
            btnLoadPlaylist.Name = "btnLoadPlaylist";
            btnLoadPlaylist.Size = new Size(138, 35);
            btnLoadPlaylist.TabIndex = 14;
            btnLoadPlaylist.Text = "Load Playlist";
            btnLoadPlaylist.UseVisualStyleBackColor = true;
            btnLoadPlaylist.Click += btnLoadPlaylist_Click;
            // 
            // AudioPlayer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(778, 665);
            Controls.Add(btnLoadPlaylist);
            Controls.Add(btnSavePlaylist);
            Controls.Add(comboBoxRepeat);
            Controls.Add(lblTrackName);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(listBoxPlaylist);
            Controls.Add(btnOpenFolder);
            Controls.Add(progressBar1);
            Controls.Add(lblTime);
            Controls.Add(btnAddTrack);
            Controls.Add(btnPlay);
            Controls.Add(btnStop);
            Controls.Add(btnPause);
            Name = "AudioPlayer";
            Text = "Audio Player";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnPause;
        private Button btnStop;
        private Button btnPlay;
        private Button btnAddTrack;
        private Label lblTime;
        private ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private Button btnOpenFolder;
        private ListBox listBoxPlaylist;
        private Button btnPrevious;
        private Button btnNext;
        private Label lblTrackName;
        private ComboBox comboBoxRepeat;
        private Button btnSavePlaylist;
        private Button btnLoadPlaylist;
    }
}
