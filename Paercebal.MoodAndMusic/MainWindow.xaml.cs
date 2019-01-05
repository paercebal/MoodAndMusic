using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paercebal.MoodAndMusic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sound.Player player = new Sound.Player();

        public MainWindow()
        {
            InitializeComponent();
        }


        private string RetrieveSelectedFile()
        {
            if(this.SelectedFile.Text == null)
            {
                return "";
            }

            return this.SelectedFile.Text;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            this.player.play(this.RetrieveSelectedFile());
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            this.player.stop();
        }

        private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.player.Volume = this.Volume.Value;
        }
    }
    
}
