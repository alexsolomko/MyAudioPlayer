namespace MyAudioPlayer
{
    using NAudio.Wave;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

    public partial class AudioPlayer : Form
    {
        List<string> playlist = new List<string>();
        int currentTrackIndex = -1;
        private IWavePlayer outputDevice;
        private AudioFileReader audioFile;
        private string currentFilePath;
        private bool isStoppingManually = false;
        private string fullTrackName = "";
        private CancellationTokenSource marqueeCts = null;


        private enum RepeatMode
        {
            None,
            RepeatOne,
            RepeatAll
        }

        private RepeatMode repeatMode = RepeatMode.None;



        public AudioPlayer()
        {
            InitializeComponent();

            comboBoxRepeat.Items.AddRange(new[] { "No Repeat", "Repeat One", "Repeat All" });
            comboBoxRepeat.SelectedIndex = 0;
            comboBoxRepeat.SelectedIndexChanged += ComboBoxRepeat_SelectedIndexChanged;

        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Audio files (*.mp3;*.wav;*.flac)|*.mp3;*.wav;*.flac";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        if (!playlist.Contains(filePath))
                        {
                            playlist.Add(filePath);
                            listBoxPlaylist.Items.Add(Path.GetFileName(filePath));
                        }
                    }

                    if (outputDevice == null && playlist.Count > 0)
                    {
                        currentTrackIndex = 0;
                        listBoxPlaylist.SelectedIndex = currentTrackIndex;
                        PlayTrack(currentTrackIndex);
                    }
                }
            }
        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (outputDevice != null && audioFile != null)
            {
                if (outputDevice.PlaybackState == PlaybackState.Stopped)
                {
                    audioFile.Position = 0;
                }

                if (outputDevice.PlaybackState != PlaybackState.Playing)
                {
                    outputDevice.Play();
                }

            }

            timer1.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                if (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    outputDevice.Pause();
                }
                else if (outputDevice.PlaybackState == PlaybackState.Paused)
                {
                    outputDevice.Play();
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                isStoppingManually = true;
                outputDevice.Stop();
                audioFile.Position = 0;
            }

            timer1.Stop();
            progressBar1.Value = 0;
            lblTime.Text = "00:00 / 00:00";
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (audioFile != null)
            {
                TimeSpan current = audioFile.CurrentTime;
                TimeSpan total = audioFile.TotalTime;

                lblTime.Text = $"{current:mm\\:ss} / {total:mm\\:ss}";

                if (total.TotalSeconds > 0)
                {
                    int progress = (int)(current.TotalSeconds / total.TotalSeconds * 100);
                    progressBar1.Value = Math.Min(progress, 100);
                }
            }
        }

        private void progressBar1_MouseDown(object sender, MouseEventArgs e)
        {
            if (audioFile != null)
            {
                // Ширина ProgressBar
                int barWidth = progressBar1.Width;

                // Позиция мыши
                int clickX = e.X;

                // Процент от начала
                double percent = (double)clickX / barWidth;

                // Новое время
                TimeSpan newTime = TimeSpan.FromSeconds(audioFile.TotalTime.TotalSeconds * percent);

                // Устанавливаем позицию
                audioFile.CurrentTime = newTime;
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = folderDialog.SelectedPath;
                    string[] supportedExtensions = { ".mp3", ".wav", ".flac" };

                    playlist = Directory
                        .GetFiles(folderPath)
                        .Where(file => supportedExtensions.Contains(Path.GetExtension(file).ToLower()))
                        .ToList();

                    listBoxPlaylist.Items.Clear();
                    foreach (var track in playlist)
                    {
                        listBoxPlaylist.Items.Add(Path.GetFileName(track));
                    }

                    if (playlist.Count > 0)
                    {
                        currentTrackIndex = 0;
                        PlayTrack(currentTrackIndex);
                        listBoxPlaylist.SelectedIndex = 0;
                    }
                }
            }
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentTrackIndex < playlist.Count - 1)
            {
                currentTrackIndex++;
                listBoxPlaylist.SelectedIndex = currentTrackIndex;
                PlayTrack(currentTrackIndex);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentTrackIndex > 0)
            {
                currentTrackIndex--;
                listBoxPlaylist.SelectedIndex = currentTrackIndex;
                PlayTrack(currentTrackIndex);
            }
        }


        private void PlayTrack(int index)
        {
            if (index >= 0 && index < playlist.Count)
            {
                string filePath = playlist[index];

                if (outputDevice != null)
                {
                    outputDevice.PlaybackStopped -= OnPlaybackStopped;
                    outputDevice.Stop();
                    outputDevice.Dispose();
                    outputDevice = null;
                }

                if (audioFile != null)
                {
                    audioFile.Dispose();
                    audioFile = null;
                }

                audioFile = new AudioFileReader(filePath);
                outputDevice = new WaveOutEvent();

                outputDevice.Init(audioFile);
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                outputDevice.Play();

                timer1.Start();
                lblTime.Text = "00:00 / 00:00";

                lblTrackName.Text = Path.GetFileNameWithoutExtension(filePath);
                fullTrackName = Path.GetFileNameWithoutExtension(filePath);
                _ = StartMarqueeAsync();

            }
        }


        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (isStoppingManually)
            {
                isStoppingManually = false;
                return;
            }

            switch (repeatMode)
            {
                case RepeatMode.RepeatOne:
                    Invoke(new Action(() =>
                    {
                        PlayTrack(currentTrackIndex);
                    }));
                    break;

                case RepeatMode.RepeatAll:
                    Invoke(new Action(() =>
                    {
                        currentTrackIndex++;
                        if (currentTrackIndex >= playlist.Count)
                            currentTrackIndex = 0;

                        listBoxPlaylist.SelectedIndex = currentTrackIndex;
                        PlayTrack(currentTrackIndex);
                    }));
                    break;

                case RepeatMode.None:
                default:
                    if (currentTrackIndex < playlist.Count - 1)
                    {
                        currentTrackIndex++;
                        Invoke(new Action(() =>
                        {
                            listBoxPlaylist.SelectedIndex = currentTrackIndex;
                            PlayTrack(currentTrackIndex);
                        }));
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            lblTrackName.Text = "🎵 Playback finished";
                        }));
                    }
                    break;
            }
        }


        private void listBoxPlaylist_DoubleClick(object sender, EventArgs e)
        {
            int index = listBoxPlaylist.SelectedIndex;
            if (index >= 0)
            {
                currentTrackIndex = index;
                PlayTrack(currentTrackIndex);
            }
        }

        private void ComboBoxRepeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxRepeat.SelectedItem.ToString())
            {
                case "No Repeat":
                    repeatMode = RepeatMode.None;
                    break;
                case "Repeat One":
                    repeatMode = RepeatMode.RepeatOne;
                    break;
                case "Repeat All":
                    repeatMode = RepeatMode.RepeatAll;
                    break;
            }
        }

        private async Task StartMarqueeAsync()
        {
            marqueeCts?.Cancel();
            marqueeCts = new CancellationTokenSource();
            var token = marqueeCts.Token;

            string padded = fullTrackName + "     ";
            int offset = 0;

            while (!token.IsCancellationRequested)
            {
                int visibleChars = fullTrackName.Length;

                Size textSize = TextRenderer.MeasureText(fullTrackName, lblTrackName.Font);
                if (textSize.Width <= lblTrackName.Width)
                {
                    lblTrackName.Text = fullTrackName;
                    return; 
                }

                // Делаем бегущую строку
                string scroll = padded.Substring(offset) + padded.Substring(0, offset);
                int maxLength = 100;
                lblTrackName.Text = scroll.Substring(0, Math.Min(scroll.Length, maxLength));

                offset = (offset + 1) % padded.Length;
                await Task.Delay(150, token);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            marqueeCts?.Cancel();
            base.OnFormClosing(e);
        }


        private void lblTrackName_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxRepeat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
