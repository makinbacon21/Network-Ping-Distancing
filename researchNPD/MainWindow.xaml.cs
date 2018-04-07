using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace researchNPD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Router algorithm to plot ellipse with input, output, average, PingReply array, and ellipse definition
        /// </summary>
        public void routerAlgorithm(TextBox input, TextBlock output, TextBlock average, PingReply[] array, Ellipse ellipse)     //set parameters: TextBox input, TextBlock output, TextBlock average,
        {                                                                                                                       //array of PingReply array, Ellipse ellipse
            for (int i = 0; i < 10; i++)
            {

                //new ping request
                Ping p = new Ping();

                //reply data from ping = r
                PingReply r;

                //define string s
                string s;

                //set s to input text from textBox1
                s = input.Text;

                //set PingReply r to ping of address s
                r = p.Send(s);

                //set the [i] of arrayReply to the current value of r
                array[i] = r;

                average.Text = null;

                //if this instance of the ping is a success
                if (array[i].Status == IPStatus.Success)
                {
                    //output data from the PingReply as text

                    string currentOutput = "Ping to " + s.ToString() + "[" + array[i].Address.ToString() + "]" + " Successful"
                       + " Response delay = " + array[i].RoundtripTime.ToString() + " ms" + "\n";

                    output.Text = output.Text + Environment.NewLine + currentOutput;
                }
                else
                {
                    output.Text = "Failure";
                }
            }

            double time = array.Average(i => i.RoundtripTime) / 2;

            pingAverage.Text = time.ToString();

            #region create router circle

            //Ellipse basic details
            
            ellipse = new Ellipse();
            ellipse.Height = time * 100; //replace * 100 with algorithm based on ex. data
            ellipse.Width = ellipse.Height;

            //Ellipse colors and thicknesses
            ellipse.Stroke = Brushes.Blue;
            ellipse.StrokeThickness = 5;
            ellipse.Fill = Brushes.LightBlue;
            ellipse.Opacity = 0.4;

            //Ellipse hierarchy and alignment
            canvas1.Children.Add(ellipse);
            ellipse.HorizontalAlignment = HorizontalAlignment.Left;
            ellipse.VerticalAlignment = VerticalAlignment.Top;

            //Get location for ellipse
            double left = 332 - (ellipse.Width / 2 - 5);
            double top = 28 - (ellipse.Height / 2 - 5);

            //Margin
            ellipse.Margin = new Thickness(left, top, 0, 0);

            #endregion create router circle
        }

        private void beginPing_Click(object sender, RoutedEventArgs e)
        {
            PingReply[] arrayReply = new PingReply[10];

            Ellipse a1 = new Ellipse();

            routerAlgorithm(textBox1, pingOutput, pingAverage, arrayReply, a1);

        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text == "")
            {
                MessageBox.Show("Please use valid IP or web address!!");
            }
        }

        
    }
}
