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
    public partial class UserControlModiferMember : UserControl
    {
        public int idsalle;
        TC.DbMembere dbMembere = new TC.DbMembere();
        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
        private SqlCommand cmd;
        GestionGymEntities GG;
        public UserControlModiferMember()
        {
            InitializeComponent();
            GG = new GestionGymEntities();
        }
        public void Actualisedatagrid()
        {
            try
            {

                DGVM.Rows.Clear();

                //string sql = "select prenom,nom,datenaissence,telephone,sexe,nom_sport,id_membere from membere inner join participer on idmembere = id_membere inner join sport on idsport = id_sport";

                if (idsalle == dbMembere.IdAdmin())
                {

                    cmd = new SqlCommand("spGetmember", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter p1 = new SqlParameter()
                    {
                        ParameterName = "@idsalle",
                        SqlDbType = SqlDbType.VarChar,
                        Value = idsalle,
                        Direction = ParameterDirection.Input
                    };
                    cmd.Parameters.Add(p1);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        DGVM.Rows.Add(rd[0], rd[1], rd[2], rd[3], rd[4], rd[5], rd[6], rd[7], rd[8], rd[9], rd[10], rd[11], rd[12]);
                    }
                    con.Close();
                }
                if(idsalle != dbMembere.IdAdmin())
                {
                    cmd = new SqlCommand("spGetmemberAJ", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter p1 = new SqlParameter()
                    {
                        ParameterName = "@idsalle",
                        SqlDbType = SqlDbType.VarChar,
                        Value = dbMembere.IdAdmin(),
                        Direction = ParameterDirection.Input
                    };
                    cmd.Parameters.Add(p1);
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        DGVM.Rows.Add(rd[0], rd[1], rd[2], rd[3], rd[4], rd[5], rd[6], rd[7], rd[8], rd[9], rd[10], rd[11], rd[12]);
                    }
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void remplircombobox()
        {
            cmbsport.DisplayMember = "nom";
            cmbsport.ValueMember = "id";
            cmbsport.DataSource = GG.sports.Select(s => new {id = s.id_sport, nom = s.nom_sport }).ToList();
        }
        private void UserControlModifer_Load(object sender, EventArgs e)
        {
            Actualisedatagrid();
            remplircombobox();
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
            DialogResult dr = MessageBox.Show("voulez-vous vraiment modifier le Membere", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                
                dbMembere.modifier_Member(int.Parse(txtid.Text), txtnom.Text, txtprenom.Text,Convert.ToDateTime(dtnais.Text), txtnumero.Text, sexe,cmbsport.Text, Convert.ToDateTime(dtdebut.Text), int.Parse(txtduree.Text),int.Parse(label13.Text),int.Parse(txtidabonnement.Text),int.Parse(txtidsport.Text));
                MessageBox.Show("Membere modifier avec sucess", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Actualisedatagrid();
            }
            else
            {
                MessageBox.Show("Modification est annule", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DGVM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVM.Rows[e.RowIndex];
                txtprenom.Text = row.Cells[0].Value.ToString();
                txtnom.Text = row.Cells[1].Value.ToString();
                dtnais.Text = row.Cells[2].Value.ToString();
                txtnumero.Text = row.Cells[3].Value.ToString();
                string sexe = row.Cells[4].Value.ToString();
                txtid.Text = row.Cells[6].Value.ToString();
                cmbsport.Text = row.Cells[5].Value.ToString();
                dtdebut.Text = row.Cells[7].Value.ToString();
                txtduree.Text = row.Cells[9].Value.ToString();
                label13.Text = row.Cells[10].Value.ToString();
                txtidsport.Text = row.Cells[12].Value.ToString();
                txtidabonnement.Text = row.Cells[11].Value.ToString();

                if (rdfemme.Text == sexe)
                {
                    rdfemme.Checked = true;
                }
                else
                {
                    rdhomme.Checked = true;
                }

            }
        }

        private void cmbsport_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtidsport.Text = cmbsport.SelectedValue.ToString();
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            rechercher();
        }






        public void rechercher()
        {
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
                                  join tyabon in dbgym.type_abonnement
                                  on abon.idabonnement equals tyabon.id_abonnement
                                  where m.idsalle == x
                                  select new
                                  {
                                      Nom = m.nom,
                                      Prenom = m.prenom,
                                      DateN = m.datenaissence,
                                      Tele = m.telephone,
                                      Sexe = m.sexe,
                                      Nomsport = s.nom_sport,
                                      Datef = abon.datefin,
                                      Dated = abon.datedebut,
                                      Mois = tyabon.duree,
                                      PRix = tyabon.tarifabonnement,
                                      IDmemeber = m.id_membere,
                                      idabonnement = abon.idabonnement,
                                      id_sport = s.id_sport
                                  }).ToList();
            if (textBox5.Text != "")
            {
                if (radioButton3.Checked == true)
                {

                    listrechercher = listrechercher.Where(s => s.Nom.IndexOf(textBox5.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();

                }
            }
            if (radioButton5.Checked == true)
            {
                listrechercher = listrechercher.Where(s => s.Sexe.IndexOf("HOMME", StringComparison.CurrentCultureIgnoreCase) != -1).ToList();

            }
            if (radioButton6.Checked == true)
            {
                listrechercher = listrechercher.Where(s => s.Sexe.IndexOf("FEMME", StringComparison.CurrentCultureIgnoreCase) != -1).ToList();

            }
            DGVM.Rows.Clear();
            foreach (var l in listrechercher)
            {
                DGVM.Rows.Add(l.Prenom, l.Nom, l.DateN, l.Tele, l.Sexe, l.Nomsport, l.IDmemeber, l.Dated, l.Datef, l.Mois, l.PRix, l.idabonnement, l.id_sport);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox5.Enabled = false;
            rechercher();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox5.Enabled = false;
            rechercher();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
        }
    }
}