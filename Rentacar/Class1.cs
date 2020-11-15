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
    class Class1
    {
        public string baglanti = ("Server=127.0.0.1; Port=3306; Database=rentacar; Uid=root; Pwd=3883;");
        public string Regex = (@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
        public static Control item;
        public static Color renk;
        //----------------------------------------------------------------------------------------------------
        public static void Cikis()
        {
            if (MessageBox.Show("Çıkmak İstediğinizden Emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        public static void Temizle()
        {
            foreach (Control a in item.Controls)
            {
                if (a is TextBox)
                {
                    a.Text = "";
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        public bool internetKontrol()
        {
            try
            {
                System.Net.Sockets.TcpClient kontrol_client = new System.Net.Sockets.TcpClient("www.google.com.tr", 80);
                kontrol_client.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool islemiptal()
        {
            if (MessageBox.Show("İşlemi iptal etmek istediğinizden Emin misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool kayitKontrol()
        {
            foreach (Control a in item.Controls)
            {
                if (a is TextBox)
                {
                    TextBox c = a as TextBox;
                    if (c.Text != "")
                    {
                        if (MessageBox.Show("Kayıt işlemi tamamlanmadı. Yinede kapatılsın mı? ", "Kayıt Tamamlanmadı.", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            return true;
                        }
                        else
                        {
                            c.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        public void Renkuret()
        {
            Random color = new Random();
            int a = color.Next(255);
            int b = color.Next(255);
            int c = color.Next(255);
            renk = Color.FromArgb(a, b, c);
        }

        public bool OtomatikGuncelleme()
        {
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("http://www.sergenorhann.com/app/Automatic/guncelle.php?v=" + Program.versionCodeAutomatic);
                StreamReader reader = new StreamReader(stream);
                String content = reader.ReadToEnd();
                if (content == "GUNCELLE")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu. Hata kodu (RC1-1)\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public bool Guncelleme()
        {
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("http://www.sergenorhann.com/app/Manuel/guncelle.php?v=" + Program.versionCode);
                StreamReader reader = new StreamReader(stream);
                String content = reader.ReadToEnd();
                if (content == "GUNCELLE")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu. Hata kodu (RC1-2)\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public bool sil()
        {
            if (DialogResult.Yes == MessageBox.Show("Silmek istediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Veritabanibaglanti()
        {
            if (MessageBox.Show("Veri tabanına bağlanılamadı tekrar denenilsin mi?", "UYARI", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Tckontrolet(string tc)
        {
            bool returnvalue = false;
            if (Convert.ToInt32(tc[0].ToString()) != 0)
            {
                if (tc.Length == 11)
                {
                    Int64 ATCNO, BTCNO, TcNo;
                    long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;
                    TcNo = Int64.Parse(tc);
                    ATCNO = TcNo / 100;
                    BTCNO = TcNo / 100;
                    C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                    C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                    Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                    Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);
                    returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
                }
                if (returnvalue)
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
                return false;
            }

        }
        public void KayitKontrol(Panel degisken)
        {
            if (degisken.Enabled == false)
            {
                if (Ana.guncelleeyadakaydett == "")
                {
                    degisken.Visible = false;
                    Ana.kontrol = true;
                }
                else
                {
                 /*   if (islemiptal() == true)
                    {
                        Ana.guncelleeyadakaydett = "";
                        Ana.kontrol = true;
                        degisken.Visible = false;
                    }
                    else
                    {*/
                        Ana.kontrol = false;
                  //  }
                }
                degisken.Enabled = true;
            }
        }
        public void ControlKilit(Panel degisken,string deger)
        {
            foreach (Control s in degisken.Controls)
            {
                if (s is Panel)
                {
                    Panel icdegiken = (Panel)s;
                    foreach (Control ss in icdegiken.Controls)
                    {
                        if (ss is Panel)
                        {
                            Panel icdegiken2 = (Panel)ss;
                            foreach (Control sss in icdegiken2.Controls)
                            {
                                if (sss is MaskedTextBox || sss is TextBox || sss is ComboBox)
                                {
                                    if (deger == "true")
                                    {
                                        sss.Enabled = true;
                                    }
                                    else if (deger == "false")
                                    {
                                        sss.Enabled = false;
                                    }
                                    else if (deger == "clear")
                                    {
                                        sss.Text = "";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public void ilksonkontrol(ComboBox degisken,ns1.BunifuImageButton ileri, ns1.BunifuImageButton geri)
        {
            if (degisken.Items.Count <= 1)
            {
                geri.Visible = false;
                ileri.Visible = false;
            }
            else if (degisken.Items.Count > 1)
            {
                if (degisken.SelectedIndex == 0)
                {
                    geri.Visible = false;
                    ileri.Visible = true;
                }
                else if (degisken.SelectedIndex == degisken.Items.Count - 1)
                {
                    geri.Visible = true;
                    ileri.Visible = false;
                }
                else
                {
                    geri.Visible = true;
                    ileri.Visible = true;
                }
            }
        }
    }
}