using System;
using System.ComponentModel;
namespace WpfApp11
{
    public class PersonneViewModel : INotifyPropertyChanged
    {
        private int idPersonne;
        private string nom;
        private string prenom;
        //private string concat;

        public PersonneViewModel() { }

        public  PersonneViewModel(int id, string nom, string prenom)
        {
            this.idPersonne = id;
            this.nomProperty = nom;
            this.prenomProperty = prenom;
          }
        public int idPersonneProperty
        {
            get { return idPersonne; }
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
        public String prenomProperty
        {
            get { return prenom; }
            set
            {
                this.prenom = value; 
                this.concatProperty =  this.nom +" "+ value;
                OnPropertyChanged("prenomProperty");
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                PersonneORM.updatePersonne(this);
            }
        }
    }
}