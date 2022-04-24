using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using KnnLibrary;
using CsvHelper;
namespace TP2_interface_graphique.ViewModels
{
    class FenetrePrincipaleViewModel
    {
        public ICommand MAJUserCommand { get; set; }
        public Models.Users User { get; set; }
        public ObservableCollection<string> Cities { get; set; }




        public FenetrePrincipaleViewModel()
        {
            User = (Models.Users)Application.Current.Properties["test"];

            this.Cities = new ObservableCollection<string>()
            {
                "Québec",
                "Lévis",
                "Rimouski"
            };

            MAJUserCommand = new RelayCommand(
                o => User.TestIsValid(),
                o => { 
                    Models.Users.UpdateUser(User);
                    MessageBox.Show($"Mise à jour du compte de {User.FirstName} {User.Name} réussit avec succès",
                                    "",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                });


        }
    }
}
