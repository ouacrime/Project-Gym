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
    public partial class UserControlSupCaoch : UserControl
    {
        public int idsalle;
        public UserControlSupCaoch()
        {
            InitializeComponent();
        }
        public void Actualisedatagrid()
        {
            try
            {

                DGVM.Rows.Clear();
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
                string sql = "select id_coach,nom,prenom,numero,sexe,coach.nom_sport from coach inner join sport on sport.idcoach = coach.id_coach inner join offrir on offrir.numsport = sport.id_sport where numsalle ='"+idsalle+"' ";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DGVM.Rows.Add(rd[0], rd[1], rd[2], rd[3], rd[4], rd[5]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UserControlSupCaoch_Load(object sender, EventArgs e)
        {
            Actualisedatagrid();
            txtnamesport.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtnamesport.Text != null )
            {
                DialogResult dr = MessageBox.Show("voulez-vous vraiment Supprimer le coach", "SUP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    TC.DbCoach dbCoach = new TC.DbCoach();
                    if (dbCoach.verifercoach(txtnamesport.Text) == 0)
                    {

                        dbCoach.supp_coach(txtnamesport.Text);
                        MessageBox.Show("coach Supprimer avec sucess", "Sup", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Actualisedatagrid();
                    }
                    else
                    {
                        MessageBox.Show("you cant remove coach ", "Sup", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("Supprimer est annule", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            GestionGymEntities dbgym = new GestionGymEntities();
            var listrechercher = dbgym.coaches.ToList();//offrirs.ToList();
            if (txtnamesport.Text != "")
            {
                if (radioButton3.Checked == true)
                {
                    listrechercher = listrechercher.Where(s => s.nom_sport.IndexOf(txtnamesport.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();

                }
            }
            DGVM.Rows.Clear();
            foreach (var l in listrechercher)
            {

                DGVM.Rows.Add(l.id_coach,l.nom, l.prenom, l.numero, l.nom_sport, l.sexe);
            }
        }

        private void DGVM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVM.Rows[e.RowIndex];
                txtnamesport.Text = row.Cells[5].Value.ToString();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtnamesport.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
