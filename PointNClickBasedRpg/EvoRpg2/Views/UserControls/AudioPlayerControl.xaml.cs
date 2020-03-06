using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EvoRpg2.Views.UserControls
{
    /// <summary>
    /// Interaction logic for AudioPlayerControl.xaml
    /// </summary>
    public partial class AudioPlayerControl : UserControl
    {
        private  MediaPlayer mediaPlayer = new MediaPlayer();
        private bool playing = false; 
        public AudioPlayerControl()
        {
            InitializeComponent();
            Unloaded += new RoutedEventHandler(this.Audio_Unloaded);
            Loaded += new RoutedEventHandler(this.Audio_Loaded);
            try
            {
                mediaPlayer.Open(new Uri(@"Resources/Audio/GameMusic.mp3", UriKind.Relative));
                mediaPlayer.Play();
                mediaPlayer.MediaEnded += new EventHandler(Media_Ended);
                playing = true;

            }
            catch (Exception)
            {
                MessageBox.Show("Couldn't play audio");
                _VolumeDown.IsEnabled = false;
                _VolumeUp.IsEnabled = false;

            }
        }

        private void Audio_Loaded(object sender, RoutedEventArgs e)
        {
            playing = true;
            mediaPlayer.Play();
        }

        private void Audio_Unloaded(object sender, RoutedEventArgs e)
        {
            playing = false;
            mediaPlayer.Pause();
        }

        private void _VolumeUp_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Volume = mediaPlayer.Volume + 0.1;
            
        }

        private void _VolumeDown_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Volume = mediaPlayer.Volume - 0.1;
            
        }

        private void _StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (playing)
            {
                mediaPlayer.Pause();
                playing = false;
            }
            else
            {
                mediaPlayer.Play();
                playing = true;
            }
        }
        private void Media_Ended(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.FromSeconds(1);
            mediaPlayer.Play();
        }
    }
}
