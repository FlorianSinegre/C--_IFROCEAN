using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11.DAL
{
   public class peDAL
    {
        private static MySqlConnection connection;
        public peDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }

        internal static ObservableCollection<peDAO> getIdEtude(int idpersonne)
        {
            ObservableCollection<peDAO> l = new ObservableCollection<peDAO>();
            string query = "SELECT * FROM etude_has_personne WHERE Etude_idEtude=" + idpersonne + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                peDAO p = new peDAO(reader.GetInt32(0), reader.GetInt32(1));
                l.Add(p);
            }
            reader.Close();
            return l;
        }

        internal static void supprimertEude(int idEtude)
        {
            connection = DALConnection.connection;

            string query = "DELETE FROM etude_has_personne WHERE Etude_IdEtude =" + idEtude + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static void insertUser(int idpersonne, int idEtude)
        {
            connection = DALConnection.connection;
            string query2 = "INSERT INTO etude_has_personne VALUES (\"" + idpersonne + "\",\"" + idEtude + "\");";
            MySqlCommand cmd22 = new MySqlCommand(query2, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap2 = new MySqlDataAdapter(cmd22);
            cmd22.ExecuteNonQuery();
        }

        public static void insertEtude(int idEtude, int idpersonne)
        {
            connection = DALConnection.connection;
            string query2 = "INSERT INTO etude_has_personne VALUES (\"" + idEtude + "\",\"" + idpersonne + "\");";
            MySqlCommand cmd22 = new MySqlCommand(query2, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap2 = new MySqlDataAdapter(cmd22);
            cmd22.ExecuteNonQuery();
        }

    }
}
