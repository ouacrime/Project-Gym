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
    public partial class UserControl_Members : UserControl
    {
        public int idsalle;
        public UserControl_Members()
        {
            InitializeComponent();
        }

        private static UserControl_Members controle_member;
        //cree un instance pour usercontrol==>controle_member
        public static UserControl_Members Instance
        {
            get{
                if(controle_member == null)
                {
                    controle_member = new UserControl_Members();
                }
                return controle_member;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            UserControl_addmember uca = new UserControl_addmember();
            uca.idsalle = idsalle;
            MainControlClasse.ShowControl(uca, panel1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UserControlModiferMember ucm = new UserControlModiferMember();
            ucm.idsalle = idsalle;
            MainControlClasse.ShowControl(ucm, panel1);
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

            UserControlFicheMember ucf = new UserControlFicheMember();
            ucf.idsalle = idsalle;
            MainControlClasse.ShowControl(ucf, panel1);

            //if (!panel1.Controls.Contains(UserControlFicheMember.Instance))
            //{
            //    panel1.Controls.Add(UserControlFicheMember.Instance);
            //    UserControlFicheMember.Instance.Dock = DockStyle.Fill;
            //    UserControlFicheMember.Instance.BringToFront();
            //}
            //else
            //{
            //    UserControlFicheMember.Instance.Dock = DockStyle.Fill;
            //    UserControlFicheMember.Instance.BringToFront();
            //}
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            UserControlSupMembere ucs = new UserControlSupMembere();
            ucs.idsalle = idsalle;
            MainControlClasse.ShowControl(ucs, panel1);
        }
    }
}
