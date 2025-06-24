namespace AudioPlayer
{
    partial class AudioPlayer
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnAddTrack;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.ListBox listBoxPlaylist;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblTrackName;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox comboBoxRepeat;
        private System.Windows.Forms.Button btnSavePlaylist;
        private System.Windows.Forms.Button btnLoadPlaylist;
        private System.Windows.Forms.Panel panelProgress;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnPause = new Button();
            btnStop = new Button();
            btnPlay = new Button();
            btnAddTrack = new Button();
            lblTime = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            btnOpenFolder = new Button();
            listBoxPlaylist = new ListBox();
            btnPrevious = new Button();
            btnNext = new Button();
            lblTrackName = new Label();
            comboBoxRepeat = new ComboBox();
            btnSavePlaylist = new Button();
            btnLoadPlaylist = new Button();
            panelProgress = new Panel();
            btnRemoveTrack = new Button();
            btnClearPlaylist = new Button();
            trackBarVolume = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
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
            listBoxPlaylist.DoubleClick += listBoxPlaylist_DoubleClick;
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
            // 
            // comboBoxRepeat
            // 
            comboBoxRepeat.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRepeat.FormattingEnabled = true;
            comboBoxRepeat.Location = new Point(28, 602);
            comboBoxRepeat.Name = "comboBoxRepeat";
            comboBoxRepeat.Size = new Size(138, 33);
            comboBoxRepeat.TabIndex = 12;
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
            // panelProgress
            // 
            panelProgress.BackColor = Color.LightGray;
            panelProgress.Cursor = Cursors.IBeam;
            panelProgress.Location = new Point(28, 158);
            panelProgress.Name = "panelProgress";
            panelProgress.Size = new Size(714, 25);
            panelProgress.TabIndex = 15;
            // 
            // btnRemoveTrack
            // 
            btnRemoveTrack.Location = new Point(172, 600);
            btnRemoveTrack.Name = "btnRemoveTrack";
            btnRemoveTrack.Size = new Size(138, 35);
            btnRemoveTrack.TabIndex = 16;
            btnRemoveTrack.Text = "Remove Track";
            btnRemoveTrack.UseVisualStyleBackColor = true;
            btnRemoveTrack.Click += btnRemoveTrack_Click;
            // 
            // btnClearPlaylist
            // 
            btnClearPlaylist.Location = new Point(316, 600);
            btnClearPlaylist.Name = "btnClearPlaylist";
            btnClearPlaylist.Size = new Size(138, 35);
            btnClearPlaylist.TabIndex = 17;
            btnClearPlaylist.Text = "Clear Playlist";
            btnClearPlaylist.UseVisualStyleBackColor = true;
            btnClearPlaylist.Click += btnClearPlaylist_Click;
            // 
            // trackBarVolume
            // 
            trackBarVolume.Location = new Point(770, 30);
            trackBarVolume.Maximum = 100;
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.Orientation = Orientation.Vertical;
            trackBarVolume.Size = new Size(69, 600);
            trackBarVolume.TabIndex = 18;
            trackBarVolume.TickFrequency = 10;
            trackBarVolume.Value = 50;
            // 
            // AudioPlayer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(840, 665);
            Controls.Add(trackBarVolume);
            Controls.Add(btnClearPlaylist);
            Controls.Add(btnRemoveTrack);
            Controls.Add(panelProgress);
            Controls.Add(btnLoadPlaylist);
            Controls.Add(btnSavePlaylist);
            Controls.Add(comboBoxRepeat);
            Controls.Add(lblTrackName);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(listBoxPlaylist);
            Controls.Add(btnOpenFolder);
            Controls.Add(lblTime);
            Controls.Add(btnAddTrack);
            Controls.Add(btnPlay);
            Controls.Add(btnStop);
            Controls.Add(btnPause);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "AudioPlayer";
            Text = "Audio Player";
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button btnRemoveTrack;
        private Button btnClearPlaylist;
        private TrackBar trackBarVolume;
    }
}
