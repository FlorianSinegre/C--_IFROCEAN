using System.Collections.ObjectModel;

namespace WpfApp11.DAL
{
    public class EspeceDAO
    {

        public int idEspeceDAO;
        public string nomDAO;
        public string genreDAO;



        public EspeceDAO(int idEspeceDAO, string nomDAO, string genreDAO)
        {
            this.idEspeceDAO = idEspeceDAO;
            this.nomDAO = nomDAO;
            this.genreDAO = genreDAO;
        }
        public static ObservableCollection<EspeceDAO> listeEspeces()
        {
            ObservableCollection<EspeceDAO> l = EspeceDAL.selectEspece();
            return l;
        }

        public static EspeceDAO getEspece(int idEspece)
        {
            EspeceDAO p = EspeceDAL.getEspece(idEspece);
            return p;
        }

        public static void updateEspece(EspeceDAO p)
        {
            EspeceDAL.updateEspece(p);
        }

        public static void supprimerEspece(int id)
        {
            EspeceDAL.supprimerEspece(id);
        }

        public static void insertEspece(EspeceDAO p)
        {
            EspeceDAL.insertEspece(p);
        }










    }
}