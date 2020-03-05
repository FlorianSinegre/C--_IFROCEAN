using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp11
{
    public class PersonneDAL
    {
        private static MySqlConnection connection;
        public PersonneDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DALConnection.connection;
        }

        public static  ObservableCollection<PersonneDAO> selectPersonnes()
        {
            ObservableCollection<PersonneDAO> l = new ObservableCollection<PersonneDAO>();
            string query = "SELECT * FROM personne;";
             MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonneDAO p = new PersonneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
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

        public static void updatePersonne(PersonneDAO p)
        {
            string query = "UPDATE personne set nom=\"" + p.nomDAO + "\", prenom=\"" + p.prenomDAO + "\", where idPersonne=" + p.idPersonneDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPersonne(PersonneDAO p)
        {
            int id = getMaxIdPersonne() + 1;
            string query = "INSERT INTO personne VALUES (\"" + id  + "\",\"" + p.nomDAO + "\",\"" + p.prenomDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerPersonne(int id)
        {
            string query = "DELETE FROM personne WHERE idPersonne = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdPersonne()
        {
            string query = "SELECT MAX(idPersonne) FROM personne;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxidPersonne = reader.GetInt32(0);
            reader.Close();
            return maxidPersonne;
        }

        public static PersonneDAO getPersonne(int idPersonne)
        {
            string query = "SELECT * FROM personne WHERE id="+ idPersonne + ";";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PersonneDAO pers = new PersonneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            reader.Close();
            return pers;
        }
    }
}
