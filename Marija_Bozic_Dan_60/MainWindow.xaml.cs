using Marija_Bozic_Dan_60.Models;
using Marija_Bozic_Dan_60.ViewModels;
using Marija_Bozic_Dan_60.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Marija_Bozic_Dan_60
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel main;
        public MainWindow()
        {
            main = new MainWindowViewModel(this);
            this.DataContext = main;
            InitializeComponent();
        }

        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            AddEditNewWorkerView addEditView = new AddEditNewWorkerView(new User(), false);
            addEditView.Show();
            Close();
        }

        private void btnEditManager_Click(object sender, RoutedEventArgs e)
        {
            main.EditEmployee();
        }

        private void btnDeleteManager_Click(object sender, RoutedEventArgs e)
        {
            main.DeleteExecute();
        }
    }
}
