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
    public partial class YonetimPaneli : Form
    {
        public YonetimPaneli()
        {
            InitializeComponent();
        }

        private void YonetimPaneli_Load(object sender, EventArgs e)
        {
            OtelYukle();
            CoinYukle();
            OyunYukle();
            label8.Text = listView3.Items.Count.ToString();
            label11.Text = listView1.Items.Count.ToString();
            label6.Text = listView2.Items.Count.ToString();
            label7.Text = ((Convert.ToInt32(label11.Text)) - (Convert.ToInt32(label6.Text))).ToString();
            label10.Text = ((Convert.ToInt32(label8.Text)) - (Convert.ToInt32(label11.Text))).ToString();

        }
        #region Otel Yükle
        private void OtelYukle()
        {
            listView1.Items.Clear();
            foreach (var item in HotelLoad())
            {
                string[] otel = item.ToString().Split('&');
                ListViewItem lvi = new ListViewItem();
                lvi.Text = otel[0];
                lvi.Tag = item;
                listView1.Items.Add(lvi);
            }
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
        #region CoinLoad
        private ArrayList CoinLoad()
        {
            ArrayList okunanlar1 = new ArrayList();
            if (File.Exists(path1))
            {
                using (StreamReader sr1 = new StreamReader(path1))
                {
                    while (sr1.Peek() >= 0)
                    {
                        okunanlar1.Add(sr1.ReadLine());
                    }
                }
            }
            return okunanlar1;
        }
#endregion
        #region CoinYukle
        private void CoinYukle()
        {
            listView2.Items.Clear();
            foreach (var item1 in CoinLoad())
            {
                string[] otel1 = item1.ToString().Split('&');
                ListViewItem lvi1 = new ListViewItem();
                lvi1.Text = otel1[0];
                lvi1.Tag = item1;
                listView2.Items.Add(lvi1);
            }
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
        private void OyunYukle()
        {
            listView3.Items.Clear();
            foreach (var item2 in OyunLoad())
            {
                string[] otel2 = item2.ToString().Split('&');
                ListViewItem lvi2 = new ListViewItem();
                lvi2.Text = otel2[0];
                lvi2.Tag = item2;
                listView3.Items.Add(lvi2);
            }
        }
        #endregion

        string path = "../../App_Data/Otel.txt";
        string path1 = "../../App_Data/Otel1.txt";
        string path2 = "../../App_Data/Otel2.txt";

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            label8.Text = textBox1.Text;
                ArrayList okunanlar2 = OyunLoad();

               using (StreamWriter sw = new StreamWriter(path2))
                {

                    if (okunanlar2.Count > 0)
                    {
                        foreach (string otel2 in okunanlar2)
                       {
                          sw.WriteLine(otel2);
                        }
                   }
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                sw.WriteLine(string.Format("{0}", "1"));
            }
               
               sw.Close();
           }
            OyunYukle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(path, String.Empty);
            File.WriteAllText(path1, String.Empty);
            File.WriteAllText(path2, String.Empty);
            OtelYukle();
            CoinYukle();
            OyunYukle();
            label8.Text = listView3.Items.Count.ToString();
            label11.Text = listView1.Items.Count.ToString();
            label6.Text = listView2.Items.Count.ToString();
            label7.Text = ((Convert.ToInt32(label11.Text)) - (Convert.ToInt32(label6.Text))).ToString();
            label10.Text = ((Convert.ToInt32(label8.Text)) - (Convert.ToInt32(label11.Text))).ToString();
        }
    }
}
