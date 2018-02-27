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
using System.Media;
//using static System.Convert;

namespace SlotDeneme2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path = "../../App_Data/Otel.txt";
        string path1 = "../../App_Data/Otel1.txt";
        string path2 = "../../App_Data/Otel2.txt";
        string path3 = "../../App_Data/cevir.wav";
        string path4 = "../../App_Data/kazandi.mp3";
        #region Otel Yükle
        private void OtelYukle()
        {
            yp.listView1.Items.Clear();
            foreach (var item in HotelLoad())
            {
                string[] otel = item.ToString().Split('&');
                ListViewItem lvi = new ListViewItem();
                lvi.Text = otel[0];
                lvi.Tag = item;
                yp.listView1.Items.Add(lvi);
            }
        }
        private void CoinYukle()
        {
            yp.listView2.Items.Clear();
            foreach (var item1 in CoinLoad())
            {
                string[] otel1 = item1.ToString().Split('&');
                ListViewItem lvi1 = new ListViewItem();
                lvi1.Text = otel1[0];
                lvi1.Tag = item1;
                yp.listView2.Items.Add(lvi1);
            }
        }
        #endregion
        #region Hotel Load
        private ArrayList HotelLoad()
        {
            ArrayList okunanlar = new ArrayList();
            if (File.Exists(path))
            {
                using (StreamReader sr1 = new StreamReader(path))
                {
                    while (sr1.Peek() >= 0)
                    {
                        okunanlar.Add(sr1.ReadLine());
                    }
                }
            }
            return okunanlar;
        }
        private ArrayList CoinLoad()
        {
            ArrayList okunanlar = new ArrayList();
            if (File.Exists(path1))
            {
                using (StreamReader sr = new StreamReader(path1))
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
        private int TotalYukle()
        {
            YonetimPaneli yon = new YonetimPaneli();
            yon.listView1.Items.Clear();
            foreach (var item5 in TotalLoad())
            {
                string[] otel2 = item5.ToString().Split('&');
                ListViewItem lvi5 = new ListViewItem();
                lvi5.Text = otel2[0];
                lvi5.Tag = item5;
                yon.listView1.Items.Add(lvi5);
            }
            return yon.listView1.Items.Count;
        }
        #endregion
        #region OyunParaLoad
        private ArrayList TotalLoad()
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
        #region DpYukle
        private int DpYukle()
        {
            YonetimPaneli yon = new YonetimPaneli();
            yon.listView1.Items.Clear();
            foreach (var item5 in DpLoad())
            {
                string[] otel2 = item5.ToString().Split('&');
                ListViewItem lvi5 = new ListViewItem();
                lvi5.Text = otel2[0];
                lvi5.Tag = item5;
                yon.listView1.Items.Add(lvi5);
            }
            return yon.listView1.Items.Count;
        }
        #endregion
        #region DpLoad
        private ArrayList DpLoad()
        {
            ArrayList okunanlar = new ArrayList();
            if (File.Exists(path1))
            {
                using (StreamReader sr = new StreamReader(path1))
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
        #region Oranlar      
        public int Oran(int a, int b, int c, double sonuc, int kasadakiPara)
        {
            // a = Kart Değeri
            // b = Oyuna Atılan Para Değeri
            // c = Şansını Katla Değeri
            // d = Kasadaki Para
            // o = Oran
            // Sonuc = kasadakiPara + disariAtilanPara
            //Oran = ((Sonuc / 100) * 35)
            //  if(sonuc > kasadakiPara)
            //   a=1;
            int elli = 0;
            int elli2 = 0;
            int on = 0;
            a = rnd.Next(0, 100);
            if (c == 1) // Normal 1tl oranları
            {
                if (b < 6)
                {
                    if (a < 54) //                0 - 53      54
                        a = 1;
                    else if (a > 53 && a < 79) //     54 - 78      25
                        a = 2;

                    if (kasadakiPara > 200)
                    {
                        if (on <= 4)
                        {
                            a = 4;
                            on++;
                        }
                    }
                    else if (a > 78 && a < 94) //      79 - 93     15 
                        a = 3;
                    else if (a > 93 && a < 97) //      94 - 96      3
                        a = 4;
                    else if (a > 96 && a < 99) //      97 - 98      2
                        a = 5;
                    else if (a == 99)  //                 99        1
                        a = 6;
                }
                else if (b > 5 && b < 11)
                {

                    if (a < 61) //                0 - 53      54
                        a = 1;
                    else if (a > 60 && a < 87) //     54 - 78      25
                    {
                        a = 2;
                        if (elli == 2)
                        {
                            if (kasadakiPara > 300)
                            {
                                a = 5;
                                elli = 0;
                            }
                        }
                        else if (sonuc > kasadakiPara)
                        {
                            a = 1;
                        }
                    }    
                    else if (a > 86 && a < 100) //      79 - 93     15 
                    {
                        a = 3;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 1;
                    }  
                }
                else if (b > 10 && b < 21)
                {
                    if (a < 61) //                0 - 53      54
                        a = 2;
                    else if (a > 60 && a < 87) //     54 - 78      25
                    {
                        a = 3;

                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 1;
                    } 
                    else if (a > 86 && a < 100) //      79 - 93     15 
                        a = 4;
                }
                else if (b > 20 && b < 50)
                {
                    if (a < 61)               //      0 - 64     65
                    {
                        a = 3;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 1;
                    }
                    else if (a > 60 && a < 87) //     65 - 84    20
                    {
                        a = 4;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 2;
                    }

                    else if (a > 86 && a < 100) //    85 - 99    15 
                    {
                        a = 5;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 3;
                    } 
                }
                else if (b > 50 && b < 151)
                {
                    
                    if (a < 61)               //      0 - 64     65
                    {
                        a = 3;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 1;
                    }
                    else if (a > 60 && a < 87) //     65 - 84    20
                    {
                        a = 4;
                        if (elli <= 2)
                        {
                            if (kasadakiPara > 250)
                            {
                                a = 5;
                                elli++;
                            }
                        }
                        else if (sonuc > kasadakiPara) //////////////////////////
                            a = 3;
                    }

                    else if (a > 86 && a < 100) //    85 - 99    15 
                    {
                        a = 5;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 2;
                    }
                }
                else if (b > 150 && b < 300)
                {
                    
                    if (a < 61)               //      0 - 64     65
                    {
                        a = 4;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 3;
                    }
                    else if (a > 60 && a < 87) //     65 - 84    20
                    {
                        a = 3;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 2;
                    }

                    else if (a > 86 && a < 100) //    85 - 99    15 
                    {
                        a = 6;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 3;
                    }
                }
            }
            else if (c > 1) //Adam Şansını Katladıysa Oranları Azalt ///////////////////////////////////////////////////////
            {
                if (b < 6)
                {
                    if (a < 54) //                0 - 53      54
                        a = 1;
                    else if (a > 53 && a < 79) //     54 - 78      25
                    {
                        a = 2;
                    } 
                    else if (a > 78 && a < 94) //      79 - 93     15 
                        a = 3;
                    else if (a > 93 && a < 97) //      94 - 96      3
                        a = 4;
                    else if (a > 96 && a < 99) //      97 - 98      2
                        a = 5;
                    else if (a == 99)  //                 99        1
                        a = 6;
                }
                else if (b > 5 && b < 11)
                {

                    if (a < 51) //                0 - 53      54
                        a = 1;
                    else if (a > 50 && a < 81) //     54 - 78      25
                    {
                        a = 2;
                        if (elli2 == 2)
                        {
                            if (kasadakiPara > 300)
                            {
                                a = 5;
                                elli2 = 0;
                            }
                        }
                        else if (sonuc > kasadakiPara) ////////////////////////
                        {
                            a = 1;
                        }
                    }
                    else if (a > 80 && a < 100) //      79 - 93     15 
                    {
                        a = 3;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 1;
                    }
                }
                else if (b > 10 && b < 21)
                {
                    if (a < 51) //                0 - 53      54
                        a = 2;
                    else if (a > 50 && a < 81) //     54 - 78      25
                    {
                        a = 3;

                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 1;
                    }
                    else if (a > 80 && a < 100) //      79 - 93     15 
                        a = 3;
                }
                else if (b > 20 && b < 50)
                {
                    if (a < 51)               //      0 - 64     65
                    {
                        a = 3;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 1;
                    }
                    else if (a > 50 && a < 81) //     65 - 84    20
                    {
                        a = 4;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 2;
                    }

                    else if (a > 80 && a < 100) //    85 - 99    15 
                    {
                        a = 5;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 2;
                    }
                }
                else if (b > 50 && b < 151)
                {

                    if (a < 51)               //      0 - 64     65
                    {
                        a = 3;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 1;
                    }
                    else if (a > 50 && a < 81) //     65 - 84    20
                    {
                        a = 4;
                        if (elli2 <= 2)
                        {
                            if (kasadakiPara > 700)
                            {
                                a = 5;
                                elli2++;
                            }
                        }
                        else if (sonuc > kasadakiPara) //////////////////////////
                            a = 3;
                    }

                    else if (a > 80 && a < 100) //    85 - 99    15 
                    {
                        a = 5;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 2;
                    }
                }
                else if (b > 150 && b < 300)
                {
                    if (a < 51)               //      0 - 64     65
                    {
                        a = 4;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 2;
                    }
                    else if (a > 50 && a < 81) //     65 - 84    20
                    {
                        a = 3;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 2;
                    }

                    else if (a > 80 && a < 100) //    85 - 99    15 
                    {
                        a = 6;
                        if (sonuc > kasadakiPara) //////////////////////////
                            a = 3;
                        else if (kasadakiPara > 1500)
                        {

                        }
                    }
                }
            }
          
            return a;
        }
        public int Para(int a, int c)
        {
            if (a == 1)
                a = 1 * c;
            else if (a == 2)
                a = 2 * c;
            else if (a == 3)
                a = 5 * c;
            else if (a == 4)
                a = 10 * c;
            else if (a == 5)
                a = 50 * c;
            else if (a == 6)
                a = 100 * c;
            return a;
        }
        #endregion
        Random rnd = new Random();
        int disaripara;
        int paRa;
        private void Form1_Load(object sender, EventArgs e)
        {
            Home lgn = new Home();
            if (/*label10.Text*/"superadmin" == "superadmin") // Eğer giriş yapan kullanıcı superadmin ise
            {
                btnYonetim.Show(); // yönetim paneli tuşu gözükecektir
            }
            else
            {
                btnYonetim.Hide(); // Değil ise gözükmicektir
            }
            
            timer.Stop(); // Timer nesnesi meyveleri döndüren timerdır form başlangıcında kapalı olucaktır. Stop
            timer1.Start(); // Coin Acceptr ü çalıştıran time1 form açılınca direk çalışmasını sağlıyor. Start
            serialPort1.Close(); // Seri Haberleşme portu form yüklendiğinde açık olucaktır Open ile seri haberleşmeyi açıyoruz.Open
            tmrDisariPara.Stop(); // Dışarı para atma olayını gerçekleştiren timer nesnesidir koşullar sağlandığında çalışıcaktır. Stop
        }
        YonetimPaneli yp = new YonetimPaneli();
        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = path3;
            player.Play();

            if (Convert.ToInt32(Coin.Text) < 1)
            {
                MessageBox.Show("Yetersiz Bakiye Lütfen Para Atınız!! ");
                btnTurn.Hide();
            }
            else if ((Convert.ToInt32(Coin.Text) - Convert.ToInt32(xCoin.Text)) >= 0)
            {
                timer1.Stop(); // Coin Acceptor ü durdur
                timer.Start(); // Çarkları döndürmeye başla
                btnTurn.Hide(); // butonu sakla
                Coin.Text = (Convert.ToInt32(Coin.Text) - Convert.ToInt32(xCoin.Text)).ToString(); // burda da para değerini kesiyoruz
                //
                ArrayList okunanlar = HotelLoad();

                using (StreamWriter sw = new StreamWriter(path))
                {

                    if (okunanlar.Count > 0)
                    {
                        foreach (string otel in okunanlar)
                        {
                            sw.WriteLine(otel);
                        }
                    }
                    for (int i = 0; i < Convert.ToInt32(xCoin.Text); i++)
                    {
                        sw.WriteLine(string.Format("{0}", DateTime.Now));
                    }

                    sw.Close();
                }
                OtelYukle();
                //
                // bu arada oynanan veriyi txt dosyasına kaydettik

            }


        }
        int sayac = 0;
        int a;
        int b;
        int c;
        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            //Oran//
            rmd(0,100)
            1.   50  (0,50)
            2.   30  (50,80)
            3.   10  (80,90)
            4.   4   (90,94)
            5.   3   (94,97)
            6.   2   (97,99)
            7.   1   (99,100)
           */
            sayac++;
            if (sayac <= 42)
            {
                a = rnd.Next(0, 100);
                b = rnd.Next(0, 100);
                c = rnd.Next(0, 100);
                pb1.Image = iList.Images[rnd.Next(1, 7)];
                pBox4.Image = iList.Images[rnd.Next(1, 7)];
                pBox7.Image = iList.Images[rnd.Next(1, 7)];
                pb2.Image = iList.Images[rnd.Next(1, 7)];
                pBox5.Image = iList.Images[rnd.Next(1, 7)];
                pBox8.Image = iList.Images[rnd.Next(1, 7)];
                pb3.Image = iList.Images[rnd.Next(1, 7)];
                pBox6.Image = iList.Images[rnd.Next(1, 7)];
                pBox9.Image = iList.Images[rnd.Next(1, 7)];
            }
            else
            {
                double oran = 1;
                double oran2 = 1;
                int toplamOyun = TotalYukle();
                int disariPara = DpYukle();
                int ot = 35;
                int yuz = 100;
                oran = toplamOyun * ot;
                oran2 = oran / yuz;
                int kasadakiPara = toplamOyun - disariPara;
                int kart1 = Oran(a, Convert.ToInt32(Coin.Text), Convert.ToInt32(xCoin.Text), oran2, kasadakiPara);
                int kart2 = Oran(b, Convert.ToInt32(Coin.Text), Convert.ToInt32(xCoin.Text), oran2, kasadakiPara);
                int kart3 = Oran(c, Convert.ToInt32(Coin.Text), Convert.ToInt32(xCoin.Text), oran2, kasadakiPara);
                pb1.Image = iList.Images[kart1];//kart1];
                pb2.Image = iList.Images[kart2];//kart2];
                pb3.Image = iList.Images[kart3];//kart3];
                timer.Stop();
                if (kart1 == kart2 && kart2 == kart3)
                {
                    label5.Text = "Tebrikler" + "\n" + Para(kart1, Convert.ToInt32(xCoin.Text)) + "TL Kazandınız";
                    paRa = Para(kart1, Convert.ToInt32(xCoin.Text));
                    btnTurn.Show();
                    //////////////////////////////////////
                    if (serialPort1.IsOpen == false)
                        serialPort1.Close();//Open
                    tmrDisariPara.Start();
                    sayac = 0;
                   // serialPort1.Write("1");
                    //////////////////////////////////////
                    ArrayList okunanlar1 = CoinLoad();
                    using (StreamWriter sw1 = new StreamWriter(path1))
                    {
                        if (okunanlar1.Count > 0)
                        {
                            foreach (string otel1 in okunanlar1)
                            {
                                sw1.WriteLine(otel1);
                            }
                        }
                        for (int i = 0; i < Para(kart1, Convert.ToInt32(xCoin.Text)); i++)
                        {
                            sw1.WriteLine(string.Format("{0}", Para(kart1, Convert.ToInt32(xCoin.Text))));
                        }

                        sw1.Close();
                    }
                    CoinYukle();


                }
                else
                {
                    label5.Text = "Kaybettiniz\nTekrar Deneyin";
                    timer1.Start(); //Coin Acceptor Start
                    sayac = 0;
                    btnTurn.Show();

                }
            }
            //else
            //{
            //    kart1 = Oran(a);
            //    pb1.Image = iList.Images[kart1];//kart1];
            //    timer.Stop();
            //    sayac = 0;
            //}


        }
        private void addCoin_Click(object sender, EventArgs e)
        {//
            Coin.Text = (Convert.ToInt32(Coin.Text) + 1).ToString();
            if (Convert.ToInt32(Coin.Text) == 1)
            {
                btnTurn.Show();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(xCoin.Text) == 3)
            {
                xCoin.Text = 3.ToString();
            }
            else
            {
                xCoin.Text = (Convert.ToInt32(xCoin.Text) + 1).ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(xCoin.Text) == 1)
            {
                xCoin.Text = 1.ToString();
            }
            else
            {
                xCoin.Text = (Convert.ToInt32(xCoin.Text) - 1).ToString();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Coin.Text = Coin.Text;
            hm.comDeger.Text = com.Text;
            timer1.Stop();
            serialPort1.Close();
            hm.Show();
            this.Hide();

        }
        private void btnYonetim_Click(object sender, EventArgs e)
        {
            YonetimPaneli yonetim = new YonetimPaneli();
            yonetim.Show();


        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //if (serialPort1.IsOpen == false)
            //{
            //    serialPort1.Close();//Open
            //}
            //serialPort1.Write("2");
            //if (serialPort1.ReadLine() == "C\r")
            //{
            //    Coin.Text = (Convert.ToInt32(Coin.Text) + 1).ToString();
            //}
        }
        private void tmrDisariPara_Tick(object sender, EventArgs e)
        {
            //string oku = serialPort1.ReadLine();
            //if (oku == "F\r")
            //{
            //    disaripara++;
            //    if (disaripara == paRa)
            //    {
            //        serialPort1.Write("0");
            //        paRa = 0;
            //        disaripara = 0;
            //        tmrDisariPara.Stop();
            //        serialPort1.Close();
            //        timer1.Start(); // Coin acceptor Start
            //    }
           // }
        }
    }
}


//{
//    int kart1 = Oran(a);
//    int kart2 = Oran(b);
//    int kart3 = Oran(c);
//    pb1.Image = iList.Images[kart1];//kart1];
//    pb2.Image = iList.Images[kart2];//kart2];
//    pb3.Image = iList.Images[kart3];//kart3];
//    timer.Stop();
//    if (kart1 == kart2 && kart2 == kart3)
//    {
//        label5.Text = "Tebrikler" + "\n" + Para(kart1, Convert.ToInt32(xCoin.Text)) + "TL Kazandınız";
//        sayac = 0;
//        //
//        ArrayList okunanlar = HotelLoad();

//        using (StreamWriter sw = new StreamWriter(path1))
//        {

//            if (okunanlar.Count > 0)
//            {
//                foreach (string otel in okunanlar)
//                {
//                    sw.WriteLine(otel);
//                }
//            }

//            sw.WriteLine(string.Format("{0}", Convert.ToInt32(xCoin.Text)) + "TL" );
//            sw.Close();
//        }
//        OtelYukle();
//        //

//    }
//    else
//    {
//        label5.Text = "Kaybettiniz\nTekrar Deneyin";
//        sayac = 0;

//    }

//}