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
   public class PrelevementDAL
    {

        private static MySqlConnection connection;
        public PrelevementDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static ObservableCollection<PrelevementDAO> selectPrelevements()
        {
            ObservableCollection<PrelevementDAO> l = new ObservableCollection<PrelevementDAO>();
            string query = "SELECT * FROM prelevement;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PrelevementDAO p = new PrelevementDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
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

        public static void updatePrelevement(PrelevementDAO p)
        {
            string query = "UPDATE prelevement set PositionGPS=\"" + p.PositionGPSDAO + "\", Type=\"" + p.TypeDAO + "\", where idprelevement=" + p.idprelevementDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPrelevement(PrelevementDAO p)
        {
            int id = getMaxIdPrelevement() + 1;
            string query = "INSERT INTO prelevement VALUES (\"" + id + "\",\"" + p.PositionGPSDAO + "\",\"" + p.TypeDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerPrelevement(int id)
        {
            string query = "DELETE FROM prelevement WHERE idprelevement = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdPrelevement()
        {
            string query = "SELECT MAX(idprelevement) FROM prelevement;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxidprelevement = reader.GetInt32(0);
            reader.Close();
            return maxidprelevement;
        }

        public static PrelevementDAO getPrelevement(int idprelevement)
        {
            string query = "SELECT * FROM prelevement WHERE idprelevement=" + idprelevement + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PrelevementDAO pers = new PrelevementDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            reader.Close();
            return pers;
        }
    }
}
