using System;
using System.ComponentModel;

namespace WpfApp11.DAL
{
    public class EtudeViewModel : INotifyPropertyChanged
    {
        internal int idEtude;
        internal string Date;
        internal string SuperficieEtudier;

        public EtudeViewModel()
        {
        }

        public EtudeViewModel(int idEtude, string Date, string SuperficieEtudier)
        {
            this.idEtude = idEtude;
            this.Date = Date;
            this.SuperficieEtudier = SuperficieEtudier;

        }
        public int idEtudeProperty
        {
            get { return idEtude; }
        }

        public string DateProperty
        {
            get { return Date; }
            set
            {
                this.Date = value;
                //this.concatProperty = value.ToUpper() + " " + prenom;*/
                OnPropertyChanged("DateProperty");
            }

        }
        public String SuperficieEtudierProperty
        {
            get { return SuperficieEtudier; }
            set
            {
                 this.SuperficieEtudier = value;
               //  this.concatProperty = this.nom + " " + value;*/
                 OnPropertyChanged("SuperficieEtudierProperty");
            }
        }

       /* public String concatProperty
        {
            get { return concat; }
            set
            {
                //this.concat = "Ajouter " + value;
            }
        }*/


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                EtudeDAO.updateEtude(this);
            }
        }

    }
}