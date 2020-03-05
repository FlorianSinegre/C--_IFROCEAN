using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp11.DAL;
using WpfApp11.Ctrl;

namespace WpfApp11.ORM
{
    public class PlageORM
    {
        public static PlageViewModel getPlage(int idPlage)
        {
            PlageDAO pDAO = PlageDAO.getPlage(idPlage);
            int  idPrelevement= pDAO.prelevement_idprelevementDAO;
            int  idVille = pDAO.Ville_idVilleDAO;
            int  iDepartement= pDAO.Departement_idDepartementDAO;

            PrelevementViewModel pr = PrelevementORM.getPrelevement(idPrelevement);
            CommuneViewModel c = CommuneORM.getCommune(idVille);
            DepartementViewModel d = DepartementORM.getDepartement(iDepartement);
            
            PlageViewModel p = new PlageViewModel(pDAO.idPlageDAO, pDAO.nomDAO, c, pr, d);
            return p;
        }

        public static ObservableCollection<PlageViewModel> listePlages()
        {
            ObservableCollection<PlageDAO> lDAO = PlageDAO.listePlages();
            ObservableCollection<PlageViewModel> l = new ObservableCollection<PlageViewModel>();
            foreach (PlageDAO element in lDAO)
            {
                  int idPrelevement = element.prelevement_idprelevementDAO;
                  int idVille = element.Ville_idVilleDAO;
                  int iDepartement = element.Departement_idDepartementDAO;

                  PrelevementDAO m = PrelevementDAO.getPrelevement(idPrelevement);
                  CommuneDAO c = CommuneDAO.getCommune(idVille);
                  DepartementDAO d = DepartementDAO.getDepartement(iDepartement);

                PrelevementViewModel prelevement = new PrelevementViewModel(m.idprelevementDAO, m.PositionGPSDAO, m.TypeDAO);
                CommuneViewModel commune = new CommuneViewModel(c.idVilleDAO, c.nomSpecialisteDAO, c.nomVilleDAO);
                DepartementViewModel departement = new DepartementViewModel(d.idDepartementDAO, d.nomDAO);
                PlageViewModel p = new PlageViewModel(element.idPlageDAO, element.nomDAO, commune, prelevement , departement);
                l.Add(p);
            }
            return l;
        }

       /* public static void updatePlage(PlageViewModel p)
        {
            PlageDAO.updatePlage(new PlageDAO(p.idPlageProperty, p.nomProperty, p.commune, p.departement,p.prelevement ));
        }

        public static void supprimerPlage(int id)
        {
            PlageDAO.supprimerPlage(id);
        }

        public static void insertPlage(PlageViewModel p)
        {
            PlageDAO.insertPlage(new PlageDAO(p.idPlageProperty, p.nomProperty, p.commune,p.departement,p.prelevement));
        }

    */
    }
}
