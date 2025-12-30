using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace countdown_timer
{
    public partial class Form1 : Form
    {
        int remainingTime;

        public Form1()
        {
            InitializeComponent();
            label1.Text = "00:00:00";

            numHour.ValueChanged += UpdateTimeFromNumeric;
            numMinute.ValueChanged += UpdateTimeFromNumeric;
            numSecond.ValueChanged += UpdateTimeFromNumeric;

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }


        private void UpdateTimeFromNumeric(object sender, EventArgs e)
        {
            remainingTime = (int)numHour.Value * 3600 + (int)numMinute.Value * 60 + (int)numSecond.Value;
            UpdateLabel();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                UpdateLabel();
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Time's up!");
            }
        }

        private void UpdateLabel()
        {

            TimeSpan time = TimeSpan.FromSeconds(remainingTime);
            label1.Text = time.ToString(@"hh\:mm\:ss");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnStart_Click(null, null);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnStop_Click(null, null);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnReset_Click(null, null);
                e.SuppressKeyPress = true;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            remainingTime = 0;
            numHour.Value = 0;
            numMinute.Value = 0;
            numSecond.Value = 0;
            UpdateLabel();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

    }
}
