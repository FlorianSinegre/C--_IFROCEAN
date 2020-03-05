using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp11.DAL;

namespace WpfApp11.ORM
{
     public class EtudeORM
    {
        public static EtudeViewModel getEtude(int idEtude)
        {
            EtudeDAO pDAO = EtudeDAO.getEtude(idEtude);

            EtudeViewModel p = new EtudeViewModel(pDAO.idEtudeDAO, pDAO.DateDAO, pDAO.SuperficieEtudierDAO);
            return p;
        }

        public static ObservableCollection<EtudeViewModel> listeEtude()
        {
            ObservableCollection<EtudeDAO> lDAO = EtudeDAO.listeEtude();
            ObservableCollection<EtudeViewModel> l = new ObservableCollection<EtudeViewModel>();
            foreach (EtudeDAO element in lDAO)
            {
                EtudeViewModel p = new EtudeViewModel(element.idEtudeDAO, element.DateDAO, element.SuperficieEtudierDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateEtude(EtudeViewModel p)
        {
            EtudeDAO.updateEtude(p);
        }
        
        public static void supprimerEtude(int id)
        {
            EtudeDAO.supprimerEtude(id);
        }

        public static void insertEtude(EtudeViewModel p)
        {
            EtudeDAO.insertEtude(p);
        }
    }
}
