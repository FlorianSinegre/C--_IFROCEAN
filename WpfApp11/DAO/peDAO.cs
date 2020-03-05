using System.Collections.ObjectModel;

namespace WpfApp11.DAL
{
    class peDAO
    {
        public int idEtudeDAO;
        public int idpersonneDAO;


        public peDAO(int idEtudeDAO, int idpersonneDAO)
        {
            this.idEtudeDAO = idEtudeDAO;
            this.idpersonneDAO = idpersonneDAO;
            
        }
        public static ObservableCollection<peDAO> getIdEtude(int idEtude)
        {
            ObservableCollection<peDAO> l = peDAO.getIdEtude(idEtude);
            return l;
        }

        public static void insertUser(int idpersonne, int idEtude)
        {
            peDAO.insertUser(idpersonne, idEtude);
        }

        public static void supprimerEtude(int idEtude)
        {
            peDAO.supprimerEtude(idEtude);
        }
    }
}