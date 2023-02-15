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
    public partial class UserControl_addmember : UserControl
    {
        public int idsalle;

        GestionGymEntities GG;
        TC.DbMembere tbmembere = new TC.DbMembere();
        public UserControl_addmember()
        {
            InitializeComponent();
            GG = new GestionGymEntities();
        }
        private static UserControl_addmember controle_addmember;
        //cree un instance pour usercontrol==>controle_member
        public static UserControl_addmember Instance
        {
            get
            {
                if (controle_addmember == null)
                {
                    controle_addmember = new UserControl_addmember();
                }
                return controle_addmember;

            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
        string testobligatoir()
        {
            if (cmbsport.Text == "")
            {
                return "Dicter le domaine du sport ";
            }
            if (txtnom.Text == "")
            {
                return "Entre nom";
            }
            if (txtprenom.Text == "")
            {
                return "Entre prenom";
            }
            if (txtnumerotele.Text == "" )
            {
                return "Entre numero ";
            }


            return null;
        }

        public void remplircombobox()
        {
            cmbsport.DisplayMember = "nom";
            cmbsport.ValueMember = "id";
            cmbsport.DataSource = GG.sports.Select(s => new { id = s.id_sport, nom = s.nom_sport }).ToList();

        }
        public void vide()
        {
            txtnom.Text = txtprenom.Text = txtnumerotele.Text = TXTID.Text = cmbsport.Text = txtduree.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sexe = "";

            if (rdfemme.Checked == true)
            {
                sexe = rdfemme.Text;
            }
            else
            {
                sexe = rdhomme.Text;
            }
            if (testobligatoir() != null)
            {

                MessageBox.Show(testobligatoir(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            else
            {

                if (tbmembere.ajouter_membere(txtnom.Text, txtprenom.Text, Convert.ToDateTime(dtnais.Text), txtnumerotele.Text, sexe, int.Parse(TXTID.Text), cmbsport.Text, Convert.ToDateTime(dtdebut.Text), int.Parse(txtduree.Text), int.Parse(label13.Text),tbmembere.IdAdmin()) == true)
                {
                    MessageBox.Show("Membere ajouter avec sucess", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DialogResult dr = MessageBox.Show("Voulez-vous imprimer ce nouvel abonné", "imprimer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        etatimprima ei = new etatimprima();
                        ei.name = txtnom.Text;
                        ei.prenom = txtprenom.Text;
                        ei.sexe = sexe;
                        if (cmbsport.SelectedIndex == -1)
                            ei.sport = "";
                        else
                            ei.sport = cmbsport.Text;

                        ei.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("imprimer est annule", "imprimer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    vide();
                }
                else
                {
                    MessageBox.Show("Membere deja existant", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public string value { get; set; }

        private void UserControl_addmember_Load(object sender, EventArgs e)
        {
            remplircombobox();
        }
       

        private void txtduree_TextChanged(object sender, EventArgs e)
        {
            TC.DbMembere tbmembere = new TC.DbMembere();
            double prix = tbmembere.Getprixchoisport(cmbsport.Text);
            if (txtduree.Text == "")
                label13.Text = "0";
            else
                label13.Text = (int.Parse(txtduree.Text) * prix).ToString();
        }

        private void txtduree_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbmembere.onlynumber(e);
        }

        private void txtnumerotele_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbmembere.onlynumber(e);
        }

        private void TXTID_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbmembere.onlynumber(e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
