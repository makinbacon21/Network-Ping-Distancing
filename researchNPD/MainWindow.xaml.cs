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

        private void beginPing_Click(object sender, RoutedEventArgs e)
        {

            long Atime = 0;

            PingReply[] arrayReply = new PingReply[9];


            for (int i = 0; i < 10; i++)
            {

                //new ping request
                Ping p = new Ping();

                //reply data from ping = r
                PingReply r;

                //define string s
                string s;

                //set s to input text from textBox1
                s = textBox1.Text;

                //set PingReply r to ping of address s
                r = p.Send(s);

                //set the [i] of arrayReply to the current value of r
                arrayReply[i] = r;

                //if this instance of the ping is a success
                if (arrayReply[i].Status == IPStatus.Success)
                {
                    //output data from the PingReply as text
                    pingOutput.Text = "Ping to " + s.ToString() + "[" + arrayReply[i].Address.ToString() + "]" + " Successful"
                       + " Response delay = " + arrayReply[i].RoundtripTime.ToString() + " ms" + "\n";

                }
            }

            //long Atime = arrayReply[0].RoundtripTime / 2;


            //New integer replyCount for counting ping replies
            int replyCount = 0;

            //for each PingReply instance in arrayReply
            foreach (PingReply item in arrayReply)
            {
                //set long integer (64-bit) Atime (time of ping) to the previous value of Atime
                //plus half of the next RoundTripTime divided by 2 (for approx one-way distance)
                Atime = Atime + (item.RoundtripTime/2);

                //add one to replyCount
                replyCount++;

                //Divide Atime by number of replies
                Atime = Atime / replyCount;
            }


            #region create routerA circle

            //Ellipse basic details
            Ellipse a1;
                a1 = new Ellipse();
                a1.Height = 100; //CHANGE
                a1.Width = 100; //CHANGE
            
                //Ellipse colors and thicknesses
                a1.Stroke = Brushes.Blue;
                a1.StrokeThickness = 5;
                a1.Fill = Brushes.LightBlue;
                a1.Opacity = 0.4;

                //Ellipse hierarchy and alignment
                canvas1.Children.Add(a1);
                a1.HorizontalAlignment = HorizontalAlignment.Left;
                a1.VerticalAlignment = VerticalAlignment.Top;

                //Get location for ellipse
                double left = 332 - (a1.Width / 2 - 5);
                double top = 28 - (a1.Height / 2 - 5);

                //Margin
                a1.Margin = new Thickness(left, top, 0, 0);
                //a1.Margin = new Thickness(332, 28, 0, 0);

            #endregion create routerA circle

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
