using System;
using System.Windows.Forms;

using AudioProcessing.Core;

namespace AudioProcessing
{
    public partial class FrmSingleAudioAnalyzer : Form
    {
        public FrmSingleAudioAnalyzer()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            chkPlay.Checked = true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "WAV Files (*.wav) | *.wav";
            openFileDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
                txtFilePath.Text = openFileDialog1.FileName;
        }

        private AudioProcessor processor = null;
        private void btnParse_Click(object sender, EventArgs e)
        {
            txtParsedText.Text = txtAudioResult.Text = string.Empty;
            if (processor != null)
                processor.Dispose();
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Please choose a WAV file", AppConfig.GetConfigValue("APP_MSG_TITLE"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                processor = new AudioProcessor(AudioSourceMode.AudioFile, txtFilePath.Text);
                processor.PlayFile = chkPlay.Checked;
                processor.SpeechRecognized += OnSpeechRecognized;
                processor.Start();
            }
            catch(Exception ex)
            {
                processor = null;
                MessageBox.Show(ex.Message, AppConfig.GetConfigValue("APP_MSG_TITLE"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnSpeechRecognized(object sender, System.Speech.Recognition.SpeechRecognizedEventArgs e)
        {
            txtParsedText.Text += string.Format("{0}\r\n", e.Result.Text.ConvertRawTextAsSentence());
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtParsedText.Text))
            {
                MessageBox.Show("No parsed text found, please choose a WAV file and parse it.", AppConfig.GetConfigValue("APP_MSG_TITLE"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var analyzer = new SentimentAnalyzer(SentimentAnalyzeSource.Text, txtParsedText.Text.Trim()))
                txtAudioResult.Text = analyzer.Analyze().ToString();
        }
    }
}
