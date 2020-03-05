using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp11.DAL;

namespace WpfApp11.ORM
{
  public  class peORM
    {
        public static ObservableCollection<EtudeViewModel> getEtudes(int idpersonne)
        {
            ObservableCollection<peDAO> lDAO = peDAO.getIdEtude(idpersonne);
            ObservableCollection<EtudeViewModel> Etudes = new ObservableCollection<EtudeViewModel>();

            foreach (peDAO p in lDAO)
            {
                EtudeViewModel e = EtudeORM.getEtude(p.idEtudeDAO);
                Etudes.Add(e);
            }
            return Etudes;
        }

        public static void insertUser(int idEtude, int idpersonne)
        {
            peDAO.insertUser(idEtude, idpersonne);
        }

        public static void suprimertEtude(int idEtude)
        {
            peDAO.supprimerEtude(idEtude);
        }
    }
}
