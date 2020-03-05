using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp11.DAL
{
    public  class PlageDAL
    {

        private static MySqlConnection connection;

        public PlageDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }



        public static PlageDAO getPlage(int idPlage)
        {
            string query = "SELECT * FROM plage WHERE id=" + idPlage + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PlageDAO pers = new PlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4));
            reader.Close();
            return pers;
        }

        public static void updatePlage(PlageDAO p)
        {
            string query = "UPDATE plage set nom=\"" + p.nomDAO + "\", Ville_idVille=\"" + p.Ville_idVilleDAO + "\", Departement_idDepartement=\"" + p.prelevement_idprelevementDAO + "\",prelevement_idprelevement=\"" + p.Departement_idDepartementDAO + "\" where idPlage=" + p.idPlageDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static ObservableCollection<PlageDAO> selectPlages()
        {
            ObservableCollection<PlageDAO> l = new ObservableCollection<PlageDAO>();
            string query = "SELECT * FROM Plage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PlageDAO p = new PlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4));
                    l.Add(p);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("La base de données n'est pas connectée");
            }
            return l;
        }

       
        public static void insertPlage(PlageDAO p)
        {
            int id = getMaxIdPlage() + 1;
            string query = "INSERT INTO plage VALUES (\"" + id + "\",\"" + p.nomDAO + "\", Ville_idVille=\"" + p.Ville_idVilleDAO + "\", Departement_idDepartement=\"" + p.prelevement_idprelevementDAO + "\",prelevement_idprelevement=\"" + p.Departement_idDepartementDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerPlage(int id)
        {
            string query = "DELETE FROM plage WHERE idPlage = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdPlage()
        {
            string query = "SELECT MAX(idPlage) FROM plage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxidPlage = reader.GetInt32(0);
            reader.Close();
            return maxidPlage;
        }




    }
}

