using Marija_Bozic_Dan_60.Models;
using Marija_Bozic_Dan_60.ViewModels;
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

namespace Marija_Bozic_Dan_60.Views
{
    /// <summary>
    /// Interaction logic for AddEditNewWorkerView.xaml
    /// </summary>
    public partial class AddEditNewWorkerView : Window
    {
        AddEditNewWorkerViewModel viewModel;
        public AddEditNewWorkerView(User user, bool isForEdit)
        {
            viewModel = new AddEditNewWorkerViewModel(user, this, isForEdit);
            this.DataContext = viewModel;
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void txtFullname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
