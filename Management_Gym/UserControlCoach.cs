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
    public partial class UserControlCoach : UserControl
    {
        public int idsalle;
        public UserControlCoach()
        {
            InitializeComponent();
        }
        private static UserControlCoach controle_coach;
        //cree un instance pour usercontrol==>controle_member
        public static UserControlCoach Instance
        {
            get
            {
                if (controle_coach == null)
                {
                    controle_coach = new UserControlCoach();
                }
                return controle_coach;

            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            UserControlAddCoach uca = new UserControlAddCoach();
            uca.idsalle = idsalle;
            MainControlClasse.ShowControl(uca, panel6);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UserControlModCoach ucm = new UserControlModCoach();
            ucm.idsalle = idsalle;
            MainControlClasse.ShowControl(ucm, panel6);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            UserControlAfficherCoach ucac = new UserControlAfficherCoach();
            ucac.idsalle = idsalle;
            MainControlClasse.ShowControl(ucac, panel6);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            UserControlSupCaoch ucsc = new UserControlSupCaoch();
            ucsc.idsalle = idsalle;
            MainControlClasse.ShowControl(ucsc, panel6);
        }

    }
}
