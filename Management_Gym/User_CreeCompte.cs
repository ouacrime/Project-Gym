using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Management_Gym
{
    public partial class User_CreeCompte : UserControl
    {

        public User_CreeCompte()
        {
            InitializeComponent();
        }
        string testobligatoir()
        {
            if (txtemail.Text == ""  || txtemail.Text== "Email")
            {
                return "Entre l'email de salle";
            }
            if (txtnomutilisateur.Text == "" || txtnomutilisateur.Text == "Nom Utilisateur")
            {
                return "Entre le nom utilisateur";
            }
            if (txtnomsalle.Text == "" || txtnomsalle.Text == "Nom Salle")
            {
                return "Entre le nom de salle";
            }
            if (txtmotdepasse.Text == "" || txtmotdepasse.Text == "Mot De Passe")
            {
                return "Entre Mot de passe";
            }
            if(txtemail.Text != "" || txtemail.Text != "Email")
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







        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtemail.Text == "Email")
            {
                txtemail.Text = "";
                txtemail.ForeColor = Color.WhiteSmoke;//changer le coulour 
            }
        }
        
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtemail.Text == "")
            {
                txtemail.Text = "Email";
                txtemail.ForeColor = Color.Gray;
            }
        }

        private void txtnomutilisateur_Leave(object sender, EventArgs e)
        {
            if (txtnomutilisateur.Text == "")
            {
                
                txtnomutilisateur.Text = "Nom Utilisateur";
                txtnomutilisateur.ForeColor = Color.Gray;
            }
        }

        private void txtnomutilisateur_Enter(object sender, EventArgs e)
        {
            if (txtnomutilisateur.Text == "Nom Utilisateur")
            {
                txtnomutilisateur.Text = "";
                txtnomutilisateur.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtnomsalle_Enter(object sender, EventArgs e)
        {
            if (txtnomsalle.Text == "Nom Salle")
            {
                txtnomsalle.Text = "";
                txtnomsalle.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtnomsalle_Leave(object sender, EventArgs e)
        {
            if (txtnomsalle.Text == "")
            {
                txtnomsalle.Text = "Nom Salle";
                txtnomsalle.ForeColor = Color.Gray;
            }
        }

        private void txtmotdepasse_Enter(object sender, EventArgs e)
        {
            if (txtmotdepasse.Text == "Mot De Passe")
            {

                txtmotdepasse.Text = "";
                txtmotdepasse.PasswordChar = '*';
                txtmotdepasse.ForeColor = Color.WhiteSmoke;
            }
        }

        private void btnajouter_Click(object sender, EventArgs e)
        {
            //if(testobligatoir()!=null)
            //{
            //    MessageBox.Show(testobligatoir(), "Obligatoire",MessageBoxButtons.OK,MessageBoxIcon.Error);
            //}
            //else
            //{
            //    DBSalle Tbsalle = new DBSalle();
            //        if (Tbsalle.ajouter_salle(txtemail.Text, txtnomutilisateur.Text, txtnomsalle.Text, txtmotdepasse.Text) == true)
            //        {
            //            MessageBox.Show("Compte ajouter avec sucess", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //            this.ParentForm.Close();
            //            Menu m = new Menu();
            //            Login l = new Login(m);
            //            l.Show();
            //    }
            //        else
            //        {
            //            MessageBox.Show("nom de salle et nom utilisateur deja existant", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
                
            //}
        }


        private void closebox_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
            Menu m = new Menu();
            Login l = new Login(m);
            l.Show();

        }

       
    }
}
