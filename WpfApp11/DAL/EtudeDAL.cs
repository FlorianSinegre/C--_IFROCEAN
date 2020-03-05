using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11.DAL
{
    public  class EtudeDAL
    {
        private static MySqlConnection connection;

        public EtudeDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }

        public static EtudeDAO getEtude(int idEtude, string Date, String SuperficieEtudier)
        {
            string query = "SELECT * FROM etude WHERE idEtude=" + idEtude + Date + SuperficieEtudier;
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EtudeDAO e = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            reader.Close();
            return e;
        }
        public static ObservableCollection<EtudeDAO> selectEtude()
        {
            ObservableCollection<EtudeDAO> l = new ObservableCollection<EtudeDAO>();
            string query = "SELECT * FROM etude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                EtudeDAO p = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                l.Add(p);
            }
            reader.Close();
            return l;
        }
        public static int getMaxIdEtude()
        {
            string query = "SELECT MAX(idEtude) FROM Etude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdEtude = reader.GetInt32(0);
            reader.Close();
            return maxIdEtude;
        }
        public static void insertEtude(EtudeDAO e)
        {
            int id = getMaxIdEtude() + 1;
            string query = "INSERT INTO Etude VALUES (\"" + id + "\",\"" + e.DateDAO + "\",\"" + e.SuperficieEtudierDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEtude(int id)
        {
            string query = "DELETE FROM Etude WHERE idEtude = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void updateEtude(EtudeDAO p)
        {
            string query = "UPDATE etude set Date=\"" + p.DateDAO + "\", SuperficieEtudier=\"" + p.SuperficieEtudierDAO + "\", where idEtude=" + p.idEtudeDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
