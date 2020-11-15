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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.StartupPath + "\\RentacarUpdate.exe");
            Application.Exit();
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            if(this.Height==240)
            {
                this.Height = 340;
                bunifuGradientPanel2.Height = 120;
                bunifuGradientPanel2.Visible = true;
            }
            else
            {
                bunifuGradientPanel2.Visible = false;
                this.Height = 240;
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            bunifuCustomLabel2.Text= "Sürümünüz: "+Program.versionCode;
        }
    }
}
