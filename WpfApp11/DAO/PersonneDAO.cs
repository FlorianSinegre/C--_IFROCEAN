using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class PersonneDAO
    {
        public int idPersonneDAO;
        public string nomDAO;
        public string prenomDAO;
        //public int idMetierPersonneDAO;

        public PersonneDAO(int idPersonneDAO, string nomDAO, string prenomDAO)
        {
            this.idPersonneDAO = idPersonneDAO;
            this.nomDAO = nomDAO;
            this.prenomDAO = prenomDAO;
        }

        public static ObservableCollection<PersonneDAO>  listePersonnes()
        {
            ObservableCollection<PersonneDAO> l = PersonneDAL.selectPersonnes();
            return l;
        }

        public static PersonneDAO getPersonne(int idPersonne)
        {
            PersonneDAO p = PersonneDAL.getPersonne(idPersonne);
            return p;
        }

        public static void updatePersonne(PersonneDAO p)
        {
            PersonneDAL.updatePersonne(p);
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAL.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneDAO p)
        {
            PersonneDAL.insertPersonne(p);
        }
    }
}
