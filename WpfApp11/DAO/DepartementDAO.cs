using System.Collections.ObjectModel;

namespace WpfApp11.DAL
{
    public class DepartementDAO
    {
        public int idDepartementDAO;
        public string nomDAO;
        

        public DepartementDAO(int idDepartementDAO, string nomDAO)
        {
            this.idDepartementDAO = idDepartementDAO;
            this.nomDAO = nomDAO;
            
        }

        public static ObservableCollection<DepartementDAO> listeDepartements()
        {
            ObservableCollection<DepartementDAO> l = DepartementDAL.selectDepartements();
            return l;
        }

        public static DepartementDAO getDepartement(int idDepartement)
        {
            DepartementDAO p = DepartementDAL.getDepartement(idDepartement);
            return p;
        }

        public static void updateDepartement(DepartementDAO p)
        {
            DepartementDAO.updateDepartement(p);
        }

        public static void supprimerDepartement(int id)
        {
            DepartementDAO.supprimerDepartement(id);
        }

        public static void insertDepartement(DepartementDAO p)
        {
            DepartementDAO.insertDepartement(p);
        }
    }
}