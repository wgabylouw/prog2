using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_interface_graphique.ViewModels
{
    class MainWindowViewModel
    {
   
        public MainWindowViewModel()
        {
            List<Models.Users> listeUsers = Models.Users.ShowUsers();
        }
    }
}
