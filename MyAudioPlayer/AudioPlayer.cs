namespace MyAudioPlayer
{
    using NAudio.Wave;

    public partial class AudioPlayer : Form
    {
        private IWavePlayer outputDevice;
        private AudioFileReader audioFile;
        private string currentFilePath;

        public AudioPlayer()
        {
            InitializeComponent();
        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Audio files (*.mp3;*.wav;*.flac)|*.mp3;*.wav;*.flac";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = openFileDialog.FileName;

                    // Освобождаем старые ресурсы
                    if (outputDevice != null)
                    {
                        outputDevice.Stop();
                        outputDevice.Dispose();
                        outputDevice = null;
                    }

                    if (audioFile != null)
                    {
                        audioFile.Dispose();
                        audioFile = null;
                    }

                    // Загружаем новый трек
                    audioFile = new AudioFileReader(currentFilePath);
                    outputDevice = new WaveOutEvent();
                    outputDevice.Init(audioFile);

                    MessageBox.Show("Трек загружен. Нажмите Play для воспроизведения.");
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

    }
}
