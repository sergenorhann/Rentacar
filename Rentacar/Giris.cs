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
//----------------------------------------------------------------------------------------------------
namespace Rentacar
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
//---------------------------------------------------------------------------------------------------- 
        public static string kullanıcı, yetki;
        string konum, yetkii;
        int gerisayim = 120;
        int b, d = 0;
        int y;
//---------------------------------------------------------------------------------------------------- 
        static Class1 GenelClass = new Class1();
        MySqlConnection baglanti = new MySqlConnection(GenelClass.baglanti);
        MySqlCommand komut = new MySqlCommand();
//---------------------------------------------------------------------------------------------------- ALT PROGRAM
        bool boslukkontrolzorunlu()
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Lütfen Adı Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return false;

            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Lütfen Soyadı Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox4.Focus();
                return false;
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Lütfen Kullanıcı Adı Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox5.Focus();
                return false;
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Lütfen Şifre Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox7.Focus();
                return false;
            }
            else if (textBox8.Text == "" && bunifuCheckbox2.Checked == false)
            {
                MessageBox.Show("Lütfen Şifre Tekrar Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox8.Focus();
                return false;
            }
            else if (textBox7.Text != textBox8.Text && bunifuCheckbox2.Checked == false)
            {
                MessageBox.Show("Lütfen Şifreleri Aynı doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox7.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        bool boslukkontrolzorunlu2()
        {
            if (textBox9.Text == "")
            {
                MessageBox.Show("Lütfen Kullanıcı Adı Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox9.Focus();
                return false;
            }
            else if (textBox10.Text == "")
            {
                MessageBox.Show("Lütfen Şifre Alanını Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox10.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        void GIRIS()
        {
            try
            {
                if (textBox1.Text != "")
                {
                    if (textBox2.Text != "")
                    {
                        komut = new MySqlCommand("SELECT * FROM kullanicigiris WHERE kullaniciadi=@kullaniciadi", baglanti);
                        komut.Parameters.AddWithValue("@kullaniciadi", textBox1.Text);
                        if (baglanti.State == ConnectionState.Closed)
                        {
                            baglanti.Open();
                            MySqlDataReader oku = komut.ExecuteReader();
                            if (oku.Read())
                            {
                                baglanti.Close();
                                komut = new MySqlCommand("SELECT * FROM kullanicigiris WHERE kullaniciadi=@kullaniciadi AND sifre=@sifre", baglanti);
                                komut.Parameters.AddWithValue("@kullaniciadi", textBox1.Text);
                                komut.Parameters.AddWithValue("@sifre", textBox2.Text);
                                baglanti.Open();
                                oku = komut.ExecuteReader();
                                if (oku.Read())
                                {
                                    kullanıcı = textBox1.Text;
                                    yetki = "" + oku["yetki"];
                                    Ana anaForm = new Ana();
                                    anaForm.Show();
                                    this.Hide();
                                    anaForm.Focus();
                                }
                                else
                                {
                                    MessageBox.Show("Şifreyi Yanlış Girdiniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    textBox2.Text = "";
                                    textBox2.Focus();
                                }
                                baglanti.Close();
                            }
                            else
                            {
                                MessageBox.Show("Girdiğiniz isimde bir Kullanıcı adı Bulunamadı!", "Kullanıcı Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Şifre Alanını Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Kullancı Adı Alanını Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                }
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu. Hata kodu (RF1)\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                baglanti.Close();
            }
        }//düzenlemek gerekiyor mu bakalım

/*
        void GuncellemeDosyasi()
        {
            if (File.Exists(Application.StartupPath + "\\RentacarUpdate.exe") == false)
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileAsync(new Uri("http://www.sergenorhann.com/app/Manuel/RentacarUpdate.exe"), Application.StartupPath + "\\RentacarUpdate.exe");
            }
            if (File.Exists(Application.StartupPath + "\\RentacarAutoUpdate.exe") == false)
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFileAsync(new Uri("http://www.sergenorhann.com/app/Automatic/RentacarAutoUpdate.exe"), Application.StartupPath + "\\RentacarAutoUpdate.exe");
            }
        }
        void OtomatikGuncellemekontrol()
        {
            if (GenelClass.OtomatikGuncelleme() == true)
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\RentacarAutoUpdate.exe");
                Application.Exit();
            }
        }
        void GuncellemeKontrol()
        {
            if (GenelClass.Guncelleme() == true)
            {
                bunifuImageButton4.Visible = true;
                toolTip1.SetToolTip(this.bunifuImageButton4, "Yeni versiyon mevcut. Bu tuşa basarak Rentacar'ın \nson versiyonunu indirebilirsiniz.");
                timer2.Start();
            }
        }
        */

        void GirisPaneli()
        {
            if(bunifuGradientPanel2.Visible==true || bunifuGradientPanel3.Visible == true)
            {
                KayitTemizle();
                bunifuSeparator1.Left = bunifuThinButton1.Left;
                if (bunifuGradientPanel2.Visible == true)
                {
                    animator3.HideSync(bunifuImageButton2);
                    bunifuImageButton2.Visible = false;
                    animator1.HideSync(bunifuGradientPanel2);
                    bunifuGradientPanel2.Visible = false;
                }
                else if(bunifuGradientPanel3.Visible == true)
                {
                    animator1.HideSync(bunifuGradientPanel3);
                    bunifuGradientPanel3.Visible = false;
                }
            }
            else if(bunifuGradientPanel5.Visible == true)
            {
                animator2.HideSync(bunifuGradientPanel5);
                bunifuGradientPanel5.Visible = false;
            }
            else if (bunifuGradientPanel4.Visible == true)
            {
                animator2.HideSync(bunifuGradientPanel4);
                bunifuGradientPanel4.Visible = false;
            }
            animator1.ShowSync(bunifuGradientPanel1);
            textBox1.Focus();
        }
        void GirisCheckbox()
        {
            if (bunifuCheckbox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
                bunifuCustomLabel4.Text = "Şifreyi Gizle";
                bunifuCustomLabel4.Location = new Point(bunifuCustomLabel4.Location.X + 10, bunifuCustomLabel4.Location.Y);
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                bunifuCustomLabel4.Text = "Şifreyi Göster";
                bunifuCustomLabel4.Location = new Point(bunifuCustomLabel4.Location.X - 10, bunifuCustomLabel4.Location.Y);
            }
        }
        void GirisPaneliTemizle()
        {
            Class1.item = bunifuGradientPanel1;
            Class1.Temizle();
        }

        void KayitolPaneli()
        {
            if (bunifuGradientPanel2.Visible == false)
            {
                if (konum != "e")
                {
                    animator3.ShowSync(bunifuImageButton2);
                    bunifuImageButton2.Visible = true;
                }
                konum = "d";

                if (bunifuGradientPanel3.Visible == true)
                {
                    bunifuGradientPanel3.Visible = false;
                    bunifuGradientPanel2.Left = 10;
                    animator2.ShowSync(bunifuGradientPanel2);
                }
                else if (bunifuGradientPanel4.Visible == true)
                {
                    if (GenelClass.islemiptal() == true)
                    {
                        KodPaneliTemizle();

                        bunifuSeparator1.Left = bunifuThinButton2.Left;
                        animator1.HideSync(bunifuGradientPanel4);
                        bunifuGradientPanel4.Visible = false;

                        bunifuGradientPanel2.Left = 10;
                        animator1.ShowSync(bunifuGradientPanel2);
                        textBox3.Focus();
                    }
                }
                else
                {
                    if (bunifuGradientPanel5.Visible == true)
                    {
                        if (GenelClass.islemiptal() == true)
                        {
                            SifrePaneliTemizle();
                            bunifuSeparator1.Left = bunifuThinButton2.Left;
                            animator1.HideSync(bunifuGradientPanel5);
                            bunifuGradientPanel5.Visible = false;

                            bunifuGradientPanel2.Left = 10;
                            animator1.ShowSync(bunifuGradientPanel2);
                            textBox3.Focus();
                        }
                    }
                    else
                    {
                        GirisPaneliTemizle();
                        bunifuSeparator1.Left = bunifuThinButton2.Left;
                        animator1.HideSync(bunifuGradientPanel1);
                        bunifuGradientPanel1.Visible = false;

                        bunifuGradientPanel2.Left = 10;
                        animator1.ShowSync(bunifuGradientPanel2);
                        textBox3.Focus();
                    }
                }
            }
        }
        void KayitCheckbox()
        {
            if (bunifuCheckbox2.Checked == true)
            {

                bunifuMetroTextbox8.Hide();
                textBox8.Hide();
                textBox8.Clear();
                bunifuCustomLabel11.Hide();
                bunifuMetroTextbox7.Width = 405;
                textBox7.Width = 394;

                textBox7.UseSystemPasswordChar = false;
                bunifuCustomLabel12.Text = "Şifreyi Gizle";
                bunifuCustomLabel12.Location = new Point(bunifuCustomLabel12.Location.X + 10, bunifuCustomLabel12.Location.Y);
            }
            else
            {
                bunifuMetroTextbox8.Show();
                textBox8.Show();
                bunifuCustomLabel11.Show();
                bunifuMetroTextbox7.Width = 200;
                textBox7.Width = 189;

                textBox7.UseSystemPasswordChar = true;
                bunifuCustomLabel12.Text = "Şifreyi Göster";
                bunifuCustomLabel12.Location = new Point(bunifuCustomLabel12.Location.X - 10, bunifuCustomLabel12.Location.Y);
            }
        }
        void KayitTemizle()
        {
            Class1.item = bunifuGradientPanel2;
            Class1.Temizle();
            KayitOnayTemizle();
        }
    
        void KayitOnaylaPaneli()
        {
            if (bunifuGradientPanel3.Visible == false)
            {
                animator3.ShowSync(bunifuImageButton2);
                bunifuImageButton2.Visible = true;
                animator2.HideSync(bunifuGradientPanel2);
                bunifuGradientPanel2.Visible = false;
                bunifuGradientPanel3.Left = 10;
                animator2.ShowSync(bunifuGradientPanel3);
                textBox9.Focus();
                konum = "e";
            }
        }
        void KayitOnayCheckbox()
        {
            if (bunifuCheckbox3.Checked == true)
            {
                textBox10.UseSystemPasswordChar = false;
                bunifuCustomLabel14.Text = "Şifreyi Gizle";
                bunifuCustomLabel14.Location = new Point(bunifuCustomLabel14.Location.X + 10, bunifuCustomLabel14.Location.Y);
            }
            else
            {
                textBox10.UseSystemPasswordChar = true;
                bunifuCustomLabel14.Text = "Şifreyi Göster";
                bunifuCustomLabel14.Location = new Point(bunifuCustomLabel14.Location.X - 10, bunifuCustomLabel14.Location.Y);
            }
        }
        void KayitOnayTemizle()
        {
            Class1.item = bunifuGradientPanel3;
            Class1.Temizle();
        }

        void KodPaneli()
        {
            if (bunifuGradientPanel4.Visible == false)
            {
                animator3.ShowSync(bunifuImageButton2);
                bunifuImageButton2.Visible = true;
                GirisPaneliTemizle();
                animator2.HideSync(bunifuGradientPanel1);
                bunifuGradientPanel1.Visible = false;
                bunifuGradientPanel4.Left = 10;
                animator2.ShowSync(bunifuGradientPanel4);
                textBox11.Focus();
                konum = "b";
            }
        }
        void KodPaneliTemizle()
        {
            timer1.Stop();
            maskedTextBox1.Text = "";
            textBox11.Text = "";
            maskedTextBox1.Visible = false;
            bunifuCustomLabel18.Visible = false;
            userControl1.Visible = false;
            bunifuCustomLabel18.Text = "120";
            bunifuThinButton7.ButtonText = "Kod Gönder";
            bunifuCustomLabel17.Text = "Kullanıcı Adı Veya E-Posta Adresi";
        }

        void SifrePaneli()
        {
            if (bunifuGradientPanel5.Visible == false)
            {
                animator3.ShowSync(bunifuImageButton2);
                bunifuImageButton2.Visible = true;
                KodPaneliTemizle();
                animator2.HideSync(bunifuGradientPanel4);
                bunifuGradientPanel4.Visible = false;
                bunifuGradientPanel5.Left = 10;
                animator2.ShowSync(bunifuGradientPanel5);
                textBox12.Focus();
                konum = "c";
            }
        }
        void SifreCheckbox()
        {
            if (bunifuCheckbox4.Checked == true)
            {
                textBox12.UseSystemPasswordChar = false;
                textBox13.UseSystemPasswordChar = false;

                bunifuCustomLabel20.Text = "Şifreyi Gizle";
                bunifuCustomLabel20.Location = new Point(bunifuCustomLabel20.Location.X + 10, bunifuCustomLabel20.Location.Y);
            }
            else
            {
                textBox12.UseSystemPasswordChar = true;
                textBox13.UseSystemPasswordChar = true;
                bunifuCustomLabel20.Text = "Şifreyi Göster";
                bunifuCustomLabel20.Location = new Point(bunifuCustomLabel20.Location.X - 10, bunifuCustomLabel20.Location.Y);
            }
        }
        void SifrePaneliTemizle()
        {
            Class1.item = bunifuGradientPanel5;
            Class1.Temizle();
        }

        public void giriss()
        {
            int deger = 0;
            while (deger == 0)
            {
                try
                {
                    komut = new MySqlCommand("SELECT * FROM kullanicigiris", baglanti);
                    baglanti.Open();
                    if (baglanti.State == ConnectionState.Open)
                    {
                        MySqlDataReader oku = komut.ExecuteReader();
                        baglanti.Close();
                        deger = 1;
                    }
                }
                catch
                {
                    if (GenelClass.Veritabanibaglanti() == false)
                    {
                        deger = 1;
                        Application.Exit();
                    }
                }
            }
        }
        void comboboxx()
        {
            try
            {
                comboBox1.Items.Clear();
                baglanti.Open();
                komut = new MySqlCommand("SELECT kullaniciadi,eposta FROM kullanicigiris", baglanti);
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox1.Items.Add("" + oku["kullaniciadi"]);
                    comboBox1.Items.Add("" + oku["eposta"]);
                }
                baglanti.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
//---------------------------------------------------------------------------------------------------- CLİCK
        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {
            if (GenelClass.internetKontrol() == true)
            {
                KodPaneli();
            }
            else
            {
                MessageBox.Show("İnternet Bağlantısı Bulunamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }//ŞİFREMİ UNUTTUM ---- internet bağlantısı gereklimi onu düşünelim

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Class1.Cikis();
        }//ÇIKIŞ
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (konum == "b")
            {
                if(bunifuThinButton7.ButtonText== "Kod Gönder")
                {
                    animator3.HideSync(bunifuImageButton2);
                    bunifuImageButton2.Visible = false;
                    KodPaneliTemizle();
                    GirisPaneli();
                    konum = "a";
                }
                else
                {
                    if (GenelClass.islemiptal() == true)
                    {
                        animator3.HideSync(bunifuImageButton2);
                        bunifuImageButton2.Visible = false;
                        KodPaneliTemizle();
                        GirisPaneli();
                        konum = "a";
                    }
                }
            }
            else if (konum == "c")
            {
                if(GenelClass.islemiptal()==true)
                {
                    animator3.HideSync(bunifuImageButton2);
                    bunifuImageButton2.Visible = false;
                    SifrePaneliTemizle();
                    GirisPaneli();
                    konum = "a";
                }
            }
            else if (konum == "d")
            {
                if (bunifuGradientPanel1.Visible == false)
                {
                    Class1.item = bunifuGradientPanel2;
                    if (GenelClass.kayitKontrol() == true)
                    {
                        animator3.HideSync(bunifuImageButton2);
                        bunifuImageButton2.Visible = false;
                        GirisPaneli();
                        konum = "a";
                    }
                }
            }
            else if (konum == "e")
            {
                KayitolPaneli();
                konum = "d";
            }
        }//GERİ
        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }//KÜÇÜLT
        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }//GÜNCELLEME İNDİR

        private void bunifuThinButton1_Click(object sender, EventArgs e)
        {
            if (bunifuGradientPanel1.Visible == false)
            {
                Class1.item = bunifuGradientPanel2;
                if (GenelClass.kayitKontrol() == true)
                {
                    GirisPaneli();
                }
            }
        }//GİRİŞ PANELİ
        private void bunifuThinButton2_Click(object sender, EventArgs e)
        {
            KayitolPaneli();
        }//KAYIT PANELİ
        private void bunifuThinButton3_Click(object sender, EventArgs e)
        {
            GIRIS();
        }//GİRİŞ YAP
        private void bunifuThinButton4_Click(object sender, EventArgs e)
        {
            if (boslukkontrolzorunlu() == true)
            {
                KayitOnaylaPaneli();
            }
        }//KAYIT OL
        private void bunifuThinButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (boslukkontrolzorunlu2() == true)
                {
                    komut = new MySqlCommand("SELECT * FROM kullanicigiris WHERE kullaniciadi=@kullaniciadi AND sifre=@sifre", baglanti);
                    komut.Parameters.AddWithValue("@kullaniciadi", textBox9.Text);
                    komut.Parameters.AddWithValue("@sifre", textBox10.Text);
                    baglanti.Open();
                    MySqlDataReader oku = komut.ExecuteReader();
                    if (oku.Read())
                    {
                        string okuyetki = "" + oku["yetki"];
                        baglanti.Close();
                        if (okuyetki == "1")
                        {
                            if (bunifuCheckbox5.Checked == true)
                            {
                                yetkii = "1";
                            }
                            else
                            {
                                yetkii = "0";
                            }
                            komut = new MySqlCommand("INSERT INTO kullanicigiris (kullaniciadi, ad, soyad, sifre, eposta, yetki) VALUES (@kullaniciadi, @ad, @soyad, @sifre, @eposta, @yetki)", baglanti);
                            komut.Parameters.AddWithValue("@ad", textBox3.Text);
                            komut.Parameters.AddWithValue("@soyad", textBox4.Text);
                            komut.Parameters.AddWithValue("@kullaniciadi", textBox5.Text);
                            komut.Parameters.AddWithValue("@sifre", textBox7.Text);
                            komut.Parameters.AddWithValue("@eposta", textBox6.Text);
                            komut.Parameters.AddWithValue("@yetki", yetkii);
                            baglanti.Open();
                            komut.ExecuteNonQuery();
                            baglanti.Close();
                            MessageBox.Show("Kullanıcı Başarıyla Oluşturuldu.", "Kayıt tamamlandı.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            animator3.HideSync(bunifuImageButton2);
                            bunifuImageButton2.Visible = false;

                            konum = "a";
                            GirisPaneli();
                            comboboxx();
                        }
                        else
                        {
                            MessageBox.Show("Yönetici Yetkisine sahip değilsiniz.!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            GirisPaneli();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Hatalı giriş yaptınız. Lütfen girdiğiniz bilgileri kontrol ediniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    baglanti.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(" Beklenmedik bir hata oluştu.\n Hata kodu(RF1-1)\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//KAYIT TAMAMLA
        private void bunifuThinButton6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kayıt işlemi tamamlanmadı. Yinede kapatılsın mı? ", "Kayıt Tamamlanmadı.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                animator3.HideSync(bunifuImageButton2);
                bunifuImageButton2.Visible = false;

                konum = "a";
                GirisPaneli();
                comboboxx();
            }
        }//KAYIT <İPTAL>
        private void bunifuThinButton7_Click(object sender, EventArgs e)
        {
            if (bunifuThinButton7.ButtonText == "Kod Gönder")
            {
                if (textBox11.Text != "")
                {
                    Class2.epostakullaniciadi = textBox11.Text;
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                    if (Form2.sonuc == "Gonderildi")
                    {
                        maskedTextBox1.Visible = true;
                        bunifuCustomLabel18.Visible = true;
                        userControl1.Visible = true;
                        bunifuThinButton7.ButtonText = "Kodu Onayla";
                        bunifuCustomLabel17.Text = "6 Haneli Doğrulama kodunu giriniz";
                        timer1.Start();
                    }
                }

            }
            else
            {
                if (maskedTextBox1.Text != "                      ")
                {
                    int kod = Convert.ToInt32(maskedTextBox1.Text.Replace(" ", ""));
                    if (kod == Class2.Kod)
                    {
                        timer1.Stop();
                        KodPaneliTemizle();
                        SifrePaneli();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı kod girişi yaptınız. Lütfen belirtilen süre içerisinde doğru kodu giriniz", "Hatalı Kod", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }
                }

            }
        }//KOD GÖNDER
        private void bunifuThinButton8_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox12.Text == textBox13.Text)
                {
                    komut = new MySqlCommand("SELECT * FROM kullanicigiris WHERE kullaniciadi=@kullaniciadi and sifre=@sifre", baglanti);
                    komut.Parameters.AddWithValue("@kullaniciadi", Class2.Kullaniciadi);
                    komut.Parameters.AddWithValue("@sifre", textBox12.Text);
                    baglanti.Open();
                    MySqlDataReader oku = komut.ExecuteReader();
                    if(oku.Read())
                    {
                        MessageBox.Show("Şifreniz Bir önceki şifreniz ile aynı olamaz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglanti.Close();
                    }
                    else
                    {
                        baglanti.Close();
                        komut = new MySqlCommand("UPDATE kullanicigiris SET sifre=@sifre WHERE kullaniciadi=@kullaniciadi", baglanti);
                        komut.Parameters.AddWithValue("@kullaniciadi", Class2.Kullaniciadi);
                        komut.Parameters.AddWithValue("@sifre", textBox12.Text);
                        baglanti.Open();
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Şifreniz Başarıyla Değiştirildi.", "Şifre Sıfırlama.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        animator3.HideSync(bunifuImageButton2);
                        bunifuImageButton2.Visible = false;
                        SifrePaneliTemizle();
                        GirisPaneli();
                        konum = "a";
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu. Hata kodu (RF1-2)\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }//ŞİFREYİ SIFIRLA
        private void bunifuThinButton9_Click(object sender, EventArgs e)
        {
            if (GenelClass.islemiptal() == true)
            {
                SifrePaneliTemizle();
                GirisPaneli();
                konum = "a";
            }
        }//ŞİFRE <İPTAL>
//---------------------------------------------------------------------------------------------------- KEYDOWN
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                GIRIS();
            }
            if(e.KeyCode==Keys.W)
            {
                Ana anaForm = new Ana();
                anaForm.Show();
                this.Hide();
                anaForm.Focus();
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                GIRIS();
            }
        }

        private void bunifuCheckbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (bunifuCheckbox1.Checked == false)
                {
                    bunifuCheckbox1.Checked = true;
                    GirisCheckbox();
                }
                else
                {
                    bunifuCheckbox1.Checked = false;
                    GirisCheckbox();
                }
            }
        }
        private void bunifuCheckbox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (bunifuCheckbox2.Checked == false)
                {
                    bunifuCheckbox2.Checked = true;
                    KayitCheckbox();
                }
                else
                {
                    bunifuCheckbox2.Checked = false;
                    KayitCheckbox();
                }
            }
        }
        private void bunifuCheckbox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (bunifuCheckbox3.Checked == false)
                {
                    bunifuCheckbox3.Checked = true;
                    KayitOnayCheckbox();
                }
                else
                {
                    bunifuCheckbox3.Checked = false;
                    KayitOnayCheckbox();
                }
            }
        }
        private void bunifuCheckbox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SifreCheckbox();
            }

        }
        private void bunifuCheckbox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (bunifuCheckbox5.Checked == true)
            {
                bunifuCheckbox5.Checked = false;
            }
            else
            {
                bunifuCheckbox5.Checked = true;
            }
        }
//---------------------------------------------------------------------------------------------------- KEYPRESS
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            textBox1.MaxLength = 15;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            textBox2.MaxLength = 15;
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
            textBox3.MaxLength = 10;
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);
            textBox4.MaxLength = 10;
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            textBox5.MaxLength = 15;
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
            textBox6.MaxLength = 75;
        }
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
            textBox7.MaxLength = 15;
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            textBox8.MaxLength = 15;
        }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            textBox9.MaxLength = 15;
        }
        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            textBox10.MaxLength = 15;
        }
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
            textBox6.MaxLength = 75;
        }
        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            textBox12.MaxLength = 15;
        }
        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            textBox13.MaxLength = 15;
        }
//---------------------------------------------------------------------------------------------------- LOAD
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.Width = 455;
                giriss();
                if (File.Exists(Application.StartupPath + "//rentacarAutoUpdate.exe") == true)
                {
                    File.Delete(Application.StartupPath + "//rentacarAutoUpdate.exe");
                }
                if (File.Exists(Application.StartupPath + "//rentacarUpdate.exe") == true)
                {
                    File.Delete(Application.StartupPath + "//rentacarUpdate.exe");
                }

                if (GenelClass.internetKontrol() == true)
                {/*
                    GuncellemeDosyasi();
                    OtomatikGuncellemekontrol();
                    GuncellemeKontrol();*/
                }

                comboboxx();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu. Hata kodu (RF1-3)\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
//---------------------------------------------------------------------------------------------------- MOUSEHOVER
        private void bunifuImageButton4_MouseHover(object sender, EventArgs e)
        {
            timer2.Stop();
            bunifuImageButton4.Location = new Point(bunifuImageButton4.Location.X, 540);
        }
//---------------------------------------------------------------------------------------------------- ONCHANGE
        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            GirisCheckbox();
        }
        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            KayitCheckbox();
        }
        private void bunifuCheckbox3_OnChange(object sender, EventArgs e)
        {
            KayitOnayCheckbox();
        }
        private void bunifuCheckbox4_OnChange(object sender, EventArgs e)
        {
            SifreCheckbox();
        }

//---------------------------------------------------------------------------------------------------- TİMER
        private void timer1_Tick(object sender, EventArgs e)
        {
            gerisayim -= 1;
            bunifuCustomLabel18.Text = gerisayim.ToString();
            if (gerisayim == 0)
            {
                timer1.Stop();
                MessageBox.Show("Belirtilen sürede işlem yapmadığınızdan dolayı İşleminiz iptal edilmiştir", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                KodPaneliTemizle();
                GirisPaneli();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            d++;
            if (bunifuImageButton4.Location.Y == 540 && d <12)
            {
                if (b == 0)
                {
                    y = 536;
                    b++;
                }
                else if (b == 1)
                {
                    y = 537;
                    b++;
                }
                else if (b == 2)
                {
                    y = 537;
                    b++;
                }
                else if (b == 3)
                {
                    y = 538;
                    b++;
                }
                else if (b == 4)
                {
                    y = 539;
                    b++;
                }
                else
                {
                    b = 0;
                    y = 540;
                }
                bunifuImageButton4.Location = new Point(bunifuImageButton4.Location.X, y);
            }
            else
            {
                bunifuImageButton4.Location = new Point(bunifuImageButton4.Location.X, 540);
            }
            if (d == 36)
            {
                d = 0;
            }
        }
        //---------------------------------------------------------------------------------------------------- VALİDATİNG
        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text != "")
            {
                if (comboBox1.FindStringExact(textBox5.Text) != -1)
                {
                    e.Cancel = true;
                    MessageBox.Show("Girdiğiniz Kullanıcıadı Sistem'de Mevcuttur.", "MEVCUT KULLANICI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text != "")
            {
                if (!new Regex(GenelClass.Regex).IsMatch(textBox6.Text))
                {
                    e.Cancel = true;
                    MessageBox.Show("Lütfen Geçerli Bir E-posta Adresi Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (comboBox1.FindStringExact(textBox6.Text) != -1)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Girdiğiniz E-Posta Adresi Sistem'de Mevcuttur.", "MEVCUT E-POSTA ADRESİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
//----------------------------------------------------------------------------------------------------
    }
}