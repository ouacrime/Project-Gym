using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Gym
{
    public partial class UserControlHome : UserControl
    {
        TC.Dbhome dbhome = new TC.Dbhome();

        
        public UserControlHome()
        {
            InitializeComponent();
            actualiseget();
        }
        private static UserControlHome controlehome;
        //cree un instance pour usercontrol==>controle_member
        public static UserControlHome Instance
        {

            get
            {
                if (controlehome == null)
                {
                    controlehome = new UserControlHome();
                }
                return controlehome;

            }
        }
        public void actualiseget()
        {
            string activemember = Convert.ToString(dbhome.Getactivemember());
            string membereadd = Convert.ToString(dbhome.Getaddmember());
            string totalsport = Convert.ToString(dbhome.Getsport());
            label3.Text = activemember;
            label4.Text = membereadd;
            label6.Text = totalsport;
        }
        private void UserControlHome_Load(object sender, EventArgs e)
        {

            actualiseget();
                
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            actualiseget();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
