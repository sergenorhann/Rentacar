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
    public partial class UserControl1 : UserControl
    {
        //----------------------------------------------------------------------------------------------------
        public UserControl1()
        {
            InitializeComponent();
        }        
//----------------------------------------------------------------------------------------------------
        int dir = 1;
//---------------------------------------------------------------------------------------------------- 
        Class1 GenelClass = new Class1();
//---------------------------------------------------------------------------------------------------- ALT PROGRAM
     /*   void renkayari()
        {
            GenelClass.Renkuret();
            bunifuCircleProgressbar1.ProgressColor = Class1.renk;
        }*/
//---------------------------------------------------------------------------------------------------- TİMER
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bunifuCircleProgressbar1.Value == 90)
            {
                dir = -1;
                bunifuCircleProgressbar1.animationIterval = 4;
               // renkayari();
            }
            if (bunifuCircleProgressbar1.Value == 10)
            {
                dir = +1;
                bunifuCircleProgressbar1.animationIterval = 2;
                //renkayari();
            }
            bunifuCircleProgressbar1.Value += dir;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        //----------------------------------------------------------------------------------------------------

    }
}