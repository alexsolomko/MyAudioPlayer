using NAudio.Wave;
using System.Text.Json;

namespace AudioPlayer
{
    public partial class AudioPlayer : Form
    {
        private List<string> playlist = new List<string>();
        private int currentTrackIndex = -1;
        private IWavePlayer outputDevice;
        private AudioFileReader audioFile;
        private bool isStoppingManually = false;
        private string fullTrackName = "";

        private enum RepeatMode { None, RepeatOne, RepeatAll }
        private RepeatMode repeatMode = RepeatMode.None;

        public AudioPlayer()
        {
            InitializeComponent();

            comboBoxRepeat.Items.AddRange(new[] { "No Repeat", "Repeat One", "Repeat All" });
            comboBoxRepeat.SelectedIndex = 0;
            comboBoxRepeat.SelectedIndexChanged += ComboBoxRepeat_SelectedIndexChanged;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            panelProgress.Paint += PanelProgress_Paint;
            panelProgress.MouseDown += PanelProgress_MouseDown;
        }

        private void ComboBoxRepeat_SelectedIndexChanged(object sender, EventArgs e)
        {
            repeatMode = (RepeatMode)comboBoxRepeat.SelectedIndex;
        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Audio Files|*.mp3;*.wav;*.wma;*.aac";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in openFileDialog.FileNames)
                    playlist.Add(file);

                RefreshPlaylist();
            }
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                var files = Directory.GetFiles(folderDialog.SelectedPath)
                    .Where(f => f.EndsWith(".mp3") || f.EndsWith(".wav") || f.EndsWith(".wma") || f.EndsWith(".aac"))
                    .ToArray();

                playlist.AddRange(files);
                RefreshPlaylist();
            }
        }

        private void RefreshPlaylist()
        {
            listBoxPlaylist.Items.Clear();
            foreach (var track in playlist)
                listBoxPlaylist.Items.Add(Path.GetFileNameWithoutExtension(track));
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (currentTrackIndex == -1 && playlist.Count > 0)
                currentTrackIndex = 0;

            if (currentTrackIndex >= 0 && currentTrackIndex < playlist.Count)
                PlayTrack(currentTrackIndex);
        }

        private void PlayTrack(int index)
        {
            if (index < 0 || index >= playlist.Count) return;

            string file = playlist[index];

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

            audioFile = new AudioFileReader(file);
            outputDevice = new WaveOutEvent();
            outputDevice.Init(audioFile);
            outputDevice.PlaybackStopped += OnPlaybackStopped;
            outputDevice.Play();

            timer1.Start();
            lblTrackName.Text = Path.GetFileNameWithoutExtension(file);
            fullTrackName = lblTrackName.Text;
            lblTime.Text = "00:00 / 00:00";

            panelProgress.Invalidate();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (isStoppingManually)
            {
                isStoppingManually = false;
                return;
            }

            if (repeatMode == RepeatMode.RepeatOne)
            {
                PlayTrack(currentTrackIndex);
            }
            else if (repeatMode == RepeatMode.RepeatAll)
            {
                currentTrackIndex = (currentTrackIndex + 1) % playlist.Count;
                PlayTrack(currentTrackIndex);
            }
            else
            {
                currentTrackIndex++;
                if (currentTrackIndex < playlist.Count)
                    PlayTrack(currentTrackIndex);
                else
                {
                    timer1.Stop();
                    audioFile?.Dispose();
                    outputDevice?.Dispose();
                    audioFile = null;
                    outputDevice = null;
                    lblTime.Text = "00:00 / 00:00";
                    panelProgress.Invalidate();
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                if (outputDevice.PlaybackState == PlaybackState.Playing)
                    outputDevice.Pause();
                else if (outputDevice.PlaybackState == PlaybackState.Paused)
                    outputDevice.Play();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                isStoppingManually = true;
                outputDevice.Stop();
                timer1.Stop();
                lblTime.Text = "00:00 / 00:00";
                panelProgress.Invalidate();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (playlist.Count == 0) return;

            currentTrackIndex--;
            if (currentTrackIndex < 0) currentTrackIndex = playlist.Count - 1;

            PlayTrack(currentTrackIndex);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (playlist.Count == 0) return;

            currentTrackIndex++;
            if (currentTrackIndex >= playlist.Count) currentTrackIndex = 0;

            PlayTrack(currentTrackIndex);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (audioFile != null)
            {
                TimeSpan current = audioFile.CurrentTime;
                TimeSpan total = audioFile.TotalTime;

                lblTime.Text = $"{current:mm\\:ss} / {total:mm\\:ss}";
                panelProgress.Invalidate();
            }
        }

        private void PanelProgress_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(panelProgress.BackColor);

            if (audioFile == null)
                return;

            float ratio = (float)(audioFile.CurrentTime.TotalSeconds / audioFile.TotalTime.TotalSeconds);
            ratio = Math.Clamp(ratio, 0f, 1f);

            using (var backBrush = new SolidBrush(Color.LightGray))
                e.Graphics.FillRectangle(backBrush, panelProgress.ClientRectangle);

            Rectangle progressRect = new Rectangle(0, 0,
                (int)(panelProgress.Width * ratio), panelProgress.Height);

            using (var progressBrush = new SolidBrush(Color.DodgerBlue))
                e.Graphics.FillRectangle(progressBrush, progressRect);

            using (var pen = new Pen(Color.Black))
                e.Graphics.DrawRectangle(pen, 0, 0, panelProgress.Width - 1, panelProgress.Height - 1);
        }

        private void PanelProgress_MouseDown(object sender, MouseEventArgs e)
        {
            if (audioFile == null || audioFile.TotalTime.TotalSeconds == 0)
                return;

            double ratio = (double)e.X / panelProgress.Width;
            ratio = Math.Clamp(ratio, 0, 1);

            audioFile.CurrentTime = TimeSpan.FromSeconds(audioFile.TotalTime.TotalSeconds * ratio);
            panelProgress.Invalidate();
        }

        private void listBoxPlaylist_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxPlaylist.SelectedIndex >= 0)
            {
                currentTrackIndex = listBoxPlaylist.SelectedIndex;
                PlayTrack(currentTrackIndex);
            }
        }

        private void btnSavePlaylist_Click(object sender, EventArgs e)
        {
            if (playlist.Count == 0) return;

            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files|*.json";
            saveFileDialog.FileName = "playlist.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = JsonSerializer.Serialize(playlist);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }

        private void btnLoadPlaylist_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files|*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                playlist = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
                RefreshPlaylist();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            timer1.Stop();
            outputDevice?.Dispose();
            audioFile?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
