using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11.Ctrl
{
   public class PrelevementViewModel : INotifyPropertyChanged
    {
        private int idprelevement;
        private string PositionGPS;
        private string Type;


        public PrelevementViewModel() { }
        public PrelevementViewModel(int idprelevement, string PositionGPS, string Type)
        {
            this.idprelevement = idprelevement;
            this.PositionGPS = PositionGPS;
            this.Type = Type;

        }

        public int idprelevementProperty
        {
            get { return idprelevement; }
        }

        public String PositionGPSProperty
        {
            get { return PositionGPS; }
            set
            {
                PositionGPS = value.ToUpper();
               // this.concatProperty = value.ToUpper() + " " + Type;
                OnPropertyChanged("PositionGPSProperty");
            }

        }
        public String TypeProperty
        {
            get { return Type; }
            set
            {
                this.Type = value;
                this.concatProperty = this.PositionGPS + " " + value;
                OnPropertyChanged("TypeProperty");
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
                PrelevementORM.updatePrelevement(this);
            }
        }

    }
}
