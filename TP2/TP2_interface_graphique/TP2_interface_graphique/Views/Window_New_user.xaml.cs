using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TP2_interface_graphique.Views
{
    /// <summary>
    /// Logique d'interaction pour Window_New_user.xaml
    /// </summary>
    public partial class Window_New_user : Window
    {
        public Window_New_user()
        {
            InitializeComponent();

            DataContext = new ViewModels.Window_New_user_ViewModel();
        }
    }
}
