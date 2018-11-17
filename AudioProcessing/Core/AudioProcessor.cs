using System;
using System.IO;
using System.Speech.Recognition;
using System.Media;
using System.Threading;

namespace AudioProcessing.Core
{
    public enum AudioSourceMode { Speaker, AudioFile }

    public class AudioProcessor : IDisposable
    {
        public static string[] SENTENCE_SEPERATORS = { ".", ",", "!", ":", ";" };

        public delegate void SpeechHypothesizedEventHandler(object sender, SpeechHypothesizedEventArgs e);
        public delegate void SpeechRecognizedEventHandler  (object sender, SpeechRecognizedEventArgs   e);

        public event SpeechHypothesizedEventHandler SpeechHypothesized;
        public event SpeechRecognizedEventHandler   SpeechRecognized;

        public SpeechRecognitionEngine Engine  { get; private set; }
        public DictationGrammar        Grammar { get; private set; }
        public AudioSourceMode         Source  { get; private set; }
        public string              WavFilePath { get; private set; }
        public bool                PlayFile    { get; set; }

        private bool disposed = false;

        public AudioProcessor(AudioSourceMode source, string wavFilePath)
        {
            Source      = source;
            WavFilePath = wavFilePath;
            PlayFile    = false;
            Setup();
        }

        public AudioProcessor(AudioSourceMode source, string wavFilePath, DictationGrammar targetGrammar) : this(source, wavFilePath)
        {
            Grammar = targetGrammar;
        }

        private void Setup()
        {
            Engine = new SpeechRecognitionEngine();
            Engine.UnloadAllGrammars();
        }

        private void AudioSetup()
        {
            if (Grammar == null)
                Grammar = new DictationGrammar();

            Engine.LoadGrammar(Grammar);
            Engine.RecognizeAsync(RecognizeMode.Multiple);

            Engine.SpeechRecognized   -= new EventHandler<SpeechRecognizedEventArgs  >(OnSpeechRecognized  );
            Engine.SpeechHypothesized -= new EventHandler<SpeechHypothesizedEventArgs>(OnSpeechHypothesized);
            Engine.SpeechRecognized   += new EventHandler<SpeechRecognizedEventArgs  >(OnSpeechRecognized  );
            Engine.SpeechHypothesized += new EventHandler<SpeechHypothesizedEventArgs>(OnSpeechHypothesized);
        }

        public void Start()
        {
            if (Source == AudioSourceMode.Speaker)
                Engine.SetInputToDefaultAudioDevice();
            else if (Source == AudioSourceMode.AudioFile)
            {
                if (string.IsNullOrEmpty(WavFilePath))
                    throw new ArgumentNullException("Invalid WAV file path");
                if (!File.Exists(WavFilePath))
                    throw new FileNotFoundException(string.Format("WAV file '{0}' does not exist.", WavFilePath));

                Engine.SetInputToWaveFile(WavFilePath);
            }
            AudioSetup();

            if (Source == AudioSourceMode.AudioFile && PlayFile)
                using (var player = new AudioPlayer(WavFilePath))
                {
                    var thread = new Thread(player.Play);
                    thread.Start();
                }
        }

        public void Stop()
        {
            Engine.UnloadGrammar(Grammar);
            Engine.RecognizeAsyncStop();
        }

        private void OnSpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            if (SpeechHypothesized != null)
                SpeechHypothesized(sender, e);
        }

        private void OnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (SpeechRecognized != null)
                SpeechRecognized(sender, e);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Stop();
                    Engine.SpeechRecognized   -= new EventHandler<SpeechRecognizedEventArgs  >(OnSpeechRecognized  );
                    Engine.SpeechHypothesized -= new EventHandler<SpeechHypothesizedEventArgs>(OnSpeechHypothesized);

                    Grammar = null;
                    Engine.UnloadAllGrammars();
                    Engine.Dispose();
                }
                disposed = true;
            }
        }
    }

    public class AudioPlayer : IDisposable
    {
        public string      AudioPath { get; private set; }
        public SoundPlayer Player    { get; private set; }

        private bool disposed = false;

        public AudioPlayer(String audioPath)
        {
            AudioPath = audioPath;
            Player    = new SoundPlayer(audioPath);
        }

        public void Play()
        {
            Player.PlaySync();
        }

        public void Dispose()
        {
            if (!disposed)
            {
                Player.Dispose();
                disposed = true;
            }
        }
    }
}
