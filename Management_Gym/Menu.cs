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
    public partial class Menu : Form
    {

        TC.Dbhome dbhome = new TC.Dbhome();
        public  int idsalle { get; set; }
        public int cont;
        public string nomsalle;


        public Menu()
        {
            InitializeComponent();
            panelcontien.Size = new Size(60, 535);
            panelparametre.Visible = false;

        }
        public void hidemenu()
        {
            this.Hide();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            DesactiveForm();
            panel4.Top = btnhome.Top;
            
        }

        public void value(string email,string mtp)
        {
            label1.Text = Convert.ToString(dbhome.IDValue(email,mtp));
            label2.Text = dbhome.NomSalleValue(email, mtp);
        }


       
        //desactive formulire
        public void DesactiveForm()
        {

            btnmember.Enabled = false;
            btnabonnement.Enabled = false;
            btncoach.Enabled = false;
            btnStatistique.Enabled = false;
            btndeconnecter.Enabled = false;
            pictureBox2.Enabled = false;
            btnchangepassword.Enabled = false;
            btnhome.Enabled = false;
            btnpackages.Enabled = false;
            btnconnecter.Enabled = true;
            btnutilisateur.Enabled = false;
            label1.Text = null;
            label2.Text = null;

        }
        //Active Form
        public void ActiveFor()
        {
            btnhome.Enabled = true;
            btnmember.Enabled = true;
            btnabonnement.Enabled = true;
            btncoach.Enabled = true;
            btnStatistique.Enabled = true;
            pictureBox2.Enabled = true;
            btnchangepassword.Enabled = true;
            btnpackages.Enabled = true;
            btnconnecter.Enabled = false;
            btndeconnecter.Enabled = true;
            btnutilisateur.Enabled = true;



        }
        //active form menu utilisateur
        public void activformutilisateur()
        {
            btnhome.Enabled = true;
            btnmember.Enabled = true;
            btnabonnement.Enabled = true;
        }




        //show usc home in load connecter
        public void showhome()
        {
            UserControlHome uch = new UserControlHome();
            MainControlClasse.ShowControl(uch, panelafficher);
        }
        //size panel afificher
        public void panelsize()
        {
           panelcontien.Size = new Size(194, 535);
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(panelcontien.Width == 194)
            {
                panel4.Visible = false;
                panelcontien.Size = new Size(60, 535);

            }
            else
            {
                panelcontien.Size =new Size(194, 535);
                panel4.Visible = true;

            }
        }

        private void btnmember_Click(object sender, EventArgs e)
        {
            btnmember.BackColor = Color.RoyalBlue;
            btnhome.BackColor = Color.Transparent;
            btnStatistique.BackColor = Color.Transparent;
            btnpackages.BackColor = Color.Transparent;
            btnStatistique.BackColor = Color.Transparent;
            btncoach.BackColor = Color.Transparent;
            btnabonnement.BackColor = Color.Transparent;
            btnutilisateur.BackColor = Color.Transparent;

            panel4.Top = btnmember.Top;


            UserControl_Members um = new UserControl_Members();
            um.idsalle = Convert.ToInt32(label1.Text);
            MainControlClasse.ShowControl(um, panelafficher);

            //if (!panelafficher.Controls.Contains(UserControl_Members.Instance))
            //{
            //    panelafficher.Controls.Add(UserControl_Members.Instance);
            //    UserControl_Members.Instance.Dock = DockStyle.Fill;
            //    UserControl_Members.Instance.BringToFront();
            //}
            //else
            //{
            //    UserControl_Members.Instance.BringToFront();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnabonnement.BackColor = Color.RoyalBlue;
            btnhome.BackColor = Color.Transparent;
            btnStatistique.BackColor = Color.Transparent;
            btnpackages.BackColor = Color.Transparent;
            btnStatistique.BackColor = Color.Transparent;
            btnmember.BackColor = Color.Transparent;
            btncoach.BackColor = Color.Transparent;
            btnutilisateur.BackColor = Color.Transparent;

            panel4.Top = btnabonnement.Top;
            if (!panelafficher.Controls.Contains(UserControlAbonnement.Instance))
            {
                panelafficher.Controls.Add(UserControlAbonnement.Instance);
                UserControlAbonnement.Instance.Dock = DockStyle.Fill;
                UserControlAbonnement.Instance.BringToFront();
            }
            else
            {
                UserControlAbonnement.Instance.BringToFront();
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {
            btncoach.BackColor = Color.RoyalBlue;
            btnhome.BackColor = Color.Transparent;
            btnStatistique.BackColor = Color.Transparent;
            btnpackages.BackColor = Color.Transparent;
            btnStatistique.BackColor = Color.Transparent;
            btnmember.BackColor = Color.Transparent;
            btnabonnement.BackColor = Color.Transparent;
            btnutilisateur.BackColor = Color.Transparent;

            panel4.Top = btncoach.Top;


            UserControlCoach um = new UserControlCoach();
            um.idsalle = Convert.ToInt32(label1.Text);
            MainControlClasse.ShowControl(um, panelafficher);

            //if (!panelafficher.Controls.Contains(UserControlCoach.Instance))
            //{
            //    panelafficher.Controls.Add(UserControlCoach.Instance);
            //    UserControlCoach.Instance.Dock = DockStyle.Fill;
            //    UserControlCoach.Instance.BringToFront();
            //}
            //else
            //{
            //    UserControlCoach.Instance.BringToFront();
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnStatistique.BackColor = Color.RoyalBlue;
            btnhome.BackColor = Color.Transparent;
            btnpackages.BackColor = Color.Transparent;
            btnmember.BackColor = Color.Transparent;
            btncoach.BackColor = Color.Transparent;
            btnabonnement.BackColor = Color.Transparent;
            btnutilisateur.BackColor = Color.Transparent;

            panel4.Top = btnStatistique.Top;

            if (!panelafficher.Controls.Contains(UserControlStatistique.Instance))
            {
                panelafficher.Controls.Add(UserControlStatistique.Instance);
                UserControlStatistique.Instance.Dock = DockStyle.Fill;
                UserControlStatistique.Instance.BringToFront();
            }
            else
            {
                UserControlStatistique.Instance.BringToFront();
            }
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            btnhome.BackColor = Color.RoyalBlue;
            btnStatistique.BackColor = Color.Transparent;
            btnpackages.BackColor = Color.Transparent;
            btnStatistique.BackColor = Color.Transparent;
            btnmember.BackColor = Color.Transparent;
            btncoach.BackColor = Color.Transparent;
            btnabonnement.BackColor = Color.Transparent;
            btnutilisateur.BackColor = Color.Transparent;



            panel4.Top = btnhome.Top;
            TC.Dbhome dbhome = new TC.Dbhome();
            dbhome.Getactivemember();
            dbhome.Getaddmember();
            dbhome.Getsport();
            if (!panelafficher.Controls.Contains(UserControlHome.Instance))
            {
                panelafficher.Controls.Add(UserControlHome.Instance);
                UserControlHome.Instance.Dock = DockStyle.Fill;
                UserControlHome.Instance.BringToFront();
            }
            else
            {
                UserControlHome.Instance.Dock = DockStyle.Fill;
                UserControlHome.Instance.BringToFront();
            }
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            panelparametre.Size = new Size(278, 157); 
            panelparametre.Visible = !panelparametre.Visible;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void btnchangepassword_Click(object sender, EventArgs e)
        {
            panelparametre.Visible = false;
            UserControlChangePassword uscp = new UserControlChangePassword();
            MainControlClasse.ShowControl(uscp, panelafficher);
        }

        private void btnconnecter_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login(this);
            lg.Show();
            panelparametre.Visible = false;
            

        }

        private void btndeconnecter_Click(object sender, EventArgs e)
        {
            DesactiveForm();
            panelparametre.Visible = false;
            panelafficher.Controls.Clear();
        }

        private void rJtoggeleButton2_CheckedChanged(object sender, EventArgs e)
        {

            panelparametre.Visible = false;
            if (tooglebox.Checked)
            {
                panelcontien.BackColor = Color.FromArgb(235, 230, 216); 
                btnmember.BackColor = Color.FromArgb(235, 230, 216);
                btncoach.BackColor = Color.FromArgb(235, 230, 216); ;
                btnabonnement.BackColor = Color.FromArgb(235, 230, 216);
                btnStatistique.BackColor = Color.FromArgb(235, 230, 216);
                btnhome.BackColor = Color.FromArgb(235, 230, 216);
                //panelparametre.BackColor = Color.SkyBlue;
                panelafficher.BackColor = Color.Gray;

                btnmember.ForeColor = Color.FromArgb(41, 40, 40);
                btnpackages.ForeColor = Color.FromArgb(41, 40, 40);
                btncoach.ForeColor = Color.FromArgb(41, 40, 40);
                btnabonnement.ForeColor = Color.FromArgb(41, 40, 40);
                btnStatistique.ForeColor = Color.FromArgb(41, 40, 40);
                labelidsalle.ForeColor = Color.FromArgb(41, 40, 40);
                labelnomesalle.ForeColor = Color.FromArgb(41, 40, 40);
                btnhome.ForeColor = Color.FromArgb(41, 40, 40);
                pictureBox2.BackColor = Color.FromArgb(235, 230, 216);

            }
            else
            {
                panelcontien.BackColor = Color.FromArgb(160, 160, 160);
                btnmember.BackColor = Color.FromArgb(160, 160, 160);
                btncoach.BackColor = Color.FromArgb(160, 160, 160);
                btnabonnement.BackColor = Color.FromArgb(160, 160, 160);
                btnStatistique.BackColor = Color.FromArgb(160, 160, 160);
                btnhome.BackColor = Color.FromArgb(160, 160, 160);

                btnmember.ForeColor = Color.FromArgb(237, 235, 235);
                btncoach.ForeColor = Color.FromArgb(237, 235, 235);
                btnabonnement.ForeColor = Color.FromArgb(237, 235, 235);
                btnStatistique.ForeColor = Color.FromArgb(237, 235, 235);
                btnhome.ForeColor = Color.FromArgb(237, 235, 235);
                labelidsalle.ForeColor = Color.FromArgb(237, 235, 235);
                labelnomesalle.ForeColor = Color.FromArgb(237, 235, 235);
                pictureBox2.BackColor = Color.FromArgb(160, 160, 160);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            btnpackages.BackColor = Color.RoyalBlue;
            btnhome.BackColor = Color.Transparent;
            btnStatistique.BackColor = Color.Transparent;
            btnStatistique.BackColor = Color.Transparent;
            btnmember.BackColor = Color.Transparent;
            btncoach.BackColor = Color.Transparent;
            btnabonnement.BackColor = Color.Transparent;
            btnutilisateur.BackColor = Color.Transparent;
            panel4.Top = btnpackages.Top;





            UserControlSport us = new UserControlSport();
            us.idsalle = Convert.ToInt32(label1.Text);
            MainControlClasse.ShowControl(us, panelafficher);
            //if (!panelafficher.Controls.Contains(UserControlSport.Instance))
            //{
            //    panelafficher.Controls.Add(UserControlSport.Instance);
            //    UserControlSport.Instance.Dock = DockStyle.Fill;
            //    UserControlSport.Instance.BringToFront();
            //}
            //else
            //{
            //    UserControlSport.Instance.BringToFront();
            //}
        }


        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.Silver;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.FromArgb(0, 102, 204);
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.Red;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.FromArgb(0, 102, 204);
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            btnutilisateur.BackColor = Color.RoyalBlue;
            btnmember.BackColor = Color.Transparent;
            btnhome.BackColor = Color.Transparent;
            btnStatistique.BackColor = Color.Transparent;
            btnpackages.BackColor = Color.Transparent;
            btnStatistique.BackColor = Color.Transparent;
            btncoach.BackColor = Color.Transparent;
            btnabonnement.BackColor = Color.Transparent;
            panel4.Top = btnutilisateur.Top;



            UserControlUtilisateur um = new UserControlUtilisateur();
            um.nomsalle = label2.Text;
            um.idsalle = Convert.ToInt32(label1.Text);
            MainControlClasse.ShowControl(um, panelafficher);


            //if (!panelafficher.Controls.Contains(UserControlUtilisateur.Instance))
            //{
            //    panelafficher.Controls.Add(UserControlUtilisateur.Instance);
            //    UserControlUtilisateur.Instance.Dock = DockStyle.Fill;
            //    UserControlUtilisateur.Instance.BringToFront();
            //}
            //else
            //{
            //    UserControlUtilisateur.Instance.BringToFront();
            //}

        }
    }
}
