using System.Collections.ObjectModel;
using WpfApp11.DAL;

namespace WpfApp11.Ctrl
{
    public class PrelevementORM
    {

        public static PrelevementViewModel getPrelevement(int idprelevement)
        {
            PrelevementDAO pDAO = PrelevementDAO.getPrelevement(idprelevement);
            // int idMetier = pDAO.idMetierPrelevementDAO;
            PrelevementViewModel p = new PrelevementViewModel(pDAO.idprelevementDAO, pDAO.PositionGPSDAO, pDAO.TypeDAO);
            return p;
        }

        public static ObservableCollection<PrelevementViewModel> listePrelevements()
        {
            ObservableCollection<PrelevementDAO> lDAO = PrelevementDAO.listePrelevements();
            ObservableCollection<PrelevementViewModel> l = new ObservableCollection<PrelevementViewModel>();
            foreach (PrelevementDAO element in lDAO)
            {
                //  int idMetier = element.idMetierPrelevementDAO;

                PrelevementViewModel p = new PrelevementViewModel(element.idprelevementDAO, element.PositionGPSDAO, element.TypeDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updatePrelevement(PrelevementViewModel p)
        {
            PrelevementDAO.updatePrelevement(new PrelevementDAO(p.idprelevementProperty, p.PositionGPSProperty, p.TypeProperty));
        }

        public static void supprimerPrelevement(int id)
        {
            PrelevementDAO.supprimerPrelevement(id);
        }

        public static void insertPrelevement(PrelevementViewModel p)
        {
            PrelevementDAO.insertPrelevement(new PrelevementDAO(p.idprelevementProperty, p.PositionGPSProperty, p.TypeProperty));
        }
    }
}