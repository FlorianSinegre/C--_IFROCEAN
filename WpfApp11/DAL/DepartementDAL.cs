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
    public  class DepartementDAL
    {

        private static MySqlConnection connection;

        public DepartementDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.connection;
        }



        public static DepartementDAO getDepartement(int idDepartement)
        {
            string query = "SELECT * FROM Departement WHERE idDepartement=" + idDepartement + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DepartementDAO pers = new DepartementDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return pers;
        }

        public static void updateDepartement(DepartementDAO p)
        {
            string query = "UPDATE Departement set nom=\"" + p.nomDAO + "\" where idDepartement=" + p.idDepartementDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static ObservableCollection<DepartementDAO> selectDepartements()
        {
            ObservableCollection<DepartementDAO> l = new ObservableCollection<DepartementDAO>();
            string query = "SELECT * FROM Departement;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DepartementDAO p = new DepartementDAO(reader.GetInt32(0), reader.GetString(1));
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


        public static void insertDepartement(DepartementDAO p)
        {
            int id = getMaxIdDepartement() + 1;
            string query = "INSERT INTO Departement VALUES (\"" + id + "\",\"" + p.nomDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerDepartement(int id)
        {
            string query = "DELETE FROM Departement WHERE idDepartement = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdDepartement()
        {
            string query = "SELECT MAX(idDepartement) FROM Departement;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxidDepartement = reader.GetInt32(0);
            reader.Close();
            return maxidDepartement;
        }
    }
}
