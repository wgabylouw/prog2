using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Windows.Input;


namespace TP2_interface_graphique.ViewModels
{
    class Window_New_user_ViewModel
    {
        public Models.Users Users { get; set; }

        public ObservableCollection<string> Cities { get; set; }

        public Window_New_user_ViewModel ()
        {
            this.Users = new Models.Users();

            this.Cities = new ObservableCollection<string>()
            {
                "Québec",
                "Lévis",
                "Rimouski"
            };


            NewUserCommand = new RelayCommand(

                o => this.Users.IsValid,
                o => Models.Users.AddUser(this.Users)

            );
    }
        public ICommand NewUserCommand { get; private set; }
    }
}
