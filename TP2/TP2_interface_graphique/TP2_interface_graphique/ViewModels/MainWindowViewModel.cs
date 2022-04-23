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
        public ObservableCollection<Models.Users> collectionUsers { get; set; }

        public MainWindowViewModel()
        {
            collectionUsers = new ObservableCollection<Models.Users>();
            foreach (Models.Users user in Models.Users.ShowUsers())
                collectionUsers.Add(user);
            //List<Models.Users> listeUsers = Models.Users.ShowUsers();

        }
        private void Connection()
        {
            Views.Fenetre_Principale Fenetre = new Views.Fenetre_Principale();
            Fenetre.Show();
            Application.Current.MainWindow.Close();
            
        }

    }
}
