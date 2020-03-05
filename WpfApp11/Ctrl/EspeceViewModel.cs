using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp11.ORM;

namespace WpfApp11.Ctrl
{
    public class EspeceViewModel : INotifyPropertyChanged
    {

        public int idEspece;
        private string nom;
        private string genre;


        public EspeceViewModel() { }


        public EspeceViewModel(int idEspece, string nom, string genre)
        {
            this.idEspece = idEspece;
            this.nomProperty = nom;
            this.genreProperty = genre;

        }
        public int idEspeceProperty
        {
            get { return idEspece; }
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
        public String genreProperty
        {
            get { return genre; }
            set
            {
                this.genre = value;
                this.concatProperty = this.nom + " " + value;
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
                EspeceORM.updateEspece(this);
            }
        }
    }
}

