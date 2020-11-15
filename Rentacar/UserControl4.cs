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
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
        }

        static Class1 GenelClass = new Class1();
        MySqlConnection baglanti = new MySqlConnection(GenelClass.baglanti);
        MySqlCommand komut = new MySqlCommand();

        public UserControl4(string Text1, string Text2,Image Icon)
        {
            InitializeComponent();
            label1.Text = Text1;
            label2.Text = Text2;
            icon.Image = Icon;
        }
        string dosyanınyeniklasoru = Application.StartupPath + "\\MBelge\\" + tcc + "\\";
        public static string tcc;
        private void label1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(label1, label1.Text);
        }
        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "\\MBelge\\" + tcc + "\\" + label1.Text);
        }
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + label1.Text))
                {
                    MessageBox.Show("Masaüstünde "+ label1.Text + " İsimli Bu Dosya Zaten Mevcut!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    File.Copy(dosyanınyeniklasoru + label1.Text, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + label1.Text);
                    MessageBox.Show("Kopyalama Başarıyla tamamlandı. (bunu altta bilgi olarak verelim mbx ile olmaz)");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if( DialogResult.Yes == MessageBox.Show(label1.Text+ " İsimli dosyayı silmek istiyor musunuz?","Uyarı!",MessageBoxButtons.YesNo,MessageBoxIcon.Information))
            {
                baglanti.Open();
                komut = new MySqlCommand("DELETE FROM mstrbelge WHERE belgeadi=@belgeadi", baglanti);
                komut.Parameters.AddWithValue("@belgeadi", label1.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                File.Delete(dosyanınyeniklasoru + "\\" + label1.Text);
                Ana Ana = (Ana)Application.OpenForms["Ana"];
                Ana.MbelgekontrolL.Text = "delete";
                Ana.MbelgekontrolL.Text = "";
            }
        }
    }
}
