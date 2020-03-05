using System.Collections.ObjectModel;

namespace WpfApp11.DAL
{
    public class PrelevementDAO
    {
        public int idprelevementDAO;
        public string PositionGPSDAO;
        public string TypeDAO;
        public PrelevementDAO(int idprelevementDAO, string PositionGPSDAO, string TypeDAO)
        {
            this.idprelevementDAO = idprelevementDAO;
            this.PositionGPSDAO = PositionGPSDAO;
            this.TypeDAO = TypeDAO;
        }
        public static ObservableCollection<PrelevementDAO> listePrelevements()
        {
            ObservableCollection<PrelevementDAO> l = PrelevementDAL.selectPrelevements();
            return l;
        }

        public static PrelevementDAO getPrelevement(int idprelevement)
        {
            PrelevementDAO p = PrelevementDAL.getPrelevement(idprelevement);
            return p;
        }

        public static void updatePrelevement(PrelevementDAO p)
        {
            PrelevementDAL.updatePrelevement(p);
        }

        public static void supprimerPrelevement(int id)
        {
            PrelevementDAL.supprimerPrelevement(id);
        }

        public static void insertPrelevement(PrelevementDAO p)
        {
            PrelevementDAL.insertPrelevement(p);
        }

    }
}