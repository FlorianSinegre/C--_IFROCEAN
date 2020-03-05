using System.Collections.ObjectModel;

namespace WpfApp11.DAL
{
    public class CommuneORM
    {

        public static CommuneViewModel getCommune(int idVille)
        {
            CommuneDAO pDAO = CommuneDAO.getCommune(idVille);
            //int idMetier = pDAO.idMetierCommuneDAO;
            CommuneViewModel p = new CommuneViewModel(pDAO.idVilleDAO, pDAO.nomVilleDAO, pDAO.nomSpecialisteDAO);
            return p;
        }

        public static ObservableCollection<CommuneViewModel> listeCommunes()
        {
            ObservableCollection<CommuneDAO> lDAO = CommuneDAO.listeCommunes();
            ObservableCollection<CommuneViewModel> l = new ObservableCollection<CommuneViewModel>();
            foreach (CommuneDAO element in lDAO)
            {
                //int idMetier = element.idMetierCommuneDAO;

                CommuneViewModel p = new CommuneViewModel(element.idVilleDAO, element.nomVilleDAO, element.nomSpecialisteDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateCommune(CommuneViewModel p)
        {
            CommuneDAO.updateCommune(new CommuneDAO(p.idVilleProperty, p.nomVilleProperty, p.nomSpecialisteProperty));
        }

        public static void supprimerCommune(int id)
        {
            CommuneDAO.supprimerCommune(id);
        }

        public static void insertCommune(CommuneViewModel p)
        {
            CommuneDAO.insertCommune(new CommuneDAO(p.idVilleProperty, p.nomVilleProperty, p.nomSpecialisteProperty));
        }
    }
}