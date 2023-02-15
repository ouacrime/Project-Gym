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
    public partial class UserControlFicheMember : UserControl
    {
        private SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
        private SqlCommand cmd;
        TC.DbMembere DbMembere = new TC.DbMembere();
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        public UserControlFicheMember()
        {
            InitializeComponent();
        }
        private static UserControlFicheMember controleFicherMember;
        //cree un instance pour usercontrol==>controle_member
        public static UserControlFicheMember Instance
        {
            get
            {
                if (controleFicherMember == null)
                {
                    controleFicherMember = new UserControlFicheMember();
                }
                return controleFicherMember;

            }
        }
       

        public int idsalle;
        GestionGymEntities dbgym = new GestionGymEntities();
        public void rechercher()
        {

            int x = DbMembere.IdAdmin();

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
                                      Datef = abon.datefin
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
                textBox5.Text = "";
                listrechercher = listrechercher.Where(s => s.Sexe.IndexOf("HOMME", StringComparison.CurrentCultureIgnoreCase) != -1).ToList();

            }
            if (radioButton6.Checked == true)
            {
                textBox5.Text = "";
                listrechercher = listrechercher.Where(s => s.Sexe.IndexOf("FEMME", StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            }
            

            DGVM.Rows.Clear();
            foreach (var l in listrechercher)
            {
                //"select prenom,membere.nom,datenaissence,telephone,sexe,nom_sport,datefin from membere inner join participer on idmembere = id_membere inner join sport on idsport = id_sport inner join salle on id_salle = idsalle inner join abonner on id_membere = abonner.idmembere where idsalle = '" + DbMembere.IdAdmin() + "' ";

                DGVM.Rows.Add(l.Prenom, l.Nom, l.DateN, l.Tele, l.Sexe, l.Nomsport, l.Datef);
            }
            for (int i = 0; i < DGVM.Rows.Count; i++)
            {
                if (Convert.ToDateTime(DGVM.Rows[i].Cells[6].Value) < DateTime.Now)
                {
                    DGVM.Rows[i].Cells[6].Style.BackColor = Color.Red;
                }
                else
                {
                    DGVM.Rows[i].Cells[6].Style.BackColor = Color.Green;
                }

            }


        }

        public void Actualisedatagrid()
        {
            try
            {
                


                DGVM.Rows.Clear();
                string sql = "select prenom,membere.nom,datenaissence,telephone,sexe,nom_sport,datefin from membere inner join participer on idmembere = id_membere inner join sport on idsport = id_sport inner join salle on id_salle = idsalle inner join abonner on id_membere = abonner.idmembere where idsalle = '"+ DbMembere.IdAdmin()+"' ";
                
                con.Open();
                //ficher xml
                da = new SqlDataAdapter(sql, con);
                da.Fill(ds, "Member");
                //fin

                cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    DGVM.Rows.Add(rd[0], rd[1], rd[2], rd[3],rd[4],rd[5],rd[6]);
                }
                for(int i =0;i < DGVM.Rows.Count;i++)
                {
                    if( Convert.ToDateTime(DGVM.Rows[i].Cells[6].Value) < DateTime.Now   )
                    {
                        DGVM.Rows[i].Cells[6].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        DGVM.Rows[i].Cells[6].Style.BackColor = Color.Green;
                    }

                }

                con.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            rechercher();
        }

        private void UserControlFicheMember_Load(object sender, EventArgs e)
        {
            Actualisedatagrid();
        }

        private void DGVM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVM.Rows[e.RowIndex];
                lbnom.Text = row.Cells[1].Value.ToString();
                lbnumero.Text = row.Cells[3].Value.ToString();
                lbanne .Text = row.Cells[2].Value.ToString();
                lbsexe.Text = row.Cells[4].Value.ToString();
                lbsport.Text = row.Cells[5].Value.ToString();
                if(Convert.ToDateTime(row.Cells[6].Value) > DateTime.Now )
                {
                    btnchaeck.Visible = true;
                    btnchaeck.Text = "ACCEPTE";
                    btnchaeck.BackColor = Color.Green;
                }
                else
                {
                    btnchaeck.Visible = true;
                    btnchaeck.Text = "REFUSE";
                    btnchaeck.BackColor = Color.Red;
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DGVM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CrystalReport.FormCrystalReport fc = new CrystalReport.FormCrystalReport();
            fc.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds.WriteXml("Member.xml");
            ds.WriteXmlSchema("Member.xsd");
            MessageBox.Show("xml Enregistre avec succes", "XML", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ds.ReadXml("Member.xml");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommandBuilder ocmb1 = new SqlCommandBuilder(da);
            da.Update(ds, "Member");
            MessageBox.Show("Ficher xml maj avec succes", "XML", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            con.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = false;
            textBox5.Text = "";
            rechercher();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = false;
            textBox5.Text = "";
            rechercher();
        }
    }
}
