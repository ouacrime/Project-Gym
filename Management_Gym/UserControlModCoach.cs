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
    public partial class UserControlModCoach : UserControl
    {
        public int idsalle;
        public UserControlModCoach()
        {
            InitializeComponent();
        }
        public void Actualisedatagrid()
        {
            try
            {

                DGVM.Rows.Clear();
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
                string sql = "select id_coach,nom,prenom,numero,coach.nom_sport,sexe from coach inner join sport on coach.id_coach = sport.idcoach inner join offrir on offrir.numsport = sport.id_sport where numsalle ='"+idsalle+"'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DGVM.Rows.Add(rd[0], rd[1], rd[2], rd[3],rd[4],rd[5]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            DialogResult dr = MessageBox.Show("voulez-vous vraiment modifier le coach", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (dr == DialogResult.Yes)
            {
                TC.DbCoach dbcoach = new TC.DbCoach();
                dbcoach.modifier_coach(Convert.ToInt32(txtid.Text), txtnom.Text, txtprenom.Text,txtnumero.Text,sexe);
                MessageBox.Show("coach modifier avec sucess", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Actualisedatagrid();
            }
            else
            {
                MessageBox.Show("Modification est annule", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UserControlModCoach_Load(object sender, EventArgs e)
        {
            Actualisedatagrid();
        }

        private void DGVM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVM.Rows[e.RowIndex];
                txtid.Text = row.Cells[0].Value.ToString();
                txtnom.Text = row.Cells[1].Value.ToString();
                txtnumero.Text = row.Cells[3].Value.ToString();
                txtprenom.Text = row.Cells[2].Value.ToString();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            GestionGymEntities dbgym = new GestionGymEntities();
            var listrechercher = dbgym.coaches.ToList();
            if (textBox5.Text != "")
            {
                if(radioButton3.Checked == true)
                {
                    listrechercher = listrechercher.Where(s => s.nom.IndexOf(textBox5.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
                }
                else
                listrechercher = listrechercher.Where(s => s.nom_sport.IndexOf(textBox5.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            }
            DGVM.Rows.Clear();

            foreach (var l in listrechercher)
            {
                DGVM.Rows.Add(l.id_coach,l.nom, l.prenom,l.numero, l.nom_sport, l.sexe);
            }
        }
    }
}
