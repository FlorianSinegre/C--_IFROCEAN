using System;
using System.ComponentModel;
using WpfApp11.Ctrl;
using WpfApp11.ORM;

namespace WpfApp11.DAL
{
    public class PlageViewModel : INotifyPropertyChanged
    {

        private int idPlage;
        private string nom;
        public CommuneViewModel communeViewModel;
        public PrelevementViewModel prelevementViewModel;
        public DepartementViewModel departementViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public PlageViewModel() { }

        public PlageViewModel(int id, string nom, CommuneViewModel commune, PrelevementViewModel prelevement, DepartementViewModel departement)
        {
            this.idPlage = id;
            this.nomProperty = nom;
            communeViewModel = commune;
            prelevementViewModel = prelevement;
            departementViewModel = departement;
            
        }
        public  CommuneViewModel commune
        {
            get { return communeViewModel; }
        }
        public PrelevementViewModel prelevement
        {
            get { return prelevementViewModel; }
        }

        public DepartementViewModel departement
        {
            get { return departementViewModel; }
        }
        public int idPlageProperty
        {
            get { return idPlage; }
        }

        public String nomProperty
        {
            get { return nom; }
            set
            {
                nom = value.ToUpper();
                //this.concatProperty = value.ToUpper() + " " + prenom;
                OnPropertyChanged("nomProperty");
            }

        }
       

        public String concatProperty
        {
            get { return ""; }
            set
            {
                //     this.concat = "Ajouter " + value;
            }
        }

        

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                PlageDAO.updatePlage(this);
            }
        }
    }
}