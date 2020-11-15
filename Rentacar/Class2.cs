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
    class Class2
    {
        public static int Kod, Sayac;
        string İsim, Soyisim, Eposta, Bugun, bugunkontrol, Belgeadi;
        public static string epostakullaniciadi, Kullaniciadi, Tc, Plaka;
        //----------------------------------------------------------------------------------------------------
        static Class1 GenelClass = new Class1();
        MySqlConnection baglanti = new MySqlConnection(GenelClass.baglanti);
        MySqlCommand komut = new MySqlCommand();
        //----------------------------------------------------------------------------------------------------
        public void bankavericek(ComboBox banka)
        {
            banka.Items.Clear();
            komut = new MySqlCommand("SELECT * FROM banka ORDER BY Kimlik ASC", baglanti);
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    banka.Items.Add(oku["bankaadi"]);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ilvericek(ComboBox il, ComboBox il2)
        {
            komut = new MySqlCommand("SELECT * FROM il ORDER BY Kimlik ASC", baglanti);
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    il.Items.Add(oku["sehir"]);
                    il2.Items.Add(oku["sehir"]);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ulkevericek(ComboBox ulke)
        {
            ulke.Items.Clear();
            komut = new MySqlCommand("SELECT * FROM ulke ORDER BY kimlik ASC", baglanti);
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    ulke.Items.Add(oku["ulke"]);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ilkontrolluilce(string il, ComboBox ilce)
        {
            komut = new MySqlCommand("SELECT * FROM il WHERE sehir=@sehir", baglanti);
            komut.Parameters.AddWithValue("@sehir", il);
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                MySqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    string ilceadi = "" + oku["Kimlik"];
                    oku.Close();
                    baglanti.Close();

                    komut = new MySqlCommand("SELECT * FROM ilce WHERE sehir=@sehir ORDER BY Kimlik DESC", baglanti);
                    komut.Parameters.AddWithValue("@sehir", ilceadi);
                    baglanti.Open();
                    MySqlDataReader oku2 = komut.ExecuteReader();
                    while (oku2.Read())
                    {
                        ilce.Items.Add(oku2["ilce"]);
                    }
                    oku2.Close();
                    baglanti.Close();
                }
                if (baglanti.State == ConnectionState.Open)
                {
                    oku.Close();
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Mcomboboxautocomplete(TextBox Mautotextbox)
        {
            try
            {
                AutoCompleteStringCollection veri = new AutoCompleteStringCollection();
                komut = new MySqlCommand("SELECT mstrtcno FROM mstrblglr", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    veri.Add("" + oku["mstrtcno"]);
                }
                oku.Close();
                baglanti.Close();
                Mautotextbox.AutoCompleteCustomSource = veri;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void markavericek(ComboBox marka)
        {
            marka.Items.Clear();
            komut = new MySqlCommand("SELECT * FROM arcmrka ORDER BY Kimlik ASC", baglanti);
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    marka.Items.Add(oku["marka"]);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void tipvericek(string marka, ComboBox tip)
        {
            tip.Items.Clear();
            komut = new MySqlCommand("SELECT * FROM arcmrka WHERE marka=@marka", baglanti);
            komut.Parameters.AddWithValue("@marka", marka);
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                MySqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    string arctip = "" + oku["Kimlik"];
                    oku.Close();
                    baglanti.Close();

                    komut = new MySqlCommand("SELECT * FROM arctip WHERE marka=@marka", baglanti);
                    komut.Parameters.AddWithValue("@marka", arctip);
                    baglanti.Open();
                    MySqlDataReader oku2 = komut.ExecuteReader();
                    while (oku2.Read())
                    {
                        tip.Items.Add(oku2["arctip"]);
                    }
                    oku2.Close();
                    baglanti.Close();
                }
                if (baglanti.State == ConnectionState.Open)
                {
                    oku.Close();
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void sigortasirketvericek(ComboBox sigorta)
        {
            sigorta.Items.Clear();
            komut = new MySqlCommand("SELECT * FROM sigortasirket ORDER BY Kimlik ASC", baglanti);
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    sigorta.Items.Add(oku["sirketadi"]);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Acomboboxautocomplete(TextBox Aautotextbox)
        {
            try
            {
                AutoCompleteStringCollection veri = new AutoCompleteStringCollection();
                komut = new MySqlCommand("SELECT arcplaka FROM arcblglr", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    veri.Add("" + oku["arcplaka"]);
                }
                oku.Close();
                baglanti.Close();
                Aautotextbox.AutoCompleteCustomSource = veri;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void istasyonvericek(ComboBox istasyon)
        {
            istasyon.Items.Clear();
            komut = new MySqlCommand("SELECT * from istasyon ORDER BY Kimlik", baglanti);      
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    istasyon.Items.Add(oku["istasyonadi"]);
                }
                oku.Close();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Kcomboboxautocomplete(TextBox Kautotextbox)
        {
            try
            {
                AutoCompleteStringCollection veri = new AutoCompleteStringCollection();
                komut = new MySqlCommand("SELECT szlsmno FROM kiralama where kralamadelete = 1", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                MySqlDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    veri.Add("" + oku["szlsmno"]);
                }
                oku.Close();
                baglanti.Close();
                Kautotextbox.AutoCompleteCustomSource = veri;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Kirasil(string Sozlesmeno)
        {
            try
            {
                komut = new MySqlCommand("DELETE FROM kiralama WHERE szlsmno = @szlsmno", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut.Parameters.AddWithValue("@szlsmno", Sozlesmeno);
                komut.ExecuteNonQuery();
                baglanti.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Aracsil(string Aracplaka)
        {
            try
            {
                komut = new MySqlCommand("DELETE FROM arcblglr WHERE arcplaka = @arcplaka", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut.Parameters.AddWithValue("@arcplaka", Aracplaka);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Directory.Delete(Application.StartupPath + "\\ABelge\\" + Aracplaka + "\\", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Musterisil(string MusteriTcNo)
        {
            try
            {
                komut = new MySqlCommand("UPDATE mstrblglr SET mstrkfltcno=@mstrkfltcno where mstrkfltcno='" + MusteriTcNo + "'", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut.Parameters.AddWithValue("@mstrkfltcno", "");
                komut.ExecuteNonQuery();
                komut = new MySqlCommand("DELETE FROM mstrblglr WHERE mstrtcno = @mstrtcno", baglanti);
                komut.Parameters.AddWithValue("@mstrtcno", MusteriTcNo);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Directory.Delete(Application.StartupPath + "\\MBelge\\" + MusteriTcNo + "\\", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Belgesil(string MBelgeadi,string Abelgeadi)
        {
            try
            {
                if (MBelgeadi != "")
                {
                    Belgeadi = MBelgeadi;
                    komut = new MySqlCommand("DELETE FROM mstrbelge WHERE belgeadi=@belgeadi", baglanti);
                }
                else if (Abelgeadi != "")
                {
                    Belgeadi = Abelgeadi;
                    komut = new MySqlCommand("DELETE FROM arcbelge WHERE belgeadi=@belgeadi", baglanti);
                }
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut.Parameters.AddWithValue("@belgeadi", Belgeadi);
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //----------------------------------------------------------------------------------------------------
        public void Mara(TextBox MusteriTextbox,Panel MusteriPanel,ComboBox MusteriCombobox)
        {
            if (MusteriTextbox.Text.Length == 11)
            {
                if (MusteriCombobox.FindStringExact(MusteriTextbox.Text) != -1)
                {
                    MusteriCombobox.SelectedIndex = MusteriCombobox.FindStringExact(MusteriTextbox.Text);
                    Tc = MusteriCombobox.Text;
                    MusteriPanel.Focus();
                }
                else
                {
                    MessageBox.Show("Müşteri Bulunamadı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Tc = "";
                    MusteriTextbox.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Bu Alanı 11 Karakter Olarak Giriniz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MusteriTextbox.Focus();
            }
        }
        public void Aara(TextBox AracTextbox, Panel AracPanel, ComboBox AracCombobox)
        {
            if (AracTextbox.Text.Length != 0)
            {
                AracCombobox.Text = AracTextbox.Text;
                if (AracCombobox.FindStringExact(AracCombobox.Text) != -1)
                {
                    AracCombobox.SelectedIndex = AracCombobox.FindStringExact(AracCombobox.Text);
                    AracPanel.Focus();
                    Plaka = AracCombobox.Text;
                }
                else
                {
                    MessageBox.Show("Araç Bulunamadı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Plaka = "";
                    AracTextbox.Focus();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Bu Alanı Doldurunuz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AracTextbox.Focus();
            }
        }
        //----------------------------------------------------------------------------------------------------
        public bool Sifresifirla()
        {
            try
            {
                Random kod = new Random();
                Kod = kod.Next(100000, 999999);

                komut = new MySqlCommand("SELECT * FROM kullanicigiris WHERE kullaniciadi=@kullaniciadi", baglanti);
                komut.Parameters.AddWithValue("@kullaniciadi", epostakullaniciadi);
                baglanti.Open();
                MySqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    İsim = "" + oku["isim"];
                    Soyisim = "" + oku["soyisim"];
                    Kullaniciadi = epostakullaniciadi;
                    Eposta = "" + oku["eposta"];
                    Sayac = Convert.ToInt16("" + oku["sayac"]);
                    Bugun = oku["bugun"].ToString().Substring(0, 10);
                    baglanti.Close();
                    if (sifrekontrolu() == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    baglanti.Close();
                    komut = new MySqlCommand("SELECT * FROM kullanicigiris WHERE eposta=@eposta", baglanti);
                    komut.Parameters.AddWithValue("@eposta", epostakullaniciadi);
                    baglanti.Open();
                    oku = komut.ExecuteReader();
                    if (oku.Read())
                    {
                        İsim = "" + oku["isim"];
                        Soyisim = "" + oku["soyisim"];
                        Kullaniciadi = "" + oku["kullaniciadi"];
                        Eposta = epostakullaniciadi;
                        Sayac = Convert.ToInt16("" + oku["sayac"]);
                        Bugun = oku["bugun"].ToString().Substring(0, 10);
                        baglanti.Close();
                        if (sifrekontrolu() == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        baglanti.Close();
                        MessageBox.Show("Hatalı giriş yaptınız. Lütfen girdiğiniz bilgiyi kontrol ediniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu. Hata kodu (RC1)\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

        }
        //----------------------------------------------------------------------------------------------------
        bool sifrekontrolu()
        {
            if (Sayac < 1)
            {
                Bugun = DateTime.Today.ToShortDateString();
                Bugun = Bugun.Substring(6, 4) + "/" + Bugun.Substring(3, 2) + "/" + Bugun.Substring(0, 2);
                komut = new MySqlCommand("UPDATE kullanicigiris SET bugun=@bugun WHERE kullaniciadi=@kullaniciadi", baglanti);
                komut.Parameters.AddWithValue("@kullaniciadi", Kullaniciadi);
                komut.Parameters.AddWithValue("@bugun", Bugun);
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                Sayac++;
            }
            else
            {
                bugunkontrol = DateTime.Today.AddDays(1).ToShortDateString();
                if (Bugun == bugunkontrol)
                {
                    Sayac++;
                }
                else
                {
                    Sayac = 1;
                }
            }
            if (Sayac > 3)
            {
                MessageBox.Show("Günlük 3 Kod gönderme limitini doldurdunuz!", "LİMİT HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                try
                {
                    Form2 form = Application.OpenForms["Form2"] as Form2;
                    form.Controls["bunifuFlatButton1"].Hide();

                    SmtpClient smtpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();

                    smtpserver.Credentials = new NetworkCredential("rentacarprogram@hotmail.com", "Programrentacar");
                    smtpserver.Port = 587;
                    smtpserver.Host = "smtp.live.com";
                    smtpserver.EnableSsl = true;
                    mail.From = new MailAddress("rentacarprogram@hotmail.com");
                    mail.To.Add(new MailAddress(Eposta));
                    mail.Subject = "Şifre Sıfırlama Kodu";
                    mail.Body = "Sayın " + İsim.ToUpper() + " " + Soyisim.ToUpper() + " ;\n\nKullanıcı Adı: " + Kullaniciadi + "\nYukarıda bulunan kullanıcı hesabınız için Şifre sıfırlama isteğinde bulundunuz. Doğruluma kodunuz aşağıda mevcuttur. Lütfen Belirtilen Süre içerinde kodu giriniz. " + "\n\nDoğrulama kodu: " + Kod;
                    smtpserver.Send(mail);

                    komut = new MySqlCommand("UPDATE kullanicigiris SET sayac=@sayac WHERE kullaniciadi=@kullaniciadi", baglanti);
                    komut.Parameters.AddWithValue("@kullaniciadi", Kullaniciadi);
                    komut.Parameters.AddWithValue("@sayac", Sayac);
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglanti.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beklenmedik bir hata oluştu. Hata kodu (RC1-3)\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
        }
    }
}