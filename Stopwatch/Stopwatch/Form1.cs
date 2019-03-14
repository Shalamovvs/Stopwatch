using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stopwatch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label1.Text = "00:00:0";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.AutoSize = false;
        }
        private DateTime StartTime;
        TimeSpan CurrentSpan = TimeSpan.Zero;
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = CurrentSpan + (DateTime.Now - StartTime);
            int teenth = elapsed.Milliseconds;
            string text = "";
            text +=
                elapsed.Minutes.ToString("00") + ":" +
                elapsed.Seconds.ToString("00") + ":" +
                teenth.ToString("0");
            label1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (timer1.Enabled == true)
            {
                button2.Enabled = true;
                timer1.Enabled = false;
                CurrentSpan += DateTime.Now - StartTime;
                button1.Text = "Start";

            }
            else
            {
                StartTime = DateTime.Now;
                button2.Enabled = false;
                timer1.Enabled = true;
                button1.Text = "Pause";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CurrentSpan = TimeSpan.Zero;
            timer1.Enabled = false;
            label1.Text = "00:00:0";
        }
    }
}
