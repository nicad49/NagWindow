using System;
using System.Windows;
using System.Windows.Threading;
using WUApiLib;

namespace NagWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                var workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
                var corner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));

                this.Left = corner.X - this.ActualWidth - 1;
                this.Top = corner.Y - this.ActualHeight;
            }));

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

    }
}
