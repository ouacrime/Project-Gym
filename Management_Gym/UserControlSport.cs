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
    public partial class UserControlSport : UserControl
    {
        GestionGymEntities GG;
        public int idsalle;

        TC.DBsport dBsport = new TC.DBsport();


        public UserControlSport()
        {
            InitializeComponent();
            GG = new GestionGymEntities();
        }
        private static UserControlSport controlehome;
        //cree un instance pour usercontrol==>controle_member
        public static UserControlSport Instance
        {
            get
            {
                if (controlehome == null)
                {
                    controlehome = new UserControlSport();
                }
                return controlehome;

            }
        }
        string testobligatoir()
        {
            if (cmbsport.Text == "")
            {
                return "Dicter le domaine du sport ";
            }
            if (txtcategorie.Text == "")
            {
                return "Entre categorie";
            }
            if (txtcapacity.Text == "")
            {
                return "Entre le capacity de sport";
            }

            return null;
        } 

        public void vider()
        {
            cmbsport.Text = txtcategorie.Text = txtcapacity.Text = txtprix.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (testobligatoir() != null)
            {
                MessageBox.Show(testobligatoir(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean x = true;
                if (label9.Text == "AJOUTER SPORT")
                {
                    for (int i = 0; i < DGVM.Rows.Count; i++)
                    {
                        if (DGVM.Rows[i].Cells[1].Value.ToString() == cmbsport.Text)
                        {
                            x = false;
                        }
                    }
                    if(x == true)
                    {
                        if (dBsport.ajouter_sport(cmbsport.Text, txtcategorie.Text, Convert.ToInt32(txtcapacity.Text), Convert.ToInt32(txtprix.Text), idsalle) == true)
                        {
                            MessageBox.Show("sport ajouter avec sucess", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            Actualisedatagrid();
                            remplircombobox();
                            vider();
                        }
                    }
                    else
                    {
                        MessageBox.Show("sport deja existant", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if(label9.Text == "MODIFIER SPORT")
                {
                    DialogResult dr = MessageBox.Show("voulez-vous vraiment modifier le sport", "Modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dr == DialogResult.Yes)
                    {
                        TC.DBsport dBsport = new TC.DBsport();
                        dBsport.modifier_sport(int.Parse(txtidsport.Text),cmbsport.Text, txtcategorie.Text, int.Parse(txtcapacity.Text), Convert.ToInt32(txtprix.Text),idsalle);
                        MessageBox.Show("sport modifier avec sucess", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Actualisedatagrid();
                        remplircombobox();
                        vider();
                    }
                    else
                    {
                        MessageBox.Show("Modification est annule", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                        
                    
                }
                if (label9.Text == "SUPREME SPORT")
                {
                    DialogResult dr = MessageBox.Show("voulez-vous vraiment Supprimer le sport", "SUP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        TC.DBsport dBsport = new TC.DBsport();
                        if (dBsport.numbermemberpaticipersport(cmbsport.Text) == 0)
                        {

                            dBsport.supp_sport(Convert.ToInt32(txtidsport.Text));
                            MessageBox.Show("sport Supprimer avec sucess", "Sup", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            Actualisedatagrid();
                            remplircombobox();
                            vider();
                        }
                        else
                        {
                            MessageBox.Show("you cant remove sport because theres a member in this sport", "Sup", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Supprimer est annule", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }

        public void Actualisedatagrid()
        {
            try
            {
                
                DGVM.Rows.Clear();
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
                string sql = "select id_sport,nom_sport,ctaegorie,capacity,tarif from sport inner join offrir on id_sport=numsport where numsalle = '"+idsalle+"'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                    DGVM.Rows.Add(rd[0], rd[1], rd[2], rd[3],rd[4]);
                }

                con.Close();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void UserControlSport_Load(object sender, EventArgs e)
        {
            Actualisedatagrid();
            remplircombobox();
        }

        public void remplircombobox()
        {
            cmbsport.DisplayMember = "nom";
            cmbsport.ValueMember = "id";
            cmbsport.DataSource = GG.offrirs.Where((s => s.numsalle == (idsalle))).Select(b => new { id = b.salle.id_salle, nom = b.sport.nom_sport }).ToList();

        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label9.Text = "MODIFIER SPORT";
            button1.Text = "MODIFIER";
            vider();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            label9.Text = "SUPREME SPORT";
            button1.Text = "SUPREME";
            vider();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label9.Text = "AJOUTER SPORT";
            button1.Text = "AJOUTER";
            vider();
        }


       
        private void DGVM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGVM.Rows[e.RowIndex];
                cmbsport.Text = row.Cells[1].Value.ToString();
                txtcategorie.Text = row.Cells[2].Value.ToString();
                txtcapacity.Text = row.Cells[3].Value.ToString();
                txtidsport.Text = row.Cells[0].Value.ToString();
                txtprix.Text = row.Cells[4].Value.ToString();
            }
        }

        private void cmbsport_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int i = cmbsport.SelectedIndex;
            txtcategorie.Text = DGVM.Rows[i].Cells[2].Value.ToString();
            txtcapacity.Text = DGVM.Rows[i].Cells[3].Value.ToString();
        }

        private void txtprix_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtcapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            dBsport.onlynumber(e);
        }

        private void txtprix_KeyPress(object sender, KeyPressEventArgs e)
        {
            dBsport.onlynumber(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void DGVM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
