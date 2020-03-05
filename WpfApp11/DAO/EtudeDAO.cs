using System;
using System.Collections.ObjectModel;

namespace WpfApp11.DAL
{
    public class EtudeDAO
    {

        public int idEtudeDAO;
        public string DateDAO;
        public string SuperficieEtudierDAO;


        public EtudeDAO(int idEtudeDAO, string DateDAO, string SuperficieEtudierDAO)
        {
            this.idEtudeDAO = idEtudeDAO;
            this.DateDAO = DateDAO;
            this.SuperficieEtudierDAO = SuperficieEtudierDAO;

        }

        public static ObservableCollection<EtudeDAO> listeEtude()
        {
            ObservableCollection<EtudeDAO> l = EtudeDAL.selectEtude();
            return l;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            EtudeDAO e = EtudeDAO.getEtude(idEtude);
            return e;
        }

        public static void updateEtude(EtudeViewModel e)
        {
            EtudeDAL.updateEtude(new EtudeDAO(e.idEtudeProperty, e.DateProperty, e.SuperficieEtudierProperty));
        }

        public static void supprimerEtude(int id)
        {
            EtudeDAL.supprimerEtude(id);
        }

        public static void insertEtude(EtudeViewModel e)
        {
            EtudeDAL.insertEtude(new EtudeDAO(e.idEtudeProperty, e.DateProperty, e.SuperficieEtudierProperty));
        }
    }
}