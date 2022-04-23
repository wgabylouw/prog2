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
        public ICommand SeConnecterCommand { get; set; }
        public ICommand CreerCommand { get; set; }
        public ICommand QuitterCommand { get; set; }
        public ObservableCollection<Models.Users> CollectionUsers { get; set; }
        public Models.Users User { get; set; }

        public MainWindowViewModel()
        {
            User = new Models.Users();

            CollectionUsers = new ObservableCollection<Models.Users>();
            foreach (Models.Users user in Models.Users.ShowUsers())
                CollectionUsers.Add(user);
            //List<Models.Users> listeUsers = Models.Users.ShowUsers();

            SeConnecterCommand = new RelayCommand(
                o => User.TestIsValid(),
                o => Connection()
                );
            CreerCommand = new RelayCommand(
                o => true,
                o => { new Views.Window_New_user().Show();
                    //Application.Current.MainWindow.Close();
                    fermer();
                }
                );
            QuitterCommand = new RelayCommand(
                o => true,
                o => fermer()//Application.Current.MainWindow.Close()
                );
        }
        private void Connection()
        {
            Application.Current.Properties["test"] = User;
            Views.Fenetre_Principale Fenetre = new Views.Fenetre_Principale();
            //Fenetre.DataContext = Application.Current.MainWindow.DataContext;
            Fenetre.Show();
            //Application.Current.MainWindow.Close();
            fermer();
            
        }
        private void fermer()
        {
            var windows = Application.Current.Windows;
            for (var i = 0; i < windows.Count; i++)
                if (windows[i].DataContext == this)
                    windows[i].Close();
        }

    }
}
