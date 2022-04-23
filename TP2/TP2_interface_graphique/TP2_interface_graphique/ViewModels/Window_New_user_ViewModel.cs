using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;


namespace TP2_interface_graphique.ViewModels
{
    public enum OptionSex
    {
        Homme,
        Femme
    }
    class Window_New_user_ViewModel
    {
        public ICommand NewUserCommand { get; private set; }
        public ICommand RetourCommand { get; private set; }
        public Models.Users Users { get; set; }
        public ObservableCollection<string> Cities { get; set; }

        public Window_New_user_ViewModel()
        {
            this.Users = new Models.Users();

            this.Cities = new ObservableCollection<string>()
            {
                "Québec",
                "Lévis",
                "Rimouski"
            };

            Users.Sex = OptionSex.Homme;

            NewUserCommand = new RelayCommand(
                o => this.Users.IsValid,
                o => {
                    Models.Users.AddUser(this.Users);
                    new MainWindow().Show();
                    fermer();
                });
            RetourCommand = new RelayCommand(
                o => true,
                o => { new MainWindow().Show();
                        fermer();
                     }
                );
        }
        //fonction qui permet de fermer les pages, car on dirait que le mvvm est pas fait pour fermer des pages!!
        private void fermer()
        {
            var windows = Application.Current.Windows;
            for (var i = 0; i < windows.Count; i++)
                if (windows[i].DataContext == this)
                    windows[i].Close();
        }
    }
}
