using System;
using System.ComponentModel;

namespace WpfApp11.ORM
{
    public class DepartementViewModel
    {
        private int idDepartement;
        private string nom;
       




        public DepartementViewModel(int idDepartement, string nom)
        {
            this.idDepartement = idDepartement;
            this.nom = nom;

        }
        public int idDepartementProperty
        {
            get { return idDepartement; }
        }



        public String nomProperty
        {
            get { return nom; }
            set
            {
                nom = value.ToUpper();
                //this.concat = value.ToUpper() + " " + prenom;
                OnPropertyChanged("nomProperty");
            }

        }
        

        public String concatProperty
        {
            get { return ""; }
            set
            {
                //   this.concat = "Ajouter " + value;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                DepartementORM.updateDepartement(this);
            }
        }
    }
}