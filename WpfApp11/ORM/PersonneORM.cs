using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    public class PersonneORM
    {

        public static PersonneViewModel getPersonne(int idPersonne)
        {
            PersonneDAO pDAO=PersonneDAO.getPersonne(idPersonne);
           // int idMetier = pDAO.idMetierPersonneDAO;
            PersonneViewModel p = new PersonneViewModel(pDAO.idPersonneDAO, pDAO.nomDAO, pDAO.prenomDAO);
            return p;
        }

        public static ObservableCollection<PersonneViewModel> listePersonnes()
        {
            ObservableCollection<PersonneDAO> lDAO = PersonneDAO.listePersonnes();
            ObservableCollection<PersonneViewModel> l = new ObservableCollection<PersonneViewModel>();
            foreach (PersonneDAO element in lDAO)
            {
              //  int idMetier = element.idMetierPersonneDAO;

                PersonneViewModel p = new PersonneViewModel(element.idPersonneDAO, element.nomDAO, element.prenomDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updatePersonne(PersonneViewModel p)
        {
            PersonneDAO.updatePersonne(new PersonneDAO(p.idPersonneProperty, p.nomProperty, p.prenomProperty));
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAO.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneViewModel p)
        {
            PersonneDAO.insertPersonne(new PersonneDAO(p.idPersonneProperty, p.nomProperty, p.prenomProperty));
        }
    }
}
