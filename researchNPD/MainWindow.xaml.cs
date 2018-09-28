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
        public void routerAlgorithm(TextBox input, TextBlock output, TextBlock average, PingReply[] array, string router, Ellipse ellipse, int leftEllipse, int topEllipse, Brush color)     //set parameters: TextBox input, TextBlock output, TextBlock average,
        {                                                                                                                       //array of PingReply array, Ellipse ellipse
            for (int i = 0; i < 20; i++)
            {

                //new ping request
                Ping p = new Ping();

                //define string s as the IP address input from the box
                string s = input.Text;

                //reply data from ping = r
                PingReply r = p.Send(s);

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
                    //Let the user know the ping sequence failed
                    output.Text = "Failure";
                }
            }

            //get average time and set it as a double and display it in the "average" box
            double time = array.Average(reply => reply.RoundtripTime) / 2;

            average.Text = time.ToString();

            double radius = 0.0;

            if(router == "a")
            {
                radius = (time + 0.0088) / 0.189;
            }

            else if(router == "b")
            {
                radius = (time + 0.0088) / 0.189;
            }

            else if(router == "c")
            {
                radius = (time + 0.0088) / 0.189;
            }



/*  THIS IS OLD TEST STUFF
            //run values through the algorithm
            double newTime = time - 0.218;

            double radius = newTime/0.0496;
            //double radius = 8.6581 * time - 3.2487;
            */

            #region create router circle

            //Ellipse basic details

            ellipse = new Ellipse();
            ellipse.Height = radius * 3.65 *2; //multiply by pixels/meters
            ellipse.Width = ellipse.Height;

            //Ellipse colors and thicknesses
            ellipse.Stroke = color;
            ellipse.StrokeThickness = 5;
            ellipse.Fill = color;
            ellipse.Opacity = 0.4;

            //Ellipse hierarchy and alignment
            canvas1.Children.Add(ellipse);
            ellipse.HorizontalAlignment = HorizontalAlignment.Left;
            ellipse.VerticalAlignment = VerticalAlignment.Top;

            //Get location for ellipse
            double left = leftEllipse - (ellipse.Width / 2 - 5);
            double top = topEllipse - (ellipse.Height / 2 - 5);

            //Margin
            ellipse.Margin = new Thickness(left, top, 0, 0);

            #endregion create router circle
        }

        private void beginPing_Click(object sender, RoutedEventArgs e)
        {
            PingReply[] arrayReply = new PingReply[20];

            Ellipse a1 = new Ellipse();

            routerAlgorithm(textBox1, pingOutput, pingAverage, arrayReply, "a", a1, 361, 187, Brushes.Blue);

        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || textBox1.Text == "")
            {
                MessageBox.Show("Please use valid IP or web address!!");
            }
        }

        private void beginPingB_Click(object sender, RoutedEventArgs e)
        {
            PingReply[] arrayBReply = new PingReply[20];

            Ellipse b1 = new Ellipse();

            routerAlgorithm(textBox2, pingOutputB, pingAverageB, arrayBReply, "b", b1, 382, 150, Brushes.Red);
        }

        private void beginPingC_Click(object sender, RoutedEventArgs e)
        {
            PingReply[] arrayCReply = new PingReply[20];

            Ellipse c1 = new Ellipse();

            routerAlgorithm(textBox3, pingOutputC, pingAverageC, arrayCReply, "c", c1, 410, 148, Brushes.Green);
        }

        
    }
}
