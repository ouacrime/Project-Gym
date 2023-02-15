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
    public partial class UserControlAfficherCoach : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
        SqlCommand cmd;
        public int idsalle;
        public UserControlAfficherCoach()
        {
            InitializeComponent();
            textBox5.Enabled = false;
        }

        private void UserControlAfficherCoach_Load(object sender, EventArgs e)
        {
            Actualisedatagrid();
        }
        public void Actualisedatagrid()
        {
            try
            {

                DGVM.Rows.Clear();
               
                string sql = "select nom,prenom,coach.nom_sport,sexe from coach inner join sport on coach.id_coach = sport.idcoach inner join offrir on offrir.numsport = sport.id_sport where numsalle =+'" + idsalle + "' ";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DGVM.Rows.Add(rd[0], rd[1], rd[2], rd[3]);
                }
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGVM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    dgvmembere.Rows.Clear();
                    string sport;
                    string sql;
                    DataGridViewRow row = this.DGVM.Rows[e.RowIndex];
                    sport = row.Cells[2].Value.ToString();
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
                    sql = "select prenom,nom,telephone,sexe from membere where id_membere in (select idmembere from participer inner join sport on sport.id_sport = participer.idsport inner join offrir on offrir.numsport = sport.id_sport where nom_sport = '"+sport+"' and  numsalle = '"+idsalle+"')";

                    con.Open();
                    cmd = new SqlCommand(sql, con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        dgvmembere.Rows.Add(rd[0], rd[1], rd[2], rd[3]);
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            GestionGymEntities dbgym = new GestionGymEntities();
            var listrechercher = dbgym.coaches.ToList();

            //var listrechercher = dbgym.offrirs.Join(dbgym.sports, offrire => offrire.numsport, sport => sport.id_sport,
            //    (offrire, sport) =>
            //new
            //{
            //    idsport = sport.id_sport,
            //    idcoach = sport.idcoach,
            //    idsalle = offrire.numsalle
            //}
            //    ).Join(dbgym.coaches, sport => sport.idcoach, coche => coche.id_coach,
            //    (sport, coach) =>
            //    new
            //    {
            //        idcoach = coach.id_coach,
            //        prenom = coach.prenom,
            //        nom = coach.nom,
            //        sexe = coach.sexe,
            //        nomsport = coach.nom_sport,
            //        idsport = sport.idsport

            //    }
            //    ).Where(c => c.idsport == idsalle).ToList();





            if (textBox5.Text != "")
            {
                listrechercher = listrechercher.Where(b => b.nom.IndexOf(textBox5.Text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            }
            DGVM.Rows.Clear();

            foreach(var l in listrechercher)
            {
                
                DGVM.Rows.Add(l.nom, l.prenom, l.nom_sport, l.sexe);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
            textBox5.Text = "";
        }
    }
}
