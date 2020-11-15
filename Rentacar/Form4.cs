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
using Microsoft.Reporting.WinForms;

namespace Rentacar
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        static Class1 GenelClass = new Class1();
        MySqlConnection baglanti = new MySqlConnection(GenelClass.baglanti);
        MySqlCommand komut = new MySqlCommand();
        MySqlDataAdapter da = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        public static long faturasozlesmeno = 0;
        public static string gecis,sozlesmetc;

        private void Form4_Load(object sender, EventArgs e)
        {
            if (gecis == "sozlesme") 
            {

                reportViewer2.Visible = false;
                reportViewer1.Visible = true;
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                da = new MySqlDataAdapter("SELECT * FROM kiralama WHERE kiralama.szlsmno=" + faturasozlesmeno + "", baglanti);
                ds = new DataSet();
                baglanti.Open();
                da.Fill(ds, "kiralama");
                kiralamaBindingSource.DataSource = ds;
                baglanti.Close();
                this.reportViewer1.RefreshReport();
             
            }
            if (gecis == "fatura") 
            {
                reportViewer1.Visible = false;
                reportViewer2.Visible = true;
                reportViewer2.SetDisplayMode(DisplayMode.PrintLayout);
                da = new MySqlDataAdapter("SELECT * FROM kiralama where szlsmno=" + faturasozlesmeno + "", baglanti);
                ds = new DataSet();
                baglanti.Open();
                da.Fill(ds, "kiralama");
                kiralamaBindingSource.DataSource = ds;
                baglanti.Close();
                this.reportViewer2.RefreshReport();
            }
        }
    }
}
