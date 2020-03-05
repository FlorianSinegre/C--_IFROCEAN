using System.Collections.ObjectModel;

namespace WpfApp11.DAL
{
    public class CommuneDAO
    {
        public int idVilleDAO;
        public string nomVilleDAO;
        public string nomSpecialisteDAO;

        public CommuneDAO(int idVilleDAO, string nomVilleDAO, string nomSpecialisteDAO)
        {
            this.idVilleDAO = idVilleDAO;
            this.nomVilleDAO = nomVilleDAO;
            this.nomSpecialisteDAO = nomSpecialisteDAO;
        }

        public static ObservableCollection<CommuneDAO> listeCommunes()
        {
            ObservableCollection<CommuneDAO> l = CommuneDAL.selectCommunes();
            return l;
        }

        public static CommuneDAO getCommune(int idCommune)
        {
            CommuneDAO p = CommuneDAL.getCommune(idCommune);
            return p;
        }

        public static void updateCommune(CommuneDAO p)
        {
            CommuneDAO.updateCommune(p);
        }

        public static void supprimerCommune(int id)
        {
            CommuneDAO.supprimerCommune(id);
        }

        public static void insertCommune(CommuneDAO p)
        {
            CommuneDAO.insertCommune(p);
        }

    }
}