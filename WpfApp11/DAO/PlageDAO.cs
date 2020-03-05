using System.Collections.ObjectModel;

namespace WpfApp11.DAL
{
    public class PlageDAO
    {

        public int idPlageDAO;
        public string nomDAO;
        public int Ville_idVilleDAO;
        public int Departement_idDepartementDAO;
        public int prelevement_idprelevementDAO;

        public PlageDAO(int idPlageDAO, string nomDAO, int Ville_idVilleDAO, int Departement_idDepartementDAO, int prelevement_idprelevementDAO)
        {
            this.idPlageDAO = idPlageDAO;
            this.nomDAO = nomDAO;
            this.Ville_idVilleDAO = Ville_idVilleDAO;
            this.Departement_idDepartementDAO = Departement_idDepartementDAO;
            this.prelevement_idprelevementDAO = prelevement_idprelevementDAO;


        }

        public static ObservableCollection<PlageDAO> listePlages()
        {
            ObservableCollection<PlageDAO> l = PlageDAL.selectPlages();
            return l;
        }

        public static PlageDAO getPlage(int idPlage)
        {
            PlageDAO p = PlageDAL.getPlage(idPlage);
            return p;
        }

        public static void updatePlage(PlageViewModel p)
        {
            PlageDAL.updatePlage(new PlageDAO(p.idPlageProperty, p.nomProperty, p.commune.idVilleProperty, p.prelevement.idprelevementProperty, p.departement.idDepartementProperty)) ;
        }

        public static void supprimerPlage(int id)
        {
            PlageDAL.supprimerPlage(id);
        }

        public static void insertPlage(PlageViewModel p)
        {
            PlageDAL.insertPlage(new PlageDAO(p.idPlageProperty, p.nomProperty, p.commune.idVilleProperty, p.prelevement.idprelevementProperty, p.departement.idDepartementProperty));
        }
    }
}
