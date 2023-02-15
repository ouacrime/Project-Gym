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
    public partial class UserControlStatistique : UserControl
    {
        public UserControlStatistique()
        {
            InitializeComponent();
        }

        GestionGymEntities GG = new GestionGymEntities();
        TC.Dbhome dbhome = new TC.Dbhome();

        private static UserControlStatistique controlehome;
        //cree un instance pour usercontrol==>controle_member
        public static UserControlStatistique Instance
        {
            get
            {
                if (controlehome == null)
                {
                    controlehome = new UserControlStatistique();
                }
                return controlehome;

            }
        }



        public void remplircombobox(ComboBox cb)
        {
            cb.DisplayMember = "nom";
            cb.ValueMember = "id";
            cb.DataSource = GG.sports.Select(s => new { id = s.id_sport, nom = s.nom_sport }).ToList();
        }
        public void actulaiser()
        {
            remplircombobox(comboBox1);
            remplircombobox(comboBox3);

            label9.Text = dbhome.Getprixauouj().ToString();
            label7.Text = dbhome.Getinactivemember().ToString();
            label3.Text = dbhome.Getactivemember().ToString();
            label5.Text = dbhome.Getsport().ToString();
            label2.Text = dbhome.Getmember().ToString();
            label11.Text = dbhome.Getprixmois().ToString();
            for (int i = 2020; i <= DateTime.Now.Year; i++)
            {
                comboBox2.Items.Add(i);
            }

        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label13.Text = dbhome.Getprixsport(comboBox1.Text).ToString();
        }

        private void UserControlStatistique_Load(object sender, EventArgs e)
        {
            actulaiser();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            actulaiser();
            label13.Text = dbhome.Getprixsport(comboBox1.Text).ToString();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            label15.Text = dbhome.Getprixyear(int.Parse(comboBox2.Text)).ToString();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            label27.Text = dbhome.GetprixChoix(comboBox3.Text, Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text)).ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label27.Text = dbhome.GetprixChoix(comboBox3.Text, Convert.ToDateTime(dateTimePicker1.Text), Convert.ToDateTime(dateTimePicker2.Text)).ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
