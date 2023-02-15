using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_Gym
{
    public partial class UserControlAbonnement : UserControl
    {
        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
        private SqlCommand cmd;
        GestionGymEntities GG;
        TC.DbMembere dbMembere = new TC.DbMembere();

        public UserControlAbonnement()
        {
            InitializeComponent();
            GG = new GestionGymEntities();
        }
        public void remplircombobox()
        {
            cmbsport.DisplayMember = "nom";
            cmbsport.ValueMember = "id";
            cmbsport.DataSource = GG.sports.Select(s => new { id = s.id_sport, nom = s.nom_sport }).ToList();

        }
        public void Actualisedatagrid()
        {
            try
            {

                DGVM.Rows.Clear();



                cmd = new SqlCommand("spGetfichierRenouvell", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DGVM.Rows.Add(rd[0], rd[1], rd[2], rd[3], rd[4], rd[5], rd[6], rd[7]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private static UserControlAbonnement controlehome;
        //cree un instance pour usercontrol==>controle_member
        public static UserControlAbonnement Instance
        {
            get
            {
                if (controlehome == null)
                {
                    controlehome = new UserControlAbonnement();
                }
                return controlehome;

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("voulez-vous vraiment Renouveller Abonnement le Membere", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                dbMembere.Renouvelleabonnement(int.Parse(txtidmember.Text), int.Parse(txtidsport.Text), int.Parse(txtidabonnement.Text), cmbsport.Text, Convert.ToDateTime(datedebut.Text), int.Parse(txtduree.Text), int.Parse(label6.Text));
                MessageBox.Show("Membere Renouvelle avec sucess", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Actualisedatagrid();
            }
            else
            {
                MessageBox.Show("Modification est annule", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UserControlAbonnement_Load(object sender, EventArgs e)
        {
            Actualisedatagrid();
            remplircombobox();
        }

        private void DGVM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVM.Rows[e.RowIndex];
                cmbsport.Text = row.Cells[2].Value.ToString();
                txtduree.Text = row.Cells[3].Value.ToString();
                txtprix.Text = row.Cells[4].Value.ToString();
                txtidsport.Text = row.Cells[5].Value.ToString();
                txtidmember.Text = row.Cells[7].Value.ToString();
                txtidabonnement.Text = row.Cells[6].Value.ToString();
            }
        }

        private void cmbsport_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtidsport.Text = cmbsport.SelectedValue.ToString();
            TC.DbMembere tbmembere = new TC.DbMembere();
            double prix = tbmembere.Getprixchoisport(cmbsport.Text);
            txtprix.Text = prix.ToString();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                cmbsport.Enabled = true;
            }
            else
                cmbsport.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Actualisedatagrid();
        }

        private void txtduree_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbMembere.onlynumber(e);
        }

        private void txtprix_KeyPress(object sender, KeyPressEventArgs e)
        {
            dbMembere.onlynumber(e);
        }

        private void txtduree_TextChanged(object sender, EventArgs e)
        {

            if(txtprix.Text !="" && txtduree.Text != "")
                label6.Text = (Convert.ToInt32(txtduree.Text) * Convert.ToInt32(txtprix.Text)).ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            TC.DbMembere dbMembere = new TC.DbMembere();
            GestionGymEntities dbgym = new GestionGymEntities();

            int x = dbMembere.IdAdmin();

            var listrechercher = (from m in dbgym.memberes

                                  join p in dbgym.participers

                                  on m.id_membere equals p.idmembere
                                  join s in dbgym.sports
                                  on p.idsport equals s.id_sport
                                  join abon in dbgym.abonners
                                  on m.id_membere equals abon.idmembere
                                  join sal in dbgym.salles
                                  on m.idsalle equals sal.id_salle
                                  join ty in dbgym.type_abonnement
                                  on abon.idabonnement equals ty.id_abonnement
                                  where m.idsalle == x
                                  select new
                                  {
                                      Nom = m.nom,
                                      Prenom = m.prenom,
                                      Nomsport = s.nom_sport,
                                      mois = ty.duree
                                  }).ToList();
            if (textBox5.Text != "")
            {
                if (radioButton3.Checked == true)
                {
                    listrechercher = listrechercher.Where(s => s.mois == 0 && s.Nom.IndexOf(textBox5.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();

                }

            }

            DGVM.Rows.Clear();
            foreach (var l in listrechercher)
            {
                if(l.mois == 0)
                DGVM.Rows.Add(l.Prenom, l.Nom, l.Nomsport, l.mois);
            }
        }
    }
}
