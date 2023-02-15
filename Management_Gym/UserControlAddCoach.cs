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
    public partial class UserControlAddCoach : UserControl
    {
        public int idsalle;
        GestionGymEntities db = new GestionGymEntities();
        TC.DbMembere dbMembere = new TC.DbMembere();
        public UserControlAddCoach()
        {
            InitializeComponent();
        }

        string testobligatoir()
        {
            if (txtnom.Text == "" )
            {
                return "Entre nom ";
            }
            if (txtprenom.Text == "" )
            {
                return "Entre le prenom utilisateur";
            }
            if (cmbsport.Text == "" )
            {
                return "choisier le sport de salle";
            }
            if (txtnumero.Text == "")
            {
                return "Entre numero ";
            }
            if (rdhomme.Checked == false && rdfemme.Checked == false)
            {
                return "cheke le sexe ";
            }



            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (testobligatoir() != null)
            {
                MessageBox.Show(testobligatoir(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
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
                TC.DbCoach Tbcoach = new TC.DbCoach();
                if (Tbcoach.ajouter_couche(txtnom.Text,txtprenom.Text,txtnumero.Text,sexe,cmbsport.Text) == true)
                {
                    MessageBox.Show("coach ajouter avec sucess", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("coach deja existant", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        public void remplircombobox()
        {
            cmbsport.DisplayMember = "nom";
            cmbsport.ValueMember = "id";
            cmbsport.DataSource = db.offrirs.Where((s => s.numsalle == (idsalle))).Select(b => new { id = b.salle.id_salle, nom = b.sport.nom_sport }).ToList();
        }

        private void cmbsport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UserControlAddCoach_Load(object sender, EventArgs e)
        {
            remplircombobox();
        }

        private void txtnumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbMembere.onlynumber(e);
        }
    }
}
