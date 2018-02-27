using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SlotDeneme2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //0013728EE05C5C0207110E73
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != null && comboBox1.Text != "")
            {
                string Drive = comboBox1.Text.Substring(0, 2);
                USBSerialNumber usb = new USBSerialNumber();
                string serial = usb.getSerialNumberFromDriveLetter(Drive);
                if (serial == "0013728EE05C5C0207110E73")
                {
                    if (txtUID.Text == "multigames")
                    {
                        if (txtPWD.Text == "mg17")
                        {
                            if (DateTime.Now > Convert.ToDateTime("1.06.2017"))
                            {
                                MessageBox.Show("Süreniz bitmiştir");
                                this.Close();
                            }
                            else
                            {
                                // Giriş Yapacak
                                YonetimPaneli yp = new YonetimPaneli();
                                int sonuc = OtelYukle();
                                int sonuc2 = OyunYukle();
                                yp.label11.Text = yp.listView1.Items.Count.ToString();
                                yp.label8.Text = yp.listView3.Items.Count.ToString();
                                if (sonuc >= sonuc2)
                                {
                                    MessageBox.Show("Oyun Sınırınız Dolmuştur");
                                    this.Close();
                                }
                                else
                                {
                                    Form1 frm = new Form1();
                                    Home home = new Home();
                                    home.comDeger.Text = "COM" + txtCom.Text;
                                    label4.Text = txtUID.Text;
                                    frm.btnYonetim.Hide();
                                    home.Show();
                                    this.Hide();
                                }
                            }


                        }
                        else
                        {
                            label3.Text = "Geçersiz Giriş";
                        }
                    }
                    else if (txtUID.Text == "superadmin")
                    {

                        if (txtPWD.Text == "mg17")
                        {
                            if (DateTime.Now > Convert.ToDateTime("1.06.2018"))
                            {
                                MessageBox.Show("Süreniz bitmiştir");
                                this.Close();
                            }
                            else
                            {
                                Form1 frm = new Form1();
                                Form2 frm2 = new Form2();
                                Home home = new Home();
                                label4.Text = txtUID.Text;
                                home.comDeger.Text = "COM" + txtCom.Text;
                                home.label1.Text = txtUID.Text;
                                home.Show();
                                this.Hide();
                                frm.btnYonetim.Show();
                                frm2.btnYonetim.Enabled = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hatalı Giriş");
                        }
                    }
                    else
                    {
                        label3.Text = "Geçersiz Giriş";
                    }
                }
                else
                {
                    MessageBox.Show("Giriş Anahtarı Geçersiz");
                    this.Close();
                }
                
            }
            

        }
        string path = "../../App_Data/Otel.txt";
        string path2 = "../../App_Data/Otel2.txt";
        #region Otel Yükle
        private int  OtelYukle()
        {
            YonetimPaneli yon = new YonetimPaneli();
            yon.listView1.Items.Clear();
            foreach (var item in HotelLoad())
            {
                string[] otel = item.ToString().Split('&');
                ListViewItem lvi = new ListViewItem();
                lvi.Text = otel[0];
                lvi.Tag = item;
                yon.listView1.Items.Add(lvi);
            }
            return yon.listView1.Items.Count;
        }
        #endregion
        #region Hotel Load
        private ArrayList HotelLoad()
        {
            ArrayList okunanlar = new ArrayList();
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        okunanlar.Add(sr.ReadLine());
                    }
                }
            }
            return okunanlar;
        }
        #endregion
        #region OyunLoad
        private ArrayList OyunLoad()
        {
            ArrayList okunanlar2 = new ArrayList();
            if (File.Exists(path2))
            {
                using (StreamReader sr2 = new StreamReader(path2))
                {
                    while (sr2.Peek() >= 0)
                    {
                        okunanlar2.Add(sr2.ReadLine());
                    }
                }
            }
            return okunanlar2;
        }
        #endregion
        #region OyunYukle
        private int OyunYukle()
        {
            YonetimPaneli yon = new YonetimPaneli();
            yon.listView3.Items.Clear();
            foreach (var item2 in OyunLoad())
            {
                string[] otel2 = item2.ToString().Split('&');
                ListViewItem lvi2 = new ListViewItem();
                lvi2.Text = otel2[0];
                lvi2.Tag = item2;
                yon.listView3.Items.Add(lvi2);
            }
            return yon.listView3.Items.Count;
        }
        #endregion
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {
                if (driveInfo.DriveType == DriveType.Removable)
                {
                    comboBox1.Items.Add(driveInfo.Name.ToString());
                    comboBox1.ValueMember = driveInfo.Name.ToString();
                    comboBox1.DisplayMember = driveInfo.Name.ToString();
                }
            }
        }
    }
}
