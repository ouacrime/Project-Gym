using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Gym
{
    class DBconexion
    {
        public int cont = 0;
        public bool conexion(GestionGymEntities db, string email, string motdepasse)
        {
            
            salle s = new salle();
            s.email = email;
            s.motpasse = motdepasse;

            //si le email et le mot de passe existe dans la base de donner 
            if (db.salles.SingleOrDefault(c => c.email == email && c.motpasse == motdepasse && c.Type == "admin") != null)
            {
                cont = 1;
                return true;
            }
            if (db.salles.SingleOrDefault(c => c.email == email && c.motpasse == motdepasse && c.Type == "utilisateur") != null)
            {
                cont = 0;
                return true;
            }
            else//si n'existe pas
            {
                return false;
            }


        }







    }
}

        
    
