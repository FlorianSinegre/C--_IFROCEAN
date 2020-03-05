using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp11.DAL;

namespace WpfApp11.ORM
{
    class DepartementORM
    {
        public static DepartementViewModel getDepartement(int idDepartement)
        {
            DepartementDAO pDAO = DepartementDAO.getDepartement(idDepartement);
            //int idMetier = pDAO.idMetierDepartementDAO;
            DepartementViewModel p = new DepartementViewModel(pDAO.idDepartementDAO, pDAO.nomDAO);
            return p;
        }

        public static ObservableCollection<DepartementViewModel> listeDepartements()
        {
            ObservableCollection<DepartementDAO> lDAO = DepartementDAO.listeDepartements();
            ObservableCollection<DepartementViewModel> l = new ObservableCollection<DepartementViewModel>();
            foreach (DepartementDAO element in lDAO)
            {
                //int idMetier = element.idMetierDepartementDAO;

                DepartementViewModel p = new DepartementViewModel(element.idDepartementDAO, element.nomDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateDepartement(DepartementViewModel p)
        {
            DepartementDAO.updateDepartement(new DepartementDAO(p.idDepartementProperty, p.nomProperty));
        }

        public static void supprimerDepartement(int id)
        {
            DepartementDAO.supprimerDepartement(id);
        }

        public static void insertDepartement(DepartementViewModel p)
        {
            DepartementDAO.insertDepartement(new DepartementDAO(p.idDepartementProperty, p.nomProperty));
        }
    }
}
