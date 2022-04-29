using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace TP2_interface_graphique.ViewModels
{
    class MainWindowViewModel
    {
        public ICommand SeConnecterCommand { get; private set; }
        public ICommand CreerCommand { get; private set; }
        public ICommand QuitterCommand { get; private set; }
        public ObservableCollection<Models.Users> CollectionUsers { get; set; }
        public Models.Users User { get; set; }





        public MainWindowViewModel()
        {
            User = new Models.Users();
            CollectionUsers = new ObservableCollection<Models.Users>();
            foreach (Models.Users user in Models.Users.GetUsers())
                CollectionUsers.Add(user);

            //Section commandes

            SeConnecterCommand = new RelayCommand(
                o => User.TestIsValid(),
                o => Connection()
                );
            CreerCommand = new RelayCommand(
                o => true,
                o =>
                { // création de la page Window_New_user et affichage + fermeture de l'ancienne page
                    new Views.Window_New_user().Show();
                    fermer();
                }
                );
            QuitterCommand = new RelayCommand(
                o => true,
                o => fermer()
                );
        }
        private void Connection()
        {
            // création d'une propriété globale "test" pour passer les infos utilisateurs aux autres pages
            Application.Current.Properties["test"] = User;

            Views.Fenetre_Principale Fenetre = new Views.Fenetre_Principale();
            Fenetre.Show();
            fermer();
            
        }
        private void fermer()
        {
            // vérifie chaque fenêtre qui a déja été instanciée et ferme celle qui a le bon datacontext

            var windows = Application.Current.Windows;
            for (var i = 0; i < windows.Count; i++)
                if (windows[i].DataContext == this)
                    windows[i].Close();
        }

    }
}
