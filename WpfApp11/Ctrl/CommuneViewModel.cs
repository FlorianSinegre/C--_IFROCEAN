using System;
using System.ComponentModel;

namespace WpfApp11.DAL
{
    public class CommuneViewModel
    {
        private int idVille;
        public string nomVille;
        private string nomSpecialiste;




        public CommuneViewModel(int idVille, string nomVille, string nomSpecialiste)
        {
            this.idVille = idVille;
            this.nomVille = nomVille;
            this.nomSpecialiste = nomSpecialiste;

        }
        public int idVilleProperty
        {
            get { return idVille; }
        }

        

        public String nomVilleProperty
        {
            get { return nomVille; }
            set
            {
                  nomVille = value.ToUpper();
                  //this.concat = value.ToUpper() + " " + prenom;
                  OnPropertyChanged("nomVilleProperty");
            }

        }
        public String nomSpecialisteProperty
        {
            get { return nomSpecialiste; }
            set
            {
                 this.nomSpecialiste = value;
                //this.concatProperty = this.nomVille + " " + value;
                 OnPropertyChanged("nomSpecialisteProperty");
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
                CommuneORM.updateCommune(this);
            }
        }
    }
}