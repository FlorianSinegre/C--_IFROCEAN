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
    public class CommuneDAL
    {

        private static MySqlConnection connection;
        public CommuneDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }

        public static ObservableCollection<CommuneDAO> selectCommunes()
        {
            ObservableCollection<CommuneDAO> l = new ObservableCollection<CommuneDAO>();
            string query = "SELECT * FROM Ville;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            { 
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    CommuneDAO p = new CommuneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
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

        public static void updateCommune(CommuneDAO p)
        {
            string query = "UPDATE Ville set nom=\"" + p.nomVilleDAO + "\", prenomCommune=\"" + p.nomSpecialisteDAO + "\", where idCommune=" + p.idVilleDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertCommune(CommuneDAO p)
        {
            int id = getMaxIdCommune() + 1;
            string query = "INSERT INTO Ville VALUES (\"" + id + "\",\"" + p.nomVilleDAO + "\",\"" + p.nomSpecialisteDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerCommune(int id)
        {
            string query = "DELETE FROM Ville WHERE idVille = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdCommune()
        {
            string query = "SELECT MAX(idVille) FROM Ville;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxidCommune = reader.GetInt32(0);
            reader.Close();
            return maxidCommune;
        }

        public static CommuneDAO getCommune(int idVille)
        {
            string query = "SELECT * FROM ville WHERE idVille=" + idVille + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            CommuneDAO pers = new CommuneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            reader.Close();
            return pers;
        }
    }
}
