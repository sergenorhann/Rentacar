using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Rentacar
{
    public partial class Ana : Form
    {
        public Ana()
        {
            InitializeComponent();
        }


        //---------------------------------------------------------------------------------------------------- PROGRAM YAPISI
        string Ustmenukonum = "a";
        string sozlesmetablo = "";
        string plaka = "";
        string tccno = "";
        public static string guncelleeyadakaydett = "";
        bool boslukkontrolu, klasor, verioneri, verioneri2, zorunlualann;
        string kayitbilgisi,Sozlesmegecisi;
        string dogumtarihi, ceptelefon, istelefon, verilistarihi;
        string gecerliliktarihi, kartno, skt, odemesistemi, Esinif;
        string ililce, hangiislem, Musterikefiltc, aracsahibitc, gecicisozlesmeno;
        string kopyalanacakdosyaismi, kopyalanacakdosya, DosyaUzantisi, uzanti, belgetc, belgeplaka, dosyanınyeniklasoru;
        string trafigecikisi, kaskobitis, muayenebitis, model, renk, yakıtturu, vites, arackiti, stepne, ruhsat, tipmarka, terstarih;
        string adii, soyadii, plakano, KiraTc, KiraPlaka;
        string arctip, guncelle, markatip, sorgu, kayıtkontrol;
        public static string  plakaa;
        public static string kiralaMAguncelle, Listeyeni;
        public static string yenitc = "";
        public static string yeniplaka = "";
        public static string Musterikonum = "a";
        public static string Arackonum = "a";
        public static bool kontrol = true;
        int kirasayısı = 0;
        int bosluk = 10;
        long qw, we, er;
        DateTime kralamaislemtrh, hafıza;
        string listekonum = "";
        string listegecis;
        string nerede = "";
        string Ustmenukonum2 = "a";
        static Class1 GenelClass = new Class1();
        static Class2 YapıClass = new Class2();
        MySqlConnection baglanti = new MySqlConnection(GenelClass.baglanti);
        MySqlCommand komut = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable tablo;
   

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rentacarDataSet.mstrblglr' table. You can move, or remove it, as needed.
            this.mstrblglrTableAdapter.Fill(this.rentacarDataSet.mstrblglr);
            // TODO: This line of code loads data into the 'rentacarDataSet.kiralama' table. You can move, or remove it, as needed.
            this.kiralamaTableAdapter.Fill(this.rentacarDataSet.kiralama);
            // TODO: This line of code loads data into the 'rentacarDataSet.arcblglr' table. You can move, or remove it, as needed.
            this.arcblglrTableAdapter.Fill(this.rentacarDataSet.arcblglr);
            programyapısınıolustur();
            KullanıcıAdıCL.Text = Giris.kullanıcı;
            musteriload();
            Aracload();
        }
        private void Form6_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if (e.KeyCode == Keys.F2)
            {
                panellerarası();
                Ustmenukonum = "a";
                panellerarası();
                SolmenuS.Location = new Point(AnasayfaFB.Location.X, SolmenuS.Location.Y);
            }
            if (e.KeyCode == Keys.F3)
            {
                if (MusteriPaneli.Visible == false)
                {
                    musteriload();
                    SolmenuS.Location = new Point(MusteriFB.Location.X, SolmenuS.Location.Y);
                    panellerarası();
                    Ustmenukonum = "b";
                    panellerarası();
                    MusteriGenel2P.Focus();
                }
            }
            if (e.KeyCode == Keys.F4)
            {
                SolmenuS.Location = new Point(AracFB.Location.X, SolmenuS.Location.Y);
                panellerarası();
                Ustmenukonum = "c";
                panellerarası();
            }
            if (e.KeyCode == Keys.F5)
            {
                SolmenuS.Location = new Point(KiralamaFB.Location.X, SolmenuS.Location.Y);
                panellerarası();
                Ustmenukonum = "e";
                panellerarası();
            }
            if (e.KeyCode == Keys.F6)
            {
                SolmenuS.Location = new Point(AyarlarFB.Location.X, SolmenuS.Location.Y);
                panellerarası();
                Ustmenukonum = "e";
                panellerarası();
            }
        }

        //---------------------------------------------------------------------- ALTPROG.
        void panellerarası()
        {
            if (Ustmenukonum == "a")
            {
                if (AnaPanel.Visible == false)
                {
                    AnaPanel.Visible = true;
                }
                else
                {
                    AnaPanel.Visible = false; 
                }
            }
            else if (Ustmenukonum == "b")
            {
                if (MusteriPaneli.Visible == false)
                {
                    MusteriPaneli.Visible = true;
                }
                else
                {
                    if (KefilGenelP.Visible == true && guncelleeyadakaydett !="guncelle")
                    {
                        guncelleeyadakaydett = "";
                        KefilGenelP.Enabled = false;
                    }
                    MusteriPaneli.Enabled = false;
                }
            }
            else if (Ustmenukonum == "c")
            {
                if (AracPaneli.Visible == false)
                {
                    AracPaneli.Visible = true;
                }
                else
                {
                    if (AsahibiGenelP.Visible == true && guncelleeyadakaydett != "guncelle")
                    {
                        guncelleeyadakaydett = "";
                        AsahibiGenelP.Enabled = false;
                    }
                    AracPaneli.Enabled = false;
                }
            }
            else if (Ustmenukonum == "d")
            {
                if (KiralamaPaneli.Visible == false)
                {
                    KiralamaPaneli.Visible = true;
                }
                else
                {
                    KiralamaPaneli.Enabled = false;
                }
            }
            else if (Ustmenukonum == "e")
            {
                if (ListelerPaneli.Visible == false)
                {
                    ListelerPaneli.Visible = true;
                }
                else
                {
                    ListelerPaneli.Visible = false;
                    ListeKiraicP.Height = 0;
                }
            }/*
            else if (Ustmenukonum == "f")
            {
                if (panel10.Visible == false)
                {
                    panel10.Visible = true;
                }
                else
                {
                    panel10.Visible = false;
                }
            }*/
        }
        void programyapısınıolustur()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut = new MySqlCommand("SELECT kayitbilgisi FROM program", baglanti);
                MySqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    kayitbilgisi = "" + oku["kayitbilgisi"];
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                baglanti.Close();
                MessageBox.Show(ex.Message);
            }

            bunifuThinButton211.BackColor = Color.FromArgb(33, 50, 70);
            bunifuThinButton213.BackColor = Color.FromArgb(33, 50, 70);
            bunifuThinButton214.BackColor = Color.FromArgb(33, 50, 70);
            bunifuThinButton215.BackColor = Color.FromArgb(33, 50, 70);
            ListeKiraicP.Height = 0;
        }
        void ustmenugecis()
        {
            if (MusteriFB2.Height == 100 || Ustmenukonum2 != "b")
            {
                MusteriUstSlider.Height = 50;
            }
            if (AracFB2.Height == 100 || Ustmenukonum2 != "c")
            {
                AracUstSlider.Height = 50;

            }
            if (KiralamaFB2.Height == 100 || Ustmenukonum2 != "d")
            {
                KiralamaUstSlider.Height = 50;
            }
        }
        //---------------------------------------------------------------------- ÜSTMENÜ
        private void UstSliderTimer_Tick(object sender, EventArgs e)
        {
            if (nerede == "")
            {
                if (Ustmenukonum2 == "b")
                {
                    if (MusteriUstSlider.Height == 100)
                    {
                        MusteriUstSlider.Height = 50;
                    }
                }
                if (Ustmenukonum2 == "c")
                {
                    if (AracUstSlider.Height == 100)
                    {
                        AracUstSlider.Height = 50;
                    }
                }
                if (Ustmenukonum2 == "d")
                {
                    if (KiralamaUstSlider.Height == 100)
                    {
                        KiralamaUstSlider.Height = 50;
                    }
                }
            }
            else if (nerede == "2")
            {
                if (Ustmenukonum2 == "b" && MusteriUstSlider.Height == 50)
                {
                    MusteriUstSlider.Height = 100;
                }
                if (Ustmenukonum2 == "c" && AracUstSlider.Height == 50)
                {

                    AracUstSlider.Height = 100;
                }
                if (Ustmenukonum2 == "d" && KiralamaUstSlider.Height == 50)
                {
                    KiralamaUstSlider.Height = 100;

                }
            }
            UstSliderTimer.Stop();
        }

        //------------------------------------------------------------ GEÇİŞLER
        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void CikisIB_Click(object sender, EventArgs e)
        {
            Class1.Cikis();
        }

        private void SolmenuS_MouseHover(object sender, EventArgs e)
        {
            nerede = "2";
        }

        /*------------------------------------------------------------------------------------------ ANASAYFA*/
        private void AnasayfaFB_Click(object sender, EventArgs e)
        {
            if (AnaPanel.Visible == false)
            {
                panellerarası();
                if (kontrol == true)
                {
                    SolmenuS.Location = new Point(380, SolmenuS.Location.Y);
                    Ustmenukonum = "a";
                    panellerarası();
                }
            }
        }
        private void ListeB_Click(object sender, EventArgs e)
        {
            if (listekonum != "musteri")
            {
                panellerarası();
                Ustmenukonum = "e";
                panellerarası();
                Listepanelarası();
                listekonum = "musteri";
                Listepanelarası();
            }
        }

        /*------------------------------------------------------------------------------------------ MÜŞTERİ*/
        private void MusteriFB_Click(object sender, EventArgs e)
        {
            if (MusteriPaneli.Visible == false)
            {
                panellerarası();
                if (kontrol == true)
                {
                    SolmenuS.Location = new Point(440, SolmenuS.Location.Y);
                    musteriload();
                    Ustmenukonum = "b";
                    Musterikonum = "a";
                    Musteripanelarası();
                    panellerarası();
                    MusteriGenel2P.Focus();
                }
            }
        }
        private void MusteriFB_MouseHover(object sender, EventArgs e)
        {
            if (MusteriUstSlider.Height == 50)
            {
                MusteriUstSlider.Height = 100;
            }
            Ustmenukonum2 = "b";
            nerede = "2";
            ustmenugecis();
        }
        private void MusteriFB_MouseLeave(object sender, EventArgs e)
        {
            nerede = "";
            UstSliderTimer.Start();
        }

        private void MusteriFB2_Click(object sender, EventArgs e)
        {
            if (ListelerPaneli.Visible == false)
            {
                panellerarası();
                Ustmenukonum = "e";
                panellerarası();
            }
            if (listekonum != "musteri")
            {
                Listepanelarası();
                listekonum = "musteri";
                Listepanelarası();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (kirasayısı == 3)
            {
                timer2.Stop();
                this.TransparentAnimator.HideSync(MBilgiP);
                kirasayısı = 0;
            }
            kirasayısı++;
        }
        private void MBbilgiP_Leave(object sender, EventArgs e)
        {
            timer2.Stop();
            this.TransparentAnimator.HideSync(MBilgiP);
            kirasayısı = 0;
        }

        private void MusteriPaneli_EnabledChanged(object sender, EventArgs e)
        {
            GenelClass.KayitKontrol(MusteriPaneli);
            if (kontrol == true)
            {
                MGMenuP.Visible = true;
                MGMenu2P.Visible = false;
            }
        }

        //---------------------------------------------------------------------- ALTPROG.

        void Mvericek()
        {
            try
            {
                MIulkeCB.Items.Clear();
                MIilCB.Items.Clear();
                MIilceCB.Items.Clear();
                MEverlnilCB.Items.Clear();
                MKKbankaCB.Items.Clear();

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    komut = new MySqlCommand("SELECT DISTINCT * FROM(mstrblglr INNER JOIN mstrehlyt ON mstrblglr.mstrtcno = mstrehlyt.mstrtcno) INNER JOIN kredikart ON mstrblglr.mstrtcno = kredikart.mstrtcno WHERE mstrblglr.mstrtcno = @mstrtcno", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", MusteriCB.Text);
                    MySqlDataReader oku = komut.ExecuteReader();
                    if (oku.Read())
                    {
                        MGtcnoTB.Text = MusteriCB.Text;
                        MMtcnoL.Text = MusteriCB.Text;
                        MGadiTB.Text = "" + oku["mstradi"];
                        MGsoyadiTB.Text = "" + oku["mstrsoyadi"];
                        MMisimsoyisimL.Text = MGadiTB.Text + "  " + MGsoyadiTB.Text;

                        Musterikefiltc = "" + oku["mstrkfltcno"];

                        MGdgmyeriTB.Text = "" + oku["mstrdgmyeri"];
                        MGserinoTB.Text = "" + oku["mstrsrino"];
                        MGanneadiTB.Text = "" + oku["mstranneadi"];
                        MGbabaadiTB.Text = "" + oku["mstrbabaadi"];
                        MIepostaTB.Text = "" + oku["mstreposta"];
                        MIadresTB.Text = "" + oku["mstradres"];

                        MGdgmtarihiMB.Text = "" + oku["mstrdgmtrhi"];
                        MEgcrllktrhiMB.Text = "" + oku["ehlytgcrllktarh"];
                        MEsicilnoMB.Text = "" + oku["ehlytsclno"];
                        MIceptelMB.Text = "" + oku["mstrceptelno"];
                        MIistelMB.Text = "" + oku["mstristelno"];
                        MKKnoMB.Text = "" + oku["kartno"];
                        MKKCvvMB.Text = "" + oku["cvv"];
                        MKKsktMB.Text = "" + oku["skt"];
                        MEvrlstrhiMB.Text = "" + oku["ehlytvrlstarh"];

                        string bankaa = "" + oku["banka"];
                        MIilCB.Items.Add("" + oku["mstril"]);
                        MIilceCB.Items.Add("" + oku["mstrilce"]);
                        MEverlnilCB.Items.Add("" + oku["ehlytvrlnil"]);
                        MIulkeCB.Items.Add("" + oku["mstrulke"]);

                        MKKodmesstmiCB.Text = "" + oku["osistemi"];
                        MEsinifiCB.Text = "" + oku["ehlytsnf"];

                        baglanti.Close();

                        MIilCB.Text = MIilCB.Items[0].ToString();
                        MIilceCB.Text = MIilceCB.Items[0].ToString();
                        MEverlnilCB.Text = MEverlnilCB.Items[0].ToString();
                        MIulkeCB.Text = MIulkeCB.Items[0].ToString();

                        if (bankaa == "")
                        {
                            YapıClass.bankavericek(MKKbankaCB);
                            MKKbankaCB.Text = MKKbankaCB.Items[0].ToString();
                        }
                        else
                        {
                            MKKbankaCB.Items.Add(bankaa);
                            MKKbankaCB.Text = MKKbankaCB.Items[0].ToString();
                        }
                        Mgelenkontrol();
                        Milksonkontrol();
                        string konum = Application.StartupPath + "\\Dosyalar\\alfabe\\" + MGadiTB.Text.Substring(0, 1) + ".png";
                        if (File.Exists(konum) == true)
                        {
                            MMalfabeIB.Image = Image.FromFile(konum);
                        }
                    }
                    baglanti.Close();
                    Msolmenu();
                    Mozetbilgilervericek();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void Mcomboboxyenile()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    MusteriCB.Items.Clear();
                    MusteriCB.Text = "";
                    baglanti.Open();
                    komut = new MySqlCommand("SELECT mstrtcno FROM mstrblglr WHERE MorK=1", baglanti);
                    MySqlDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        MusteriCB.Items.Add(oku["mstrtcno"]);
                    }
                    baglanti.Close();
                    Msonkayit();
                }
                if (baglanti.State == ConnectionState.Closed)
                {
                    MorKCB.Items.Clear();
                    MorKCB.Text = "";
                    baglanti.Open();
                    komut = new MySqlCommand("SELECT mstrtcno FROM mstrblglr", baglanti);
                    MySqlDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        MorKCB.Items.Add(oku["mstrtcno"]);
                    }
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }

        void Mkayitt()
        {
            int icislem = 0;
            if (MGtcnoTB.Text == "" && MGtcnoTB.Text.Length != 11)
            {
                MessageBox.Show("Lütfen T.C Kimlik No Alanını 11 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MGtcnoTB.Focus();
            }
            else if (MGadiTB.Text == "")
            {
                MessageBox.Show("Lütfen Adı Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MGadiTB.Focus();
            }
            else if (MGsoyadiTB.Text == "")
            {
                MessageBox.Show("Lütfen Soyadı Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MGsoyadiTB.Focus();
            }
            else
            {
                Mboslukkontrolbool();
                if (boslukkontrolu == true)
                {
                    icislem = 1;
                }
                else
                {
                    DialogResult c = MessageBox.Show("Boş Alanlar Mevcut!\nYine'de Kaydedilsin Mi?", "KAYIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (c == DialogResult.Yes)
                    {
                        icislem = 1;
                    }
                    else
                    {
                        Mboslukkontrol();
                    }
                }
            }
            if (icislem == 1)
            {
                if (guncelleeyadakaydett == "kaydet")
                {
                    Mkaydett();
                }
                if (guncelleeyadakaydett == "guncelle")
                {
                    Mguncelleekaydet();
                }
            }
            guncelleeyadakaydett = "";
            MusteriGenel2P.Focus();
        }
        void Mguncelleekaydet()
        {
            int icsayac = 0;
            if (sozlesmetablo == "")
            {
                sozlesmetablo = "mstrblglr";
            }
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    Mgirilen();
                    Mgirilenkontrol();
                    while (icsayac < 1)
                    {
                        baglanti.Open();
                        komut = new MySqlCommand("UPDATE " + sozlesmetablo + " SET mstradi=@mstradi, mstrsoyadi=@mstrsoyadi, mstrdgmtrhi=@mstrdgmtrhi, mstrdgmyeri=@mstrdgmyeri, mstrceptelno=@mstrceptelno, mstristelno=@mstristelno, mstreposta=@mstreposta, mstril=@mstril, mstrilce=@mstrilce, mstrulke=@mstrulke, mstradres=@mstradres, mstranneadi=@mstranneadi, mstrbabaadi=@mstrbabaadi , mstrsrino=@mstrsrino WHERE mstrtcno=@mstrtcno", baglanti);
                        komut.Parameters.AddWithValue("@mstrtcno", MGtcnoTB.Text);
                        komut.Parameters.AddWithValue("@mstradi", MGadiTB.Text);
                        komut.Parameters.AddWithValue("@mstrsoyadi", MGsoyadiTB.Text);
                        komut.Parameters.AddWithValue("@mstrdgmtrhi", dogumtarihi);
                        komut.Parameters.AddWithValue("@mstrdgmyeri", MGdgmyeriTB.Text);
                        komut.Parameters.AddWithValue("@mstrceptelno", ceptelefon);
                        komut.Parameters.AddWithValue("@mstristelno", istelefon);
                        komut.Parameters.AddWithValue("@mstreposta", MIepostaTB.Text);
                        komut.Parameters.AddWithValue("@mstril", MIilCB.Text);
                        komut.Parameters.AddWithValue("@mstrilce", MIilceCB.Text);
                        komut.Parameters.AddWithValue("@mstrulke", MIulkeCB.Text);
                        komut.Parameters.AddWithValue("@mstradres", MIadresTB.Text);
                        komut.Parameters.AddWithValue("@mstranneadi", MGanneadiTB.Text);
                        komut.Parameters.AddWithValue("@mstrbabaadi", MGbabaadiTB.Text);
                        komut.Parameters.AddWithValue("@mstrsrino", MGserinoTB.Text);
                        komut.ExecuteNonQuery();
                        if (sozlesmetablo != "kiralama")
                        {
                            sozlesmetablo = "mstrehlyt";
                        }
                        komut = new MySqlCommand("UPDATE " + sozlesmetablo + "  SET ehlytvrlnil=@ehlytvrlnil, ehlytvrlstarh=@ehlytvrlstarh, ehlytgcrllktarh=@ehlytgcrllktarh, ehlytsclno=@ehlytsclno, ehlytsnf=@ehlytsnf WHERE mstrtcno=@mstrtcno", baglanti);
                        komut.Parameters.AddWithValue("@mstrtcno", MGtcnoTB.Text);
                        komut.Parameters.AddWithValue("@ehlytvrlnil", MEverlnilCB.Text);
                        komut.Parameters.AddWithValue("@ehlytvrlstarh", verilistarihi);
                        komut.Parameters.AddWithValue("@ehlytgcrllktarh", gecerliliktarihi);
                        komut.Parameters.AddWithValue("@ehlytsclno", MEsicilnoMB.Text);
                        komut.Parameters.AddWithValue("@ehlytsnf", Esinif);
                        komut.ExecuteNonQuery();
                        if (sozlesmetablo != "kiralama")
                        {
                            sozlesmetablo = "kredikart";
                        }
                        komut = new MySqlCommand("UPDATE " + sozlesmetablo + "  SET kartno=@kartno, banka=@banka, cvv=@cvv, skt=@skt, osistemi=@osistemi WHERE mstrtcno=@mstrtcno", baglanti);
                        komut.Parameters.AddWithValue("@mstrtcno", MGtcnoTB.Text);
                        komut.Parameters.AddWithValue("@kartno", kartno);
                        komut.Parameters.AddWithValue("@banka", MKKbankaCB.Text);
                        komut.Parameters.AddWithValue("@cvv", MKKCvvMB.Text);
                        komut.Parameters.AddWithValue("@skt", skt);
                        komut.Parameters.AddWithValue("@osistemi", odemesistemi);
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                        if (sozlesmetablo != "kiralama")
                        {
                            Mverikontrol();
                            MusteriCB.Text = tccno;
                            MBilgiP.BackColor = Color.Green;
                            MBilgiCL.Text = "Güncelleme İşlemi Başarıyla Tamamlandı!";
                            TransparentAnimator.ShowSync(MBilgiP);
                            MBilgiCL.Focus();
                            timer2.Start();
                            sozlesmetablo = "kiralama";
                        }
                        else
                        {
                            icsayac++;
                            sozlesmetablo = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void Mkaydett()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    Mgirilen();
                    Mgirilenkontrol();
                    baglanti.Open();
                    komut = new MySqlCommand("INSERT INTO mstrblglr (mstrtcno,mstradi,mstrsoyadi,mstrdgmtrhi,mstrdgmyeri,mstrceptelno,mstristelno,mstreposta,mstril,mstrilce,mstrulke,mstradres,mstranneadi,mstrbabaadi,mstrsrino,MorK) VALUES (@mstrtcno,@mstradi,@mstrsoyadi,@mstrdgmtrhi,@mstrdgmyeri,@mstrceptelno,@mstristelno,@mstreposta,@mstril,@mstrilce,@mstrulke,@mstradres,@mstranneadi,@mstrbabaadi,@mstrsrino,@MorK)", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", MGtcnoTB.Text);
                    komut.Parameters.AddWithValue("@mstradi", MGadiTB.Text.ToUpper());
                    komut.Parameters.AddWithValue("@mstrsoyadi", MGsoyadiTB.Text.ToUpper());
                    komut.Parameters.AddWithValue("@mstrdgmtrhi", dogumtarihi);
                    komut.Parameters.AddWithValue("@mstrdgmyeri", MGdgmyeriTB.Text);
                    komut.Parameters.AddWithValue("@mstrceptelno", ceptelefon);
                    komut.Parameters.AddWithValue("@mstristelno", istelefon);
                    komut.Parameters.AddWithValue("@mstreposta", MIepostaTB.Text);
                    komut.Parameters.AddWithValue("@mstril", MIilCB.Text);
                    komut.Parameters.AddWithValue("@mstrilce", MIilceCB.Text);
                    komut.Parameters.AddWithValue("@mstrulke", MIulkeCB.Text);
                    komut.Parameters.AddWithValue("@mstradres", MIadresTB.Text);
                    komut.Parameters.AddWithValue("@mstranneadi", MGanneadiTB.Text);
                    komut.Parameters.AddWithValue("@mstrbabaadi", MGbabaadiTB.Text);
                    komut.Parameters.AddWithValue("@mstrsrino", MGserinoTB.Text);
                    komut.Parameters.AddWithValue("@MorK", "1");
                    komut.ExecuteNonQuery();
                    komut = new MySqlCommand("INSERT INTO mstrehlyt (mstrtcno,ehlytvrlnil,ehlytvrlstarh,ehlytgcrllktarh,ehlytsclno,ehlytsnf) VALUES (@mstrtcno,@ehlytvrlnil,@ehlytvrlstarh,@ehlytgcrllktarh,@ehlytsclno,@ehlytsnf)", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", MGtcnoTB.Text);
                    komut.Parameters.AddWithValue("@ehlytvrlnil", MEverlnilCB.Text);
                    komut.Parameters.AddWithValue("@ehlytvrlstarh", verilistarihi);
                    komut.Parameters.AddWithValue("@ehlytgcrllktarh", gecerliliktarihi);
                    komut.Parameters.AddWithValue("@ehlytsclno", MEsicilnoMB.Text);
                    komut.Parameters.AddWithValue("@ehlytsnf", Esinif);
                    komut.ExecuteNonQuery();
                    komut = new MySqlCommand("INSERT INTO kredikart (mstrtcno,kartno,banka,cvv,skt,osistemi) VALUES (@mstrtcno,@kartno,@banka,@cvv,@skt,@osistemi)", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", MGtcnoTB.Text);
                    komut.Parameters.AddWithValue("@kartno", kartno);
                    komut.Parameters.AddWithValue("@banka", MKKbankaCB.Text);
                    komut.Parameters.AddWithValue("@cvv", MKKCvvMB.Text);
                    komut.Parameters.AddWithValue("@skt", skt);
                    komut.Parameters.AddWithValue("@osistemi", odemesistemi);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    Mverikontrol();
                    MBilgiP.BackColor = Color.Green;
                    MBilgiCL.Text = "Kayıt İşlemi Başarıyla Tamamlandı!";
                    TransparentAnimator.ShowSync(MBilgiP);
                    MBilgiCL.Focus();
                    timer2.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }

        void Mcontrolkilitle()
        {
            GenelClass.ControlKilit(MusteriGenel2P, "false");

            MBelgeTB.Visible = true;
            KefilTB.Visible = true;
        }
        void Mcontrolkilitac()
        {
            GenelClass.ControlKilit(MusteriGenel2P, "true");

            MBelgeTB.Visible = false;
            KefilTB.Visible = false;
            MSDetayTB.Visible = false;
            MKGecmisiTB.Visible = false;
        }
        void Mcontroltemizle()
        {
            GenelClass.ControlKilit(MusteriGenel2P, "clear");

            MIulkeCB.Items.Clear();
            MIilCB.Items.Clear();
            MIilceCB.Items.Clear();
            MKKbankaCB.Items.Clear();
            MKKodmesstmiCB.Text = MKKodmesstmiCB.Items[0].ToString();
            MEverlnilCB.Items.Clear();
            MEsinifiCB.Text = MEsinifiCB.Items[0].ToString();

            MkefilCL.Text = "";
            MkefilCL2.Text = "";
            MBelgeSCL.Text = "";
            MKAracSCL.Text = "";
            MSkiraTarihCL.Text = "";
            MSkiraParaCL.Text = "";
            MSkiralamaCL.Text = "";
            Sozlesmegecisi = "";
        }

        void Mgirilen()
        {
            dogumtarihi = MGdgmtarihiMB.Text;
            ceptelefon = MIceptelMB.Text;
            istelefon = MIistelMB.Text;
            verilistarihi = MEvrlstrhiMB.Text;
            gecerliliktarihi = MEgcrllktrhiMB.Text;
            kartno = MKKnoMB.Text;
            skt = MKKsktMB.Text;
            odemesistemi = MKKodmesstmiCB.Text;
            Esinif = MEsinifiCB.Text;
        }
        void Mverikontrol()
        {
            Mcomboboxyenile();
            if (MGtcnoTB.Text != "")
            {
                if (hangiislem != "sil")
                {
                    Mislemmenusudegis();
                }
            }
            else
            {
                MGMenuP.Visible = false;
                Myeni();
            }
            Milksonkontrol();
        }
        void Mboslukkontrol()
        {
            if (MGserinoTB.Text == "")
            {
                MGserinoTB.Focus();
            }
            else if (MGdgmtarihiMB.Text.Length != 10)
            {
                MGdgmtarihiMB.Focus();
            }
            else if (MGdgmyeriTB.Text == "")
            {
                MGdgmyeriTB.Focus();
            }
            else if (MGanneadiTB.Text == "")
            {
                MGanneadiTB.Focus();
            }
            else if (MGbabaadiTB.Text == "")
            {
                MGbabaadiTB.Focus();
            }
            else if (MIceptelMB.Text == "(   )    -")
            {
                MIceptelMB.Focus();
            }
            else if (MIistelMB.Text == "(   )    -")
            {
                MIistelMB.Focus();
            }
            else if (MIepostaTB.Text == "")
            {
                MIepostaTB.Focus();
            }
            else if (MIulkeCB.Text == "Ülke Seçiniz." || MIulkeCB.Text == "")
            {
                MIulkeCB.Focus();
            }
            else if (MIilCB.Text == "Şehir Seçiniz." || MIilCB.Text == "")
            {
                MIulkeCB.Focus();
            }
            else if (MIilceCB.Text == "İlçe Seçiniz." || MIilceCB.Text == "")
            {
                MIilceCB.Focus();
            }
            else if (MIadresTB.Text == "")
            {
                MIadresTB.Focus();
            }
            else if (MKKnoMB.Text == "    -    -    -")
            {
                MKKnoMB.Focus();
            }
            else if (MKKCvvMB.Text == "")
            {
                MKKCvvMB.Focus();
            }
            else if (MKKsktMB.Text == "  -")
            {
                MKKsktMB.Focus();
            }
            else if (MKKbankaCB.Text == "Banka Seçiniz." || MKKbankaCB.Text == "")
            {
                MKKbankaCB.Focus();
            }
            else if (MKKodmesstmiCB.Text == "Ödeme Sistemi Seçiniz." || MKKodmesstmiCB.Text == "")
            {
                MKKodmesstmiCB.Focus();
            }
            else if (MEsicilnoMB.Text == "")
            {
                MEsicilnoMB.Focus();
            }
            else if (MEvrlstrhiMB.Text.Length != 10)
            {
                MEvrlstrhiMB.Focus();
            }
            else if (MEgcrllktrhiMB.Text.Length != 10)
            {
                MEgcrllktrhiMB.Focus();
            }
            else if (MEverlnilCB.Text == "Şehir Seçiniz." || MEverlnilCB.Text == "")
            {
                MEverlnilCB.Focus();
            }
            else if (MEsinifiCB.Text == "Ehliyet Sınıfı Seçiniz." || MEsinifiCB.Text == "")
            {
                MEsinifiCB.Focus();
            }
        }
        void Mgirilenkontrol()
        {
            if (dogumtarihi == "  .  .")
            {
                dogumtarihi = "";
            }
            if (ceptelefon == "(   )    -")
            {
                ceptelefon = "";
            }
            if (istelefon == "(   )    -")
            {
                istelefon = "";
            }
            if (MIilCB.Text == "Şehir Seçiniz.")
            {
                MIilCB.Items.Add("");
                MIilCB.Text = "";
            }
            if (MIilceCB.Text == "İlçe Seçiniz.")
            {
                MIilceCB.Items.Add("");
                MIilceCB.Text = "";
            }
            if (MEverlnilCB.Text == "Şehir Seçiniz.")
            {
                MEverlnilCB.Items.Add("");
                MEverlnilCB.Text = "";
            }
            if (verilistarihi == "  .  .")
            {
                verilistarihi = "";
            }
            if (gecerliliktarihi == "  .  .")
            {
                gecerliliktarihi = "";
            }
            if (MKKbankaCB.Text == "Banka Seçiniz.")
            {
                MKKbankaCB.Items.Add("");
                MKKbankaCB.Text = "";
            }
            if (kartno == "    -    -    -")
            {
                kartno = "";
            }
            if (skt == "  -")
            {
                skt = "";
            }
            if (MKKodmesstmiCB.Text == "Ödeme Sistemi Seçiniz.")
            {
                odemesistemi = "";
            }
            if (MEsinifiCB.Text == "Ehliyet Sınıfı Seçiniz.")
            {
                Esinif = "";
            }
        }
        void Milksonkontrol()
        {
            GenelClass.ilksonkontrol(MusteriCB, MMileriIB, MMgeriIB);
        }
        void Mgelenkontrol()
        {
            if (MKKodmesstmiCB.Text == "")
            {
                MKKodmesstmiCB.Text = MKKodmesstmiCB.Items[0].ToString();
            }
            if (MEsinifiCB.Text == "")
            {
                MEsinifiCB.Text = MEsinifiCB.Items[0].ToString();
            }
        }

        void Mboslukkontrolbool()
        {
            if (
                MGdgmtarihiMB.Text == "  .  ." || MGdgmtarihiMB.Text.Length != 10 ||
                MGdgmyeriTB.Text == "" ||
                MIceptelMB.Text.Length != 14 || MIceptelMB.Text == "(   )    -" ||
                MIistelMB.Text.Length != 14 || MIistelMB.Text == "(   )    -" ||
                MIulkeCB.Text == "Ülke Seçiniz." || MIulkeCB.Text == "" ||
                MIilCB.Text == "Şehir Seçiniz." || MIilCB.Text == "" ||
                MIilceCB.Text == "İlçe Seçiniz." || MIilceCB.Text == "" ||
                MEverlnilCB.Text == "Şehir Seçiniz." || MEverlnilCB.Text == "" ||
                MIadresTB.Text == "" ||
                MEvrlstrhiMB.Text.Length != 10 ||
                MEgcrllktrhiMB.Text.Length != 10 ||
                MEsicilnoMB.Text.Length != 6 ||
                MIepostaTB.Text == "" ||
                MKKbankaCB.Text == "Banka Seçiniz." || MKKbankaCB.Text == "" ||
                MKKnoMB.Text == "    -    -    - " || MKKnoMB.Text.Length != 19 ||
                MKKCvvMB.Text == "" || MKKCvvMB.Text.Length != 3 ||
                MKKsktMB.Text == "  -" || MKKsktMB.Text.Length != 5
                )
            {
                boslukkontrolu = false;
            }
            else
            {
                boslukkontrolu = true;
            }
        }
        void Msonkayit()
        {
            if (MusteriCB.Items.Count > 0)
            {
                MusteriCB.Text = MusteriCB.Items[MusteriCB.Items.Count - 1].ToString();
                MaraTB.Enabled = true;
                MaraIB.Enabled = true;
                Mcontrolkilitle();
            }
            else
            {
                MaraTB.Enabled = false;
                MaraIB.Enabled = false;
                Mcontrolkilitac();
            }
            Milksonkontrol();
        }
        void Milkkayit()
        {
            MusteriCB.Text = MusteriCB.Items[0].ToString();
            Milksonkontrol();
        }
        void Myeni()
        {
            MusteriGpaneli.Focus();
            while (MGMenuicP.Visible == true)
            {

            }
            guncelleeyadakaydett = "kaydet";
            Mcontroltemizle();
            MusteriCB.Text = "";
            Mcontrolkilitac();
            MaraTB.Enabled = false;
            MaraIB.Enabled = false;

            MGMenuP.Visible = false;
            MGMenu2P.Show();
            MMisimsoyisimL.Text = "YENİ MÜŞTERİ";
            MMtcnoL.Text = "";
            MMalfabeIB.Image = Image.FromFile(Application.StartupPath + "\\Dosyalar\\alfabe\\new.png");

            MMgeriIB.Visible = false;
            MMileriIB.Visible = false;

            YapıClass.ulkevericek(MIulkeCB);
            MIulkeCB.Text = MIulkeCB.Items[189].ToString();
            if (MIulkeCB.Text == "Türkiye")
            {
                MIilCB.Items.Clear();
                MIilceCB.Items.Clear();
                MEverlnilCB.Items.Clear();
                YapıClass.ilvericek(MIilCB, MEverlnilCB);
                MIilCB.Text = MIilCB.Items[0].ToString();
                YapıClass.ilkontrolluilce(MIilCB.Text, MIilceCB);
                MIilceCB.Text = MIilceCB.Items[0].ToString();
                MEverlnilCB.Text = MEverlnilCB.Items[0].ToString();
            }

            YapıClass.bankavericek(MKKbankaCB);
            MKKbankaCB.Text = MKKbankaCB.Items[0].ToString();
            MGtcnoTB.Focus();
        }
        void Mguncelle()
        {
            tccno = MGtcnoTB.Text;
            MusteriGpaneli.Focus();
            while (MGMenuicP.Visible == true)
            {

            }
            MGMenuP.Visible = false;
            MGMenu2P.Show();

            MMgeriIB.Visible = false;
            MMileriIB.Visible = false;
            guncelleeyadakaydett = "guncelle";
            Mcontrolkilitac();
            MGtcnoTB.Enabled = false;
            MaraTB.Enabled = false;
            MaraIB.Enabled = false;

            string bnka = MKKbankaCB.Text;
            MKKbankaCB.Items.Clear();
            YapıClass.bankavericek(MKKbankaCB);
            MKKbankaCB.Text = bnka;

            string c = MIulkeCB.Text;
            string a = MIilCB.Text;
            string d = MIilceCB.Text;
            string b = MEverlnilCB.Text;

            YapıClass.ulkevericek(MIulkeCB);
            MIulkeCB.Text = c;
            if (MIulkeCB.Text == "Türkiye")
            {
                MIilCB.Items.Clear();
                MIilceCB.Items.Clear();
                MEverlnilCB.Items.Clear();
                YapıClass.ilvericek(MIilCB, MEverlnilCB);
                MIilCB.Text = a;
                MEverlnilCB.Text = b;
                YapıClass.ilkontrolluilce(MIilCB.Text, MIilceCB);
                MIilceCB.Text = d;
            }
        }

        void Mozetbilgilervericek()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                komut = new MySqlCommand("SELECT * FROM rentacar.kiralama where mstrtcno=@mstrtcno", baglanti);
                komut.Parameters.AddWithValue("@mstrtcno", MGtcnoTB.Text);
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    kirasayısı++;
                    kralamaislemtrh = Convert.ToDateTime("" + oku["kralamaislemtrh"].ToString().Substring(0, 10));
                    if (hafıza < kralamaislemtrh)
                    {
                        hafıza = kralamaislemtrh;
                        plaka = oku["arcplaka"].ToString() ;
                        MSkiraTarihCL.Text = "" + oku["kralamaislemtrh"];
                        MSkiraParaCL.Text = "" + oku["kralamatplmttr"];
                        Sozlesmegecisi = oku["szlsmno"].ToString();
                    }
                }
                if (plaka != "")
                {
                    MSDetayTB.Visible = true;
                    MKGecmisiTB.Visible = true;
                    MSkiralamaCL.Text = plaka;
                    MKAracSCL.Text = kirasayısı.ToString();
                    plaka = "";
                    kirasayısı = 0;
                }
                else
                {

                    MSDetayTB.Visible = false;
                    MKGecmisiTB.Visible = false;
                    plaka = "";
                    MKAracSCL.Text = "";
                    MSkiralamaCL.Text = "";
                    MSkiraTarihCL.Text = "";
                    MSkiraParaCL.Text = "";

                }
                baglanti.Close();
                hafıza = Convert.ToDateTime("01.01.0001");
            }
        }
        void musteriload()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                komut = new MySqlCommand("SELECT mstrtcno FROM mstrblglr WHERE MorK=1", baglanti);
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    MusteriCB.Items.Add(oku["mstrtcno"]);
                }
                baglanti.Close();
                YapıClass.Mcomboboxautocomplete(MaraTB);
                Mverikontrol();
            }
            klasor = Directory.Exists(Application.StartupPath + "\\MBelge\\");
            if (klasor == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\MBelge\\");
            }
        }
        void Mislemmenusukapat()
        {
            if (MGMenuicP.Visible == true)
            {
                MGMenuIB.Enabled = false;
                RotateAnimator.HideSync(MGMenuIB);
                RotateAnimator.ShowSync(MGMenuIB);
                TransparentAnimator.HideSync(YeniMusteriIB);
                TransparentAnimator.HideSync(GuncelleMusteriIB);
                TransparentAnimator.HideSync(SilMusteriIB);
                MGMenuicP.Visible = false;
            }
            MGMenuIB.Enabled = true;
        }
        void Mislemmenusudegis()
        {
            if (MGMenuP.Visible == true)
            {
                MGMenu2P.Visible = true;
                MGMenuP.Visible = false;
            }
            else if (MGMenu2P.Visible == true)
            {
                MGMenuP.Visible = true;
                MGMenu2P.Visible = false;
            }
        }
        void Msolmenu()
        {
            baglanti.Open();
            komut = new MySqlCommand("SELECT COUNT(mstrtcno) FROM mstrbelge WHERE mstrtcno=@mstrtcno", baglanti);
            komut.Parameters.AddWithValue("@mstrtcno", MMtcnoL.Text);
            string gecici = komut.ExecuteScalar().ToString();
            if (gecici == "0")
            {
                MBelgeTB.ButtonText = "Belge Ekle";
                MBelgeSCL.Text = "";
            }
            else
            {
                MBelgeSCL.Text = gecici;
                MBelgeTB.ButtonText = "Detaylar";
            }

            komut = new MySqlCommand("SELECT * FROM mstrblglr WHERE mstrtcno=@mstrtcno", baglanti);
            komut.Parameters.AddWithValue("@mstrtcno", Musterikefiltc);
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                MkefilCL2.Text = oku["mstradi"] + " " + oku["mstrsoyadi"];
                KefilTB.ButtonText = "Detaylar";
            }
            else
            {
                KefilTB.ButtonText = "Kefil Ekle";
                MkefilCL2.Text = "";
            }
            oku.Close();
            baglanti.Close();
            MkefilCL.Text = Musterikefiltc;
        }

        void Musteripanelarası()
        {
            if (Musterikonum == "a")
            {
                if (MusteriGenelP.Visible == false)
                {
                    MusteriGenelP.Visible = true;
                    MusteriBelgeP.Visible = false;
                    KefilGenelP.Visible = false;
                }
                else
                {
                    MusteriGenelP.Visible = false;
                }
            }
            else if (Musterikonum == "b")
            {
                if (MusteriBelgeP.Visible == false)
                {
                    MusteriBelgeP.Visible = true;
                }
                else
                {
                    MusteriBelgeP.Visible = false;
                }
            }
            else if (Musterikonum == "d")
            {
                if (KefilGenelP.Visible == false)
                {
                    KefilGenelP.Visible = true;
                }
                else
                {
                    KefilGenelP.Enabled = false;
                }
            }
        }

        //---------------------------------------------------------------------- SOLMENÜ
        private void MsMenuPictureB_Click(object sender, EventArgs e)
        {
            MsMenuPictureB.Focus();
        }

        private void MusteriCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mvericek();
        }

        private void MaraTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaraTB.MaxLength = 11;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void MaraTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                YapıClass.Mara(MaraTB, MusteriGenel2P, MusteriCB);
            }
        }
        private void MaraTB_Enter(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.BorderColorIdle = Color.FromArgb(26, 177, 136);
            if (MaraTB.Text == "Müşteri Ara")
            {
                MaraTB.Text = "";
                MaraTB.ForeColor = Color.White;
            }
        }
        private void MaraTB_Leave(object sender, EventArgs e)
        {
            bunifuMetroTextbox1.BorderColorIdle = Color.Gray;
            if (MaraTB.Text == "")
            {
                MaraTB.ForeColor = Color.Gray;
                MaraTB.Text = "Müşteri Ara";
            }
        }
        private void MaraIB_Click(object sender, EventArgs e)
        {
            YapıClass.Mara(MaraTB, MusteriGenel2P, MusteriCB);
        }

        private void MMtcnoL_TextChanged(object sender, EventArgs e)
        {
            belgetc = MMtcnoL.Text;
            UserControl4.tcc = MMtcnoL.Text;
        }

        private void MMgeriIB_Click(object sender, EventArgs e)
        {
            if (MMgeriIB.Enabled == true)
            {
                MusteriCB.Text = MusteriCB.Items[MusteriCB.SelectedIndex - 1].ToString();
                Milksonkontrol();
                if (Musterikonum == "b")
                {
                    Mbelgekontrol();
                    MusteriBelge2P.VerticalScroll.Value = MusteriBelge2P.VerticalScroll.Minimum;
                    MusteriBelge2P.AutoScroll = true;
                }
                else if (Musterikonum == "d")
                {
                    Kefilkontrol();
                }
            }
        }
        private void MMileriIB_Click(object sender, EventArgs e)
        {
            if (MMileriIB.Enabled == true)
            {
                MusteriCB.Text = MusteriCB.Items[MusteriCB.SelectedIndex + 1].ToString();
                Milksonkontrol();
                if (Musterikonum == "b")
                {
                    Mbelgekontrol();
                    MusteriBelge2P.VerticalScroll.Value = MusteriBelge2P.VerticalScroll.Minimum;
                    MusteriBelge2P.AutoScroll = true;
                }
                else if (Musterikonum == "d")
                {
                    Kefilkontrol();
                }
            }
        }

        private void MGenelCL_Click(object sender, EventArgs e)
        {
            if (Musterikonum != "a")
            {
                if(guncelleeyadakaydett == "guncelle")
                {
                    if (GenelClass.islemiptal() == true)
                    {
                        guncelleeyadakaydett = "";
                        Musteripanelarası();
                        Musterikonum = "a";
                        Musteripanelarası();
                        MusteriGenel2P.VerticalScroll.Value = MusteriGenel2P.VerticalScroll.Minimum;
                        MusteriGenel2P.AutoScroll = true;
                        MusteriGenel2P.Focus();
                    }
                }
                else if(guncelleeyadakaydett != "guncelle")
                {
                    guncelleeyadakaydett = "";
                    Musteripanelarası();
                    Musterikonum = "a";
                    Musteripanelarası();
                    MusteriGenel2P.VerticalScroll.Value = MusteriGenel2P.VerticalScroll.Minimum;
                    MusteriGenel2P.AutoScroll = true;
                    MusteriGenel2P.Focus();
                }
            }
        }
        private void MKGecmisiTB_Click(object sender, EventArgs e)
        {
            if (Musterikonum != "c")
            {
                panellerarası();
                if (kontrol == true)
                {
                    Arackonum = "c";
                    Ustmenukonum = "e";
                    panellerarası();
                    listekonum = "kira";
                    Listepanelarası();
                    ListedegiskenTB.Text = MMtcnoL.Text;
                    KLvericeksartli();
                }
            }
        }

        private void MSDetayB_Click(object sender, EventArgs e)
        {
            if (Sozlesmegecisi != "")
            {
                panellerarası();
                if (kontrol == true)
                {
                    Kiralamayagecis();
                    KiralamaCB.Text = Sozlesmegecisi;
                    Sozlesmegecisi = "";
                    Kilksonkontrol();
                }
            }
        }/*BUNUN GİBİ KOD TEKRARLARINI DÜZENLEMEK GEREKİYOR
        ÖZET YAPMAK GEREKİRSE ARAÇ VE MÜŞTERİYİ KİRALAMAYA YOLLUYORUZ EE KOD AYNI OLDUĞU İÇİN KOD TEKRARINA GEREK KALMIYOR
        İKİ BUTONUDA BURAYA YÖNLENDİRDİM ASLINDA BUNU YAPMAYA BAŞLADIM FAKAT GENEL DÜZENDE BUNLARI UYGULAYALIM*/

        //---------------------------------------------------------------------- İÇMENÜ
        private void MusteriGenel2P_Click(object sender, EventArgs e)
        {
            MusteriGenel2P.Focus();
        }

        private void MGMenuIB_Click(object sender, EventArgs e)
        {
            MGMenuIB.Enabled = false;
            RotateAnimator.HideSync(MGMenuIB);
            RotateAnimator.ShowSync(MGMenuIB);
            MGMenuP.Focus();
            if (MGMenuicP.Visible == false)
            {
                MGMenuicP.Visible = true;
                this.TransparentAnimator.ShowSync(SilMusteriIB);
                this.TransparentAnimator.ShowSync(GuncelleMusteriIB);
                this.TransparentAnimator.ShowSync(YeniMusteriIB);
            }
            else
            {
                this.TransparentAnimator.HideSync(YeniMusteriIB);
                this.TransparentAnimator.HideSync(GuncelleMusteriIB);
                this.TransparentAnimator.HideSync(SilMusteriIB);
                MGMenuicP.Visible = false;
                MusteriGenel2P.Focus();
            }
            MGMenuIB.Enabled = true;
        }
        private void MGMenuP_Leave(object sender, EventArgs e)
        {
            Mislemmenusukapat();
        }
        private void YeniMusteriIB_Click(object sender, EventArgs e)
        {
            Myeni();
        }
        private void SilMusteriIB_Click(object sender, EventArgs e)
        {
            if (GenelClass.sil() == true)
            {
                YapıClass.Musterisil(MGtcnoTB.Text);
                hangiislem = "sil";
                Mcontroltemizle();
                Mverikontrol();
                MusteriGenel2P.Focus();
                hangiislem = "";
                MBilgiCL.Text = "1 Kayıt Başarıyla Silindi!";
                MBilgiP.BackColor = Color.Maroon;
                this.TransparentAnimator.ShowSync(MBilgiP);
                MBilgiCL.Focus();
                timer2.Start();
            }
        }
        private void GuncelleMusteriIB_Click(object sender, EventArgs e)
        {
            Mguncelle();
        }
        private void MusteriKaydetIB_Click(object sender, EventArgs e)
        {
            try
            {
                klasor = Directory.Exists(Application.StartupPath + "\\MBelge\\" + MGtcnoTB.Text + "\\");
                if (klasor == false)
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\MBelge\\" + MGtcnoTB.Text + "\\");
                }
                Mkayitt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MiptalIB_Click(object sender, EventArgs e)
        {
            MusteriGenel2P.Focus();
            string gecici = MMtcnoL.Text;
            Mcontroltemizle();
            Mverikontrol();
            MusteriCB.Text = gecici;
            guncelleeyadakaydett = "";
        }

        //------------------------------------------------------------ KİMLİK
        private void MGtcnoTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MGtcnoTB.MaxLength = 11;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void MGtcnoTB_KeyUp(object sender, KeyEventArgs e)
        {
            MMtcnoL.Text = MGtcnoTB.Text;
            if (MGtcnoTB.Text.Length < 11)
            {
                verioneri = true;
                verioneri2 = true;
            }
            if (MGtcnoTB.Text.Length == 11 && verioneri2 == true)
            {
                MGserinoTB.Focus();
                verioneri2 = false;
            }
        }
        private void MGtcnoTB_Validating(object sender, CancelEventArgs e)
        {
            if (MGtcnoTB.Text.Length == 11)
            {
                GenelClass.Tckontrolet(MGtcnoTB.Text);
                if (MusteriCB.FindStringExact(MGtcnoTB.Text) != -1)
                {
                    e.Cancel = true;
                    MessageBox.Show("Girdiğiniz T.C Kimlik No Sistem'de Mevcuttur.", "MEVCUT KİŞİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (GenelClass.Tckontrolet(MGtcnoTB.Text) == false)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir T.C Kimlik No Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (verioneri == true)
                    {
                    }
                }
            }
            else if (MGtcnoTB.Text.Length == 0)
            {

            }
            else
            {
                MessageBox.Show("Lütfen T.C Kimlik No Alanını 11 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MGserinoTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MGserinoTB.MaxLength = 9;
        }

        private void MGadiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MGadiTB.MaxLength = 10;
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void MGadiTB_TextChanged(object sender, EventArgs e)
        {
            MMisimsoyisimL.Text = MGadiTB.Text + "  " + MGsoyadiTB.Text;
        }

        private void MGsoyadiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MGsoyadiTB.MaxLength = 10;
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void MGsoyadiTB_TextChanged(object sender, EventArgs e)
        {
            MMisimsoyisimL.Text = MGadiTB.Text + " " + MGsoyadiTB.Text;
        }

        private void MGdgmtarihiMB_Validating(object sender, CancelEventArgs e)
        {
            if (MGdgmtarihiMB.Text != "  .  .")
            {
                try
                {
                    DateTime a = Convert.ToDateTime(MGdgmtarihiMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Doğum Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void MGdgmyeriTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MGdgmyeriTB.MaxLength = 15;
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void MGanneadiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MGanneadiTB.MaxLength = 10;
        }

        private void MGbabaadiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MGbabaadiTB.MaxLength = 10;
        }

        //------------------------------------------------------------ İLETİŞİM
        private void MIceptelMB_Validating(object sender, CancelEventArgs e)
        {
            if (MIceptelMB.Text != "(   )    -")
            {
                if (MIceptelMB.Text.Length != 14)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir Cep Telefon Numarası Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (MIceptelMB.Text.Substring(1, 1) == "0")
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir Cep Telefon Numarası Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MIistelMB_Validating(object sender, CancelEventArgs e)
        {
            if (MIistelMB.Text != "(   )    -")
            {
                if (MIistelMB.Text.Length != 14)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir İş Telefon Numarası Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (MIistelMB.Text.Substring(1, 1) == "0")
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir Cep Telefon Numarası Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MIepostaTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MIepostaTB.MaxLength = 50;
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }
        private void MIepostaTB_Validating(object sender, CancelEventArgs e)
        {
            if (MIepostaTB.Text != "")
            {
                if (!new Regex(GenelClass.Regex).IsMatch(MIepostaTB.Text))
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir E-mail Adresi Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MIadresTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MIadresTB.MaxLength = 100;
        }

        private void MIulkeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MIulkeCB.Text == "Türkiye")
            {
                if (MIilCB.Text == "Şehir Seçiniz." || MIilCB.Text == "")
                {
                    MIilCB.Items.Clear();
                    MIilceCB.Items.Clear();
                    MIilCB.Items.Add("Şehir Seçiniz.");
                    MIilceCB.Items.Add("İlçe Seçiniz.");
                    MIilCB.Text = MIilCB.Items[0].ToString();
                    MIilceCB.Text = MIilceCB.Items[0].ToString();
                }
                if (MEverlnilCB.Text == "Şehir Seçiniz." || MEverlnilCB.Text == "")
                {
                    MEverlnilCB.Items.Clear();
                    MEverlnilCB.Items.Add("Şehir Seçiniz.");
                    MEverlnilCB.Text = MEverlnilCB.Items[0].ToString();
                }
                if (MIilceCB.Text == "İlçe Seçiniz." || MIilceCB.Text == "")
                {
                    MIilceCB.Items.Clear();
                    MIilceCB.Items.Add("İlçe Seçiniz.");
                    MIilceCB.Text = MIilceCB.Items[0].ToString();
                }
            }
            else
            {
                MIilCB.Items.Clear();
                MIilceCB.Items.Clear();
                MEverlnilCB.Items.Clear();
                MIilCB.Items.Add("Şehir Seçiniz.");
                MIilceCB.Items.Add("İlçe Seçiniz.");
                MEverlnilCB.Items.Add("Şehir Seçiniz.");
                MIilCB.Text = MIilCB.Items[0].ToString();
                MIilceCB.Text = MIilceCB.Items[0].ToString();
                MEverlnilCB.Text = MEverlnilCB.Items[0].ToString();
            }
        }
        private void MIulkeCB_Leave(object sender, EventArgs e)
        {
            if (MIulkeCB.Text == "Türkiye")
            {
                if (MIilCB.Text == "Şehir Seçiniz." || MIilCB.Text == "")
                {
                    MIilCB.Items.Clear();
                    MIilceCB.Items.Clear();
                    YapıClass.ilvericek(MIilCB, MEverlnilCB);
                    MIilCB.Text = MIilCB.Items[0].ToString();
                    YapıClass.ilkontrolluilce(MIilCB.Text, MIilceCB);
                    MIilceCB.Text = MIilceCB.Items[0].ToString();
                }
                if (MEverlnilCB.Text == "Şehir Seçiniz." || MEverlnilCB.Text == "")
                {
                    MEverlnilCB.Items.Clear();
                    YapıClass.ilvericek(MIilCB, MEverlnilCB);
                    MEverlnilCB.Text = MEverlnilCB.Items[0].ToString();
                }
                if (MIilceCB.Text == "İlçe Seçiniz." || MIilceCB.Text == "")
                {
                    MIilceCB.Items.Clear();
                    YapıClass.ilkontrolluilce(MIilCB.Text, MIilceCB);
                    MIilceCB.Text = MIilceCB.Items[0].ToString();
                }
            }
            else
            {
                MIilCB.Items.Clear();
                MIilceCB.Items.Clear();
                MEverlnilCB.Items.Clear();
                MIilCB.Items.Add("Şehir Seçiniz.");
                MIilceCB.Items.Add("İlçe Seçiniz.");
                MEverlnilCB.Items.Add("Şehir Seçiniz.");
                MIilCB.Text = MIilCB.Items[0].ToString();
                MIilceCB.Text = MIilceCB.Items[0].ToString();
                MEverlnilCB.Text = MEverlnilCB.Items[0].ToString();
            }
        }

        private void MIilCB_Enter(object sender, EventArgs e)
        {
            ililce = MIilCB.Text;
        }
        private void MIilCB_Leave(object sender, EventArgs e)
        {
            if (MIilCB.Text != ililce)
            {
                MIilceCB.Items.Clear();
                MIilceCB.Text = "";
                YapıClass.ilkontrolluilce(MIilCB.Text, MIilceCB);
                MIilceCB.Text = MIilceCB.Items[0].ToString();
            }
        }

        //------------------------------------------------------------ KKARTI
        private void MKKnoMB_Validating(object sender, CancelEventArgs e)
        {
            if (MKKnoMB.Text != "    -    -    -")
            {
                if (MKKnoMB.Text.Length != 19)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Kart No Alanını 16 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void MKKCvvMB_Validating(object sender, CancelEventArgs e)
        {
            if (MKKCvvMB.Text != "")
            {
                if (MKKCvvMB.Text.Length != 3)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen CVV Alanını 3 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void MKKsktMB_Validating(object sender, CancelEventArgs e)
        {
            if (MKKsktMB.Text != "  -")
            {
                if (MKKsktMB.Text.Length != 5)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen SKT Alanını 4 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        //------------------------------------------------------------ EHLİYET
        private void MEsicilnoMB_Validating(object sender, CancelEventArgs e)
        {
            if (MEsicilnoMB.Text.Length > 0)
            {
                if (MEsicilnoMB.Text.Length != 6)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Sicil No Alanını 6 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void MEvrlstrhiMB_Validating(object sender, CancelEventArgs e)
        {
            if (MEvrlstrhiMB.Text != "  .  .")
            {
                try
                {
                    DateTime b = Convert.ToDateTime(MEvrlstrhiMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Veriliş Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void MEgcrllktrhiMB_Validating(object sender, CancelEventArgs e)
        {
            if (MEgcrllktrhiMB.Text != "  .  .")
            {
                try
                {
                    DateTime c = Convert.ToDateTime(MEgcrllktrhiMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerlilik Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /*-------------------------------------------------------------------------------- MUSTERİBELGE*/

        //---------------------------------------------------------------------- ALTPROG.
        void dosyauzantıkontrol()
        {
            if (DosyaUzantisi == ".docx" || DosyaUzantisi == ".docx")
            {
                DosyaUzantisi = "Word Belgesi";
                uzanti = Application.StartupPath + "\\Dosyalar\\images\\icon8\\word.png";
            }
            else if (DosyaUzantisi == ".xlsx")
            {
                DosyaUzantisi = "Excel Belgesi";
                uzanti = Application.StartupPath + "\\Dosyalar\\images\\icon8\\Excel.png";
            }
            else if (DosyaUzantisi == ".mp3" || DosyaUzantisi == ".MP3")
            {
                DosyaUzantisi = "Müzik Dosyası";
                uzanti = Application.StartupPath + "\\Dosyalar\\images\\icon8\\mp3.png";
            }
            else if (DosyaUzantisi == ".mp4" || DosyaUzantisi == ".MP4")
            {
                DosyaUzantisi = "Video Dosyası";
                uzanti = Application.StartupPath + "\\Dosyalar\\images\\icon8\\mp4.png";
            }
            else if (DosyaUzantisi == ".txt")
            {
                DosyaUzantisi = "Metin Belgesi";
                uzanti = Application.StartupPath + "\\Dosyalar\\images\\icon8\\txt.png";
            }
            else if (DosyaUzantisi == ".rar" || DosyaUzantisi == ".zip")
            {
                DosyaUzantisi = "Winrar";
                uzanti = Application.StartupPath + "\\Dosyalar\\images\\icon8\\winrar.png";
            }
            else if (DosyaUzantisi == ".rar" || DosyaUzantisi == ".zip")
            {
                DosyaUzantisi = "Winrar";
                uzanti = Application.StartupPath + "\\Dosyalar\\images\\icon8\\winrar.png";
            }
            else if (DosyaUzantisi == ".png" || DosyaUzantisi == ".jpg")
            {
                DosyaUzantisi = "Resim";
                uzanti = Application.StartupPath + "\\Dosyalar\\images\\icon8\\photo.png";
            }
            else
            {
                DosyaUzantisi = "Dosya";
                uzanti = Application.StartupPath + "\\Dosyalar\\images\\icon8\\File.png";
            }
        }
        void Mbelgekontrol()
        {
            if (Musterikonum == "b")
            {
                dosyanınyeniklasoru = Application.StartupPath + "\\MBelge\\" + MMtcnoL.Text + "\\";
                klasor = Directory.Exists(Application.StartupPath + "\\MBelge\\" + MMtcnoL.Text + "\\");
                if (klasor == false)
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\MBelge\\" + MMtcnoL.Text + "\\");
                }
                MBvericekme();
                MBdosyaesitleme();
            }
        }
        void MBvericekme()
        {
            MusteriBelge2P.Controls.Clear();
            bosluk = 10;
            try
            {
                baglanti.Open();
                komut = new MySqlCommand("SELECT * FROM mstrbelge WHERE mstrtcno=@mstrtcno", baglanti);
                komut.Parameters.AddWithValue("@mstrtcno", MMtcnoL.Text);
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    kopyalanacakdosyaismi = "" + oku["belgeadi"];
                    DosyaUzantisi = "" + oku["uzanti"];
                    dosyauzantıkontrol();
                    MitemAdd(kopyalanacakdosyaismi, DosyaUzantisi, Image.FromFile(uzanti));
                }
                baglanti.Close();
                Msolmenuyenile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void MBdosyaesitleme()
        {
            int i = 0;
            try
            {
                foreach (Control ad in MusteriBelge2P.Controls)
                {
                    if (ad is UserControl)
                    {
                        i++;
                        while (!File.Exists(dosyanınyeniklasoru + "" + ad.Name))
                        {
                            YapıClass.Belgesil(ad.Name, "");
                            MusteriBelge2P.Controls.Clear();
                            MBvericekme();
                        }
                    }
                }
                if (i == 0)
                {
                    MBbilgiP.Visible = true;
                }
                else
                {
                    MBbilgiP.Visible = false;
                }
            }
            catch (Exception)
            {

            }
        }

        public void MitemAdd(string Text1, string Text2, Image Icon)
        {
            MusteriBelge2P.VerticalScroll.Value = 0;
            UserControl4 item = new Rentacar.UserControl4(Text1, Text2, Icon);
            MusteriBelge2P.Controls.Add(item);
            item.Name = Text1;
            item.Top = bosluk;
            bosluk = (item.Top + item.Height + 10);
            MusteriBelge2P.VerticalScroll.Value = MusteriBelge2P.VerticalScroll.Maximum;
            MusteriBelge2P.AutoScroll = true;
            MusteriBelge2P.Focus();

        }
        //---------------------------------------------------------------------- SOLMENÜ
        private void MBelgeTB_Click(object sender, EventArgs e)
        {
            if (Musterikonum != "b")
            {
                if (guncelleeyadakaydett == "guncelle")
                {
                    if (GenelClass.islemiptal() == true)
                    {
                        guncelleeyadakaydett = "";
                        Musteripanelarası();
                        Musterikonum = "b";
                        Musteripanelarası();
                        MusteriBelge2P.VerticalScroll.Value = MusteriBelge2P.VerticalScroll.Minimum;
                        MusteriBelge2P.AutoScroll = true;
                        Mbelgekontrol();
                        MusteriBelge2P.Focus();
                    }
                }
                else if (guncelleeyadakaydett != "guncelle")
                {
                    guncelleeyadakaydett = "";
                    Musteripanelarası();
                    Musterikonum = "b";
                    Musteripanelarası();
                    MusteriBelge2P.VerticalScroll.Value = MusteriBelge2P.VerticalScroll.Minimum;
                    MusteriBelge2P.AutoScroll = true;
                    Mbelgekontrol();
                    MusteriBelge2P.Focus();
                }
            }
        }

        //---------------------------------------------------------------------- ORTAMENÜ
        private void belgekontrolL_TextChanged(object sender, EventArgs e)
        {
            if (MbelgekontrolL.Text == "delete")
            {
                MusteriBelge2P.Controls.Clear();
                MBvericekme();
                MBdosyaesitleme();
                Msolmenuyenile();
            }
        }

        //---------------------------------------------------------------------- İÇMENÜ
        private void MbelgeYeniIB_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = openFileDialog1;
            dosya.InitialDirectory = "D:\\";
            dosya.Title = "Belge Seç";
            dosya.FileName = "";
            if (dosya.ShowDialog() == DialogResult.OK)
            {
                kopyalanacakdosyaismi = dosya.SafeFileName.ToString();
                kopyalanacakdosya = dosya.FileName.ToString();
                System.IO.FileInfo ff = new System.IO.FileInfo(dosyanınyeniklasoru + kopyalanacakdosyaismi);
                DosyaUzantisi = ff.Extension;
                if (File.Exists(dosyanınyeniklasoru + "" + kopyalanacakdosyaismi))
                {
                    MessageBox.Show(kopyalanacakdosyaismi + " İsimli Bu Dosya Zaten Mevcut!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    File.Copy(kopyalanacakdosya, dosyanınyeniklasoru + "" + kopyalanacakdosyaismi);
                    baglanti.Open();
                    komut = new MySqlCommand("INSERT INTO mstrbelge (belgeadi,mstrtcno,uzanti) VALUES (@belgeadi,@mstrtcno,@uzanti)", baglanti);
                    komut.Parameters.AddWithValue("@belgeadi", kopyalanacakdosyaismi);
                    komut.Parameters.AddWithValue("@mstrtcno", belgetc);
                    komut.Parameters.AddWithValue("@uzanti", DosyaUzantisi);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    dosyauzantıkontrol();
                    MitemAdd(kopyalanacakdosyaismi, DosyaUzantisi, Image.FromFile(uzanti));
                    Msolmenuyenile();
                }
                MBbilgiP.Visible = false;
                
            }
        }

        private void MusteriBelge2P_Click(object sender, EventArgs e)
        {
            MusteriBelge2P.Focus();
        }

        /*-------------------------------------------------------------------------------- MUSTERİKEFİL*/
        private void KefilGenelP_EnabledChanged(object sender, EventArgs e)
        {
            if (KefilGenelP.Enabled == false)
            {
                if (guncelleeyadakaydett != "guncelle")
                {
                    KefilGenelP.Visible = false;
                }
                else
                {
                    if (GenelClass.islemiptal() == true)
                    {
                        KefilGenelP.Visible = false;
                        KefilGMenuP.Visible = true;
                        KefilGMenu2P.Visible = false;
                    }               
                }
                KefilGenelP.Enabled = true;
            }
        }

        //---------------------------------------------------------------------- ALTPROG.
        void Mkvericek()
        {
            try
            {
                MkIulkeCB.Items.Clear();
                MkIilCB.Items.Clear();
                MkIilceCB.Items.Clear();
                MkEverlnilCB.Items.Clear();
                MkKKbankaCB.Items.Clear();

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    komut = new MySqlCommand("SELECT DISTINCT * FROM(mstrblglr INNER JOIN mstrehlyt ON mstrblglr.mstrtcno = mstrehlyt.mstrtcno) INNER JOIN kredikart ON mstrblglr.mstrtcno = kredikart.mstrtcno WHERE mstrblglr.mstrtcno = @mstrtcno", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", Musterikefiltc);
                    MySqlDataReader oku = komut.ExecuteReader();
                    if (oku.Read())
                    {
                        MkGtcnoTB.Text = Musterikefiltc;
                        MkGadiTB.Text = "" + oku["mstradi"];
                        MkGsoyadiTB.Text = "" + oku["mstrsoyadi"];

                        MkGdgmyeriTB.Text = "" + oku["mstrdgmyeri"];
                        MkGserinoTB.Text = "" + oku["mstrsrino"];
                        MkGanneadiTB.Text = "" + oku["mstranneadi"];
                        MkGbabaadiTB.Text = "" + oku["mstrbabaadi"];
                        MkIepostaTB.Text = "" + oku["mstreposta"];
                        MkIadresTB.Text = "" + oku["mstradres"];

                        MkGdgmtarihiMB.Text = "" + oku["mstrdgmtrhi"];
                        MkEgcrllktrhiMB.Text = "" + oku["ehlytgcrllktarh"];
                        MkEsicilnoMB.Text = "" + oku["ehlytsclno"];
                        MkIceptelMB.Text = "" + oku["mstrceptelno"];
                        MkIistelMB.Text = "" + oku["mstristelno"];
                        MkKKnoMB.Text = "" + oku["kartno"];
                        MkKKCvvMB.Text = "" + oku["cvv"];
                        MkKKsktMB.Text = "" + oku["skt"];
                        MkEvrlstrhiMB.Text = "" + oku["ehlytvrlstarh"];

                        string bankaa = "" + oku["banka"];
                        MkIilCB.Items.Add("" + oku["mstril"]);
                        MkIilceCB.Items.Add("" + oku["mstrilce"]);
                        MkEverlnilCB.Items.Add("" + oku["ehlytvrlnil"]);
                        MkIulkeCB.Items.Add("" + oku["mstrulke"]);

                        MkKKodmesstmiCB.Text = "" + oku["osistemi"];
                        MkEsinifiCB.Text = "" + oku["ehlytsnf"];

                        baglanti.Close();

                        MkIilCB.Text = MkIilCB.Items[0].ToString();
                        MkIilceCB.Text = MkIilceCB.Items[0].ToString();
                        MkEverlnilCB.Text = MkEverlnilCB.Items[0].ToString();
                        MkIulkeCB.Text = MkIulkeCB.Items[0].ToString();

                        if (bankaa == "")
                        {
                            YapıClass.bankavericek(MkKKbankaCB);
                            MkKKbankaCB.Text = MkKKbankaCB.Items[0].ToString();
                        }
                        else
                        {
                            MkKKbankaCB.Items.Add(bankaa);
                            MkKKbankaCB.Text = MkKKbankaCB.Items[0].ToString();
                        }
                        Mkgelenkontrol();
                    }
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void Mkkayitt()
        {
            int icislem = 0;
            if (MkGtcnoTB.Text == "" && MkGtcnoTB.Text.Length != 11)
            {
                MessageBox.Show("Lütfen T.C Kimlik No Alanını 11 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MkGtcnoTB.Focus();
            }
            else if (MkGadiTB.Text == "")
            {
                MessageBox.Show("Lütfen Adı Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MkGadiTB.Focus();
            }
            else if (MkGsoyadiTB.Text == "")
            {
                MessageBox.Show("Lütfen Soyadı Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MkGsoyadiTB.Focus();
            }
            else
            {
                if (MorKCB.Items.IndexOf(MkGtcnoTB.Text) != -1)
                {
                    guncelleeyadakaydett = "guncelle";
                }
                Mkboslukkontrolbool();
                if (boslukkontrolu == true)
                {
                    icislem = 1;
                }
                else
                {
                    DialogResult c = MessageBox.Show("Boş Alanlar Mevcut!\nYine'de Kaydedilsin Mi?", "KAYIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (c == DialogResult.Yes)
                    {
                        icislem = 1;
                    }
                    else
                    {
                        Mkboslukkontrol();
                    }
                }
                if (icislem == 1)
                {
                    if (guncelleeyadakaydett == "kaydet")
                    {
                        Mkkaydett();
                    }
                    if (guncelleeyadakaydett == "guncelle")
                    {
                        Mkguncelleekaydet();
                    }
                }
            }
            guncelleeyadakaydett = "";
        }
        void Mkguncelleekaydet()
        {

            int icsayac = 0;
            if (sozlesmetablo == "")
            {
                sozlesmetablo = "mstrblglr";
            }
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    Mkgirilen();
                    Mkgirilenkontrol();
                    while (icsayac < 1)
                    {
                        baglanti.Open();
                        if (sozlesmetablo != "kiralama")
                        {
                            komut = new MySqlCommand("UPDATE mstrblglr SET mstradi=@mstradi, mstrsoyadi=@mstrsoyadi, mstrdgmtrhi=@mstrdgmtrhi, mstrdgmyeri=@mstrdgmyeri, mstrceptelno=@mstrceptelno, mstristelno=@mstristelno, mstreposta=@mstreposta, mstril=@mstril, mstrilce=@mstrilce, mstrulke=@mstrulke, mstradres=@mstradres, mstranneadi=@mstranneadi, mstrbabaadi=@mstrbabaadi , mstrsrino=@mstrsrino WHERE mstrtcno=@mstrtcno", baglanti);
                        }
                        else
                        {
                            komut = new MySqlCommand("UPDATE kiralama SET mstrkfladi=@mstradi, mstrkflsoyadi=@mstrsoyadi, mstrkfldgmtrhi=@mstrdgmtrhi, mstrkfldgmyeri=@mstrdgmyeri, mstrkflceptelno=@mstrceptelno, mstrkflistelno=@mstristelno, mstrkfleposta=@mstreposta, mstrkflil=@mstril, mstrkflilce=@mstrilce, mstrkflulke=@mstrulke, mstrkfladres=@mstradres, mstrkflanneadi=@mstranneadi, mstrkflbabaadi=@mstrbabaadi , mstrkflsrino=@mstrsrino WHERE mstrkfltcno=@mstrtcno", baglanti);
                        }
                        komut.Parameters.AddWithValue("@mstrtcno", MkGtcnoTB.Text);
                        komut.Parameters.AddWithValue("@mstradi", MkGadiTB.Text);
                        komut.Parameters.AddWithValue("@mstrsoyadi", MkGsoyadiTB.Text);
                        komut.Parameters.AddWithValue("@mstrdgmtrhi", dogumtarihi);
                        komut.Parameters.AddWithValue("@mstrdgmyeri", MkGdgmyeriTB.Text);
                        komut.Parameters.AddWithValue("@mstrceptelno", ceptelefon);
                        komut.Parameters.AddWithValue("@mstristelno", istelefon);
                        komut.Parameters.AddWithValue("@mstreposta", MkIepostaTB.Text);
                        komut.Parameters.AddWithValue("@mstril", MkIilCB.Text);
                        komut.Parameters.AddWithValue("@mstrilce", MkIilceCB.Text);
                        komut.Parameters.AddWithValue("@mstrulke", MkIulkeCB.Text);
                        komut.Parameters.AddWithValue("@mstradres", MkIadresTB.Text);
                        komut.Parameters.AddWithValue("@mstranneadi", MkGanneadiTB.Text);
                        komut.Parameters.AddWithValue("@mstrbabaadi", MkGbabaadiTB.Text);
                        komut.Parameters.AddWithValue("@mstrsrino", MkGserinoTB.Text);
                        komut.ExecuteNonQuery();
                        if (sozlesmetablo != "kiralama")
                        {
                            komut = new MySqlCommand("UPDATE mstrehlyt SET ehlytvrlnil=@ehlytvrlnil, ehlytvrlstarh=@ehlytvrlstarh, ehlytgcrllktarh=@ehlytgcrllktarh, ehlytsclno=@ehlytsclno, ehlytsnf=@ehlytsnf WHERE mstrtcno=@mstrtcno", baglanti);
                        }
                        else
                        {
                            komut = new MySqlCommand("UPDATE kiralama SET kflehlytvrlnil=@ehlytvrlnil, kflehlytvrlstarh=@ehlytvrlstarh, kflehlytgcrllktarh=@ehlytgcrllktarh, kflehlytsclno=@ehlytsclno, kflehlytsnf=@ehlytsnf WHERE mstrkfltcno=@mstrtcno", baglanti);
                        }
                        komut.Parameters.AddWithValue("@mstrtcno", MkGtcnoTB.Text);
                        komut.Parameters.AddWithValue("@ehlytvrlnil", MkEverlnilCB.Text);
                        komut.Parameters.AddWithValue("@ehlytvrlstarh", verilistarihi);
                        komut.Parameters.AddWithValue("@ehlytgcrllktarh", gecerliliktarihi);
                        komut.Parameters.AddWithValue("@ehlytsclno", MkEsicilnoMB.Text);
                        komut.Parameters.AddWithValue("@ehlytsnf", Esinif);
                        komut.ExecuteNonQuery();
                        if (sozlesmetablo != "kiralama")
                        {
                            komut = new MySqlCommand("UPDATE kredikart SET kartno=@kartno, banka=@banka, cvv=@cvv, skt=@skt, osistemi=@osistemi WHERE mstrtcno=@mstrtcno", baglanti);
                        }
                        else
                        {
                            komut = new MySqlCommand("UPDATE kiralama SET kflkartno=@kartno, kflbanka=@banka, kflcvv=@cvv, kflskt=@skt, kflosistemi=@osistemi WHERE mstrkfltcno=@mstrtcno", baglanti);
                        }
                        komut.Parameters.AddWithValue("@mstrtcno", MkGtcnoTB.Text);
                        komut.Parameters.AddWithValue("@kartno", kartno);
                        komut.Parameters.AddWithValue("@banka", MkKKbankaCB.Text);
                        komut.Parameters.AddWithValue("@cvv", MkKKCvvMB.Text);
                        komut.Parameters.AddWithValue("@skt", skt);
                        komut.Parameters.AddWithValue("@osistemi", odemesistemi);
                        komut.ExecuteNonQuery();

                        if (sozlesmetablo != "kiralama")
                        {
                            komut = new MySqlCommand("UPDATE mstrblglr SET mstrtcno=@mstrtcno, mstrkfltcno=@mstrkfltcno WHERE mstrtcno=@mstrtcno", baglanti);
                        }
                        else
                        {
                            komut = new MySqlCommand("UPDATE kiralama SET mstrtcno=@mstrtcno, mstrkfltcno=@mstrkfltcno WHERE mstrtcno=@mstrtcno", baglanti);
                        }
                        komut.Parameters.AddWithValue("@mstrtcno", MMtcnoL.Text);
                        komut.Parameters.AddWithValue("@mstrkfltcno", MkGtcnoTB.Text);
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                        if (sozlesmetablo != "kiralama")
                        {
                            Mkverikontrol();
                            MBilgiP.BackColor = Color.Green;
                            MBilgiCL.Text = "Güncelleme İşlemi Başarıyla Tamamlandı!";
                            TransparentAnimator.ShowSync(MBilgiP);
                            MBilgiCL.Focus();
                            timer2.Start();

                            sozlesmetablo = "kiralama";
                        }
                        else
                        {
                            icsayac++;
                            sozlesmetablo = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void Mkkaydett()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    Mkgirilen();
                    Mkgirilenkontrol();
                    baglanti.Open();
                    komut = new MySqlCommand("INSERT INTO mstrblglr (mstrtcno,mstradi,mstrsoyadi,mstrdgmtrhi,mstrdgmyeri,mstrceptelno,mstristelno,mstreposta,mstril,mstrilce,mstrulke,mstradres,mstranneadi,mstrbabaadi,mstrsrino,MorK) VALUES (@mstrtcno,@mstradi,@mstrsoyadi,@mstrdgmtrhi,@mstrdgmyeri,@mstrceptelno,@mstristelno,@mstreposta,@mstril,@mstrilce,@mstrulke,@mstradres,@mstranneadi,@mstrbabaadi,@mstrsrino,@MorK)", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", MkGtcnoTB.Text);
                    komut.Parameters.AddWithValue("@mstradi", MkGadiTB.Text.ToUpper());
                    komut.Parameters.AddWithValue("@mstrsoyadi", MkGsoyadiTB.Text.ToUpper());
                    komut.Parameters.AddWithValue("@mstrdgmtrhi", dogumtarihi);
                    komut.Parameters.AddWithValue("@mstrdgmyeri", MkGdgmyeriTB.Text);
                    komut.Parameters.AddWithValue("@mstrceptelno", ceptelefon);
                    komut.Parameters.AddWithValue("@mstristelno", istelefon);
                    komut.Parameters.AddWithValue("@mstreposta", MkIepostaTB.Text);
                    komut.Parameters.AddWithValue("@mstril", MkIilCB.Text);
                    komut.Parameters.AddWithValue("@mstrilce", MkIilceCB.Text);
                    komut.Parameters.AddWithValue("@mstrulke", MkIulkeCB.Text);
                    komut.Parameters.AddWithValue("@mstradres", MkIadresTB.Text);
                    komut.Parameters.AddWithValue("@mstranneadi", MkGanneadiTB.Text);
                    komut.Parameters.AddWithValue("@mstrbabaadi", MkGbabaadiTB.Text);
                    komut.Parameters.AddWithValue("@mstrsrino", MkGserinoTB.Text);

                    komut.Parameters.AddWithValue("@MorK", kayitbilgisi);

                    komut.ExecuteNonQuery();
                    komut = new MySqlCommand("INSERT INTO mstrehlyt (mstrtcno,ehlytvrlnil,ehlytvrlstarh,ehlytgcrllktarh,ehlytsclno,ehlytsnf) VALUES (@mstrtcno,@ehlytvrlnil,@ehlytvrlstarh,@ehlytgcrllktarh,@ehlytsclno,@ehlytsnf)", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", MkGtcnoTB.Text);
                    komut.Parameters.AddWithValue("@ehlytvrlnil", MkEverlnilCB.Text);
                    komut.Parameters.AddWithValue("@ehlytvrlstarh", verilistarihi);
                    komut.Parameters.AddWithValue("@ehlytgcrllktarh", gecerliliktarihi);
                    komut.Parameters.AddWithValue("@ehlytsclno", MkEsicilnoMB.Text);
                    komut.Parameters.AddWithValue("@ehlytsnf", Esinif);
                    komut.ExecuteNonQuery();
                    komut = new MySqlCommand("INSERT INTO kredikart (mstrtcno,kartno,banka,cvv,skt,osistemi) VALUES (@mstrtcno,@kartno,@banka,@cvv,@skt,@osistemi)", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", MkGtcnoTB.Text);
                    komut.Parameters.AddWithValue("@kartno", kartno);
                    komut.Parameters.AddWithValue("@banka", MkKKbankaCB.Text);
                    komut.Parameters.AddWithValue("@cvv", MkKKCvvMB.Text);
                    komut.Parameters.AddWithValue("@skt", skt);
                    komut.Parameters.AddWithValue("@osistemi", odemesistemi);
                    komut.ExecuteNonQuery();

                    komut = new MySqlCommand("UPDATE mstrblglr SET mstrtcno=@mstrtcno, mstrkfltcno=@mstrkfltcno WHERE mstrtcno=@mstrtcno", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", MMtcnoL.Text);
                    komut.Parameters.AddWithValue("@mstrkfltcno", MkGtcnoTB.Text);
                    komut.ExecuteNonQuery();

                    komut = new MySqlCommand("UPDATE kiralama SET mstrtcno=@mstrtcno, mstrkfltcno=@mstrkfltcno WHERE mstrtcno=@mstrtcno", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", MMtcnoL.Text);
                    komut.Parameters.AddWithValue("@mstrkfltcno", MkGtcnoTB.Text);
                    komut.ExecuteNonQuery();

                    baglanti.Close();
                    sozlesmetablo = "kiralama";
                    Mkguncelleekaydet();
                    Musterikefiltc = MkGtcnoTB.Text;

                    Msolmenuyenile();


                    Mkverikontrol();
                    MBilgiP.BackColor = Color.Green;
                    MBilgiCL.Text = "Kayıt İşlemi Başarıyla Tamamlandı!";
                    TransparentAnimator.ShowSync(MBilgiP);
                    MBilgiCL.Focus();
                    timer2.Start();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }

        void Mkcontrolkilitle()
        {
            GenelClass.ControlKilit(KefilGenel2P, "false");
        }
        void Mkcontrolkilitac()
        {
            GenelClass.ControlKilit(KefilGenel2P, "true");
        }
        void Mkcontroltemizle()
        {
            GenelClass.ControlKilit(KefilGenel2P, "clear");
            MkIulkeCB.Items.Clear();
            MkIilCB.Items.Clear();
            MkIilceCB.Items.Clear();
            MkKKbankaCB.Items.Clear();
            MkKKodmesstmiCB.Text = MkKKodmesstmiCB.Items[0].ToString();
            MkEverlnilCB.Items.Clear();
            MkEsinifiCB.Text = MkEsinifiCB.Items[0].ToString();
        }

        void Mkyeni()
        {
            KefilGPaneli.Focus();
            while (KefilGMenuicP.Visible == true)
            {

            }
            KefilGMenuP.Visible = false;
            KefilGMenu2P.Show();

            guncelleeyadakaydett = "kaydet";
            Mkcontroltemizle();
            Mkcontrolkilitac();

            YapıClass.ulkevericek(MkIulkeCB);
            MkIulkeCB.Text = MkIulkeCB.Items[189].ToString();
            if (MkIulkeCB.Text == "Türkiye")
            {
                MkIilCB.Items.Clear();
                MkIilceCB.Items.Clear();
                MkEverlnilCB.Items.Clear();
                YapıClass.ilvericek(MkIilCB, MkEverlnilCB);
                MkIilCB.Text = MkIilCB.Items[0].ToString();
                YapıClass.ilkontrolluilce(MkIilCB.Text, MkIilceCB);
                MkIilceCB.Text = MkIilceCB.Items[0].ToString();
                MkEverlnilCB.Text = MkEverlnilCB.Items[0].ToString();
            }
            YapıClass.bankavericek(MkKKbankaCB);
            MkKKbankaCB.Text = MkKKbankaCB.Items[0].ToString();
            MkGtcnoTB.Focus();
        }
        void Mkguncelle()
        {
            tccno = MkGtcnoTB.Text;
            KefilGPaneli.Focus();
            while (KefilGMenuicP.Visible == true)
            {

            }
            KefilGMenuP.Visible = false;
            KefilGMenu2P.Show();

            guncelleeyadakaydett = "guncelle";
            Mkcontrolkilitac();
            MkGtcnoTB.Enabled = false;

            string bnka = MkKKbankaCB.Text;
            MkKKbankaCB.Items.Clear();
            YapıClass.bankavericek(MkKKbankaCB);
            MkKKbankaCB.Text = bnka;

            string c = MkIulkeCB.Text;
            string a = MkIilCB.Text;
            string d = MkIilceCB.Text;
            string b = MkEverlnilCB.Text;

            YapıClass.ulkevericek(MkIulkeCB);
            MkIulkeCB.Text = c;
            if (MkIulkeCB.Text == "Türkiye")
            {
                MkIilCB.Items.Clear();
                MkIilceCB.Items.Clear();
                MkEverlnilCB.Items.Clear();
                YapıClass.ilvericek(MkIilCB, MkEverlnilCB);
                MkIilCB.Text = a;
                MkEverlnilCB.Text = b;
                YapıClass.ilkontrolluilce(MkIilCB.Text, MkIilceCB);
                MkIilceCB.Text = d;
            }
        }

        void Mkgirilen()
        {
            dogumtarihi = MkGdgmtarihiMB.Text;
            ceptelefon = MkIceptelMB.Text;
            istelefon = MkIistelMB.Text;
            verilistarihi = MkEvrlstrhiMB.Text;
            gecerliliktarihi = MkEgcrllktrhiMB.Text;
            kartno = MkKKnoMB.Text;
            skt = MkKKsktMB.Text;
            odemesistemi = MKKodmesstmiCB.Text;
            Esinif = MEsinifiCB.Text;
        }
        void Mkverikontrol()
        {
            if (Musterikefiltc != "")
            {
                Mkcontrolkilitle();
                if (hangiislem != "sil" && KefilGMenuP.Visible == false)
                {
                    Kefilislemmenusudegis();
                }
            }
            else
            {
                KefilGMenuP.Visible = false;
                Mkyeni();
            }
        }
        void Mkboslukkontrol()
        {
            if (MkGserinoTB.Text == "")
            {
                MkGserinoTB.Focus();
            }
            else if (MkGdgmtarihiMB.Text.Length != 10)
            {
                MkGdgmtarihiMB.Focus();
            }
            else if (MkGdgmyeriTB.Text == "")
            {
                MkGdgmyeriTB.Focus();
            }
            else if (MkGanneadiTB.Text == "")
            {
                MkGanneadiTB.Focus();
            }
            else if (MkGbabaadiTB.Text == "")
            {
                MkGbabaadiTB.Focus();
            }
            else if (MkIceptelMB.Text == "(   )    -")
            {
                MkIceptelMB.Focus();
            }
            else if (MkIistelMB.Text == "(   )    -")
            {
                MkIistelMB.Focus();
            }
            else if (MkIepostaTB.Text == "")
            {
                MkIepostaTB.Focus();
            }
            else if (MkIulkeCB.Text == "Ülke Seçiniz." || MkIulkeCB.Text == "")
            {
                MkIulkeCB.Focus();
            }
            else if (MkIilCB.Text == "Şehir Seçiniz." || MkIilCB.Text == "")
            {
                MkIulkeCB.Focus();
            }
            else if (MkIilceCB.Text == "İlçe Seçiniz." || MkIilceCB.Text == "")
            {
                MkIilceCB.Focus();
            }
            else if (MkIadresTB.Text == "")
            {
                MkIadresTB.Focus();
            }
            else if (MkKKnoMB.Text == "    -    -    -")
            {
                MkKKnoMB.Focus();
            }
            else if (MkKKCvvMB.Text == "")
            {
                MkKKCvvMB.Focus();
            }
            else if (MkKKsktMB.Text == "  -")
            {
                MkKKsktMB.Focus();
            }
            else if (MkKKbankaCB.Text == "Banka Seçiniz." || MkKKbankaCB.Text == "")
            {
                MkKKbankaCB.Focus();
            }
            else if (MkKKodmesstmiCB.Text == "Ödeme Sistemi Seçiniz." || MkKKodmesstmiCB.Text == "")
            {
                MkKKodmesstmiCB.Focus();
            }
            else if (MkEsicilnoMB.Text == "")
            {
                MkEsicilnoMB.Focus();
            }
            else if (MkEvrlstrhiMB.Text.Length != 10)
            {
                MkEvrlstrhiMB.Focus();
            }
            else if (MkEgcrllktrhiMB.Text.Length != 10)
            {
                MkEgcrllktrhiMB.Focus();
            }
            else if (MkEverlnilCB.Text == "Şehir Seçiniz." || MkEverlnilCB.Text == "")
            {
                MkEverlnilCB.Focus();
            }
            else if (MkEsinifiCB.Text == "Ehliyet Sınıfı Seçiniz." || MkEsinifiCB.Text == "")
            {
                MkEsinifiCB.Focus();
            }
        }
        void Mkgirilenkontrol()
        {
            if (dogumtarihi == "  .  .")
            {
                dogumtarihi = "";
            }
            if (ceptelefon == "(   )    -")
            {
                ceptelefon = "";
            }
            if (istelefon == "(   )    -")
            {
                istelefon = "";
            }
            if (MkIilCB.Text == "Şehir Seçiniz.")
            {
                MkIilCB.Items.Add("");
                MkIilCB.Text = "";
            }
            if (MkIilceCB.Text == "İlçe Seçiniz.")
            {
                MkIilceCB.Items.Add("");
                MkIilceCB.Text = "";
            }
            if (MkEverlnilCB.Text == "Şehir Seçiniz.")
            {
                MkEverlnilCB.Items.Add("");
                MkEverlnilCB.Text = "";
            }
            if (verilistarihi == "  .  .")
            {
                verilistarihi = "";
            }
            if (gecerliliktarihi == "  .  .")
            {
                gecerliliktarihi = "";
            }
            if (MkKKbankaCB.Text == "Banka Seçiniz.")
            {
                MkKKbankaCB.Items.Add("");
                MkKKbankaCB.Text = "";
            }
            if (kartno == "    -    -    -")
            {
                kartno = "";
            }
            if (skt == "  -")
            {
                skt = "";
            }
            if (MkKKodmesstmiCB.Text == "Ödeme Sistemi Seçiniz.")
            {
                odemesistemi = "";
            }
            if (MkEsinifiCB.Text == "Ehliyet Sınıfı Seçiniz.")
            {
                Esinif = "";
            }
        }
        void Mkgelenkontrol()
        {
            if (MkKKodmesstmiCB.Text == "")
            {
                MkKKodmesstmiCB.Text = MkKKodmesstmiCB.Items[0].ToString();
            }
            if (MkEsinifiCB.Text == "")
            {
                MkEsinifiCB.Text = MkEsinifiCB.Items[0].ToString();
            }
        }

        void Mkboslukkontrolbool()
        {
            if (
                MkGdgmtarihiMB.Text == "  .  ." || MkGdgmtarihiMB.Text.Length != 10 ||
                MkGdgmyeriTB.Text == "" ||
                MkIceptelMB.Text.Length != 14 || MkIceptelMB.Text == "(   )    -" ||
                MkIistelMB.Text.Length != 14 || MkIistelMB.Text == "(   )    -" ||
                MkIulkeCB.Text == "Ülke Seçiniz." || MkIulkeCB.Text == "" ||
                MkIilCB.Text == "Şehir Seçiniz." || MkIilCB.Text == "" ||
                MkIilceCB.Text == "İlçe Seçiniz." || MkIilceCB.Text == "" ||
                MkEverlnilCB.Text == "Şehir Seçiniz." || MkEverlnilCB.Text == "" ||
                MkIadresTB.Text == "" ||
                MkEvrlstrhiMB.Text.Length != 10 ||
                MkEgcrllktrhiMB.Text.Length != 10 ||
                MkEsicilnoMB.Text.Length != 6 ||
                MkIepostaTB.Text == "" ||
                MkKKbankaCB.Text == "Banka Seçiniz." || MkKKbankaCB.Text == "" ||
                MkKKnoMB.Text == "    -    -    - " || MkKKnoMB.Text.Length != 19 ||
                MkKKCvvMB.Text == "" || MkKKCvvMB.Text.Length != 3 ||
                MkKKsktMB.Text == "  -" || MkKKsktMB.Text.Length != 5
                )
            {
                boslukkontrolu = false;
            }
            else
            {
                boslukkontrolu = true;
            }
        }

        void Kefilislemmenusukapat()
        {
            if (KefilGMenuicP.Visible == true)
            {
                KefilGMenuIB.Enabled = false;
                RotateAnimator.HideSync(KefilGMenuIB);
                RotateAnimator.ShowSync(KefilGMenuIB);
                TransparentAnimator.HideSync(GuncelleKefilIB);
                TransparentAnimator.HideSync(SilKefilIB);
                KefilGMenuicP.Visible = false;
            }
            KefilGMenuIB.Enabled = true;
        }
        void Kefilkontrol()
        {
            if (Musterikonum == "d")
            {
                if (Musterikefiltc != "")
                {
                    Mkvericek();
                    Mkverikontrol();
                }
                else
                {
                    Mkyeni();
                }
            }
        }
        void Kefilislemmenusudegis()
        {
            if (KefilGMenuP.Visible == true)
            {
                KefilGMenu2P.Visible = true;
                KefilGMenuP.Visible = false;
            }
            else if (KefilGMenu2P.Visible == true)
            {
                KefilGMenuP.Visible = true;
                KefilGMenu2P.Visible = false;
            }
        }
        void Msolmenuyenile()
        {
            string gecici = MMtcnoL.Text;
            hangiislem = "sil";
            Mverikontrol();
            MusteriCB.Text = gecici;
            hangiislem = "";
        }

        //---------------------------------------------------------------------- SOLMENÜ
        private void KefilTB_Click(object sender, EventArgs e)
        {
            if (Musterikonum != "d")
            {
                Musteripanelarası();
                Musterikonum = "d";
                Musteripanelarası();
                KefilGenel2P.Focus();
                Kefilkontrol();
                /*      if (kiraguncellekefil != "")
                      {
                          maskedTextBox1.Text = kiraguncellekefil;
                          sozlesmekefil();
                      }
                      else
                      {
                          maskedTextBox1.Text = MMtcnoL.Text;
                      }*/
            }
        }

        //---------------------------------------------------------------------- İÇMENÜ
        private void KefilGenelP_Click(object sender, EventArgs e)
        {
            KefilGenel2P.Focus();
        }

        private void KefilGMenuIB_Click(object sender, EventArgs e)
        {
            KefilGMenuIB.Enabled = false;
            RotateAnimator.HideSync(KefilGMenuIB);
            RotateAnimator.ShowSync(KefilGMenuIB);
            KefilGMenuP.Focus();
            if (KefilGMenuicP.Visible == false)
            {
                KefilGMenuicP.Visible = true;
                this.TransparentAnimator.ShowSync(SilKefilIB);
                this.TransparentAnimator.ShowSync(GuncelleKefilIB);
            }
            else
            {
                this.TransparentAnimator.HideSync(GuncelleKefilIB);
                this.TransparentAnimator.HideSync(SilKefilIB);
                KefilGMenuicP.Visible = false;
                KefilGenel2P.Focus();
            }
            KefilGMenuIB.Enabled = true;
        }
        private void KefilGMenuP_Leave(object sender, EventArgs e)
        {
            Kefilislemmenusukapat();
        }
        private void SilKefilIB_Click(object sender, EventArgs e)
        {
            if (GenelClass.sil() == true)
            {
                baglanti.Open();
                komut = new MySqlCommand("UPDATE mstrblglr SET mstrtcno=@mstrtcno, mstrkfltcno=@mstrkfltcno WHERE mstrtcno=@mstrtcno", baglanti);
                komut.Parameters.AddWithValue("@mstrtcno", MMtcnoL.Text);
                komut.Parameters.AddWithValue("@mstrkfltcno", "");
                komut.ExecuteNonQuery();
                baglanti.Close();
                Musterikefiltc = "";
                hangiislem = "sil";

                MBilgiCL.Text = "1 Kayıt Başarıyla Silindi!";
                MBilgiP.BackColor = Color.Maroon;
                this.TransparentAnimator.ShowSync(MBilgiP);
                MBilgiCL.Focus();
                timer2.Start();
                Mkcontroltemizle();
                Mkverikontrol();
                KefilGenel2P.Focus();
                hangiislem = "";
            }
        }
        private void GuncelleKefilIB_Click(object sender, EventArgs e)
        {
            Mkguncelle();
        }
        private void KefilkaydetIB_Click(object sender, EventArgs e)
        {
            try
            {
                klasor = Directory.Exists(Application.StartupPath + "\\MBelge\\" + MkGtcnoTB.Text + "\\");
                if (klasor == false)
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\MBelge\\" + MkGtcnoTB.Text + "\\");
                }
                Mkkayitt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void KefiliptalIB_Click(object sender, EventArgs e)
        {
            if (Musterikefiltc != "")
            {
                KefilGenel2P.Focus();
                Mkcontroltemizle();
                Mkvericek();
                Mkverikontrol();
            }
            else
            {
                Mkyeni();
            }
            guncelleeyadakaydett = "";
        }

        //------------------------------------------------------------ KİMLİK
        private void MkGtcnoTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MkGtcnoTB.MaxLength = 11;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void MkGtcnoTB_KeyUp(object sender, KeyEventArgs e)
        {
            if (MkGtcnoTB.Text.Length < 11)
            {
                verioneri = true;
                verioneri2 = true;
            }
            if (MkGtcnoTB.Text.Length == 11 && verioneri2 == true)
            {
                MkGserinoTB.Focus();
                verioneri2 = false;
            }
        }
        private void MkGtcnoTB_Validating(object sender, CancelEventArgs e)
        {
            if (MkGtcnoTB.Text.Length == 11)
            {
                GenelClass.Tckontrolet(MkGtcnoTB.Text);
                if (GenelClass.Tckontrolet(MkGtcnoTB.Text) == false)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir T.C Kimlik No Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (MMtcnoL.Text == MkGtcnoTB.Text)
                {
                    e.Cancel = true;
                    MessageBox.Show("Müşteri İle Kefil Aynı Olamaz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (verioneri == true)
                    {
                        if (MorKCB.Items.IndexOf(MkGtcnoTB.Text) != -1)
                        {
                            Musterikefiltc = MkGtcnoTB.Text;
                            Mkcontroltemizle();
                            Mkvericek();
                        }
                        else
                        {
                            //buraya araç sahibinin comboboxını yapınca geleceğiz bu elsenin ifindeki gibi yani
                            /* if (comboBox4.Items.IndexOf(MkGtcnoTB.Text) != -1)
                             {
                                 DialogResult c = MessageBox.Show("Girdiğiniz T.C Kimlik No Sistem'de Araç Sahibi Olarak Mevcuttur.\nBilgileri Alınsın Mı?", "MEVCUT KİŞİ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                 if (c == DialogResult.Yes)
                                 {
                                     Musterikefiltc = MkGtcnoTB.Text;
                                     Mkcontroltemizle();
                                     Mkvericekme();
                                 }
                             }
                             */
                        }
                    }
                }

            }
            else if (MkGtcnoTB.Text.Length == 0)
            {

            }
            else
            {
                MessageBox.Show("Lütfen T.C Kimlik No Alanını 11 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MkGserinoTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MkGserinoTB.MaxLength = 9;
        }

        private void MkGadiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MkGadiTB.MaxLength = 10;
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void MkGsoyadiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MkGsoyadiTB.MaxLength = 10;
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void MkGdgmtarihiMB_Validating(object sender, CancelEventArgs e)
        {
            if (MkGdgmtarihiMB.Text != "  .  .")
            {
                try
                {
                    DateTime a = Convert.ToDateTime(MkGdgmtarihiMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Doğum Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void MkGdgmyeriTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MkGdgmyeriTB.MaxLength = 15;
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void MkGanneadiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MkGanneadiTB.MaxLength = 10;
        }

        private void MkGbabaadiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MkGbabaadiTB.MaxLength = 10;
        }

        //------------------------------------------------------------ İLETİŞİM
        private void MkIceptelMB_Validating(object sender, CancelEventArgs e)
        {
            if (MkIceptelMB.Text != "(   )    -")
            {
                if (MkIceptelMB.Text.Length != 14)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir Cep Telefon Numarası Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (MkIceptelMB.Text.Substring(1, 1) == "0")
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir Cep Telefon Numarası Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MkIistelMB_Validating(object sender, CancelEventArgs e)
        {
            if (MkIistelMB.Text != "(   )    -")
            {
                if (MkIistelMB.Text.Length != 14)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir İş Telefon Numarası Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (MkIistelMB.Text.Substring(1, 1) == "0")
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir Cep Telefon Numarası Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MkIepostaTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MkIepostaTB.MaxLength = 50;
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }
        private void MkIepostaTB_Validating(object sender, CancelEventArgs e)
        {
            if (MkIepostaTB.Text != "")
            {
                if (!new Regex(GenelClass.Regex).IsMatch(MkIepostaTB.Text))
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir E-mail Adresi Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MkIadresTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            MkIadresTB.MaxLength = 100;
        }

        private void MkIulkeCB_Leave(object sender, EventArgs e)
        {
            if (MkIulkeCB.Text == "Türkiye")
            {
                if (MkIilCB.Text == "Şehir Seçiniz." || MkIilCB.Text == "")
                {
                    MkIilCB.Items.Clear();
                    MkIilceCB.Items.Clear();
                    YapıClass.ilvericek(MkIilCB, MkEverlnilCB);
                    MkIilCB.Text = MIilCB.Items[0].ToString();
                    YapıClass.ilkontrolluilce(MkIilCB.Text, MkIilceCB);
                    MkIilceCB.Text = MkIilceCB.Items[0].ToString();
                }
                if (MkEverlnilCB.Text == "Şehir Seçiniz." || MkEverlnilCB.Text == "")
                {
                    MkEverlnilCB.Items.Clear();
                    YapıClass.ilvericek(MkIilCB, MkEverlnilCB);
                    MkEverlnilCB.Text = MkEverlnilCB.Items[0].ToString();
                }
                if (MkIilceCB.Text == "İlçe Seçiniz." || MkIilceCB.Text == "")
                {
                    MkIilceCB.Items.Clear();
                    YapıClass.ilkontrolluilce(MkIilCB.Text, MkIilceCB);
                    MkIilceCB.Text = MkIilceCB.Items[0].ToString();
                }
            }
            else
            {
                MkIilCB.Items.Clear();
                MkIilceCB.Items.Clear();
                MkEverlnilCB.Items.Clear();
                MkIilCB.Items.Add("Şehir Seçiniz.");
                MkIilceCB.Items.Add("İlçe Seçiniz.");
                MkEverlnilCB.Items.Add("Şehir Seçiniz.");
                MkIilCB.Text = MkIilCB.Items[0].ToString();
                MkIilceCB.Text = MkIilceCB.Items[0].ToString();
                MkEverlnilCB.Text = MkEverlnilCB.Items[0].ToString();
            }
        }
        private void MkIulkeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MkIulkeCB.Text == "Türkiye")
            {
                if (MkIilCB.Text == "Şehir Seçiniz." || MkIilCB.Text == "")
                {
                    MkIilCB.Items.Clear();
                    MkIilceCB.Items.Clear();
                    MkIilCB.Items.Add("Şehir Seçiniz.");
                    MkIilceCB.Items.Add("İlçe Seçiniz.");
                    MkIilCB.Text = MkIilCB.Items[0].ToString();
                    MkIilceCB.Text = MkIilceCB.Items[0].ToString();
                }
                if (MkEverlnilCB.Text == "Şehir Seçiniz." || MkEverlnilCB.Text == "")
                {
                    MkEverlnilCB.Items.Clear();
                    MkEverlnilCB.Items.Add("Şehir Seçiniz.");
                    MkEverlnilCB.Text = MkEverlnilCB.Items[0].ToString();
                }
                if (MkIilceCB.Text == "İlçe Seçiniz." || MkIilceCB.Text == "")
                {
                    MkIilceCB.Items.Clear();
                    MkIilceCB.Items.Add("İlçe Seçiniz.");
                    MkIilceCB.Text = MkIilceCB.Items[0].ToString();
                }
            }
            else
            {
                MkIilCB.Items.Clear();
                MkIilceCB.Items.Clear();
                MkEverlnilCB.Items.Clear();
                MkIilCB.Items.Add("Şehir Seçiniz.");
                MkIilceCB.Items.Add("İlçe Seçiniz.");
                MkEverlnilCB.Items.Add("Şehir Seçiniz.");
                MkIilCB.Text = MkIilCB.Items[0].ToString();
                MkIilceCB.Text = MkIilceCB.Items[0].ToString();
                MkEverlnilCB.Text = MkEverlnilCB.Items[0].ToString();
            }
        }

        private void MkIilCB_Enter(object sender, EventArgs e)
        {
            ililce = MkIilCB.Text;
        }
        private void MkIilCB_Leave(object sender, EventArgs e)
        {

        }

        //------------------------------------------------------------ KKARTI
        private void MkKKnoMB_Validating(object sender, CancelEventArgs e)
        {
            if (MkKKnoMB.Text != "    -    -    -")
            {
                if (MkKKnoMB.Text.Length != 19)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Kart No Alanını 16 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void MkKKCvvMB_Validating(object sender, CancelEventArgs e)
        {
            if (MkKKCvvMB.Text != "")
            {
                if (MkKKCvvMB.Text.Length != 3)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen CVV Alanını 3 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void MkKKsktMB_Validating(object sender, CancelEventArgs e)
        {
            if (MkKKsktMB.Text != "  -")
            {
                if (MkKKsktMB.Text.Length != 5)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen SKT Alanını 4 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //------------------------------------------------------------ EHLİYET
        private void MkEsicilnoMB_Validating(object sender, CancelEventArgs e)
        {
            if (MkEsicilnoMB.Text.Length > 0)
            {
                if (MkEsicilnoMB.Text.Length != 6)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Sicil No Alanını 6 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void MkEvrlstrhiMB_Validating(object sender, CancelEventArgs e)
        {
            if (MkEvrlstrhiMB.Text != "  .  .")
            {
                try
                {
                    DateTime b = Convert.ToDateTime(MkEvrlstrhiMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Veriliş Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void MkEgcrllktrhiMB_Validating(object sender, CancelEventArgs e)
        {
            if (MkEgcrllktrhiMB.Text != "  .  .")
            {
                try
                {
                    DateTime c = Convert.ToDateTime(MkEgcrllktrhiMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerlilik Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /*------------------------------------------------------------------------------------------ ARAÇ*/
        private void AracFB_Click(object sender, EventArgs e)
        {
            if (AracPaneli.Visible == false)
            {
                panellerarası();
                if (kontrol == true)
                {
                    SolmenuS.Location = new Point(500, SolmenuS.Location.Y);
                    Aracload();
                    Ustmenukonum = "c";              
                    Aracpanelarası();
                    Arackonum = "a";
                    Aracpanelarası();
                    panellerarası();
                    AracGenel2P.Focus();
                }
            }
        }
        private void AracFB_MouseHover(object sender, EventArgs e)
        {
            if (AracUstSlider.Height == 50)
            {
                AracUstSlider.Height = 100;
            }
            Ustmenukonum2 = "c";
            nerede = "2";
            ustmenugecis();
        }

        private void AracFB2_Click(object sender, EventArgs e)
        {
            if (ListelerPaneli.Visible == false)
            {
                panellerarası();
                Ustmenukonum = "e";
                panellerarası();
            }
            if (listekonum != "arac")
            {
                Listepanelarası();
                listekonum = "arac";
                Listepanelarası();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (kirasayısı == 3)
            {
                timer2.Stop();
                this.TransparentAnimator.HideSync(ABilgiP);
                kirasayısı = 0;
            }
            kirasayısı++;
        }
        private void ABilgiP_Leave(object sender, EventArgs e)
        {
            timer3.Stop();
            this.TransparentAnimator.HideSync(ABilgiP);
            kirasayısı = 0;
        }

        private void AracPaneli_EnabledChanged(object sender, EventArgs e)
        {
            GenelClass.KayitKontrol(AracPaneli);
            if (kontrol == true)
            {
                AGMenuP.Visible = true;
                AGMenu2P.Visible = false;
            }
        }

        //---------------------------------------------------------------------- ALTPROG.
        void Avericek()
        {
            AGMarkaCB.Items.Clear();
            AGTipCB.Items.Clear();
            ASKsigortaCB.Items.Clear();
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    komut = new MySqlCommand("SELECT * FROM arcblglr WHERE arcplaka = @arcplaka", baglanti);
                    komut.Parameters.AddWithValue("@arcplaka", AracCB.Text);
                    MySqlDataReader oku = komut.ExecuteReader();
                    if (oku.Read())
                    {
                        APlakaL.Text = "" + oku["arcplaka"];
                        AGPlakaTB.Text = "" + oku["arcplaka"];
                        AGSasinoTB.Text = "" + oku["arcsasino"];
                        AGMotornoTB.Text = "" + oku["arcmotorno"];
                        AGtrafigecikisMB.Text = "" + oku["arctrfkcıkıs"];

                        string markaa = "" + oku["arcmarka"];
                        string tipp = "" + oku["arctip"];

                        AGRenkCB.Text = "" + oku["arcrenk"];
                        AGYakıtturuCB.Text = "" + oku["arcyakit"];
                        AGModelCB.Text = "" + oku["arcmodel"];
                        AGVitesCB.Text = "" + oku["arcvites"];

                        aracsahibitc = "" + oku["arcsahibitcno"];

                        string sigortasirkett = "" + oku["arcsigortasrkt"];

                        ASKpolicenoTB.Text = "" + oku["arcpoliceno"];
                        ASKkaskonoTB.Text = "" + oku["arckasko"];
                        ASKmuayenebitisMB.Text = "" + oku["arcmuaynebts"];
                        ASKkaskobitisMB.Text = "" + oku["arckaskobts"];

                        AsonkmTB.Text = "" + oku["arcsonkm"];

                        arackiti = "" + oku["arckiti"];
                        stepne = "" + oku["arcstepne"];
                        ruhsat = "" + oku["arcrhst"];
                        baglanti.Close();

                        if (markaa == "")
                        {
                            YapıClass.markavericek(AGMarkaCB);
                            AGMarkaCB.Text = AGMarkaCB.Items[0].ToString();
                            YapıClass.tipvericek(AGMarkaCB.Text, AGTipCB);
                            AGTipCB.Text = AGTipCB.Items[0].ToString();
                        }
                        else
                        {
                            AGMarkaCB.Items.Add(markaa);
                            AGMarkaCB.Text = AGMarkaCB.Items[0].ToString();
                            if (tipp == "" || tipp == "Tip seçiniz.")
                            {
                                AGTipCB.Items.Clear();
                                YapıClass.tipvericek(AGMarkaCB.Text, AGTipCB);
                                AGTipCB.Text = AGTipCB.Items[0].ToString();
                            }
                            else
                            {
                                AGTipCB.Items.Add(tipp);
                                AGTipCB.Text = AGTipCB.Items[0].ToString();
                            }
                        }
                        if (sigortasirkett == "")
                        {
                            YapıClass.sigortasirketvericek(ASKsigortaCB);
                            ASKsigortaCB.Text = ASKsigortaCB.Items[0].ToString();
                        }
                        else
                        {
                            ASKsigortaCB.Items.Add(sigortasirkett);
                            ASKsigortaCB.Text = ASKsigortaCB.Items[0].ToString();
                        }

                        Agelenkontrol();

                        Aswitch1vricek();
                        Aswitch2vricek();
                        Aswitch3vricek();
                        Ailksonkontrol();
                        Aozetbilgilervericek();
                        Asolmenu();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void Acomboboxyenile()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    AracCB.Items.Clear();
                    AracCB.Text = "";
                    baglanti.Open();
                    komut = new MySqlCommand("SELECT arcplaka FROM arcblglr", baglanti);
                    MySqlDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        AracCB.Items.Add(oku["arcplaka"]);
                    }
                    baglanti.Close();
                    Asonkayit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }

        void Akayitt()
        {
            int icislem = 0;
            if (AGPlakaTB.Text != "")
            {
                Aboslukkontrolbool();
                if (boslukkontrolu == true)
                {
                    icislem = 1;
                }
                else
                {
                    DialogResult c = MessageBox.Show("Boş alanlar mevcut!\nYine'de kaydedilsin mi?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (c == DialogResult.Yes)
                    {
                        icislem = 1;
                    }
                    else
                    {
                        Aboslukkontrol();
                    }
                }
                if (icislem == 1)
                {
                    Aswitch1kontrol();
                    Aswitch2kontrol();
                    Aswitch3kontrol();
                    if (guncelleeyadakaydett == "kaydett")
                    {
                        Akaydett();
                    }
                    if (guncelleeyadakaydett == "guncelle")
                    {
                        Aguncelleekaydet();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Plaka No Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AGPlakaTB.Focus();
            }
            guncelleeyadakaydett = "";
        }
        void Aguncelleekaydet()
        {
            int icsayac = 0;
            if (sozlesmetablo == "")
            {
                sozlesmetablo = "arcblglr";
            }
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    Agirilen();
                    Agirilenkontrol();
                    while (icsayac < 1)
                    {
                        baglanti.Open();
                        komut = new MySqlCommand("UPDATE " + sozlesmetablo + " SET arcmarka=@arcmarka, arctip=@arctip, arcmodel=@arcmodel, arcrenk=@arcrenk, arcyakit=@arcyakit, arcvites=@arcvites, arcmotorno=@arcmotorno, arcsasino=@arcsasino, arctrfkcıkıs=@arctrfkcıkıs, arcsonkm=@arcsonkm, arckiti=@arckiti, arcstepne=@arcstepne, arcrhst=@arcrhst, arcsigortasrkt=@arcsigortasrkt, arcpoliceno=@arcpoliceno, arckasko=@arckasko, arckaskobts=@arckaskobts, arcmuaynebts=@arcmuaynebts WHERE arcplaka=@arcplaka ", baglanti);
                        komut.Parameters.AddWithValue("@arcplaka", AGPlakaTB.Text);
                        komut.Parameters.AddWithValue("@arcmarka", AGMarkaCB.Text);
                        komut.Parameters.AddWithValue("@arctip", AGTipCB.Text);
                        komut.Parameters.AddWithValue("@arcmodel", model);
                        komut.Parameters.AddWithValue("@arcrenk", renk);
                        komut.Parameters.AddWithValue("@arcyakit", yakıtturu);
                        komut.Parameters.AddWithValue("@arcvites", vites);
                        komut.Parameters.AddWithValue("@arcmotorno", AGMotornoTB.Text);
                        komut.Parameters.AddWithValue("@arcsasino", AGSasinoTB.Text);
                        komut.Parameters.AddWithValue("@arctrfkcıkıs", trafigecikisi);
                        komut.Parameters.AddWithValue("@arcsonkm", AsonkmTB.Text);
                        komut.Parameters.AddWithValue("@arcsigortasrkt", ASKsigortaCB.Text);
                        komut.Parameters.AddWithValue("@arcpoliceno", ASKpolicenoTB.Text);
                        komut.Parameters.AddWithValue("@arckasko", ASKkaskonoTB.Text);
                        komut.Parameters.AddWithValue("@arckaskobts", kaskobitis);
                        komut.Parameters.AddWithValue("@arcmuaynebts", muayenebitis);
                        komut.Parameters.AddWithValue("@arckiti", arackiti);
                        komut.Parameters.AddWithValue("@arcstepne", stepne);
                        komut.Parameters.AddWithValue("@arcrhst", ruhsat);
                        komut.ExecuteNonQuery();
                        baglanti.Close();

                        if (sozlesmetablo != "kiralama")
                        {
                            Averikontrol();
                            AracCB.Text = plakano;
                            ABilgiP.BackColor = Color.Green;
                            ABilgiCL.Text = "Güncelleme İşlemi Başarıyla Tamamlandı!";
                            TransparentAnimator.ShowSync(ABilgiP);
                            ABilgiCL.Focus();
                            timer3.Start();
                            sozlesmetablo = "kiralama";
                        }
                        else
                        {
                            icsayac++;
                            sozlesmetablo = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void Akaydett()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    Agirilen();
                    Agirilenkontrol();
                    baglanti.Open();
                    komut = new MySqlCommand("INSERT INTO arcblglr (arcplaka, arcmarka, arctip, arcmodel,arcrenk, arcyakit, arcvites, arcmotorno, arcsasino, arctrfkcıkıs, arcsonkm, arcsigortasrkt, arcpoliceno, arckasko, arckaskobts, arcmuaynebts, arckiti, arcstepne, arcrhst) VALUES (@arcplaka, @arcmarka, @arctip, @arcmodel, @arcrenk, @arcyakit, @arcvites,@arcmotorno, @arcsasino, @arctrfkcıkıs, @arcsonkm, @arcsigortasrkt, @arcpoliceno, @arckasko, @arckaskobts, @arcmuaynebts, @arckiti, @arcstepne, @arcrhst)", baglanti);
                    komut.Parameters.AddWithValue("@arcplaka", AGPlakaTB.Text);
                    komut.Parameters.AddWithValue("@arcmarka", AGMarkaCB.Text);
                    komut.Parameters.AddWithValue("@arctip", AGTipCB.Text);
                    komut.Parameters.AddWithValue("@arcmodel", model);
                    komut.Parameters.AddWithValue("@arcrenk", renk);
                    komut.Parameters.AddWithValue("@arcyakit", yakıtturu);
                    komut.Parameters.AddWithValue("@arcvites", vites);
                    komut.Parameters.AddWithValue("@arcmotorno", AGMotornoTB.Text);
                    komut.Parameters.AddWithValue("@arcsasino", AGSasinoTB.Text);
                    komut.Parameters.AddWithValue("@arctrfkcıkıs", trafigecikisi);
                    komut.Parameters.AddWithValue("@arcsonkm", AsonkmTB.Text);//değişecek
                    komut.Parameters.AddWithValue("@arcsigortasrkt", ASKsigortaCB.Text);
                    komut.Parameters.AddWithValue("@arcpoliceno", ASKpolicenoTB.Text);
                    komut.Parameters.AddWithValue("@arckasko", ASKkaskonoTB.Text);
                    komut.Parameters.AddWithValue("@arckaskobts", kaskobitis);
                    komut.Parameters.AddWithValue("@arcmuaynebts", muayenebitis);
                    komut.Parameters.AddWithValue("@arckiti", arackiti);
                    komut.Parameters.AddWithValue("@arcstepne", stepne);
                    komut.Parameters.AddWithValue("@arcrhst", ruhsat);
                    komut.ExecuteNonQuery();
                    baglanti.Close();


                    Averikontrol();
                    ABilgiP.BackColor = Color.Green;
                    ABilgiCL.Text = "Kayıt İşlemi Başarıyla Tamamlandı!";
                    TransparentAnimator.ShowSync(ABilgiP);
                    ABilgiCL.Focus();
                    timer3.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }

        void Acontrolkilitle()
        {
            GenelClass.ControlKilit(AracGenel2P,"false");
            bunifuiOSSwitch1.Enabled = false;
            bunifuiOSSwitch2.Enabled = false;
            bunifuiOSSwitch3.Enabled = false;
            ABelgeTB.Visible = true;
            AsahibiTB.Visible = true;
        }
        void Acontrolkilitac()
        {
            GenelClass.ControlKilit(AracGenel2P, "true");
            bunifuiOSSwitch1.Enabled = true;
            bunifuiOSSwitch2.Enabled = true;
            bunifuiOSSwitch3.Enabled = true;
            ABelgeTB.Visible = false;
            AsahibiTB.Visible = false;
            ASDetayTB.Visible = false;
            AKGecmisiTB.Visible = false;
        }
        void Acontroltemizle()
        {
            GenelClass.ControlKilit(AracGenel2P, "true");
            AGRenkCB.Text = AGRenkCB.Items[0].ToString();
            AGYakıtturuCB.Text = AGYakıtturuCB.Items[0].ToString();
            AGModelCB.Text = AGModelCB.Items[0].ToString();
            AGVitesCB.Text = AGVitesCB.Items[0].ToString();
            ASKsigortaCB.Items.Clear();
            bunifuiOSSwitch1.Enabled = false;
            bunifuiOSSwitch2.Enabled = false;
            bunifuiOSSwitch3.Enabled = false;     
            KAracSCL.Text = "";
            ASkiraTarihCL.Text = "";
            ASkiraParaCL.Text = "";
            ASkiralamaCL.Text = "";
            Sozlesmegecisi = "";
        }

        void Agirilen()
        {
            trafigecikisi = AGtrafigecikisMB.Text;
            kaskobitis = ASKkaskobitisMB.Text;
            muayenebitis = ASKmuayenebitisMB.Text;
            model = AGModelCB.Text;
            renk = AGRenkCB.Text;
            yakıtturu = AGYakıtturuCB.Text;
            vites = AGVitesCB.Text;
        }
        void Aswitch1vricek()
        {
            if (arackiti == "1")
            {
                bunifuiOSSwitch1.Value = true;
            }
            else
            {
                bunifuiOSSwitch1.Value = false;
            }
        }
        void Aswitch2vricek()
        {
            if (stepne == "1")
            {
                bunifuiOSSwitch2.Value = true;
            }
            else
            {
                bunifuiOSSwitch2.Value = false;
            }
        }
        void Aswitch3vricek()
        {
            if (ruhsat == "1")
            {
                bunifuiOSSwitch3.Value = true;
            }
            else
            {
                bunifuiOSSwitch3.Value = false;
            }
        }

        void Aboslukkontrolbool()
        {
            if (
                AGMarkaCB.Text == "Marka Seçiniz." || AGMarkaCB.Text == "" ||
                AGTipCB.Text == "Tip Seçiniz." || AGTipCB.Text == "" ||
                AGModelCB.Text == "Model Seçiniz." || AGModelCB.Text == "" ||
                AGRenkCB.Text == "Renk Seçiniz." || AGRenkCB.Text == "" ||
                AGYakıtturuCB.Text == "Yakıt Seçiniz." || AGYakıtturuCB.Text == "" ||
                AGVitesCB.Text == "Vites Seçiniz." || AGVitesCB.Text == "" ||
                AGMotornoTB.Text == "" ||
                AGSasinoTB.Text == "" ||
                AGtrafigecikisMB.Text == "  .  ." || AGtrafigecikisMB.Text.Length != 10 ||
                AsonkmTB.Text == "" ||
                ASKsigortaCB.Text == "Sigorta Seçiniz." || ASKsigortaCB.Text == "" ||
                ASKpolicenoTB.Text == "" ||
                ASKkaskonoTB.Text == "" ||
                ASKkaskobitisMB.Text == "  .  ." || ASKkaskobitisMB.Text.Length != 10 ||
                ASKmuayenebitisMB.Text == "  .  ." || ASKmuayenebitisMB.Text.Length != 10)
            {
                boslukkontrolu = false;
            }
            else
            {
                boslukkontrolu = true;
            }
        }

        void Averikontrol()
        {
            Acomboboxyenile();
            if (AGPlakaTB.Text != "")
            {
                if (hangiislem != "sil")
                {
                    Aislemmenusudegis();
                }
            }
            else
            {
                AGMenuP.Visible = false;
                Ayeni();
            }
            Ailksonkontrol();
        }
        void Asonkayit()
        {
            if (AracCB.Items.Count > 0)
            {
                AracCB.Text = AracCB.Items[AracCB.Items.Count - 1].ToString();
                AaraTB.Enabled = true;
                AaraIB.Enabled = true;
                Acontrolkilitle();
            }
            else
            {
                AaraTB.Enabled = false;
                AaraIB.Enabled = false;
                Acontrolkilitac();
            }
            Ailksonkontrol();
        }
        void Ailkkayit()
        {
            AracCB.Text = AracCB.Items[0].ToString();
            Ailksonkontrol();
        }
        void Aboslukkontrol()
        {
            if (AGSasinoTB.Text == "")
            {
                AGSasinoTB.Focus();
            }
            else if (AGMotornoTB.Text == "")
            {
                AGMotornoTB.Focus();
            }
            else if (AGtrafigecikisMB.Text.Length != 10)
            {
                AGtrafigecikisMB.Focus();
            }
            else if (AGMarkaCB.Text == "Marka Seçiniz." || AGMarkaCB.Text == "")
            {
                AGMarkaCB.Focus();
            }
            else if (AGTipCB.Text == "Tip Seçiniz." || AGTipCB.Text == "")
            {
                AGTipCB.Focus();
            }
            else if (AGRenkCB.Text == "Renk Seçiniz.")
            {
                AGRenkCB.Focus();
            }
            else if (AGYakıtturuCB.Text == "Yakıt Seçiniz.")
            {
                AGYakıtturuCB.Focus();
            }
            else if (AGModelCB.Text == "Model Seçiniz.")
            {
                AGModelCB.Focus();
            }
            else if (AGVitesCB.Text == "Vites Seçiniz.")
            {
                AGVitesCB.Focus();
            }
            else if (ASKsigortaCB.Text == "Sigorta Seçiniz." || ASKsigortaCB.Text == "")
            {
                ASKsigortaCB.Focus();
            }
            else if (ASKpolicenoTB.Text == "")
            {
                ASKpolicenoTB.Focus();
            }
            else if (ASKkaskonoTB.Text == "")
            {
                ASKkaskonoTB.Focus();
            }
            else if (ASKmuayenebitisMB.Text.Length != 10)
            {
                ASKmuayenebitisMB.Focus();
            }
            else if (ASKkaskobitisMB.Text.Length != 10)
            {
                ASKkaskobitisMB.Focus();
            }
            else if (AsonkmTB.Text == "")
            {
                AsonkmTB.Focus();
            }
        }
        void Agirilenkontrol()
        {
            if (trafigecikisi == "  .  .")
            {
                trafigecikisi = "";
            }
            if (kaskobitis == "  .  .")
            {
                kaskobitis = "";
            }
            if (muayenebitis == "  .  .")
            {
                muayenebitis = "";
            }
            if (AGMarkaCB.Text == "Marka Seçiniz.")
            {
                AGMarkaCB.Items.Add("");
                AGMarkaCB.Text = "";
            }
            if (AGTipCB.Text == "Tip Seçiniz.")
            {
                AGTipCB.Items.Add("");
                AGTipCB.Text = "";
            }
            if (AGModelCB.Text == "Model Seçiniz.")
            {
                model = "";
            }
            if (AGRenkCB.Text == "Renk Seçiniz.")
            {
                renk = "";
            }
            if (AGYakıtturuCB.Text == "Yakıt Seçiniz.")
            {
                yakıtturu = "";
            }
            if (AGVitesCB.Text == "Vites Seçiniz.")
            {
                vites = "";
            }
            if (ASKsigortaCB.Text == "Sigorta Seçiniz.")
            {
                ASKsigortaCB.Items.Add("");
                ASKsigortaCB.Text = "";
            }
        }

        void Agelenkontrol()
        {
            if (AGModelCB.Text == "")
            {
                AGModelCB.Text = AGModelCB.Items[0].ToString();
            }
            if (AGRenkCB.Text == "")
            {
                AGRenkCB.Text = AGRenkCB.Items[0].ToString();
            }
            if (AGYakıtturuCB.Text == "")
            {
                AGYakıtturuCB.Text = AGYakıtturuCB.Items[0].ToString();
            }
            if (AGVitesCB.Text == "")
            {
                AGVitesCB.Text = AGVitesCB.Items[0].ToString();
            }
        }
        void Ailksonkontrol()
        {
            GenelClass.ilksonkontrol(AracCB, AileriIB, AgeriIB);
        }
        void Aswitch1kontrol()
        {
            if (bunifuiOSSwitch1.Value == true)
            {
                arackiti = "1";
            }
            else
            {
                arackiti = "0";
            }
        }
        void Aswitch2kontrol()
        {
            if (bunifuiOSSwitch2.Value == true)
            {
                stepne = "1";
            }
            else
            {
                stepne = "0";
            }
        }
        void Aswitch3kontrol()
        {
            if (bunifuiOSSwitch3.Value == true)
            {
                ruhsat = "1";
            }
            else
            {
                ruhsat = "0";
            }
        }

        void Ayeni()
        {
            AracGenelP.Focus();
            while (AGMenuicP.Visible == true)
            {

            }
            AGMenuP.Visible = false;
            AGMenu2P.Show();
            APlakaL.Text = "YENİ ARAÇ";
            ALogoIB.Image = Image.FromFile(Application.StartupPath + "\\Dosyalar\\alfabe\\new.png");

            AgeriIB.Visible = false;
            AileriIB.Visible = false;

            guncelleeyadakaydett = "kaydet";

            Acontroltemizle();
            AracCB.Text = "";
            Acontrolkilitac();
            AaraTB.Enabled = false;

            YapıClass.markavericek(AGMarkaCB);
            AGMarkaCB.Text = AGMarkaCB.Items[0].ToString();
            YapıClass.tipvericek(AGMarkaCB.Text, AGTipCB);
            AGTipCB.Text = AGTipCB.Items[0].ToString();
            AGRenkCB.Text = AGRenkCB.Items[0].ToString();
            AGYakıtturuCB.Text = AGYakıtturuCB.Items[0].ToString();
            AGVitesCB.Text = AGVitesCB.Items[0].ToString();
            AGModelCB.Text = AGModelCB.Items[0].ToString();

            YapıClass.sigortasirketvericek(ASKsigortaCB);
            ASKsigortaCB.Text = ASKsigortaCB.Items[0].ToString();

            AGPlakaTB.Focus();
        }
        void Aguncelle()
        {
            plakano = AGPlakaTB.Text;

            AracGpaneli.Focus();
            while (AGMenuicP.Visible == true)
            {

            }
            AGMenuP.Visible = false;
            AGMenu2P.Show();

            AgeriIB.Visible = false;
            AileriIB.Visible = false;
            guncelleeyadakaydett = "guncelle";
            Acontrolkilitac();
            AGPlakaTB.Enabled = false;
            AaraTB.Enabled = false;
            AaraIB.Enabled = false;


            string aa = AGMarkaCB.Text;
            YapıClass.markavericek(AGMarkaCB);
            AGMarkaCB.Text = aa;
            aa = AGTipCB.Text;
            YapıClass.tipvericek(AGMarkaCB.Text, AGTipCB);
            AGTipCB.Text = aa;

            aa = ASKsigortaCB.Text;
            YapıClass.sigortasirketvericek(ASKsigortaCB);
            ASKsigortaCB.Text = aa;

        }

        void Aozetbilgilervericek()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                komut = new MySqlCommand("SELECT * FROM rentacar.kiralama where arcplaka=@arcplaka", baglanti);
                komut.Parameters.AddWithValue("@arcplaka", AGPlakaTB.Text);
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    kirasayısı++;
                    kralamaislemtrh = Convert.ToDateTime("" + oku["kralamaislemtrh"].ToString().Substring(0, 10));
                    if (hafıza < kralamaislemtrh)
                    {
                        hafıza = kralamaislemtrh;
                        tccno = "" + oku["mstrtcno"];
                        ASkiraTarihCL.Text = "" + oku["kralamaislemtrh"];
                        ASkiraParaCL.Text = "" + oku["kralamatplmttr"];
                        Sozlesmegecisi = oku["szlsmno"].ToString();
                    }
                }
                if (tccno != "")
                {
                    ASDetayTB.Visible = true;
                    AKGecmisiTB.Visible = true;
                    ASkiralamaCL.Text = tccno;
                    KAracSCL.Text = kirasayısı.ToString();
                    kirasayısı = 0;
                    tccno = "";
                }
                else
                {
                    ASDetayTB.Visible = false;
                    AKGecmisiTB.Visible = false;
                    tccno = "";
                    ASkiralamaCL.Text = "";
                    ASkiraTarihCL.Text = "";
                    ASkiraParaCL.Text = "";
                }
                baglanti.Close();
                hafıza = Convert.ToDateTime("01.01.0001");
            }

        }
        void Aracload()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                komut = new MySqlCommand("SELECT arcplaka FROM arcblglr", baglanti);
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    AracCB.Items.Add(oku["arcplaka"]);
                }
                baglanti.Close();
                YapıClass.Acomboboxautocomplete(AaraTB);
                Averikontrol();
            }
            klasor = Directory.Exists(Application.StartupPath + "\\ABelge\\");
            if (klasor == false)
            {
                Directory.CreateDirectory(Application.StartupPath + "\\ABelge\\");
            }
        }
        void Aislemmenusukapat()
        {
            if (AGMenuicP.Visible == true)
            {
                AGMenuIB.Enabled = false;
                RotateAnimator.HideSync(AGMenuIB);
                RotateAnimator.ShowSync(AGMenuIB);
                TransparentAnimator.HideSync(YeniAracIB);
                TransparentAnimator.HideSync(GuncelleAracIB);
                TransparentAnimator.HideSync(SilAracIB);
                AGMenuicP.Visible = false;
            }
            AGMenuIB.Enabled = true;
        }
        void Aislemmenusudegis()
        {
            if (AGMenuP.Visible == true)
            {
                AGMenu2P.Visible = true;
                AGMenuP.Visible = false;
            }
            else if (AGMenu2P.Visible == true)
            {
                AGMenuP.Visible = true;
                AGMenu2P.Visible = false;
            }
        }

        void Aracpanelarası()
        {
            if (Arackonum == "a")
            {
                if (AracGenelP.Visible == false)
                {
                    AracGenelP.Visible = true;
                    AracBelgeP.Visible = false;
                    AsahibiGenelP.Visible = false;
                }
                else
                {
                    AracGenelP.Visible = false;
                }
            }
            else if (Arackonum == "b")
            {
                if (AracBelgeP.Visible == false)
                {
                    AracBelgeP.Visible = true;
                }
                else
                {
                    AracBelgeP.Visible = false;
                }
            }
            else if (Arackonum == "d")
            {
                if (AsahibiGenelP.Visible == false)
                {
                    AsahibiGenelP.Visible = true;
                }
                else
                {
                    AsahibiGenelP.Enabled = false;
                }
            }
        }

        //---------------------------------------------------------------------- SOLMENÜ
        void Asolmenu()
        {
            baglanti.Open();
            komut = new MySqlCommand("SELECT count(arcplaka) FROM arcbelge WHERE arcplaka=@arcplaka", baglanti);
            komut.Parameters.AddWithValue("@arcplaka", APlakaL.Text);
            string gecici = komut.ExecuteScalar().ToString();
            if (gecici == "0")
            {
                ABelgeTB.ButtonText = "Belge Ekle";
                ABelgeSCL.Text = "";
            }
            else
            {
                ABelgeSCL.Text = gecici;
                ABelgeTB.ButtonText = "Detaylar";
            }

            komut = new MySqlCommand("SELECT * FROM mstrblglr WHERE mstrtcno=@mstrtcno", baglanti);
            komut.Parameters.AddWithValue("@mstrtcno", aracsahibitc);
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                ASahibiCL2.Text = oku["mstradi"] + " " + oku["mstrsoyadi"];
                AsahibiTB.ButtonText = "Detaylar";
            }
            else
            {
                AsahibiTB.ButtonText = "Araç Sahibi Ekle";
                ASahibiCL2.Text = "";
            }
            oku.Close();
            baglanti.Close();
            ASahibiCL.Text = aracsahibitc;
        }

        private void AsMenuPictureB_Click(object sender, EventArgs e)
        {
            AsMenuPictureB.Focus();
        }

        private void AracCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Avericek();
        }

        private void AaraTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AaraTB.MaxLength = 10;
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void AaraTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                YapıClass.Aara(AaraTB, AracGenel2P, AracCB);

            }
        }
        private void AaraTB_Enter(object sender, EventArgs e)
        {
            AAraMTB.BorderColorIdle = Color.FromArgb(26, 177, 136);
            if (AaraTB.Text == "Araç Ara")
            {
                AaraTB.Text = "";
                AaraTB.ForeColor = Color.White;
            }
        }
        private void AaraTB_Leave(object sender, EventArgs e)
        {
            AAraMTB.BorderColorIdle = Color.Gray;
            if (AaraTB.Text == "")
            {
                AaraTB.ForeColor = Color.Gray;
                AaraTB.Text = "Araç Ara";
            }
        }
        private void AaraIB_Click(object sender, EventArgs e)
        {
            YapıClass.Aara(AaraTB, AracGenel2P, AracCB);
        }

        private void APlakaL_TextChanged(object sender, EventArgs e)
        {
            belgeplaka = APlakaL.Text;
            UserControl5.plakaa = APlakaL.Text;
        }

        private void AgeriIB_Click(object sender, EventArgs e)
        {
            if (AgeriIB.Enabled == true)
            {
                AracCB.Text = AracCB.Items[AracCB.SelectedIndex - 1].ToString();
                Ailksonkontrol();
                if (Arackonum == "b")
                {
                    Abelgekontrol();
                    AracBelge2P.VerticalScroll.Value = AracBelge2P.VerticalScroll.Minimum;
                    AracBelge2P.AutoScroll = true;
                }
                else if (Arackonum == "d")
                {
                    Asahibikontrol();
                }
            }
        }
        private void AileriIB_Click(object sender, EventArgs e)
        {
            if (AileriIB.Enabled == true)
            {
                AracCB.Text = AracCB.Items[AracCB.SelectedIndex + 1].ToString();
                Ailksonkontrol();
                if (Arackonum == "b")
                {
                    Abelgekontrol();
                    AracBelge2P.VerticalScroll.Value = AracBelge2P.VerticalScroll.Minimum;
                    AracBelge2P.AutoScroll = true;
                }
                else if (Arackonum == "d")
                {
                    Asahibikontrol();
                }
            }
        }

        private void AGenelCL_Click(object sender, EventArgs e)
        {
            if (Arackonum != "a")
            {
                AracGenel2P.VerticalScroll.Value = AracGenel2P.VerticalScroll.Minimum;
                AracGenel2P.AutoScroll = true;
                Aracpanelarası();
                Arackonum = "a";
                Aracpanelarası();
                AracGenel2P.Focus();
            }
        }
        private void AKGecmisiTB_Click(object sender, EventArgs e)
        {
            if (Arackonum != "c")
            { panellerarası();
                if (kontrol == true)
                {
                    Arackonum = "c";
                    Ustmenukonum = "e";
                    panellerarası();
                    listekonum = "kira";
                    Listepanelarası();
                    ListedegiskenTB.Text = APlakaL.Text;
                    KLvericeksartli();
                }
            }
        }

        //---------------------------------------------------------------------- İÇMENÜ
        private void AracGenel2P_Click(object sender, EventArgs e)
        {
            AracGenel2P.Focus();
        }

        private void AGMenuIB_Click(object sender, EventArgs e)
        {
            AGMenuIB.Enabled = false;
            RotateAnimator.HideSync(AGMenuIB);
            RotateAnimator.ShowSync(AGMenuIB);
            AGMenuP.Focus();
            if (AGMenuicP.Visible == false)
            {
                AGMenuicP.Visible = true;
                this.TransparentAnimator.ShowSync(SilAracIB);
                this.TransparentAnimator.ShowSync(GuncelleAracIB);
                this.TransparentAnimator.ShowSync(YeniAracIB);
            }
            else
            {
                this.TransparentAnimator.HideSync(YeniAracIB);
                this.TransparentAnimator.HideSync(GuncelleAracIB);
                this.TransparentAnimator.HideSync(SilAracIB);
                AGMenuicP.Visible = false;
                AracGenel2P.Focus();
            }
            AGMenuIB.Enabled = true;
        }
        private void AGMenuP_Leave(object sender, EventArgs e)
        {
            Aislemmenusukapat();
        }
        private void YeniAraciIB_Click(object sender, EventArgs e)
        {
            Ayeni();
        }
        private void SilAracIB_Click(object sender, EventArgs e)
        {
            if (GenelClass.sil() == true)
            {
                YapıClass.Aracsil(APlakaL.Text);
                hangiislem = "sil";
                Acontroltemizle();
                Averikontrol();
                AracGenel2P.Focus();
                hangiislem = "";
                ABilgiCL.Text = "1 Kayıt Başarıyla Silindi!";
                ABilgiP.BackColor = Color.Maroon;
                this.TransparentAnimator.ShowSync(ABilgiP);
                ABilgiCL.Focus();
                timer3.Start();
            }
        }
        private void GuncelleAracIB_Click(object sender, EventArgs e)
        {
            Aguncelle();
        }
        private void AracKaydetIB_Click(object sender, EventArgs e)
        {
            try
            {
                klasor = Directory.Exists(Application.StartupPath + "\\ABelge\\" + APlakaL.Text + "\\");
                if (klasor == false)
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\ABelge\\" + APlakaL.Text + "\\");
                }
                Akayitt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AiptalIB_Click(object sender, EventArgs e)
        {
            AracGenel2P.Focus();

            string gecici = APlakaL.Text;
            Acontroltemizle();
            Averikontrol();
            AracCB.Text = gecici;

            guncelleeyadakaydett = "";
        }
        //---------------------------------------------------------------------- KİMLİK
        private void AGPlakaTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AGPlakaTB.MaxLength = 10;
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void AGPlaka2TB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AGPlakaTB.MaxLength = 4;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void AGMarkaCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            AGTipCB.Focus();
        }
        private void AGMarkaCB_Leave(object sender, EventArgs e)
        {
            if (AGMarkaCB.Text != tipmarka)
            {
                YapıClass.tipvericek(AGMarkaCB.Text, AGTipCB);
                AGTipCB.Text = AGTipCB.Items[0].ToString();
            }
        }
        private void AGMarkaCB_Enter(object sender, EventArgs e)
        {
            tipmarka = AGMarkaCB.Text;
        }
        private void AGSasinoTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AGSasinoTB.MaxLength = 10;
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void AGMotornoTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AGMotornoTB.MaxLength = 10;
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void AGtrafigecikisMB_Validating(object sender, CancelEventArgs e)
        {
            if (AGtrafigecikisMB.Text != "  .  .")
            {
                try
                {
                    DateTime a = Convert.ToDateTime(AGtrafigecikisMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Trafiğe Çıkış Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //---------------------------------------------------------------------- SİGORTA
        private void ASKpolicenoTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ASKpolicenoTB.MaxLength = 10;
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ASKkaskonoTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            ASKkaskonoTB.MaxLength = 10;
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ASKmuayenebitisMB_Validating(object sender, CancelEventArgs e)
        {
            if (ASKmuayenebitisMB.Text != "  .  .")
            {
                try
                {
                    DateTime a = Convert.ToDateTime(ASKmuayenebitisMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Muayene Bitiş Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ASKkaskobitisMB_Validating(object sender, CancelEventArgs e)
        {
            if (ASKkaskobitisMB.Text != "  .  .")
            {
                try
                {
                    DateTime a = Convert.ToDateTime(ASKkaskobitisMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Kasko Bitiş Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //---------------------------------------------------------------------- EK/YAKIT

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {

        }
        private void bunifuiOSSwitch2_OnValueChange(object sender, EventArgs e)
        {

        }
        private void bunifuiOSSwitch3_OnValueChange(object sender, EventArgs e)
        {

        }
        private void AsonkmTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AsonkmTB.MaxLength = 10;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /*-------------------------------------------------------------------------------- ARACBELGE*/

        //---------------------------------------------------------------------- ALTPROG.
        void Abelgekontrol()
        {
            if (Arackonum == "b")
            {
                dosyanınyeniklasoru = Application.StartupPath + "\\ABelge\\" + APlakaL.Text + "\\";
                klasor = Directory.Exists(Application.StartupPath + "\\ABelge\\" + APlakaL.Text + "\\");
                if (klasor == false)
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\ABelge\\" + APlakaL.Text + "\\");
                }
                ABvericekme();
                ABdosyaesitleme();
            }
        }
        void ABvericekme()
        {
            AracBelge2P.Controls.Clear();
            bosluk = 10;
            try
            {
                baglanti.Open();
                komut = new MySqlCommand("SELECT * FROM arcbelge WHERE arcplaka=@arcplaka", baglanti);
                komut.Parameters.AddWithValue("@arcplaka", APlakaL.Text);
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    kopyalanacakdosyaismi = "" + oku["belgeadi"];
                    DosyaUzantisi = "" + oku["uzanti"];
                    dosyauzantıkontrol();
                    AitemAdd(kopyalanacakdosyaismi, DosyaUzantisi, Image.FromFile(uzanti));
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void ABdosyaesitleme()
        {
            int i = 0;
            try
            {
                foreach (Control ad in AracBelge2P.Controls)
                {
                    if (ad is UserControl)
                    {
                        i++;
                        while (!File.Exists(dosyanınyeniklasoru + "" + ad.Name))
                        {
                            YapıClass.Belgesil("", ad.Name);
                            AracBelge2P.Controls.Clear();
                            ABvericekme();
                        }
                    }
                }
                if (i == 0)
                {
                    ABbilgiP.Visible = true;
                }
                else
                {
                    ABbilgiP.Visible = false;
                }
            }
            catch (Exception)
            {
                baglanti.Close();
            }
        }

        public void AitemAdd(string Text1, string Text2, Image Icon)
        {
            AracBelge2P.VerticalScroll.Value = 0;
            UserControl5 item = new Rentacar.UserControl5(Text1, Text2, Icon);
            AracBelge2P.Controls.Add(item);
            item.Name = Text1;
            item.Top = bosluk;
            bosluk = (item.Top + item.Height + 10);
            AracBelge2P.VerticalScroll.Value = AracBelge2P.VerticalScroll.Maximum;
            AracBelge2P.AutoScroll = true;
            AracBelge2P.Focus();
        }
        //---------------------------------------------------------------------- SOLMENÜ
        private void ABelgeTB_Click(object sender, EventArgs e)
        {
            if (Arackonum != "b")
            {
                if (guncelleeyadakaydett == "guncelle")
                {
                    if (GenelClass.islemiptal() == true)
                    {
                        guncelleeyadakaydett = "";
                        Abelgekontrol();
                        AracBelge2P.VerticalScroll.Value = AracBelge2P.VerticalScroll.Minimum;
                        AracBelge2P.AutoScroll = true;
                        Aracpanelarası();
                        Arackonum = "b";
                        Aracpanelarası();
                        AracBelge2P.Focus();
                    }
                }
                else if (guncelleeyadakaydett != "guncelle")
                {
                    guncelleeyadakaydett = "";
                    Abelgekontrol();
                    AracBelge2P.VerticalScroll.Value = AracBelge2P.VerticalScroll.Minimum;
                    AracBelge2P.AutoScroll = true;
                    Aracpanelarası();
                    Arackonum = "b";
                    Aracpanelarası();
                    AracBelge2P.Focus();
                }
            }
        }

        //---------------------------------------------------------------------- ORTAMENÜ
        private void AbelgekontrolL_TextChanged(object sender, EventArgs e)
        {
            if (AbelgekontrolL.Text == "delete")
            {
                AracBelge2P.Controls.Clear();
                ABvericekme();
                ABdosyaesitleme();
                Asolmenuyenile();
            }
        }

        //---------------------------------------------------------------------- İÇMENÜ
        private void ABelgeYeniIB_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = openFileDialog1;
            dosya.InitialDirectory = "D:\\";
            dosya.Title = "Belge Seç";
            dosya.FileName = "";
            if (dosya.ShowDialog() == DialogResult.OK)
            {
                kopyalanacakdosyaismi = dosya.SafeFileName.ToString();
                kopyalanacakdosya = dosya.FileName.ToString();
                System.IO.FileInfo ff = new System.IO.FileInfo(dosyanınyeniklasoru + kopyalanacakdosyaismi);
                DosyaUzantisi = ff.Extension;
                if (File.Exists(dosyanınyeniklasoru + "" + kopyalanacakdosyaismi))
                {
                    MessageBox.Show(kopyalanacakdosyaismi + " İsimli Bu Dosya Zaten Mevcut!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    File.Copy(kopyalanacakdosya, dosyanınyeniklasoru + "" + kopyalanacakdosyaismi);
                    baglanti.Open();
                    komut = new MySqlCommand("INSERT INTO arcbelge (belgeadi,arcplaka,uzanti) VALUES (@belgeadi,@arcplaka,@uzanti)", baglanti);
                    komut.Parameters.AddWithValue("@belgeadi", kopyalanacakdosyaismi);
                    komut.Parameters.AddWithValue("@arcplaka", belgeplaka);
                    komut.Parameters.AddWithValue("@uzanti", DosyaUzantisi);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    dosyauzantıkontrol();
                    AitemAdd(kopyalanacakdosyaismi, DosyaUzantisi, Image.FromFile(uzanti));
                    Asolmenuyenile();
                }
                ABbilgiP.Visible = false;
            }
        }
        private void AracBelge2P_Click(object sender, EventArgs e)
        {
            AracBelge2P.Focus();
        }

        /*-------------------------------------------------------------------------------- ARAÇSAHİBİ*/
        private void AsahibiGenelP_EnabledChanged(object sender, EventArgs e)
        {
            if (AsahibiGenelP.Enabled == false)
            {
                if (guncelleeyadakaydett != "guncelle")
                {
                    AsahibiGenelP.Visible = false;
                }
                else
                {
                    if (GenelClass.islemiptal() == true)
                    {
                        AsahibiGenelP.Visible = false;
                        AsGMenuP.Visible = true;
                        AsGMenu2P.Visible = false;
                    }
                }
                AsahibiGenelP.Enabled = true;
            }
        }
        //---------------------------------------------------------------------- ALTPROG.
        void Asvericek()
        {
            try
            {
                AsIulkeCB.Items.Clear();
                AsIilCB.Items.Clear();
                AsIilceCB.Items.Clear();
                AsEverlnilCB.Items.Clear();
                AsKKbankaCB.Items.Clear();

                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    komut = new MySqlCommand("SELECT DISTINCT * FROM(mstrblglr INNER JOIN mstrehlyt ON mstrblglr.mstrtcno = mstrehlyt.mstrtcno) INNER JOIN kredikart ON mstrblglr.mstrtcno = kredikart.mstrtcno WHERE mstrblglr.mstrtcno = @mstrtcno", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", aracsahibitc);
                    MySqlDataReader oku = komut.ExecuteReader();
                    if (oku.Read())
                    {
                        AsGtcnoTB.Text = aracsahibitc;
                        AsGadiTB.Text = "" + oku["mstradi"];
                        AsGsoyadiTB.Text = "" + oku["mstrsoyadi"];

                        AsGdgmyeriTB.Text = "" + oku["mstrdgmyeri"];
                        AsGserinoTB.Text = "" + oku["mstrsrino"];
                        AsGanneadiTB.Text = "" + oku["mstranneadi"];
                        AsGbabaadiTB.Text = "" + oku["mstrbabaadi"];
                        AsIepostaTB.Text = "" + oku["mstreposta"];
                        AsIadresTB.Text = "" + oku["mstradres"];

                        AsGdgmtarihiMB.Text = "" + oku["mstrdgmtrhi"];
                        AsEgcrllktrhiMB.Text = "" + oku["ehlytgcrllktarh"];
                        AsEsicilnoMB.Text = "" + oku["ehlytsclno"];
                        AsIceptelMB.Text = "" + oku["mstrceptelno"];
                        AsIistelMB.Text = "" + oku["mstristelno"];
                        AsKKnoMB.Text = "" + oku["kartno"];
                        AsKKCvvMB.Text = "" + oku["cvv"];
                        AsKKsktMB.Text = "" + oku["skt"];
                        AsEvrlstrhiMB.Text = "" + oku["ehlytvrlstarh"];

                        string bankaa = "" + oku["banka"];
                        AsIilCB.Items.Add("" + oku["mstril"]);
                        AsIilceCB.Items.Add("" + oku["mstrilce"]);
                        AsEverlnilCB.Items.Add("" + oku["ehlytvrlnil"]);
                        AsIulkeCB.Items.Add("" + oku["mstrulke"]);

                        AsKKodmesstmiCB.Text = "" + oku["osistemi"];
                        AsEsinifiCB.Text = "" + oku["ehlytsnf"];

                        baglanti.Close();

                        AsIilCB.Text = AsIilCB.Items[0].ToString();
                        AsIilceCB.Text = AsIilceCB.Items[0].ToString();
                        AsEverlnilCB.Text = AsEverlnilCB.Items[0].ToString();
                        AsIulkeCB.Text = AsIulkeCB.Items[0].ToString();

                        if (bankaa == "")
                        {
                            YapıClass.bankavericek(AsKKbankaCB);
                            AsKKbankaCB.Text = AsKKbankaCB.Items[0].ToString();
                        }
                        else
                        {
                            AsKKbankaCB.Items.Add(bankaa);
                            AsKKbankaCB.Text = AsKKbankaCB.Items[0].ToString();
                        }
                        Asgelenkontrol();
                    }
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void Askayitt()
        {
            int icislem = 0;
            if (AsGtcnoTB.Text == "" && AsGtcnoTB.Text.Length != 11)
            {
                MessageBox.Show("Lütfen T.C Kimlik No Alanını 11 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AsGtcnoTB.Focus();
            }
            else if (AsGadiTB.Text == "")
            {
                MessageBox.Show("Lütfen Adı Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AsGadiTB.Focus();
            }
            else if (AsGsoyadiTB.Text == "")
            {
                MessageBox.Show("Lütfen Soyadı Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                AsGsoyadiTB.Focus();
            }
            else
            {
                if (MorKCB.Items.IndexOf(AsGtcnoTB.Text) != -1)
                {
                    guncelleeyadakaydett = "guncelle";
                }
                Asboslukkontrolbool();
                if (boslukkontrolu == true)
                {
                    icislem = 1;
                }
                else
                {
                    DialogResult c = MessageBox.Show("Boş Alanlar Mevcut!\nYine'de Kaydedilsin Mi?", "KAYIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (c == DialogResult.Yes)
                    {
                        icislem = 1;
                    }
                    else
                    {
                        Asboslukkontrol();
                    }
                }
                if (icislem == 1)
                {
                    if (guncelleeyadakaydett == "kaydet")
                    {
                        Askaydett();
                    }
                    if (guncelleeyadakaydett == "guncelle")
                    {
                        Asguncelleekaydet();
                    }
                }
            }
            guncelleeyadakaydett = "";
        }
        void Asguncelleekaydet()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    Asgirilen();
                    Asgirilenkontrol();
                    baglanti.Open();
                    komut = new MySqlCommand("UPDATE mstrblglr SET mstradi=@mstradi, mstrsoyadi=@mstrsoyadi, mstrdgmtrhi=@mstrdgmtrhi, mstrdgmyeri=@mstrdgmyeri, mstrceptelno=@mstrceptelno, mstristelno=@mstristelno, mstreposta=@mstreposta, mstril=@mstril, mstrilce=@mstrilce, mstrulke=@mstrulke, mstradres=@mstradres, mstranneadi=@mstranneadi, mstrbabaadi=@mstrbabaadi , mstrsrino=@mstrsrino WHERE mstrtcno=@mstrtcno", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", AsGtcnoTB.Text);
                    komut.Parameters.AddWithValue("@mstradi", AsGadiTB.Text);
                    komut.Parameters.AddWithValue("@mstrsoyadi", AsGsoyadiTB.Text);
                    komut.Parameters.AddWithValue("@mstrdgmtrhi", dogumtarihi);
                    komut.Parameters.AddWithValue("@mstrdgmyeri", AsGdgmyeriTB.Text);
                    komut.Parameters.AddWithValue("@mstrceptelno", ceptelefon);
                    komut.Parameters.AddWithValue("@mstristelno", istelefon);
                    komut.Parameters.AddWithValue("@mstreposta", AsIepostaTB.Text);
                    komut.Parameters.AddWithValue("@mstril", AsIilCB.Text);
                    komut.Parameters.AddWithValue("@mstrilce", AsIilceCB.Text);
                    komut.Parameters.AddWithValue("@mstrulke", AsIulkeCB.Text);
                    komut.Parameters.AddWithValue("@mstradres", AsIadresTB.Text);
                    komut.Parameters.AddWithValue("@mstranneadi", AsGanneadiTB.Text);
                    komut.Parameters.AddWithValue("@mstrbabaadi", AsGbabaadiTB.Text);
                    komut.Parameters.AddWithValue("@mstrsrino", AsGserinoTB.Text);
                    komut.ExecuteNonQuery();
                    komut = new MySqlCommand("UPDATE mstrehlyt SET ehlytvrlnil=@ehlytvrlnil, ehlytvrlstarh=@ehlytvrlstarh, ehlytgcrllktarh=@ehlytgcrllktarh, ehlytsclno=@ehlytsclno, ehlytsnf=@ehlytsnf WHERE mstrtcno=@mstrtcno", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", AsGtcnoTB.Text);
                    komut.Parameters.AddWithValue("@ehlytvrlnil", AsEverlnilCB.Text);
                    komut.Parameters.AddWithValue("@ehlytvrlstarh", verilistarihi);
                    komut.Parameters.AddWithValue("@ehlytgcrllktarh", gecerliliktarihi);
                    komut.Parameters.AddWithValue("@ehlytsclno", AsEsicilnoMB.Text);
                    komut.Parameters.AddWithValue("@ehlytsnf", Esinif);
                    komut.ExecuteNonQuery();
                    komut = new MySqlCommand("UPDATE kredikart SET kartno=@kartno, banka=@banka, cvv=@cvv, skt=@skt, osistemi=@osistemi WHERE mstrtcno=@mstrtcno", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", AsGtcnoTB.Text);
                    komut.Parameters.AddWithValue("@kartno", kartno);
                    komut.Parameters.AddWithValue("@banka", AsKKbankaCB.Text);
                    komut.Parameters.AddWithValue("@cvv", AsKKCvvMB.Text);
                    komut.Parameters.AddWithValue("@skt", skt);
                    komut.Parameters.AddWithValue("@osistemi", odemesistemi);
                    komut.ExecuteNonQuery();

                    komut = new MySqlCommand("UPDATE arcblglr SET arcplaka=@arcplaka, arcsahibitcno=@arcsahibitcno WHERE arcplaka=@arcplaka", baglanti);
                    komut.Parameters.AddWithValue("@arcplaka", APlakaL.Text);
                    komut.Parameters.AddWithValue("@arcsahibitcno", AsGtcnoTB.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    Asverikontrol();

                    ABilgiP.BackColor = Color.Green;
                    ABilgiCL.Text = "Güncelleme İşlemi Başarıyla Tamamlandı!";
                    TransparentAnimator.ShowSync(ABilgiP);
                    ABilgiCL.Focus();
                    timer3.Start();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void Askaydett()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    Asgirilen();
                    Asgirilenkontrol();
                    baglanti.Open();
                    komut = new MySqlCommand("INSERT INTO mstrblglr (mstrtcno,mstradi,mstrsoyadi,mstrdgmtrhi,mstrdgmyeri,mstrceptelno,mstristelno,mstreposta,mstril,mstrilce,mstrulke,mstradres,mstranneadi,mstrbabaadi,mstrsrino,MorK) VALUES (@mstrtcno,@mstradi,@mstrsoyadi,@mstrdgmtrhi,@mstrdgmyeri,@mstrceptelno,@mstristelno,@mstreposta,@mstril,@mstrilce,@mstrulke,@mstradres,@mstranneadi,@mstrbabaadi,@mstrsrino,@MorK)", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", AsGtcnoTB.Text);
                    komut.Parameters.AddWithValue("@mstradi", AsGadiTB.Text);
                    komut.Parameters.AddWithValue("@mstrsoyadi", AsGsoyadiTB.Text);
                    komut.Parameters.AddWithValue("@mstrdgmtrhi", dogumtarihi);
                    komut.Parameters.AddWithValue("@mstrdgmyeri", AsGdgmyeriTB.Text);
                    komut.Parameters.AddWithValue("@mstrceptelno", ceptelefon);
                    komut.Parameters.AddWithValue("@mstristelno", istelefon);
                    komut.Parameters.AddWithValue("@mstreposta", AsIepostaTB.Text);
                    komut.Parameters.AddWithValue("@mstril", AsIilCB.Text);
                    komut.Parameters.AddWithValue("@mstrilce", AsIilceCB.Text);
                    komut.Parameters.AddWithValue("@mstrulke", AsIulkeCB.Text);
                    komut.Parameters.AddWithValue("@mstradres", AsIadresTB.Text);
                    komut.Parameters.AddWithValue("@mstranneadi", AsGanneadiTB.Text);
                    komut.Parameters.AddWithValue("@mstrbabaadi", AsGbabaadiTB.Text);
                    komut.Parameters.AddWithValue("@mstrsrino", AsGserinoTB.Text);

                    komut.Parameters.AddWithValue("@MorK", kayitbilgisi);

                    komut.ExecuteNonQuery();
                    komut = new MySqlCommand("INSERT INTO mstrehlyt (mstrtcno,ehlytvrlnil,ehlytvrlstarh,ehlytgcrllktarh,ehlytsclno,ehlytsnf) VALUES (@mstrtcno,@ehlytvrlnil,@ehlytvrlstarh,@ehlytgcrllktarh,@ehlytsclno,@ehlytsnf)", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", AsGtcnoTB.Text);
                    komut.Parameters.AddWithValue("@ehlytvrlnil", AsEverlnilCB.Text);
                    komut.Parameters.AddWithValue("@ehlytvrlstarh", verilistarihi);
                    komut.Parameters.AddWithValue("@ehlytgcrllktarh", gecerliliktarihi);
                    komut.Parameters.AddWithValue("@ehlytsclno", AsEsicilnoMB.Text);
                    komut.Parameters.AddWithValue("@ehlytsnf", Esinif);
                    komut.ExecuteNonQuery();
                    komut = new MySqlCommand("INSERT INTO kredikart (mstrtcno,kartno,banka,cvv,skt,osistemi) VALUES (@mstrtcno,@kartno,@banka,@cvv,@skt,@osistemi)", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", AsGtcnoTB.Text);
                    komut.Parameters.AddWithValue("@kartno", kartno);
                    komut.Parameters.AddWithValue("@banka", AsKKbankaCB.Text);
                    komut.Parameters.AddWithValue("@cvv", AsKKCvvMB.Text);
                    komut.Parameters.AddWithValue("@skt", skt);
                    komut.Parameters.AddWithValue("@osistemi", odemesistemi);
                    komut.ExecuteNonQuery();

                    komut = new MySqlCommand("UPDATE arcblglr SET arcplaka=@arcplaka, arcsahibitcno=@arcsahibitcno WHERE arcplaka=@arcplaka", baglanti);
                    komut.Parameters.AddWithValue("@arcplaka", APlakaL.Text);
                    komut.Parameters.AddWithValue("@arcsahibitcno", AsGtcnoTB.Text);
                    komut.ExecuteNonQuery();

                    baglanti.Close();
                    aracsahibitc = AsGtcnoTB.Text;

                    Asolmenuyenile();
                    Asverikontrol();
                    ABilgiP.BackColor = Color.Green;
                    ABilgiCL.Text = "Kayıt İşlemi Başarıyla Tamamlandı!";
                    TransparentAnimator.ShowSync(ABilgiP);
                    ABilgiCL.Focus();
                    timer3.Start();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }

        void Ascontrolkilitle()
        {
            GenelClass.ControlKilit(AsahibiGenel2P, "false");
        }
        void Ascontrolkilitac()
        {
            GenelClass.ControlKilit(AsahibiGenel2P, "true");
        }
        void Ascontroltemizle()
        {
            GenelClass.ControlKilit(AsahibiGenel2P, "clear");

            AsIulkeCB.Items.Clear();
            AsIilCB.Items.Clear();
            AsIilceCB.Items.Clear();
            AsIadresTB.Clear();

            AsKKbankaCB.Items.Clear();
            AsKKodmesstmiCB.Text = AsKKodmesstmiCB.Items[0].ToString();

            AsEsicilnoMB.Clear();
            AsEvrlstrhiMB.Clear();
            AsEgcrllktrhiMB.Clear();
            AsEverlnilCB.Text = "";
            AsEverlnilCB.Items.Clear();
            AsEsinifiCB.Text = AsEsinifiCB.Items[0].ToString();
        }

        void Asyeni()
        {
            AsGPaneli.Focus();
            while (AsGMenuicP.Visible == true)
            {

            }
            AsGMenuP.Visible = false;
            AsGMenu2P.Show();

            guncelleeyadakaydett = "kaydet";
            Ascontroltemizle();
            Ascontrolkilitac();

            YapıClass.ulkevericek(AsIulkeCB);
            AsIulkeCB.Text = AsIulkeCB.Items[189].ToString();
            if (AsIulkeCB.Text == "Türkiye")
            {
                AsIilCB.Items.Clear();
                AsIilCB.Items.Clear();
                AsEverlnilCB.Items.Clear();
                YapıClass.ilvericek(AsIilCB, AsEverlnilCB);
                AsIilCB.Text = AsIilCB.Items[0].ToString();
                YapıClass.ilkontrolluilce(AsIilCB.Text, AsIilCB);
                AsIilCB.Text = AsIilCB.Items[0].ToString();
                AsEverlnilCB.Text = AsEverlnilCB.Items[0].ToString();
            }
            YapıClass.bankavericek(AsKKbankaCB);
            AsKKbankaCB.Text = AsKKbankaCB.Items[0].ToString();
            AsGtcnoTB.Focus();
        }
        void Asguncelle()
        {
            plaka = AsGtcnoTB.Text;
            AsGPaneli.Focus();
            while (AsGMenuicP.Visible == true)
            {

            }
            AsGMenuP.Visible = false;
            AsGMenu2P.Show();

            guncelleeyadakaydett = "guncelle";
            Ascontrolkilitac();
            AsGtcnoTB.Enabled = false;

            string bnka = AsKKbankaCB.Text;
            AsKKbankaCB.Items.Clear();
            YapıClass.bankavericek(AsKKbankaCB);
            AsKKbankaCB.Text = bnka;

            string c = AsIulkeCB.Text;
            string a = AsIilCB.Text;
            string d = AsIilceCB.Text;
            string b = AsEverlnilCB.Text;

            YapıClass.ulkevericek(AsIulkeCB);
            AsIulkeCB.Text = c;
            if (AsIulkeCB.Text == "Türkiye")
            {
                AsIilCB.Items.Clear();
                AsIilceCB.Items.Clear();
                AsEverlnilCB.Items.Clear();
                YapıClass.ilvericek(AsIilCB, AsEverlnilCB);
                AsIilCB.Text = a;
                AsEverlnilCB.Text = b;
                YapıClass.ilkontrolluilce(AsIilCB.Text, AsIilceCB);
                AsIilceCB.Text = d;
            }
        }

        void Asgirilen()
        {
            dogumtarihi = AsGdgmtarihiMB.Text;
            ceptelefon = AsIceptelMB.Text;
            istelefon = AsIistelMB.Text;
            verilistarihi = AsEvrlstrhiMB.Text;
            gecerliliktarihi = AsEgcrllktrhiMB.Text;
            kartno = AsKKnoMB.Text;
            skt = AsKKsktMB.Text;
            odemesistemi = AsKKodmesstmiCB.Text;
            Esinif = AsEsinifiCB.Text;
        }
        void Asverikontrol()
        {
            if (aracsahibitc != "")
            {
                Ascontrolkilitle();
                if (hangiislem != "sil" && AsGMenuP.Visible == false)
                {
                    Asahibiislemmenusudegis();
                }

            }
            else
            {
                AsGMenuP.Visible = false;
                Asyeni();
            }
        }
        void Asboslukkontrol()
        {
            if (AsGserinoTB.Text == "")
            {
                AsGserinoTB.Focus();
            }
            else if (AsGdgmtarihiMB.Text.Length != 10)
            {
                AsGdgmtarihiMB.Focus();
            }
            else if (AsGdgmyeriTB.Text == "")
            {
                AsGdgmyeriTB.Focus();
            }
            else if (AsGanneadiTB.Text == "")
            {
                AsGanneadiTB.Focus();
            }
            else if (AsGbabaadiTB.Text == "")
            {
                AsGbabaadiTB.Focus();
            }
            else if (AsIceptelMB.Text == "(   )    -")
            {
                AsIceptelMB.Focus();
            }
            else if (AsIistelMB.Text == "(   )    -")
            {
                AsIistelMB.Focus();
            }
            else if (AsIepostaTB.Text == "")
            {
                AsIepostaTB.Focus();
            }
            else if (AsIulkeCB.Text == "Ülke Seçiniz." || AsIulkeCB.Text == "")
            {
                AsIulkeCB.Focus();
            }
            else if (AsIilCB.Text == "Şehir Seçiniz." || AsIilCB.Text == "")
            {
                AsIulkeCB.Focus();
            }
            else if (AsIilceCB.Text == "İlçe Seçiniz." || AsIilceCB.Text == "")
            {
                AsIilceCB.Focus();
            }
            else if (AsIadresTB.Text == "")
            {
                AsIadresTB.Focus();
            }
            else if (AsKKnoMB.Text == "    -    -    -")
            {
                AsKKnoMB.Focus();
            }
            else if (AsKKCvvMB.Text == "")
            {
                AsKKCvvMB.Focus();
            }
            else if (AsKKsktMB.Text == "  -")
            {
                AsKKsktMB.Focus();
            }
            else if (AsKKbankaCB.Text == "Banka Seçiniz." || AsKKbankaCB.Text == "")
            {
                AsKKbankaCB.Focus();
            }
            else if (AsKKodmesstmiCB.Text == "Ödeme Sistemi Seçiniz." || AsKKodmesstmiCB.Text == "")
            {
                AsKKodmesstmiCB.Focus();
            }
            else if (AsEsicilnoMB.Text == "")
            {
                AsEsicilnoMB.Focus();
            }
            else if (AsEvrlstrhiMB.Text.Length != 10)
            {
                AsEvrlstrhiMB.Focus();
            }
            else if (AsEgcrllktrhiMB.Text.Length != 10)
            {
                AsEgcrllktrhiMB.Focus();
            }
            else if (AsEverlnilCB.Text == "Şehir Seçiniz." || AsEverlnilCB.Text == "")
            {
                AsEverlnilCB.Focus();
            }
            else if (AsEsinifiCB.Text == "Ehliyet Sınıfı Seçiniz." || AsEsinifiCB.Text == "")
            {
                AsEsinifiCB.Focus();
            }
        }
        void Asgirilenkontrol()
        {
            if (dogumtarihi == "  .  .")
            {
                dogumtarihi = "";
            }
            if (ceptelefon == "(   )    -")
            {
                ceptelefon = "";
            }
            if (istelefon == "(   )    -")
            {
                istelefon = "";
            }
            if (AsIilCB.Text == "Şehir Seçiniz.")
            {
                AsIilCB.Items.Add("");
                AsIilCB.Text = "";
            }
            if (AsIilceCB.Text == "İlçe Seçiniz.")
            {
                AsIilceCB.Items.Add("");
                AsIilceCB.Text = "";
            }
            if (AsEverlnilCB.Text == "Şehir Seçiniz.")
            {
                AsEverlnilCB.Items.Add("");
                AsEverlnilCB.Text = "";
            }
            if (verilistarihi == "  .  .")
            {
                verilistarihi = "";
            }
            if (gecerliliktarihi == "  .  .")
            {
                gecerliliktarihi = "";
            }
            if (AsKKbankaCB.Text == "Banka Seçiniz.")
            {
                AsKKbankaCB.Items.Add("");
                AsKKbankaCB.Text = "";
            }
            if (kartno == "    -    -    -")
            {
                kartno = "";
            }
            if (skt == "  -")
            {
                skt = "";
            }
            if (AsKKodmesstmiCB.Text == "Ödeme Sistemi Seçiniz.")
            {
                odemesistemi = "";
            }
            if (AsEsinifiCB.Text == "Ehliyet Sınıfı Seçiniz.")
            {
                Esinif = "";
            }
        }
        void Asgelenkontrol()
        {
            if (AsKKodmesstmiCB.Text == "")
            {
                AsKKodmesstmiCB.Text = AsKKodmesstmiCB.Items[0].ToString();
            }
            if (AsEsinifiCB.Text == "")
            {
                AsEsinifiCB.Text = AsEsinifiCB.Items[0].ToString();
            }
        }

        void Asboslukkontrolbool()
        {
            if (
                AsGdgmtarihiMB.Text == "  .  ." || AsGdgmtarihiMB.Text.Length != 10 ||
                AsGdgmyeriTB.Text == "" ||
                AsIceptelMB.Text.Length != 14 || AsIceptelMB.Text == "(   )    -" ||
                AsIistelMB.Text.Length != 14 || AsIistelMB.Text == "(   )    -" ||
                AsIulkeCB.Text == "Ülke Seçiniz." || AsIulkeCB.Text == "" ||
                AsIilCB.Text == "Şehir Seçiniz." || AsIilCB.Text == "" ||
                AsIilceCB.Text == "İlçe Seçiniz." || AsIilceCB.Text == "" ||
                AsEverlnilCB.Text == "Şehir Seçiniz." || AsEverlnilCB.Text == "" ||
                AsIadresTB.Text == "" ||
                AsEvrlstrhiMB.Text.Length != 10 ||
                AsEgcrllktrhiMB.Text.Length != 10 ||
                AsEsicilnoMB.Text.Length != 6 ||
                AsIepostaTB.Text == "" ||
                AsKKbankaCB.Text == "Banka Seçiniz." || AsKKbankaCB.Text == "" ||
                AsKKnoMB.Text == "    -    -    - " || AsKKnoMB.Text.Length != 19 ||
                AsKKCvvMB.Text == "" || AsKKCvvMB.Text.Length != 3 ||
                AsKKsktMB.Text == "  -" || AsKKsktMB.Text.Length != 5
                )
            {
                boslukkontrolu = false;
            }
            else
            {
                boslukkontrolu = true;
            }
        }

        void Asahibiislemmenusukapat()
        {
            if (AsGMenuicP.Visible == true)
            {
                AsGMenuIB.Enabled = false;
                RotateAnimator.HideSync(AsGMenuIB);
                RotateAnimator.ShowSync(AsGMenuIB);
                TransparentAnimator.HideSync(GuncelleAsahibiIB);
                TransparentAnimator.HideSync(SilAsahibiIB);
                AsGMenuicP.Visible = false;
            }
            AsGMenuIB.Enabled = true;
        }
        void Asahibikontrol()
        {
            if (Arackonum == "d")
            {
                if (aracsahibitc != "")
                {
                    Asvericek();
                    Asverikontrol();
                }
                else
                {
                    Asyeni();
                }
            }
        }
        void Asahibiislemmenusudegis()
        {
            if (AsGMenuP.Visible == true)
            {
                AsGMenu2P.Visible = true;
                AsGMenuP.Visible = false;
            }
            else if (AsGMenu2P.Visible == true)
            {
                AsGMenuP.Visible = true;
                AsGMenu2P.Visible = false;
            }
        }
        void Asolmenuyenile()
        {
            string gecici = APlakaL.Text;
            hangiislem = "sil";
            Averikontrol();
            AracCB.Text = gecici;
            hangiislem = "";
        }

        //---------------------------------------------------------------------- SOLMENÜ
        private void AsahibiTB_Click(object sender, EventArgs e)
        {
            if (Arackonum != "d")
            {
                Aracpanelarası();
                Arackonum = "d";
                Aracpanelarası();
                AsahibiGenel2P.Focus();
                Asahibikontrol();
                /*      if (kiraguncellekefil != "")
                      {
                          maskedTextBox1.Text = kiraguncellekefil;
                          sozlesmekefil();
                      }
                      else
                      {
                          maskedTextBox1.Text = MMtcnoL.Text;
                      }*/
            }
        }
        //---------------------------------------------------------------------- İÇMENÜ
        private void AsahibiGenelP_Click(object sender, EventArgs e)
        {
            AsahibiGenel2P.Focus();
        }

        private void AsGMenuIB_Click(object sender, EventArgs e)
        {
            AsGMenuIB.Enabled = false;
            RotateAnimator.HideSync(AsGMenuIB);
            RotateAnimator.ShowSync(AsGMenuIB);
            AsGMenuP.Focus();
            if (AsGMenuicP.Visible == false)
            {
                AsGMenuicP.Visible = true;
                this.TransparentAnimator.ShowSync(SilAsahibiIB);
                this.TransparentAnimator.ShowSync(GuncelleAsahibiIB);
            }
            else
            {
                this.TransparentAnimator.HideSync(GuncelleAsahibiIB);
                this.TransparentAnimator.HideSync(SilAsahibiIB);
                AsGMenuicP.Visible = false;
                AsahibiGenel2P.Focus();
            }
            AsGMenuIB.Enabled = true;
        }
        private void AsGMenuP_Leave(object sender, EventArgs e)
        {
            Asahibiislemmenusukapat();
        }
        private void SilAsahibiIB_Click(object sender, EventArgs e)
        {
            if (GenelClass.sil() == true)
            {
                baglanti.Open();
                komut = new MySqlCommand("UPDATE arcblglr SET arcplaka=@arcplaka, arcsahibitcno=@arcsahibitcno WHERE arcplaka=@arcplaka", baglanti);
                komut.Parameters.AddWithValue("@arcplaka", APlakaL.Text);
                komut.Parameters.AddWithValue("@arcsahibitcno", "");
                komut.ExecuteNonQuery();
                baglanti.Close();
                Musterikefiltc = "";
                hangiislem = "sil";

                ABilgiCL.Text = "1 Kayıt Başarıyla Silindi!";
                ABilgiP.BackColor = Color.Maroon;
                this.TransparentAnimator.ShowSync(ABilgiP);
                ABilgiCL.Focus();
                timer3.Start();
                Ascontroltemizle();
                Asverikontrol();
                AsahibiGenel2P.Focus();
                hangiislem = "";
            }
        }
        private void GuncelleAsahibiIB_Click(object sender, EventArgs e)
        {
            Asguncelle();
        }
        private void AskaydetIB_Click(object sender, EventArgs e)
        {
            try
            {
                klasor = Directory.Exists(Application.StartupPath + "\\MBelge\\" + AsGtcnoTB.Text + "\\");
                if (klasor == false)
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\MBelge\\" + AsGtcnoTB.Text + "\\");
                }
                Askayitt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AsIptalIB_Click(object sender, EventArgs e)
        {
            if (aracsahibitc != "")
            {
                AsahibiGenel2P.Focus();
                Ascontroltemizle();
                Asvericek();
                Asverikontrol();
            }
            else
            {
                Asyeni();
            }
            guncelleeyadakaydett = "";
        }

        //------------------------------------------------------------ KİMLİK
        private void AsGtcnoTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AsGtcnoTB.MaxLength = 11;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void AsGtcnoTB_KeyUp(object sender, KeyEventArgs e)
        {
            if (AsGtcnoTB.Text.Length < 11)
            {
                verioneri = true;
                verioneri2 = true;
            }
            if (AsGtcnoTB.Text.Length == 11 && verioneri2 == true)
            {
                AsGserinoTB.Focus();
                verioneri2 = false;
            }
        }
        private void AsGtcnoTB_Validating(object sender, CancelEventArgs e)
        {
            if (AsGtcnoTB.Text.Length == 11)
            {
                GenelClass.Tckontrolet(AsGtcnoTB.Text);
                if (GenelClass.Tckontrolet(AsGtcnoTB.Text) == false)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir T.C Kimlik No Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (verioneri == true)
                    {
                        if (MorKCB.Items.IndexOf(AsGtcnoTB.Text) != -1)//DÜZENLENECEK BÖLÜM
                        {
                            aracsahibitc = AsGtcnoTB.Text;
                            Ascontroltemizle();
                            Asvericek();
                        }
                        else
                        {
                            //buraya araç sahibinin comboboxını yapınca geleceğiz bu elsenin ifindeki gibi yani
                            /* if (comboBox4.Items.IndexOf(MkGtcnoTB.Text) != -1)
                             {
                                 DialogResult c = MessageBox.Show("Girdiğiniz T.C Kimlik No Sistem'de Araç Sahibi Olarak Mevcuttur.\nBilgileri Alınsın Mı?", "MEVCUT KİŞİ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                 if (c == DialogResult.Yes)
                                 {
                                     Musterikefiltc = MkGtcnoTB.Text;
                                     Mkcontroltemizle();
                                     Mkvericekme();
                                 }
                             }
                             */
                        }
                    }
                }

            }
            else if (AsGtcnoTB.Text.Length == 0)
            {

            }
            else
            {
                MessageBox.Show("Lütfen T.C Kimlik No Alanını 11 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AsGserinoTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AsGserinoTB.MaxLength = 9;
        }

        private void AsGadiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AsGadiTB.MaxLength = 10;
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void AsGsoyadiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AsGsoyadiTB.MaxLength = 10;
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void AsGdgmtarihiMB_Validating(object sender, CancelEventArgs e)
        {
            if (AsGdgmtarihiMB.Text != "  .  .")
            {
                try
                {
                    DateTime a = Convert.ToDateTime(AsGdgmtarihiMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Doğum Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AsGdgmyeriTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AsGdgmyeriTB.MaxLength = 15;
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void AsGanneadiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AsGanneadiTB.MaxLength = 10;
        }

        private void AsGbabaadiTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AsGbabaadiTB.MaxLength = 10;
        }

        //------------------------------------------------------------ İLETİŞİM
        private void AsIceptelMB_Validating(object sender, CancelEventArgs e)
        {
            if (AsIceptelMB.Text != "(   )    -")
            {
                if (AsIceptelMB.Text.Length != 14)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir Cep Telefon Numarası Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (AsIceptelMB.Text.Substring(1, 1) == "0")
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir Cep Telefon Numarası Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AsIistelMB_Validating(object sender, CancelEventArgs e)
        {
            if (AsIistelMB.Text != "(   )    -")
            {
                if (AsIistelMB.Text.Length != 14)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir İş Telefon Numarası Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (AsIistelMB.Text.Substring(1, 1) == "0")
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir Cep Telefon Numarası Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AsIepostaTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AsIepostaTB.MaxLength = 50;
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }
        private void AsIepostaTB_Validating(object sender, CancelEventArgs e)
        {
            if (AsIepostaTB.Text != "")
            {
                if (!new Regex(GenelClass.Regex).IsMatch(AsIepostaTB.Text))
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir E-mail Adresi Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AsIadresTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            AsIadresTB.MaxLength = 100;
        }

        private void AsIulkeCB_Leave(object sender, EventArgs e)
        {

        }
        private void AsIulkeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AsIulkeCB.Text == "Türkiye")
            {
                if (AsIilCB.Text == "Şehir Seçiniz." || AsIilCB.Text == "")
                {
                    AsIilCB.Items.Clear();
                    AsIilceCB.Items.Clear();
                    AsIilCB.Items.Add("Şehir Seçiniz.");
                    AsIilceCB.Items.Add("İlçe Seçiniz.");
                    AsIilCB.Text = AsIilCB.Items[0].ToString();
                    AsIilceCB.Text = AsIilceCB.Items[0].ToString();
                }
                if (AsEverlnilCB.Text == "Şehir Seçiniz." || AsEverlnilCB.Text == "")
                {
                    AsEverlnilCB.Items.Clear();
                    AsEverlnilCB.Items.Add("Şehir Seçiniz.");
                    AsEverlnilCB.Text = AsEverlnilCB.Items[0].ToString();
                }
                if (AsIilceCB.Text == "İlçe Seçiniz." || AsIilceCB.Text == "")
                {
                    AsIilceCB.Items.Clear();
                    AsIilceCB.Items.Add("İlçe Seçiniz.");
                    AsIilceCB.Text = AsIilceCB.Items[0].ToString();
                }
            }
            else
            {
                AsIilCB.Items.Clear();
                AsIilceCB.Items.Clear();
                AsEverlnilCB.Items.Clear();
                AsIilCB.Items.Add("Şehir Seçiniz.");
                AsIilceCB.Items.Add("İlçe Seçiniz.");
                AsEverlnilCB.Items.Add("Şehir Seçiniz.");
                AsIilCB.Text = AsIilCB.Items[0].ToString();
                AsIilceCB.Text = AsIilceCB.Items[0].ToString();
                AsEverlnilCB.Text = AsEverlnilCB.Items[0].ToString();
            }
        }

        private void AsIilCB_Enter(object sender, EventArgs e)
        {
            ililce = AsIilCB.Text;
        }
        private void AsIilCB_Leave(object sender, EventArgs e)
        {

        }


        //------------------------------------------------------------ KKARTI
        private void AsKKnoMB_Validating(object sender, CancelEventArgs e)
        {
            if (AsKKnoMB.Text != "    -    -    -")
            {
                if (AsKKnoMB.Text.Length != 19)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Kart No Alanını 16 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AsKKCvvMB_Validating(object sender, CancelEventArgs e)
        {
            if (AsKKCvvMB.Text != "")
            {
                if (AsKKCvvMB.Text.Length != 3)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen CVV Alanını 3 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AsKKsktMB_Validating(object sender, CancelEventArgs e)
        {
            if (AsKKsktMB.Text != "  -")
            {
                if (AsKKsktMB.Text.Length != 5)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen SKT Alanını 4 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //------------------------------------------------------------ EHLİYET
        private void AsEsicilnoMB_Validating(object sender, CancelEventArgs e)
        {
            if (AsEsicilnoMB.Text.Length > 0)
            {
                if (AsEsicilnoMB.Text.Length != 6)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Sicil No Alanını 6 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AsEvrlstrhiMB_Validating(object sender, CancelEventArgs e)
        {
            if (AsEvrlstrhiMB.Text != "  .  .")
            {
                try
                {
                    DateTime b = Convert.ToDateTime(AsEvrlstrhiMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Veriliş Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AsEgcrllktrhiMB_Validating(object sender, CancelEventArgs e)
        {
            if (AsEgcrllktrhiMB.Text != "  .  .")
            {
                try
                {
                    DateTime c = Convert.ToDateTime(AsEgcrllktrhiMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerlilik Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /*------------------------------------------------------------------------------------------ KİRALAMA*/
        private void KiralamaFB_Click(object sender, EventArgs e)
        {
            panellerarası();
            if (kontrol == true)
            {
                Kiralamayagecis();
            }
        }
        private void KiralamaFB_MouseHover(object sender, EventArgs e)
        {
            if (KiralamaUstSlider.Height == 50)
            {
                KiralamaUstSlider.Height = 100;
            }
            Ustmenukonum2 = "d";
            nerede = "2";
            ustmenugecis();
        }

        private void KiralamaFB2_Click(object sender, EventArgs e)
        {
            if (ListelerPaneli.Visible == false)
            {
                panellerarası();
                Ustmenukonum = "e";
                panellerarası();
            }
            if (listekonum != "kira")
            {
                Listepanelarası();
                listekonum = "kira";
                Listepanelarası();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (kirasayısı == 3)
            {
                timer4.Stop();
                this.TransparentAnimator.HideSync(KBilgiP);
                kirasayısı = 0;
            }
            kirasayısı++;
        }
        private void KBilgiP_Leave(object sender, EventArgs e)
        {
            timer4.Stop();
            this.TransparentAnimator.HideSync(KBilgiP);
            kirasayısı = 0;
        }

        private void KiralamaPaneli_EnabledChanged(object sender, EventArgs e)
        {
            GenelClass.KayitKontrol(KiralamaPaneli);
            if (kontrol == true)
            {
                KGMenuP.Visible = true;
                KGMenu2P.Visible = false;
            }
        }

        //---------------------------------------------------------------------- ALTPROG.
        void Kiralamayagecis()
        {
            if (KiralamaPaneli.Visible == false)
            {
                if (kontrol==true)
                {
                    SolmenuS.Location = new Point(560, SolmenuS.Location.Y);
                    KiralamaLoad();
                    Ustmenukonum = "d";
                    panellerarası();
                    KiralamaGenel2P.Focus();
                }
            }
        }

        void Kvericek()
        {
            KGcikisistasyonCB.Items.Clear();
            try
            {
                baglanti.Open();
                komut = new MySqlCommand("SELECT * FROM kiralama WHERE szlsmno=@szlsmno", baglanti);
                komut.Parameters.AddWithValue("@szlsmno", Convert.ToInt32(KiralamaCB.Text));
                MySqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    KGsozlesmenoTB.Text = KiralamaCB.Text;
                    KSsozlesmenoL.Text = KGsozlesmenoTB.Text;
                    KGislemyapanTB.Text = "" + oku["kralamaislemyapn"];
                    KGgunlukucretTB.Text = "" + oku["kralamagnlkucret"];
                    KGgunsayisiTB.Text = "" + oku["kralamagunsysi"];
                    KGislemtarihiMB.Text = "" + oku["kralamaislemtrh"];
                    KGbaslangicMB.Text = "" + oku["kralamabslngtrh"];
                    KGbitisMB.Text = "" + oku["kralamabitstrh"];
                    KiraTc = "" + oku["mstrtcno"];
                    KiraPlaka = "" + oku["arcplaka"];
                    KGtoplamtutarTB.Text = "" + oku["kralamatplmttr"];
                    string cikisistasyonn;
                    cikisistasyonn = "" + oku["kralamacıkısistsyn"];
                    baglanti.Close();
                    if (cikisistasyonn == "")
                    {
                        YapıClass.istasyonvericek(KGcikisistasyonCB);
                        KGcikisistasyonCB.Text = KGcikisistasyonCB.Items[0].ToString();
                    }
                    else
                    {
                        KGcikisistasyonCB.Items.Add(cikisistasyonn);
                        KGcikisistasyonCB.Text = KGcikisistasyonCB.Items[0].ToString();
                    }
                    kiraMusteriolustur();
                    kiraAracolustur();
                    Karackontrol();
                    Kmusterikontrol();
                    Kkayıtkontroll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void Kcomboboxyenile()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    KiralamaCB.Items.Clear();
                    KiralamaCB.Text = "";
                    baglanti.Open();
                    komut = new MySqlCommand("SELECT szlsmno FROM kiralama where kralamadelete=1", baglanti);
                    MySqlDataReader oku = komut.ExecuteReader();
                    while (oku.Read())
                    {
                        KiralamaCB.Items.Add(oku["szlsmno"]);
                    }
                    baglanti.Close();
                    Ksonkayit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }

        void Kkayitt()
        {
            Kzorunlualanbool();
            if (zorunlualann == true)
            {
                terstarih = KGislemtarihiMB.Text.Substring(6, 4) + "/" + KGislemtarihiMB.Text.Substring(3, 2) + "/" + KGislemtarihiMB.Text.Substring(0, 2);
                if (guncelleeyadakaydett == "kaydet")
                {
                    Kkaydett();
                }
                else
                {
                    Kguncelleekaydet();
                }
                KiralamaGenel2P.Focus();
            }
            else
            {
                Kzorunlualankontrol();
            }
        }
        void Kguncelleekaydet()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    Kgirilenkontrol();
                    baglanti.Open();
                    komut = new MySqlCommand("UPDATE kiralama SET kralamaislemyapn=@kralamaislemyapn, kralamaislemtrh=@kralamaislemtrh, kralamacıkısistsyn=@kralamacıkısistsyn, kralamagunsysi=@kralamagunsysi, kralamagnlkucret=@kralamagnlkucret, kralamatplmttr=@kralamatplmttr, kralamabslngtrh=@kralamabslngtrh, kralamabitstrh=@kralamabitstrh, mstrtcno=@mstrtcno, arcplaka=@arcplaka WHERE szlsmno=@szlsmno", baglanti);
                    komut.Parameters.AddWithValue("@szlsmno", Convert.ToInt32(KGsozlesmenoTB.Text));
                    komut.Parameters.AddWithValue("@kralamaislemyapn", KGislemyapanTB.Text);
                    komut.Parameters.AddWithValue("@kralamaislemtrh", terstarih);
                    komut.Parameters.AddWithValue("@kralamacıkısistsyn", KGcikisistasyonCB.Text);
                    komut.Parameters.AddWithValue("@kralamabslngtrh", KGbaslangicMB.Text);
                    komut.Parameters.AddWithValue("@kralamabitstrh", KGbitisMB.Text);
                    komut.Parameters.AddWithValue("@kralamagnlkucret", KGgunlukucretTB.Text);
                    komut.Parameters.AddWithValue("@kralamagunsysi", KGgunsayisiTB.Text);
                    komut.Parameters.AddWithValue("@kralamatplmttr", KGtoplamtutarTB.Text);
                    komut.Parameters.AddWithValue("@mstrtcno", KMusteritcL.Text);
                    komut.Parameters.AddWithValue("@arcplaka", KAracplakaL.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    AracCB.Text = KAracplakaL.Text;
                    sozlesmetablo = "kiralama";
                    Aguncelleekaydet();
                    MusteriCB.Text = KMusteritcL.Text;
                    sozlesmetablo = "kiralama";
                    Mguncelleekaydet();

                    Kverikontrol();
                    KiralamaCB.Text = gecicisozlesmeno;
                    KBilgiP.BackColor = Color.Green;
                    KBilgiCL.Text = "Güncelleme İşlemi Başarıyla Tamamlandı!";
                    TransparentAnimator.ShowSync(KBilgiP);
                    KBilgiCL.Focus();
                    timer4.Start();
                    guncelleeyadakaydett = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void Kkaydett()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    Kgirilenkontrol();
                    baglanti.Open();
                    komut = new MySqlCommand("INSERT INTO kiralama(kralamaislemyapn, kralamaislemtrh, kralamacıkısistsyn, kralamabslngtrh, kralamabitstrh, kralamagnlkucret, kralamagunsysi, kralamatplmttr, mstrtcno, arcplaka,kralamadelete) VALUES (@kralamaislemyapn, @kralamaislemtrh, @kralamacıkısistsyn, @kralamabslngtrh, @kralamabitstrh, @kralamagnlkucret, @kralamagunsysi, @kralamatplmttr, @mstrtcno,@arcplaka,@kralamadelete)", baglanti);
                    komut.Parameters.AddWithValue("@kralamaislemyapn", KGislemyapanTB.Text);
                    komut.Parameters.AddWithValue("@kralamaislemtrh", terstarih);
                    komut.Parameters.AddWithValue("@kralamacıkısistsyn", KGcikisistasyonCB.Text);
                    komut.Parameters.AddWithValue("@kralamabslngtrh", KGbaslangicMB.Text);
                    komut.Parameters.AddWithValue("@kralamabitstrh", KGbitisMB.Text);
                    komut.Parameters.AddWithValue("@kralamagnlkucret", KGgunlukucretTB.Text);
                    komut.Parameters.AddWithValue("@kralamagunsysi", KGgunsayisiTB.Text);
                    komut.Parameters.AddWithValue("@kralamatplmttr", KGtoplamtutarTB.Text);
                    komut.Parameters.AddWithValue("@mstrtcno", KMusteritcL.Text);
                    komut.Parameters.AddWithValue("@arcplaka", KAracplakaL.Text);
                    komut.Parameters.AddWithValue("@kralamadelete", "1");
                    komut.ExecuteNonQuery();
                    baglanti.Close();

                    AracCB.Text = KAracplakaL.Text;
                    sozlesmetablo = "kiralama";
                    Aguncelleekaydet();
                    MusteriCB.Text = KMusteritcL.Text;
                    sozlesmetablo = "kiralama";
                    Mguncelleekaydet();

                    if (Listeyeni == "yeni")
                    {
                        this.Close();
                    }
                    else
                    {
                        Kverikontrol();
                        KBilgiP.BackColor = Color.Green;
                        KBilgiCL.Text = "Kayıt İşlemi Başarıyla Tamamlandı!";
                        TransparentAnimator.ShowSync(KBilgiP);
                        KBilgiCL.Focus();
                        timer4.Start();
                        guncelleeyadakaydett = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }

        void Karackontrol()
        {
            //kodları düzenleyip bu tc veya plaakayı buralarda tutmak yerine hafıza mı tutalım ona bir bakalım 

            baglanti.Open();
            komut = new MySqlCommand("SELECT * FROM arcblglr WHERE arcplaka=@arcplaka", baglanti);
            komut.Parameters.AddWithValue("@arcplaka", KAracplakaL.Text);
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                kayıtkontrol = "";
            }
            else
            {
                kayıtkontrol = "kayıtlıdeğil";
                //        button16.Text = "Araç Sistemden Silindiği İçin Bu Kiralama Bilgisinde Değişiklik Yapılamaz!"; düzenlenecek bölüm
            }
            baglanti.Close();
        }
        void Kmusterikontrol()
        {
            //kodları düzenleyip bu tc veya plaakayı buralarda tutmak yerine hafıza mı tutalım ona bir bakalım 
            baglanti.Open();
            komut = new MySqlCommand("SELECT  * FROM mstrblglr WHERE mstrtcno=@mstrtcno", baglanti);
            komut.Parameters.AddWithValue("@mstrtcno", KMusteritcL.Text);
            MySqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
            }
            else
            {
                kayıtkontrol = "kayıtlıdeğil";
                //  button17.Text = "Müşteri Sistemden Silindiği İçin Bu Kiralama Bilgisinde Değişiklik Yapılamaz!"; düzenlenecek bölüm
            }
            baglanti.Close();
        }
        void Kkayıtkontroll()
        {
            //BUNLAR ARA GEÇİŞLER BUNLARI TASARIM DEĞİŞECEĞİ İÇİN DEĞİŞİTİRMEMİZ GEREKİYOR
            /*
            if (kayıtkontrol == "kayıtlıdeğil")
            {
                button16.Enabled = false;
                button17.Enabled = false;
                button3.Enabled = false;

                if (button16.Text == "Araç İşlem Menüsü")
                {
                    button16.Text = "Müşteri Sistemden Silindiği İçin Bu Kiralama Bilgisinde Değişiklik Yapılamaz!";
                }
                else
                {
                    if (button17.Text == "Müşteri İşlem Menüsü")
                    {
                        button17.Text = "Araç Sistemden Silindiği İçin Bu Kiralama Bilgisinde Değişiklik Yapılamaz!";
                    }
                }
            }
            else
            {
                button16.Enabled = true;
                button17.Enabled = true;
                button16.Text = "Araç İşlem Menüsü";
                button17.Text = "Müşteri İşlem Menüsü";
                button3.Enabled = true;
            }*/
        }

        void Kcontrolkilitle()
        {
            KGislemtarihiMB.Enabled = false;
            KGcikisistasyonCB.Enabled = false;
            KGbaslangicMB.Enabled = false;
            KGbitisMB.Enabled = false;
            KGgunlukucretTB.Enabled = false;

            KMusteriDegisB.Visible = false;
            KAracDegisB.Visible = false;
        }
        void Kcontrolkilitac()
        {
            KGislemtarihiMB.Enabled = true;
            KGcikisistasyonCB.Enabled = true;
            KGbaslangicMB.Enabled = true;
            KGbitisMB.Enabled = true;
            KGgunlukucretTB.Enabled = true;

            KMusteriDegisB.Visible = true;
            KAracDegisB.Visible = true;
        }
        void Kcontroltemizle()
        {
            KGsozlesmenoTB.Text = "";
            KGislemyapanTB.Text = "";
            KGislemtarihiMB.Clear();
            KGgunsayisiTB.Text = "";
            KGtoplamtutarTB.Text = "";
            KGbaslangicMB.Clear();
            KGbitisMB.Clear();
            KGgunlukucretTB.Text = "";
            KGcikisistasyonCB.Text = "";
            KGcikisistasyonCB.Items.Clear();
        }

        void Kilksonkontrol()
        {
            GenelClass.ilksonkontrol(KiralamaCB,KileriIB,KgeriIB);
        }
        void Ksonkayit()
        {
            if (KiralamaCB.Items.Count > 0)
            {
                KiralamaCB.Text = KiralamaCB.Items[KiralamaCB.Items.Count - 1].ToString();
                KaraTB.Enabled = true;
                KaraIB.Enabled = true;
                Kcontrolkilitle();
            }
            else
            {
                KaraTB.Enabled = true;
                KaraIB.Enabled = true;
                Kcontrolkilitac();
            }
            Kilksonkontrol();
        }
        void Kilkkayit()
        {
            KiralamaCB.Text = KiralamaCB.Items[0].ToString();
            Kilksonkontrol();
        }
        void Kverikontrol()
        {
            Kcomboboxyenile();
            if (KiralamaCB.Text != "")
            {
                Kmenukontrol();
                if (hangiislem != "sil")
                {
                    Kislemmenusudegis();
                }
            }
            else
            {
                KGMenuP.Visible = false;
                Kyeni();
            }
            Kilksonkontrol();
            kayıtkontrol = "";
        }

        void Kzorunlualanbool()
        {
            if (
                KGcikisistasyonCB.Text == "İstasyon Seçiniz." || KGcikisistasyonCB.Text == "" ||
                KGislemtarihiMB.Text == "  .  ." || KGislemtarihiMB.Text.Length != 10 ||
                KGbaslangicMB.Text == "  .  .       :" || KGbaslangicMB.Text.Length != 16 ||
                KGbitisMB.Text == "  .  .       :" || KGbitisMB.Text.Length != 16 ||
                KGgunlukucretTB.Text == "" || panel1.Visible != false || panel9.Visible != false
                )
            {
                zorunlualann = false;
            }
            else
            {
                zorunlualann = true;
            }
        }
        void Kzorunlualankontrol()
        {
            if (KGislemtarihiMB.Text == "  .  .")
            {
                MessageBox.Show("Lütfen İşlem Tarihi Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KGislemtarihiMB.Focus();
            }
            else if (KGcikisistasyonCB.Text == "İstasyon Seçiniz." || KGcikisistasyonCB.Text == "")
            {
                MessageBox.Show("Lütfen Çıkış İstasyon Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KGcikisistasyonCB.Focus();
            }
            else if (KGbaslangicMB.Text == "  .  .       :")
            {
                MessageBox.Show("Lütfen Başlangıç Tarihi Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KGbaslangicMB.Focus();
            }
            else if (KGbitisMB.Text == "  .  .       :")
            {
                MessageBox.Show("Lütfen Bitiş Tarihi Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KGbitisMB.Focus();
            }
            else if (KGgunlukucretTB.Text == "")
            {
                MessageBox.Show("Lütfen Günlük Ücreti Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KGgunlukucretTB.Focus();
            }
            else if (panel1.Visible != false)
            {
                MessageBox.Show("Lütfen Müşteri Seçiniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KiraMaraTB.Focus();
            }
            else if (panel9.Visible != false)
            {
                MessageBox.Show("Lütfen Araç Seçiniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KiraAaraTB.Focus();
            }        
        }
        void Kgirilenkontrol()
        {
            if (KGcikisistasyonCB.Text == "İstasyon Seçiniz.")
            {
                KGcikisistasyonCB.Items.Add("");
                KGcikisistasyonCB.Text = "";
            }
        }
        void Kbaglangicbitistarih()
        {
            try
            {
                if (KGbaslangicMB.Text != "  .  .       :" && KGbitisMB.Text != "  .  .       :")
                {
                    DateTime baslangıc = Convert.ToDateTime(KGbaslangicMB.Text.Substring(0, 10));
                    DateTime bitis = Convert.ToDateTime(KGbitisMB.Text.Substring(0, 10));
                    if (baslangıc < bitis)
                    {
                        TimeSpan g = bitis - baslangıc;
                        KGgunsayisiTB.Text = g.Days.ToString();
                    }
                    if (baslangıc.Day == bitis.Day)
                    {
                        KGgunsayisiTB.Text = "1";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void Kmenukontrol()
        {
            if (panel6.Visible == false)
            {
                panel1.Visible = false;
                panel6.Visible = true;
            }

            if (panel2.Visible == false)
            {
                panel9.Visible = false;
                panel2.Visible = true;
            }
        }
        void Kmenukontrol2()
        {
            if (panel9.Visible == false)
            {
                panel2.Visible = false;
                panel9.Visible = true;
            }
            if (panel1.Visible == false)
            {
                panel6.Visible = false;
                panel1.Visible = true;
            }
        }

        void Kyeni()
        {
            KiralamaGpaneli.Focus();
            while (KGMenuicP.Visible == true)
            {

            }
            KGMenuP.Visible = false;
            KGMenu2P.Show();
            KgeriIB.Visible = false;
            KileriIB.Visible = false;
            guncelleeyadakaydett = "kaydet";
            Kcontroltemizle();
            KiralamaCB.Text = "";
            KSsozlesmenoL.Text = "";
            Kcontrolkilitac();
            KaraTB.Enabled = false;

            Kmenukontrol2();
            //  panelaraconoff = "on";
            // timer3.Start(); BUNLAR DA MENÜ ARA GEÇİŞİ
            //   panelmusterionoff = "on";
            //  timer4.Start();
            YapıClass.istasyonvericek(KGcikisistasyonCB);
            KGcikisistasyonCB.Text = KGcikisistasyonCB.Items[0].ToString();

            KGislemyapanTB.Text = Giris.kullanıcı;
            KGislemtarihiMB.Focus();
        }

        void Kguncelle()
        {
            gecicisozlesmeno = KSsozlesmenoL.Text;
            Kcontrolkilitac();
            KiralamaGpaneli.Focus();
            while (KGMenuicP.Visible == true)
            {

            }
            KGMenuP.Visible = false;
            KGMenu2P.Show();
            KgeriIB.Visible = false;
            KileriIB.Visible = false;
            guncelleeyadakaydett = "guncelle";
            KaraTB.Enabled = false;
            KaraIB.Enabled = false;
            string a = KGcikisistasyonCB.Text;
            YapıClass.istasyonvericek(KGcikisistasyonCB);
            KGcikisistasyonCB.Text = a;
        }
        void Ksil()
        {
            if (GenelClass.sil() == true)
            {
                YapıClass.Kirasil(KGsozlesmenoTB.Text);
                hangiislem = "sil";
                Kcontroltemizle();
                Kverikontrol();
                KiralamaGenel2P.Focus();
                hangiislem = "";
                KBilgiCL.Text = "1 Kayıt Başarıyla Silindi!";
                KBilgiP.BackColor = Color.Maroon;
                this.TransparentAnimator.ShowSync(KBilgiP);
                KBilgiCL.Focus();
                timer4.Start();

            }
        }
        void Kara()
        {
            if (KaraTB.Text.Length != 0)
            {
                KiralamaCB.Text = KaraTB.Text;
                if (KiralamaCB.FindStringExact(KiralamaCB.Text) != -1)
                {
                    KiralamaCB.SelectedIndex = KiralamaCB.FindStringExact(KiralamaCB.Text);
                    KiralamaGenel2P.Focus();
                }
                else
                {
                    MessageBox.Show("Kiralama Bulunamadı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KaraTB.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Bu Alanı Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KaraTB.Focus();
            }
        }

        void KiralamaLoad()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                komut = new MySqlCommand("SELECT szlsmno FROM kiralama where kralamadelete=1", baglanti);
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    KiralamaCB.Items.Add(oku["szlsmno"]);
                }
                baglanti.Close();
                YapıClass.Kcomboboxautocomplete(KaraTB);
                YapıClass.Mcomboboxautocomplete(KiraMaraTB);
                YapıClass.Acomboboxautocomplete(KiraAaraTB);
                Kverikontrol();
            }
        }
        void Kislemmenusukapat()
        {
            if (KGMenuicP.Visible == true)
            {
                KGMenuIB.Enabled = false;
                RotateAnimator.HideSync(KGMenuIB);
                RotateAnimator.ShowSync(KGMenuIB);
                TransparentAnimator.HideSync(YeniKiralamaIB);
                TransparentAnimator.HideSync(GuncelleKiralamaIB);
                TransparentAnimator.HideSync(SilKiralamaIB);
                KGMenuicP.Visible = false;
            }
            KGMenuIB.Enabled = true;
        }
        void Kislemmenusudegis()
        {
            if (KGMenuP.Visible == true)
            {
                KGMenu2P.Visible = true;
                KGMenuP.Visible = false;
            }
            else if (KGMenu2P.Visible == true)
            {
                KGMenuP.Visible = true;
                KGMenu2P.Visible = false;
            }
        }

        void kiraMusteriolustur()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed && KiraTc != "")
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        komut = new MySqlCommand("SELECT * FROM mstrblglr WHERE mstrtcno = @mstrtcno", baglanti);
                        komut.Parameters.AddWithValue("@mstrtcno", KiraTc);
                        MySqlDataReader oku = komut.ExecuteReader();
                        if (oku.Read())
                        {
                            KMusteritcL.Text = KiraTc;
                            KMusteriAdSoyadL.Text = "" + oku["mstradi"];
                            KMusteriAdSoyadL.Text += "   -   " + oku["mstrsoyadi"];
                            KMusteridtrhYerL.Text = "" + oku["mstrdgmtrhi"];
                            KMusteridtrhYerL.Text += "   -   " + oku["mstrdgmyeri"];
                            KMusteriCepIstelL.Text = "" + oku["mstrceptelno"];
                            KMusteriCepIstelL.Text += " - " + oku["mstristelno"];
                            baglanti.Close();

                            if (panel6.Visible == false)
                            {
                                panel1.Visible = false;
                                panel6.Visible = true;
                            }

                        }
                        baglanti.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }
        void kiraAracolustur()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed && KiraPlaka != "")
                {
                    baglanti.Open();
                    komut = new MySqlCommand("SELECT * FROM arcblglr WHERE arcplaka = @arcplaka", baglanti);
                    komut.Parameters.AddWithValue("@arcplaka", KiraPlaka);
                    MySqlDataReader oku = komut.ExecuteReader();
                    if (oku.Read())
                    {
                        KAracplakaL.Text = "" + oku["arcplaka"];
                        KAracmarkaTipL.Text = "" + oku["arcmarka"];
                        KAracmarkaTipL.Text += "   -   " + oku["arctip"];
                        KAracVitesYakitL.Text = "" + oku["arcvites"];
                        KAracVitesYakitL.Text += "   -   " + oku["arcyakit"];
                        KAracsonkmModleL.Text = "" + oku["arcsonkm"];
                        KAracsonkmModleL.Text += "   -   " + oku["arcmodel"];
                        baglanti.Close();

                        if (panel2.Visible == false)
                        {
                            panel9.Visible = false;
                            panel2.Visible = true;
                        }
                    }
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }

        //---------------------------------------------------------------------- SOLMENÜ
        private void KileriIB_Click(object sender, EventArgs e)
        {
            if (KileriIB.Enabled == true)
            {
                KileriIB.Enabled = false;
                KiralamaCB.Text = KiralamaCB.Items[KiralamaCB.SelectedIndex + 1].ToString();
                Kilksonkontrol();
            }
            KileriIB.Enabled = true;
        }
        private void KgeriIB_Click(object sender, EventArgs e)
        {
            if (KgeriIB.Enabled == true)
            {
                KgeriIB.Enabled = false;
                KiralamaCB.Text = KiralamaCB.Items[KiralamaCB.SelectedIndex - 1].ToString();
                Kilksonkontrol();
            }
            KgeriIB.Enabled = true;
        }

        private void KaraTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Kara();
            }
        }
        private void KaraTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            KaraTB.MaxLength = 5;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void KaraTB_Leave(object sender, EventArgs e)
        {
            KaraMTB.BorderColorIdle = Color.Gray;
            if (KaraTB.Text == "")
            {
                KaraTB.ForeColor = Color.Gray;
                KaraTB.Text = "Kiralama Ara";
            }
        }
        private void KaraTB_Enter(object sender, EventArgs e)
        {
            KaraMTB.BorderColorIdle = Color.FromArgb(26, 177, 136);
            if (KaraTB.Text == "Kiralama Ara")
            {
                KaraTB.Text = "";
                KaraTB.ForeColor = Color.White;
            }
        }
        private void KaraIB_Click(object sender, EventArgs e)
        {
            Kara();
        }

        private void KiralamaCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kvericek();
        }
        private void bunifuThinButton212_Click(object sender, EventArgs e)
        {
            Form4.gecis = "sozlesme";
            Form4.sozlesmetc = KMusteritcL.Text;
            long faturasozlesmenoo = Convert.ToInt64(KSsozlesmenoL.Text);
            Form4.faturasozlesmeno = faturasozlesmenoo;
            Form4 fatura = new Form4();
            fatura.ShowDialog();
        }
        private void bunifuThinButton216_Click(object sender, EventArgs e)
        {
            Form4.gecis = "fatura";
            long faturasozlesmenoo = Convert.ToInt64(KSsozlesmenoL.Text);
            Form4.faturasozlesmeno = faturasozlesmenoo;
            Form4 fatura = new Form4();
            fatura.ShowDialog();
        }
        //---------------------------------------------------------------------- İÇMENÜ
        private void KGMenuIB_Click(object sender, EventArgs e)
        {
            KGMenuIB.Enabled = false;
            RotateAnimator.HideSync(KGMenuIB);
            RotateAnimator.ShowSync(KGMenuIB);
            KGMenuP.Focus();
            if (KGMenuicP.Visible == false)
            {
                KGMenuicP.Visible = true;
                this.TransparentAnimator.ShowSync(SilKiralamaIB);
                this.TransparentAnimator.ShowSync(GuncelleKiralamaIB);
                this.TransparentAnimator.ShowSync(YeniKiralamaIB);
            }
            else
            {
                this.TransparentAnimator.HideSync(YeniKiralamaIB);
                this.TransparentAnimator.HideSync(GuncelleKiralamaIB);
                this.TransparentAnimator.HideSync(SilKiralamaIB);
                KGMenuicP.Visible = false;
                KiralamaGenel2P.Focus();
            }
            KGMenuIB.Enabled = true;
        }
        private void KiralamaGenel2P_Click(object sender, EventArgs e)
        {
            KiralamaGenel2P.Focus();
        }
        private void SilKiralamaIB_Click(object sender, EventArgs e)
        {
            Ksil();
        }
        private void GuncelleKiralamaIB_Click(object sender, EventArgs e)
        {
            Kguncelle();
        }
        private void YeniKiralamaIB_Click(object sender, EventArgs e)
        {
            Kyeni();
        }
        private void KiptalIB_Click(object sender, EventArgs e)
        {
            KiralamaGenel2P.Focus();
            string gecici = KGsozlesmenoTB.Text;
            Kcontroltemizle();
            Kverikontrol();
            KiralamaCB.Text = gecici;
            guncelleeyadakaydett = "";
        }

        private void KGMenuP_Leave(object sender, EventArgs e)
        {
            Kislemmenusukapat();
        }

        private void KiralamaKaydetIB_Click(object sender, EventArgs e)
        {
            try
            {
                Kkayitt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //---------------------------------------------------------------------- KİRA
        private void KGislemtarihiMB_Validating(object sender, CancelEventArgs e)
        {
            if (KGislemtarihiMB.Text != "  .  .")
            {
                try
                {
                    DateTime a = Convert.ToDateTime(KGislemtarihiMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen işlem Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void KGgunsayisiTB_TextChanged(object sender, EventArgs e)
        {
            if (KGgunlukucretTB.Text != "" && KGgunsayisiTB.Text != "")
            {
                qw = Convert.ToInt64(KGgunlukucretTB.Text);
                we = Convert.ToInt64(KGgunsayisiTB.Text);
                er = qw * we;
                KGtoplamtutarTB.Text = er.ToString();
            }
        }

        private void panel11_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (KGbaslangicMB.Text != "  .  .       :" && KGbitisMB.Text != "  .  .       :")
                {
                    DateTime baslangıc = Convert.ToDateTime(KGbaslangicMB.Text.Substring(0, 10));
                    DateTime bitis = Convert.ToDateTime(KGbitisMB.Text.Substring(0, 10));
                    if (baslangıc < bitis)
                    {
                        TimeSpan g = bitis - baslangıc;
                        KGgunsayisiTB.Text = g.Days.ToString();
                    }
                    else if (baslangıc > bitis)
                    {
                        MessageBox.Show("Başlangıç tarihi Bitiş tarihinden küçük olmalıdır!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        e.Cancel = true;
                    }
                    else if (baslangıc.Day == bitis.Day)
                    {
                        KGgunsayisiTB.Text = "1";
                    }
                    if (KGgunlukucretTB.Text != "" && KGgunsayisiTB.Text != "")
                    {
                        qw = Convert.ToInt32(KGgunlukucretTB.Text);
                        we = Convert.ToInt32(KGgunsayisiTB.Text);
                        er = qw * we;
                        KGtoplamtutarTB.Text = "₺" + er.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void KGbaslangicMB_Validating(object sender, CancelEventArgs e)
        {
            if (KGbaslangicMB.Text != "  .  .       :")
            {
                try
                {
                    DateTime a = Convert.ToDateTime(KGbaslangicMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Başlangıç Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KGbaslangicMB.Focus();
                }
            }
        }
        private void KGbitisMB_Validating(object sender, CancelEventArgs e)
        {
            if (KGbitisMB.Text != "  .  .       :")
            {
                try
                {
                    DateTime a = Convert.ToDateTime(KGbitisMB.Text);
                }
                catch (Exception)
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Bitiş Tarihi Alanını Doğru Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    KGbitisMB.Focus();
                }
            }
        }//BU VE BAŞLANGIÇ TARİHLERİNİ NORMALDE, PANELE ALMIŞIM. O DATETİMEPİCKERDAN DİYE HATIRLIYORUM. TAM BİLMİYORUM SORUN ÇIKARSA BURADA HALLEDELİM


        private void KGgunlukucretTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            KGgunlukucretTB.MaxLength = 4;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void KGgunlukucretTB_Validating(object sender, CancelEventArgs e)
        {
            if (KGgunlukucretTB.Text == "0")
            {
                MessageBox.Show("Geçerli Bir Ücret Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
        private void KGgunlukucretTB_TextChanged(object sender, EventArgs e)
        {
            if (KGgunlukucretTB.Text != "" && KGgunsayisiTB.Text != "")
            {
                qw = Convert.ToInt64(KGgunlukucretTB.Text);
                we = Convert.ToInt64(KGgunsayisiTB.Text);
                er = qw * we;
                KGtoplamtutarTB.Text = "₺" + er.ToString();
            }
        }

        //---------------------------------------------------------------------- KİRAMÜŞTERİ

        private void KiraMaraTB_Leave(object sender, EventArgs e)
        {
            bunifuMetroTextbox78.BorderColorIdle = Color.Gray;
            if (KiraMaraTB.Text == "")
            {
                KiraMaraTB.ForeColor = Color.Gray;
                KiraMaraTB.Text = "Müşteri Ara";
            }
        }
        private void KiraMaraTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            KiraMaraTB.MaxLength = 11;
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void KiraMaraTB_Enter(object sender, EventArgs e)
        {
            bunifuMetroTextbox78.BorderColorIdle = Color.IndianRed;
            if (KiraMaraTB.Text == "Müşteri Ara")
            {
                KiraMaraTB.Text = "";
                KiraMaraTB.ForeColor = Color.White;
            }
        }
        private void KiraMaraIB_Click(object sender, EventArgs e)
        {
            YapıClass.Mara(KiraMaraTB, KiralamaGenel2P, MusteriCB);
            KiraTc = Class2.Tc;
            if (KiraTc != "")
            {
                kiraMusteriolustur();
                KiraMaraTB.ForeColor = Color.Gray;
                KiraMaraTB.Text = "Müşteri Ara";
            }
        }
        private void KiraMaraTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                YapıClass.Mara(KiraMaraTB, KiralamaGenel2P, MusteriCB);
                KiraTc = Class2.Tc;
                if (KiraTc != "")
                {
                    kiraMusteriolustur();
                    KiraMaraTB.ForeColor = Color.Gray;
                    KiraMaraTB.Text = "Müşteri Ara";
                }
            }
        }

        private void KMusteriDegisB_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == false)
            {
                panel6.Visible = false;
                panel1.Visible = true;
            }
        }

        //---------------------------------------------------------------------- KİRAARAÇ
        private void KiraAaraTB_Enter(object sender, EventArgs e)
        {
            bunifuMetroTextbox79.BorderColorIdle = Color.FromArgb(2, 119, 189);
            if (KiraAaraTB.Text == "Araç Ara")
            {
                KiraAaraTB.Text = "";
                KiraAaraTB.ForeColor = Color.White;
            }
        }
        private void KiraAaraTB_Leave(object sender, EventArgs e)
        {
            bunifuMetroTextbox79.BorderColorIdle = Color.Gray;
            if (KiraAaraTB.Text == "")
            {
                KiraAaraTB.ForeColor = Color.Gray;
                KiraAaraTB.Text = "Araç Ara";
            }
        }
        private void KiraAaraTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            KiraMaraTB.MaxLength = 10;
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void KiraAaraTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                YapıClass.Aara(KiraAaraTB, KiralamaGenel2P, AracCB);
                KiraPlaka = Class2.Plaka;
                if (KiraPlaka != "")
                {
                    kiraAracolustur();
                    KiraAaraTB.ForeColor = Color.Gray;
                    KiraAaraTB.Text = "Araç Ara";
                }
            }
        }
        private void KiraAaraIB_Click(object sender, EventArgs e)
        {
            YapıClass.Aara(KiraAaraTB, KiralamaGenel2P, AracCB);
            KiraPlaka = Class2.Plaka;
            if (KiraPlaka != "")
            {
                kiraAracolustur();
                KiraAaraTB.ForeColor = Color.Gray;
                KiraAaraTB.Text = "Araç Ara";
            }
        }

        private void KAracDegisB_Click(object sender, EventArgs e)
        {
            if (panel9.Visible == false)
            {
                panel2.Visible = false;
                panel9.Visible = true;
            }
        }

        /*------------------------------------------------------------------------------------------ LİSTELER*/

        //---------------------------------------------------------------------- ALTPROG.
        void Listepanelarası()
        {
            if (listekonum == "musteri")
            {
                if (ListeMusteriP.Visible == false)
                {
                    ListePB.Location = new Point(MusteriListeFB.Location.X + 15, ListePB.Location.Y);
                    ListePB.BackColor = Color.IndianRed;
                    ListedegiskenB.ActiveFillColor = Color.IndianRed;
                    ListedegiskenB.ButtonText = "Müşteri Oluştur";
                    ListeMusteriP.Visible = true;
                    MLvericek();
                    SolmenuS.Location = new Point(440, SolmenuS.Location.Y);
                }
                else
                {
                    ListeMusteriP.Visible = false;
                }
            }
            else if (listekonum == "arac")
            {
                if (ListeAracP.Visible == false)
                {
                    ListePB.BackColor = Color.FromArgb(120, 160, 237);
                    ListedegiskenB.ActiveFillColor = Color.FromArgb(120, 160, 237);
                    ListePB.Location = new Point(AracListeFB.Location.X + 17, ListePB.Location.Y);
                    ListedegiskenB.ButtonText = "Araç Oluştur";
                    ListeAracP.Visible = true;
                    ALvericek();
                    SolmenuS.Location = new Point(500, SolmenuS.Location.Y);
                }
                else
                {
                    ListeAracP.Visible = false;
                }
            }
            else if (listekonum == "kira")
            {
                if (ListeKiraP.Visible == false)
                {
                    ListePB.Location = new Point(KiraListeFB.Location.X + 17, ListePB.Location.Y);
                    ListedegiskenB.ButtonText = "Kiralama Oluştur";
                    KLvericek();
                    ListeKiraP.Visible = true;
                    ListeKiraicP.Height = 65;
                    SolmenuS.Location = new Point(560, SolmenuS.Location.Y);
                }
                else
                {
                    ListeKiraP.Visible = false;
                    ListeKiraicP.Height = 0;
                }
            }
//            ListedegiskenTB.Focus();
        }

        void MLvericek()
        {
            ListedegiskenTB.Clear();
            da = new MySqlDataAdapter("SELECT mstrtcno,mstradi,mstrsoyadi,mstrdgmtrhi,mstrdgmyeri,mstrceptelno,mstristelno,mstreposta,mstril,mstrilce,mstrulke,mstradres,mstrsrino,mstrbabaadi,mstranneadi FROM mstrblglr", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "mstrblglr");
            ListeMusteriDG.DataSource = ds.Tables["mstrblglr"];
            baglanti.Close();
            if (ListeMusteriDG.RowCount <= 0)
            {
                MessageBox.Show("Kayıtlı Müşteri Bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void MLvericeksartli()
        {
            string ara = ListedegiskenTB.Text.Trim();
            baglanti.Open();
            da = new MySqlDataAdapter(("SELECT mstrtcno,mstradi,mstrsoyadi,mstrdgmtrhi,mstrdgmyeri,mstrceptelno,mstristelno,mstreposta,mstril,mstrilce,mstrulke,mstradres,mstrsrino,mstrbabaadi,mstranneadi  FROM mstrblglr where (mstrtcno like '%") + ara + "%')", baglanti);
            ds = new DataSet();
            da.Fill(ds, "mstrblglr");
            ListeMusteriDG.DataSource = ds.Tables["mstrblglr"];
            baglanti.Close();
            if (ListeMusteriDG.RowCount <= 0)
            {
                MessageBox.Show("Kayıtlı Müşteri Bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MLvericek();
            }
        }

        void ALvericek()
        {
            ListedegiskenTB.Clear();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT arcplaka,arcmarka,arctip,arcmodel,arcrenk,arcyakit,arcvites,arcmotorno,arcsasino,arctrfkcıkıs,arcsonkm,arcsigortasrkt,arcpoliceno,arckasko,arckaskobts,arcmuaynebts FROM arcblglr", baglanti);
            ds = new DataSet();
            baglanti.Open();
            da.Fill(ds, "arcblglr");
            ListeAracDG.DataSource = ds.Tables["arcblglr"];
            baglanti.Close();
            if (ListeAracDG.RowCount <= 0)
            {
                MessageBox.Show("Kayıtlı Araç Bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void ALvericeksartli()
        {
            string ara = ListedegiskenTB.Text.Trim();
            baglanti.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(("SELECT arcplaka,arcmarka,arctip,arcmodel,arcrenk,arcyakit,arcvites,arcmotorno,arcsasino,arctrfkcıkıs,arcsonkm,arcsigortasrkt,arcpoliceno,arckasko,arckaskobts,arcmuaynebts FROM arcblglr where (arcplaka like '%") + ara + "%')", baglanti);
            ds = new DataSet();
            da.Fill(ds, "arcblglr");
            ListeAracDG.DataSource = ds.Tables["arcblglr"];
            da.Dispose();
            baglanti.Close();
            if (ListeAracDG.RowCount <= 0)
            {
                MessageBox.Show("Kayıtlı Araç Bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ALvericek();
            }
        }

        void KLvericek()
        {
            //   ListedegiskenTB.Clear();
            baglanti.Open();
            da = new MySqlDataAdapter("SELECT szlsmno,arcplaka,arcmarka,arctip,mstrtcno,mstradi,mstrsoyadi,kralamaislemyapn,kralamaislemtrh,kralamacıkısistsyn,kralamagunsysi,kralamagnlkucret,kralamatplmttr,kralamabslngtrh,kralamabitstrh FROM kiralama WHERE kralamadelete=1", baglanti);
            tablo = new DataTable();
            da.Fill(tablo);
            ListeKiraDG.DataSource = tablo;
            baglanti.Close();
            if (ListeKiraDG.RowCount <= 0)
            {
                MessageBox.Show("Kayıtlı Kiralama Bilgisi Bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void KLvericeksartli()
        {
            try
            {
                int a = 0;
                baglanti.Open();
                while (a < 3)
                {
                    if (a == 0)
                    {
                        da = new MySqlDataAdapter(("SELECT szlsmno,arcplaka,arcmarka,arctip,mstrtcno,mstradi,mstrsoyadi,kralamaislemyapn,kralamaislemtrh,kralamacıkısistsyn,kralamagunsysi,kralamagnlkucret,kralamatplmttr,kralamabslngtrh,kralamabitstrh FROM kiralama WHERE (arcplaka like '%") + ListedegiskenTB.Text + "%') and kralamadelete=1", baglanti);
                    }
                    else if (a == 1)
                    {
                        da = new MySqlDataAdapter(("SELECT szlsmno,arcplaka,arcmarka,arctip,mstrtcno,mstradi,mstrsoyadi,kralamaislemyapn,kralamaislemtrh,kralamacıkısistsyn,kralamagunsysi,kralamagnlkucret,kralamatplmttr,kralamabslngtrh,kralamabitstrh FROM kiralama WHERE (szlsmno like '%") + ListedegiskenTB.Text + "%')  and kralamadelete=1", baglanti);
                    }
                    else if (a == 2)
                    {
                        da = new MySqlDataAdapter(("SELECT szlsmno,arcplaka,arcmarka,arctip,mstrtcno,mstradi,mstrsoyadi,kralamaislemyapn,kralamaislemtrh,kralamacıkısistsyn,kralamagunsysi,kralamagnlkucret,kralamatplmttr,kralamabslngtrh,kralamabitstrh FROM kiralama WHERE  (mstrtcno like '%") + ListedegiskenTB.Text + "%')  and kralamadelete=1", baglanti);
                    }
                    tablo = new DataTable();
                    da.Fill(tablo);
                    if (tablo.Rows.Count < 1)
                    {
                        a++;
                        if (a == 3)
                        {
                            baglanti.Close();
                            KLvericek();
                            MessageBox.Show("Kayıtlı Kiralama Bilgisi Bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        a = 3;
                        ListeKiraDG.DataSource = tablo;
                    }
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                baglanti.Close();
            }
        }

        //---------------------------------------------------------------------- İÇMENÜ
        private void ListelerPaneli_Click(object sender, EventArgs e)
        {
            ListelerPaneli.Focus();
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void güncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Silmek istediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                string musteritcno = ListeMusteriDG.CurrentRow.Cells[0].Value.ToString();
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    komut = new MySqlCommand("DELETE FROM mstrblglr where mstrtcno=@mstrtcno", baglanti);
                    komut.Parameters.AddWithValue("@mstrtcno", musteritcno);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("1 Kayıt Silindi.", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MLvericek();
                }
            }
        }

        private void ListedegiskenTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (listekonum == "musteri")
                {
                    if (ListedegiskenTB.Text != " ARA" && ListedegiskenTB.Text != "")
                    {
                        MLvericeksartli();
                    }
                    else if (ListedegiskenTB.Text == "")
                    {
                        MLvericek();
                    }

                }
                else if (listekonum == "arac")
                {
                    if (ListedegiskenTB.Text != " ARA" && ListedegiskenTB.Text != "")
                    {
                        ALvericeksartli();
                    }
                    else if (ListedegiskenTB.Text == "")
                    {
                        ALvericek();
                    }
                }
                else if (listekonum == "kira")
                {
                    if (ListedegiskenTB.Text != " ARA" && ListedegiskenTB.Text != "")
                    {
                        KLvericeksartli();
                    }
                    else if (ListedegiskenTB.Text == "")
                    {
                        KLvericek();
                    }
                }
                e.SuppressKeyPress = true;
            }
        }
        private void ListedegiskenTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (listekonum == "musteri")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                ListedegiskenTB.MaxLength = 11;
            }
            else if (listekonum == "arac")
            {
                e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                ListedegiskenTB.MaxLength = 10;
            }
            else if (listekonum == "kira")
            {
                e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
                ListedegiskenTB.MaxLength = 11;
            }
        }
        private void ListedegiskenTB_TextChanged(object sender, EventArgs e)
        {
            if (listekonum == "musteri" && ListedegiskenTB.Text == "")
            {
                MLvericek();
            }
            else if (listekonum == "arac" && ListedegiskenTB.Text == "")
            {
                ALvericek();
            }
            else if (listekonum == "kira" && ListedegiskenTB.Text == "")
            {
                KLvericek();
            }
        }
        private void ListedegiskenTB_Enter(object sender, EventArgs e)
        {
            ListedegiskenTB.ForeColor = Color.Black;
            if (ListedegiskenTB.Text == " ARA")
            {
                ListedegiskenTB.Text = "";
            }
        }
        private void ListedegiskenTB_Leave(object sender, EventArgs e)
        {
            if (ListedegiskenTB.Text == "")
            {
                ListedegiskenTB.Text = " ARA";
                ListedegiskenTB.ForeColor = Color.Gray;
            }
        }

        private void ListearaIB_Click(object sender, EventArgs e)
        {
            if (listekonum == "musteri")
            {
                if (ListedegiskenTB.Text != " ARA" && ListedegiskenTB.Text != "")
                {
                    MLvericeksartli();
                }
                else if (ListedegiskenTB.Text == "")
                {
                    MLvericek();
                }
            }
            else if (listekonum == "arac")
            {
                if (ListedegiskenTB.Text != " ARA" && ListedegiskenTB.Text != "")
                {
                    ALvericeksartli();
                }
                else if (ListedegiskenTB.Text == "")
                {
                    ALvericek();
                }
            }
            else if (listekonum == "kira")
            {
                if (ListedegiskenTB.Text != " ARA" && ListedegiskenTB.Text != "")
                {
                    KLvericeksartli();
                }
                else if (ListedegiskenTB.Text == "")
                {
                    KLvericek();
                }
            }
        }

        private void ListeMusteriDG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (listegecis == "kira")
            {
                string musteritcno = ListeMusteriDG.CurrentRow.Cells[0].Value.ToString();
                DialogResult c = MessageBox.Show("Seçtiğiniz Müşteri: " + musteritcno + " Onaylıyor musunuz?", "BİLGİ", MessageBoxButtons.YesNo);
                if (c == DialogResult.Yes)
                {

                    //label39.Text = musteritcno;
                }
            }
        }

        private void KLlisteleB_Click(object sender, EventArgs e)
        {
            if (KLbaslangcDP.Value <= KLbitisDP.Value)
            {
                string bit = KLbitisDP.Value.ToShortDateString().Substring(6, 4) + "/" + KLbitisDP.Value.ToShortDateString().Substring(3, 2) + "/" + KLbitisDP.Value.ToShortDateString().Substring(0, 2);
                string bas = KLbaslangcDP.Value.ToShortDateString().Substring(6, 4) + "/" + KLbaslangcDP.Value.ToShortDateString().Substring(3, 2) + "/" + KLbaslangcDP.Value.ToShortDateString().Substring(0, 2);
                baglanti.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT szlsmno,arcplaka,arcmarka,arctip,mstrtcno,mstradi,mstrsoyadi,kralamaislemyapn,kralamaislemtrh,kralamacıkısistsyn,kralamagunsysi,kralamagnlkucret,kralamatplmttr,kralamabslngtrh,kralamabitstrh FROM rentacar.kiralama where kralamaislemtrh between '" + bas + "' And '" + bit + "' and kralamadelete=1", baglanti);
                tablo = new DataTable();
                da.Fill(tablo);
                ListeKiraDG.DataSource = tablo;
                baglanti.Close();
                if (ListeKiraDG.RowCount <= 0)
                {
                    KLvericek();
                    MessageBox.Show("Seçtiğiniz Tarih Aralığında Kiralama Bilgisi Bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (KLbaslangcDP.Value > KLbitisDP.Value)
            {
                MessageBox.Show("Başlangıç tarihi Bitiş tarihinden küçük olmalıdır!");
            }
        }

        private void ListeMusteriDG_MouseDown(object sender, MouseEventArgs e)
        {
            if (listegecis == "kira")
            {
                int currentMouseOverRow = ListeMusteriDG.HitTest(e.X, e.Y).RowIndex;
                if (e.Button == MouseButtons.Right)
                {
                    if (currentMouseOverRow == ListeMusteriDG.CurrentRow.Cells[0].RowIndex)
                    {
                        contextMenuStrip2.Show(ListeMusteriDG, new Point(e.X, e.Y));
                    }
                }
            }
            else
            {
                int currentMouseOverRow = ListeMusteriDG.HitTest(e.X, e.Y).RowIndex;
                if (e.Button == MouseButtons.Right)
                {
                    if (currentMouseOverRow == ListeMusteriDG.CurrentRow.Cells[0].RowIndex)
                    {
                        contextMenuStrip2.Show(ListeMusteriDG, new Point(e.X, e.Y));
                    }
                }
            }
        }

        private void ListedegiskenB_Click(object sender, EventArgs e)
        {
            if (listekonum == "musteri" && MusteriPaneli.Visible == false)
            {
                SolmenuS.Location = new Point(440, SolmenuS.Location.Y);
                panellerarası();
                Ustmenukonum = "b";
                Musterikonum = "a";
                panellerarası();
                MusteriGenel2P.Focus();
                Myeni();
            }
            else if (listekonum == "arac" && AracPaneli.Visible == false)
            {
                SolmenuS.Location = new Point(500, SolmenuS.Location.Y);
                panellerarası();
                Ustmenukonum = "c";
                Arackonum = "a";
                panellerarası();
                AracGenel2P.Focus();
                Ayeni();
            }
            else if (listekonum == "kira" && KiralamaPaneli.Visible == false)
            {
                SolmenuS.Location = new Point(560, SolmenuS.Location.Y);
                panellerarası();
                Ustmenukonum = "d";
                panellerarası();
                KiralamaGenel2P.Focus();
                Kyeni();
            }
        }

        private void ListelerPaneli_VisibleChanged(object sender, EventArgs e)
        {
            if(ListelerPaneli.Visible==false)
            {
                ListeKiraicP.Height = 0;
                KLbaslangcDP.Value = DateTime.Today;
                KLbitisDP.Value = KLbaslangcDP.Value;
                listekonum = "";
                ListeMusteriP.Visible = false;
                ListeAracP.Visible = false;
                ListeKiraP.Visible = false;
            }
        }
        /*------------------------------------------------------------------------------------------ AYARLAR*/
        private void AyarlarFB_Click(object sender, EventArgs e)
        {
            panellerarası();
            Ustmenukonum = "a";
            panellerarası();
            SolmenuS.Location = new Point(620, SolmenuS.Location.Y);
        }

        /*------------------------------------------------------------------------------------------ BİLGİ*/
        private void information_Click(object sender, EventArgs e)
        {          
            SolmenuS.Location = new Point(AnasayfaFB.Location.X, SolmenuS.Location.Y);
            panellerarası();
            Ustmenukonum = "f";
            panellerarası();
        }

        /*------------------------------------------------------------------------------------------ DENEMEALANI*/
    }
}