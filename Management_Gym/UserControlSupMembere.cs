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
    public partial class UserControlSupMembere : UserControl
    {
        public int idsalle;
        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
        private SqlCommand cmd;
        public UserControlSupMembere()
        {
            InitializeComponent();
        }

        private void UserControlSup_Load(object sender, EventArgs e)
        {
            Actualisedatagrid();
        }
        public void Actualisedatagrid()
        {
            try
            {

                DGVM.Rows.Clear();

                string sql = "select prenom,nom,datenaissence,telephone,sexe,id_membere from membere where idsalle ='"+idsalle+"'";
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DGVM.Rows.Add(rd[0], rd[1], rd[2], rd[3], rd[4],rd[5]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("voulez-vous vraiment supremer le Membere", "Suppremer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                TC.DbMembere dbMembere = new TC.DbMembere();
                dbMembere.supp_sport(int.Parse(txtid.Text));
                MessageBox.Show("Membere Suppremer avec sucess", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Actualisedatagrid();
            }
            else
            {
                MessageBox.Show("Suppremer est annule", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void DGVM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVM.Rows[e.RowIndex];
                txtid.Text = row.Cells[5].Value.ToString();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                                      idmember = m.id_membere
                                  }).ToList();
            if (textBox5.Text != "")
            {
                if (radioButton3.Checked == true)
                {
                    listrechercher = listrechercher.Where(s => s.Nom.IndexOf(textBox5.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();

                }

            }

            DGVM.Rows.Clear();
            foreach (var l in listrechercher)
            {
                DGVM.Rows.Add(l.Prenom, l.Nom, l.DateN, l.Tele, l.Sexe, l.idmember);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
        }
    }
}
