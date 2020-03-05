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
    public  class EspeceDAL
    {
        private static MySqlConnection connection;

        public EspeceDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }
        public static ObservableCollection<EspeceDAO> selectEspece()
        {
            ObservableCollection<EspeceDAO> l = new ObservableCollection<EspeceDAO>();
            string query = "SELECT * FROM Espece;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EspeceDAO p = new EspeceDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
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

        public static EspeceDAO getEspece(int idEspece)
        {
            string query = "SELECT * FROM espece WHERE id=" + idEspece + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EspeceDAO pers = new EspeceDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            reader.Close();
            return pers;
        }
        public static void updateEspece(EspeceDAO p)
        {
            string query = "UPDATE personne set nom=\"" + p.nomDAO + "\", genre=\"" + p.genreDAO + "\", where idEspece=" + p.idEspeceDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static void insertEspece(EspeceDAO p)
        {
            int id = getMaxIdEspece() + 1;
            string query = "INSERT INTO espece VALUES (\"" + id + "\",\"" + p.nomDAO + "\",\"" + p.genreDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEspece(int id)
        {
            string query = "DELETE FROM espece WHERE idEspece = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdEspece()
        {
            string query = "SELECT MAX(idEspece) FROM espece;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxidEspece = reader.GetInt32(0);
            reader.Close();
            return maxidEspece;
        }

    }
}
