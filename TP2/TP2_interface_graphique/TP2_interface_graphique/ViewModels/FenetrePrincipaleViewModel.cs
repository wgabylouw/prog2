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
    class FenetrePrincipaleViewModel
    {
        public FenetrePrincipaleViewModel()
        {
            Models.Users user = (Models.Users)Application.Current.Properties["test"];
        }
    }
}
