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
    public partial class Login : Form
    {
        private GestionGymEntities db;
       
        Menu formmenu;
        //classe connexion
        DBconexion c = new DBconexion();

        public Login(Menu menu )
        {
            InitializeComponent();
            //initialisationbasse de donne
            db = new GestionGymEntities();
            
            this.formmenu = menu;
            this.txtmotdepasse.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnter);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        string testobligatoire()
        {
            if (txtemail.Text == "Email" || txtemail.Text == "")
            {
                return "Email";
            }
            if (txtmotdepasse.Text == "Mot de Passe" || txtmotdepasse.Text == "")
            {
                return "Entrer votre Mot De Passe";
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
            //si l'utilisateur est entrer son nom et son mot de passe
            return null;
        }

        

        
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            

            if (e.KeyChar == (char)Keys.Enter)
            {
                btnconnexion_Click_1(sender,e);
            }
            if (e.KeyChar == 13)
            {
                btnconnexion_Click_1(sender, e);
            }
        }
        
        

        private void linkforgetpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword fp = new ForgotPassword();
            fp.Show();
            this.Hide();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_CreeCompte usc = new User_CreeCompte();
            MainControlClasse.ShowControl(usc, panel3);
        }

        private void linkforgetpassword_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgotPassword fp = new ForgotPassword();
            fp.Show();
        }

        private void txtemail_Enter(object sender, EventArgs e)
        {
            //pour vider le TextBox
            if (txtemail.Text == "Email")
            {
                txtemail.Text = "";
                txtemail.BackColor = Color.White;
                txtemail.ForeColor = Color.Black;//changer le coulour 
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (txtemail.Text == "")
            {
                txtemail.Text = "Email";
                txtemail.ForeColor = Color.Silver;
            }
        }

        private void txtmotdepasse_Leave(object sender, EventArgs e)
        {
            if (txtmotdepasse.Text == "")
            {
                txtmotdepasse.Text = "Mot de Passe";
                txtmotdepasse.ForeColor = Color.Silver;
            }
        }

        private void txtmotdepasse_Enter(object sender, EventArgs e)
        {
            if (txtmotdepasse.Text == "Mot de Passe")
            {
                txtmotdepasse.Text = "";
                txtmotdepasse.UseSystemPasswordChar = false;
                txtmotdepasse.PasswordChar = '*';
                txtmotdepasse.BackColor = Color.White;
                txtmotdepasse.ForeColor = Color.Black;//changer le coulour 
            }
        }
        public string id;
        private void btnconnexion_Click_1(object sender, EventArgs e)
        {
            if (testobligatoire() == null)
            {
                if (c.conexion(db, txtemail.Text, txtmotdepasse.Text) == true)
                {

                    formmenu.value(txtemail.Text, txtmotdepasse.Text);
                    formmenu.cont = c.cont ;
                    Close();
                    if(c.cont == 1)
                    {
                        formmenu.ActiveFor();
                        formmenu.panelsize();
                        formmenu.showhome();
                        formmenu.Show();
                    }
                    if(c.cont == 0)
                    {
                        formmenu.activformutilisateur();
                        formmenu.panelsize();
                        formmenu.showhome();
                        formmenu.Show();

                    }



                }
                else
                {
                    MessageBox.Show("Compte n'éxiste pas", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show(testobligatoire(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Close();
            Menu m = new Menu();
            m.Show();
        }

        private void txtmotdepasse_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
