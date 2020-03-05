using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;
using System.Windows.Media;
using System.Collections.ObjectModel;
using WpfApp11.Ctrl;
using WpfApp11.DAL;
using WpfApp11.ORM;
using WpfApp11;

namespace WpfApp11
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window window;

        int selectedPersonneId;
        int selectedPrelevementId;
        int selectedEspeceId;
        int selectedEtudeId;
        int selectedPlageId;

        PersonneViewModel myDataObject; // Objet de liaison
        PrelevementViewModel myDataObject_prelevement;
        EspeceViewModel myDataObject_Espece;
        EtudeViewModel myDataObject_Etude;
        PlageViewModel myDataObject_Plage;


        ObservableCollection<PersonneViewModel> lp;
        ObservableCollection<PrelevementViewModel> lp_prel;
        ObservableCollection<EspeceViewModel> lp_Esp;
        ObservableCollection<EtudeViewModel> lp_Et;
        ObservableCollection<PlageViewModel> lp_Pl;
        ObservableCollection<CommuneViewModel> lc;
        ObservableCollection<DepartementViewModel> de;
        
        
        
        

        int compteur = 0;

        public MainWindow(Window actual_window)
        {
            window = actual_window;
            InitializeComponent();
            DALConnection.OpenConnection();

            // Initialisation de la liste des personnes via la BDD.
            lp = PersonneORM.listePersonnes();
            lp_prel = PrelevementORM.listePrelevements();
            lp_Esp = EspeceORM.listeEspeces();
            lp_Et = EtudeORM.listeEtude();
            lp_Pl = PlageORM.listePlages();
            lc = CommuneORM.listeCommunes();
            de = DepartementORM.listeDepartements();

            //LIEN AVEC la VIEW
            listePersonnes.ItemsSource = lp;
            listePrelevement.ItemsSource = lp_prel;
            listeEspece.ItemsSource = lp_Esp;
            listeEtude.ItemsSource = lp_Et;
            listePlages.ItemsSource = lp_Pl;
            // bind de la liste avec la source, permettant le binding.
            // this.DataContext = lp; // bind de la liste avec la source, permettant le binding mais de façon globale sur toute la fenetre


            //COMBO BOX FONCTIONNEL
            foreach (var item in lc)
            {
                liste_box1.Items.Add(item.nomVilleProperty);
            }
            foreach (var item in de)
            {
                liste_box3.Items.Add(item.nomProperty);
            }
            foreach (var item2 in lp_prel)
            {
                liste_box2.Items.Add(item2.idprelevementProperty);
            }

        }
        public void prenomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.prenomProperty = prenomTextBox.Text;
        }
        public void nomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.nomProperty = nomTextBox.Text;
        }

        /////////////// Prelevement////////////////////////////////////////////////////////
        public void PositionGPSChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject_prelevement.PositionGPSProperty = PositionGPSTextBox.Text;
        }
        public void TypeChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject_prelevement.TypeProperty = TypeTextBox.Text;
        }

        ////////////////////////////////////////////////////////////////////////////////


        /////////////// Espece////////////////////////////////////////////////////////
        public void nomEspeceChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject_Espece.nomProperty = nom_especeTextBox.Text;
        }
        public void genreEspeceChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject_Espece.genreProperty = genre_especeTextBox.Text;
        }

        ////////////////////////////////////////////////////////////////////////////////



        /////////////// Etude////////////////////////////////////////////////////////


        public void DateEtudeChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject_Etude.DateProperty = Date_etudeTextBox.Text;
                
        }
        public void SuperficieEtudierChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject_Etude.SuperficieEtudierProperty = Super_etudeTextBox.Text;
        }


        ////////////////////////////////////////////////////////////////////////////////


        /////////////// Plage////////////////////////////////////////////////////////
        
        public void nom_PlageChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject_Plage.nomProperty = nomPlageTextBox.Text;
        }


        ////////////////////////////////////////////////////////////////////////////////
        private void nomPrenomButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myDataObject = new PersonneViewModel();
            myDataObject.prenomProperty = prenomTextBox.Text;
            myDataObject.nomProperty = nomTextBox.Text;
            PersonneViewModel nouveau = new PersonneViewModel(PersonneDAL.getMaxIdPersonne() + 1, myDataObject.nomProperty, myDataObject.prenomProperty);
            lp.Add(nouveau);
            PersonneORM.insertPersonne(nouveau);
            listePersonnes.Items.Refresh();
            compteur = lp.Count();
            myDataObject = new PersonneViewModel(PersonneDAL.getMaxIdPersonne() + 1, "", "");
        }


        /////////////// Prelevement////////////////////////////////////////////////////////
        private void ajouterPrelevementButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myDataObject_prelevement = new PrelevementViewModel();
            
            myDataObject_prelevement.PositionGPSProperty = PositionGPSTextBox.Text;
            myDataObject_prelevement.TypeProperty = TypeTextBox.Text;
            PrelevementViewModel nouveau = new PrelevementViewModel(PrelevementDAL.getMaxIdPrelevement() + 1, myDataObject_prelevement.PositionGPSProperty, myDataObject_prelevement.TypeProperty);
            lp_prel.Add(nouveau);
            PrelevementORM.insertPrelevement(nouveau);
            listePrelevement.Items.Refresh();
            compteur = lp_prel.Count();
            myDataObject_prelevement = new PrelevementViewModel(PrelevementDAL.getMaxIdPrelevement() + 1, "", "");
        }

        ////////////////////////////////////////////////////////////////////////////////


        /////////////// Espece////////////////////////////////////////////////////////
        private void ajouterEspeceButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myDataObject_Espece = new EspeceViewModel();
            myDataObject_Espece.nomProperty = nom_especeTextBox.Text;
            myDataObject_Espece.genreProperty = genre_especeTextBox.Text;
            EspeceViewModel nouveau = new EspeceViewModel(EspeceDAL.getMaxIdEspece() + 1, myDataObject_Espece.nomProperty, myDataObject_Espece.genreProperty);
            lp_Esp.Add(nouveau);
            EspeceORM.insertEspece(nouveau);
            listeEspece.Items.Refresh();
            compteur = lp_Esp.Count();
            myDataObject_Espece = new EspeceViewModel(EspeceDAL.getMaxIdEspece() + 1, "", "");
        }

        ////////////////////////////////////////////////////////////////////////////////

        /////////////// Etude////////////////////////////////////////////////////////

        private void ajouterEtudeButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myDataObject_Etude = new EtudeViewModel();
            myDataObject_Etude.DateProperty = Date_etudeTextBox.Text;
            myDataObject_Etude.SuperficieEtudierProperty = Super_etudeTextBox.Text;
            EtudeViewModel nouveau = new EtudeViewModel(EtudeDAL.getMaxIdEtude() + 1, myDataObject_Etude.DateProperty, myDataObject_Etude.SuperficieEtudierProperty);
            lp_Et.Add(nouveau);
            EtudeORM.insertEtude(nouveau);
            listeEtude.Items.Refresh();
            compteur = lp_Et.Count();
            myDataObject_Etude = new EtudeViewModel(EtudeDAL.getMaxIdEtude() + 1, "", "");
        }


        ////////////////////////////////////////////////////////////////////////////////


        
        /////////////// Plage////////////////////////////////////////////////////////

        private void ajouterPlageButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myDataObject_Plage = new PlageViewModel();

            myDataObject_Plage.nomProperty = nomPlageTextBox.Text;
            //  myDataObject_Plage.TypeProperty = TypeTextBox.Text;
            PlageViewModel nouveau = new PlageViewModel(PlageDAL.getMaxIdPlage() + 1, myDataObject_Plage.nomProperty, new CommuneViewModel(1, "", ""), new PrelevementViewModel(1, "",""), new DepartementViewModel(1, "boulanger")) ;
            lp_Pl.Add(nouveau);
            PlageDAO.insertPlage(nouveau);
            listePlages.Items.Refresh();
            compteur = lp_Pl.Count();
            myDataObject_Plage = new PlageViewModel(PlageDAL.getMaxIdPlage() + 1, "", new CommuneViewModel(1, "", ""), new PrelevementViewModel(1, "", ""), new DepartementViewModel(1, "boulanger"));
        }


        ////////////////////////////////////////////////////////////////////////////////
        private void supprimerButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            PersonneViewModel toRemove = (PersonneViewModel)listePersonnes.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Voulez vous bien supprimer l'utilisateure "+toRemove.nomProperty+ "de la table ?","Table Utilisateur", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("l'utilisateur a été suprimmer");
                    
                    lp.Remove(toRemove);
                    listePersonnes.Items.Refresh();
                    PersonneORM.supprimerPersonne(selectedPersonneId);
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("L'utilisateur n'a pas été supprimer", "Table Utilisateur");
                    break;
                
            }
        }


        /////////////// Prelevement////////////////////////////////////////////////////////
        private void supprimerButton_Prelevement_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PrelevementViewModel toRemove = (PrelevementViewModel)listePrelevement.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Voulez vous bien supprimer le Prélèvement n° "+toRemove.idprelevementProperty + " de la table  ?", "", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Le prélèvement a bien été suprimmer", "Table Prélèvement");
                    
                    lp_prel.Remove(toRemove);
                    listePrelevement.Items.Refresh();
                    PrelevementORM.supprimerPrelevement(selectedPrelevementId);
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Le prélèvement n'a pas été supprimer", "Table Prélèvement");
                    break;
                
            }
        }

        /////////////// Espece////////////////////////////////////////////////////////

        private void supprimerButton_Espece_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EspeceViewModel toRemove = (EspeceViewModel)listeEspece.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Voulez vous bien supprimer l'Espece "+toRemove.nomProperty+ " de la table ?", "Table espece", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("l'èspece a été suprimmer", "Table Espece");
                    
                    lp_Esp.Remove(toRemove);
                    listeEspece.Items.Refresh();
                    EspeceORM.supprimerEspece(selectedEspeceId);
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("L'èspece n'a pas été supprimer", "Table Espece");
                    break;
                
            }
        }



        ////////////////////////////////////////////////////////////////////////////////
        /////////////// Etude////////////////////////////////////////////////////////


        private void supprimerButton_Etude_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EtudeViewModel toRemove = (EtudeViewModel)listeEtude.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Voulez vous bien supprimer l'Etude " + toRemove.idEtudeProperty + " de la table ?", "Table Etude", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("L'étude a été suprimmer", "Table Etude");
                    
                    lp_Et.Remove(toRemove);
                    listeEtude.Items.Refresh();
                    EtudeORM.supprimerEtude(selectedEtudeId);
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("L'étude n'a pas été supprimer", "Table Etude");
                    break;
               
            }
        }


        /////////////// Plage////////////////////////////////////////////////////////

        private void supprimerButton_Plage_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlageViewModel toRemove = (PlageViewModel)listePlages.SelectedItem;
            MessageBoxResult result = MessageBox.Show("Voulez vous bien supprimer la plage "+toRemove.nomProperty+ " de la table ?", "Table Plage", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("l'utilisateur a été suprimmer");
                    
                    lp_Pl.Remove(toRemove);
                    listePlages.Items.Refresh();
                    PlageDAO.supprimerPlage(selectedPlageId);
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("La plage n'a pas été supprimer", "Table Plage");
                    break;
              
            }
        }

        ////////////////////////////////////////////////////////////////////////////////
        private void VClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Blue !");
        }
        private void RClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Red !");
        }
        private void BClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Blue !");
        }

        private void listePersonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePersonnes.SelectedIndex < lp.Count) && (listePersonnes.SelectedIndex>=0))
            {
                selectedPersonneId = (lp.ElementAt<PersonneViewModel>(listePersonnes.SelectedIndex)).idPersonneProperty;
            }
        }

        private void listePrelevements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePrelevement.SelectedIndex < lp_prel.Count) && (listePrelevement.SelectedIndex >= 0))
            {
                selectedPrelevementId = (lp_prel.ElementAt<PrelevementViewModel>(listePrelevement.SelectedIndex)).idprelevementProperty;
            }
        }

        private void listeEspeces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEspece.SelectedIndex < lp_Esp.Count) && (listeEspece.SelectedIndex >= 0))
            {
                selectedEspeceId = (lp_Esp.ElementAt<EspeceViewModel>(listeEspece.SelectedIndex)).idEspeceProperty;
            }
        }


        private void listeEtudes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEtude.SelectedIndex < lp_Et.Count) && (listeEtude.SelectedIndex >= 0))
            {
                selectedEtudeId = (lp_Et.ElementAt<EtudeViewModel>(listeEtude.SelectedIndex)).idEtudeProperty;
            }
        }
        private void listePlages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePlages.SelectedIndex < lp_Et.Count) && (listePlages.SelectedIndex >= 0))
            {
                selectedPlageId = (lp_Pl.ElementAt<PlageViewModel>(listePlages.SelectedIndex)).idPlageProperty;
            }
        }






        /* private void Button_Click(object sender, RoutedEventArgs e)
         {
             Window2 window2 = new Window2();
             window2.Show();

         }
         */
        /* private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
         {
             grigrid.Height = sliderHeight.Value + 200;
         }*/

        /*  MessageBoxResult result = MessageBox.Show("Would you like to greet the world with a \"Hello, world\"?", "My App", MessageBoxButton.YesNoCancel);
          switch(result)
          {
      case MessageBoxResult.Yes:
          MessageBox.Show("Hello to you too!", "My App");
          break;
      case MessageBoxResult.No:
          MessageBox.Show("Oh well, too bad!", "My App");
          break;
      case MessageBoxResult.Cancel:
          MessageBox.Show("Nevermind then...", "My App");
          break;
          }*/
    }
}
