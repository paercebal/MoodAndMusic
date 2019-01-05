using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Paercebal.MoodAndMusic.Sound
{
    public class Player
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader fileReader;

        public Player()
        {

        }

        private string GetFileExtension(string musicFile)
        {
            var lastIndex = musicFile.LastIndexOf('.');

            if((lastIndex > 0) && (lastIndex + 1 < musicFile.Length))
            {
                return musicFile.Substring(lastIndex + 1);
            }

            return "";
        }

        private AudioFileReader GetReader(string musicFile)
        {
            var extension = this.GetFileExtension(musicFile);

            if (extension == "mp3")
            {
                return new AudioFileReader(musicFile);
            }

            return null;
        }

        public void play(string musicFile)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (fileReader == null)
            {
                fileReader = this.GetReader(musicFile);
                this.SetReaderVolume(this.fileReader);
                outputDevice.Init(fileReader);
            }
            outputDevice.Play();
        }

        public void stop()
        {
            outputDevice?.Stop();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            this.outputDevice.Dispose();
            this.outputDevice = null;
            this.fileReader.Dispose();
            this.fileReader = null;
        }


        private double volume;
        public double Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
                this.SetReaderVolume(this.fileReader);
            }
        }

        private void SetReaderVolume(AudioFileReader reader)
        {
            if (reader != null)
            {
                reader.Volume = (float)(volume / 100.0);
            }
        }
    }
}
