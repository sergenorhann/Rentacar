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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
        }

        private void AyarlarFB_Click(object sender, EventArgs e)
        {
        }





        /*

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(pictureBox1.Location.X + 10, pictureBox1.Location.Y);
            pictureBox1.Width -= 10;
            if (pictureBox1.Width <= 0)
            {
                //  bunifuGradientPanel1.BackColor = Color.FromArgb(120, 160, 237);
                pictureBox1.Location = new Point(bunifuFlatButton2.Location.X + 17, pictureBox1.Location.Y);
                pictureBox1.Width =0;
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y);
            pictureBox1.Width += 10;
            if (pictureBox1.Width > 90)
            {
                //pictureBox1.Location = new Point(bunifuFlatButton2.Location.X + 15, pictureBox1.Location.Y);
                timer2.Stop();
            }
        }
        */
        /*protected override CreateParams CreateParams
    {
    get
    {
        CreateParams cp = base.CreateParams;
        cp.ClassStyle |= 0x20000;
        return cp;
    }
    }*/
    }
}
