using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Gym
{
    public partial class UserControlChangePassword : UserControl
    {
        DBSalle dBSalle = new DBSalle();
        public UserControlChangePassword()
        {
            InitializeComponent();
        }
        string testobligatoir()
        {
            if (txtemail.Text == "" || txtemail.Text == "Email")
            {
                return "Entre l'email de salle";
            }
            if (txtusername.Text == "" )
            {
                return "Entre le nom utilisateur";
            }
            if (txtpass.Text == "" )
            {
                return "Entre Mot de passe";
            }
            if ( txtconfig.Text == "")
            {
                return "Entre Mot de passe";
            }
            if (txtemail.Text != "" || txtemail.Text != "Email")
            {
                try
                {
                    new MailAddress(txtemail.Text);//pour verifier email si valid ou non
                }
                catch
                {
                    return "Email invalide";
                }
            }


            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (testobligatoir() != null)
            {
                MessageBox.Show(testobligatoir(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if(txtpass.Text != txtconfig.Text)
                {
                    MessageBox.Show("ne pas le meme mot de passe", "Verifier", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    if (dBSalle.changeapssword(txtemail.Text, txtusername.Text, txtpass.Text) == true)
                    {
                        MessageBox.Show("Mot de passe change avec sucess", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txtconfig.Text = txtemail.Text = txtpass.Text = txtusername.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("nom de salle et nom utilisateur pas existant dans", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    } 
}

