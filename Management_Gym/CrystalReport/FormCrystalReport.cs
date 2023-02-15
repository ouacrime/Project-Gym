using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Management_Gym.CrystalReport
{
    public partial class FormCrystalReport : Form
    {
        SqlDataAdapter dt = new SqlDataAdapter();
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");


        public FormCrystalReport()
        {
            InitializeComponent();
        }

        private void FormCrystalReport_Load(object sender, EventArgs e)
        {
            con.Open();
            string sql = "SELECT membere.nom, membere.prenom, sport.nom_sport, abonner.datefin FROM membere INNER JOIN abonner ON abonner.idmembere = membere.id_membere INNER JOIN participer ON participer.idmembere = membere.id_membere INNER JOIN sport ON sport.id_sport = participer.idsport WHERE(abonner.datefin > GETDATE()) order by nom_sport";
            dt = new SqlDataAdapter(sql, con);
            CrystalReport.DataSetCrystal ds = new CrystalReport.DataSetCrystal();
            dt.Fill(ds.DataTable1);
            CrystalReport.CrystalReportFicherMember crf = new CrystalReportFicherMember();
            crf.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = crf;
            crystalReportViewer1.Refresh();
            con.Close();

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
