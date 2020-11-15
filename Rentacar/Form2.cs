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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
//----------------------------------------------------------------------------------------------------
        public static string sonuc;
        int i = 1;
//---------------------------------------------------------------------------------------------------- 
        Class1 GenelClass = new Class1();
        Class2 YapıClass = new Class2();
        //----------------------------------------------------------------------------------------------------
        private void gonder()
        {
            if (i == 1)
            {
                i = 0;
                if (YapıClass.Sifresifirla() == true)
                {
                    sonuc = "Gonderildi";
                    bunifuCustomLabel2.Hide();
                    bunifuCustomLabel1.Text = "Kod Gönderildi.";
                    animator1.ShowSync(bunifuImageButton1);
                    Thread.Sleep(2000);
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
        }
//---------------------------------------------------------------------------------------------------- ACTİCATED
        private void Form2_Activated(object sender, EventArgs e)
        {     
            Thread thread = new Thread(new ThreadStart(gonder));
            thread.Start();
        }
//---------------------------------------------------------------------------------------------------- CLİCK
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(GenelClass.islemiptal()==true)
            {
                this.Close();
            }
        }
//---------------------------------------------------------------------------------------------------- LOAD
        private void Form2_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
