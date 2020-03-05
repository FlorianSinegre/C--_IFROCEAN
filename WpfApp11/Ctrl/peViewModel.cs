using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11.Ctrl
{
    class peViewModel
    {
        public int idEtude;
        public int idpersonne;

        public peViewModel() { }

        public peViewModel(int idEtude, int idpersonne)
        {
            this.idEtude = idEtude;
            this.idpersonne = idpersonne;
        }
        public int idEtudeProperty
        {
            get { return idEtude; }
        }

        public int idPersonneProperty
        {
            get { return idpersonne; }

        }
    }
}
