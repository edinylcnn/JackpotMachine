using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlotDeneme2
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            if (label1.Text == "superadmin")
            {
                frm2.label11.Text = "superadmin";

            }
            timer1.Stop();
            serialPort1.Close();      
            frm2.serialPort1.PortName = comDeger.Text;
            frm2.com.Text = comDeger.Text;
            frm2.Coin.Text = Coin.Text;
            frm2.Show();
            this.Hide();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            if (label1.Text == "superadmin")
            {
                frm1.label10.Text = "superadmin";

            }
            timer1.Stop();
            serialPort1.Close();
            frm1.serialPort1.PortName = comDeger.Text;
            frm1.com.Text = comDeger.Text;
            frm1.Coin.Text = Coin.Text;
            frm1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            Form2 frm2 = new Form2();
            frm1.serialPort1.Close();
            frm2.serialPort1.Close();
            this.Close();
            
        }

        private void Home_Load(object sender, EventArgs e)
        {
            timer1.Start();
            serialPort1.PortName = comDeger.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                serialPort1.Open();
            }
            serialPort1.Write("2");
            if (serialPort1.ReadLine() == "C\r")
            {
                Coin.Text = (Convert.ToInt32(Coin.Text) + 1).ToString();
            }
        }
    }
}
