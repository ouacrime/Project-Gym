using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Gym.TC
{
    class Dbhome
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9I3RI7B;Initial Catalog=GestionGym;Integrated Security=True");
        SqlCommand cmd;

        private GestionGymEntities db = new GestionGymEntities();

        public int Getactivemember()
        {
            int num = 0;
            cmd = new SqlCommand()
            {
                CommandText = "spGetactivemember",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                num = int.Parse(rd[0].ToString());
            }
            con.Close();

            return num;
        }
        public int Getaddmember()
        {
            int num = 0;
            cmd = new SqlCommand()
            {
                CommandText = "spGetaddmember",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                num = int.Parse(rd[0].ToString());
            }
            con.Close();

            return num;
        }
        public int Getsport()
        {
            int num = 0;
            cmd = new SqlCommand()
            {
                CommandText = "spGetsport",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };
            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                num = int.Parse(rd[0].ToString());
            }
            con.Close();

            return num;
        }
        public void Gettarif()
        {
            cmd = new SqlCommand()
            {
                CommandText = "spmodificationtarif",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };
            con.Open();
            cmd.ExecuteReader();
            con.Close();
        }






        public int Getinactivemember()
        {
            int num = 0;
            cmd = new SqlCommand()
            {
                CommandText = "spGetinactivemember",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };
            con.Open();
            num = (int)cmd.ExecuteScalar();
            con.Close();

            return num;
        }
       
        public int Getprixsport(string nomsport)
        {
            int prix ;
            cmd = new SqlCommand()
            {
                CommandText = "spGetprixsport",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter p1 = new SqlParameter()
            {
                ParameterName = "@sport",
                SqlDbType = SqlDbType.VarChar,
                Value = nomsport,
                Direction = ParameterDirection.Input
            };
            cmd.Parameters.Add(p1);
            con.Open();
            prix = (int)cmd.ExecuteScalar();
           
            
            con.Close();

            return prix;
        }
        public int Getprixyear(int year)
        {
            int prix;
            cmd = new SqlCommand()
            {
                CommandText = "spGetprixyear",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter p1 = new SqlParameter()
            {
                ParameterName = "@year",
                SqlDbType = SqlDbType.Int,
                Value = year,
                Direction = ParameterDirection.Input
            };
            cmd.Parameters.Add(p1);
            con.Open();
            prix = (int)cmd.ExecuteScalar();


            con.Close();

            return prix;
        }
        public int Getprixauouj()
        {
            int num = 0;
            cmd = new SqlCommand()
            {
                CommandText = "spGetprixaujour",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };
            con.Open();
            num = (int)cmd.ExecuteScalar();
            con.Close();

            return num;
        }
        public int Getprixmois()
        {
            int num = 0;
            cmd = new SqlCommand()
            {
                CommandText = "spGettarifmois",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };
            con.Open();
            num = (int)cmd.ExecuteScalar();
            con.Close();

            return num;
        }
        public int Getmember()
        {
            int num = 0;
            cmd = new SqlCommand()
            {
                CommandText = "spGetemember",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };
            con.Open();
            num = (int)cmd.ExecuteScalar();
            con.Close();

            return num;
        }
        public int GetprixChoix(string nomsport,DateTime datedebut,DateTime datefin)
        {
            int prix;
            cmd = new SqlCommand()
            {
                CommandText = "spGetprixparchoix",
                Connection = con,
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@sport", nomsport);
            cmd.Parameters.AddWithValue("@datedebut", datedebut);
            cmd.Parameters.AddWithValue("@datefin", datefin);

            con.Open();
            prix = (int)cmd.ExecuteScalar();
            con.Close();
            return prix;
        }
        public int IDValue(string email, string mtp)
        {
            int idsalle;
            string sql = "select id_salle from salle WHERE email ='" + email + "' and motpasse ='" + mtp + "'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            idsalle = (int)cmd.ExecuteScalar();
            con.Close();
            return idsalle;
        }
        public string NomSalleValue(string email, string mtp)
        {
            string nomsalle;
            string sql = "select nom_salle from salle WHERE email = '" + email + "' and motpasse = '"+mtp+"'";
            cmd = new SqlCommand(sql, con);
            con.Open();
            nomsalle = (string)cmd.ExecuteScalar();
            con.Close();
            return nomsalle;
        }


    }
}
