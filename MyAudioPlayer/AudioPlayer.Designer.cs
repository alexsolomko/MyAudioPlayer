namespace MyAudioPlayer
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
            SuspendLayout();
            // 
            // btnPause
            // 
            btnPause.Location = new Point(45, 388);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(200, 46);
            btnPause.TabIndex = 1;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(45, 460);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(200, 46);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(45, 316);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(200, 46);
            btnPlay.TabIndex = 3;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnAddTrack
            // 
            btnAddTrack.Location = new Point(45, 246);
            btnAddTrack.Name = "btnAddTrack";
            btnAddTrack.Size = new Size(200, 46);
            btnAddTrack.TabIndex = 4;
            btnAddTrack.Text = "Add Track";
            btnAddTrack.UseVisualStyleBackColor = true;
            btnAddTrack.Click += btnAddTrack_Click;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(628, 209);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(117, 25);
            lblTime.TabIndex = 5;
            lblTime.Text = "00:00 / 00:00";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(45, 167);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(700, 25);
            progressBar1.TabIndex = 6;
            // 
            // timer1
            // 
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
            // 
            // AudioPlayer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(778, 544);
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
    }
}
