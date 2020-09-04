using Marija_Bozic_Dan_60.Models;
using Marija_Bozic_Dan_60.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private bool isValidFullName;
        private bool isValidDate;
        private bool isValidIDNumber;
        private bool isValidJmbg;
        private bool isValidGender;
        private bool isValidPhoneNumber;
        private bool isValidSector;
        private bool isValidLocation;
        private bool isValidMenager;

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

        private bool IsAddindEditUserEnabled()
        {
            if (isValidFullName &&
                isValidDate &&
                isValidGender &&
                isValidIDNumber &&
                isValidJmbg &&
                isValidPhoneNumber &&
                isValidSector &&
                isValidLocation)
            {
                return true;                 
            }
            else
            {
                return false;
            }
        }

        private bool IsEditUserEnabled()
        {
            if (isValidFullName &&
                isValidDate &&
                isValidGender &&
                isValidIDNumber &&
                isValidJmbg &&
                isValidPhoneNumber &&
                isValidSector &&
                isValidLocation && 
                isValidMenager)
            {

               return true;
            }
            else
            {
                return false;
            }
        }

        private void txtFullname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtFullname.Focus())
            {
                lblValidationFullname.Visibility = Visibility.Visible;
                lblValidationFullname.FontSize = 16;
                lblValidationFullname.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationFullname.Content = "The name must contain \nat least 5 caracters!";
            }

            string patternFullName = @"^([a-zA-Z ]{5,100})$";
            Match match = Regex.Match(txtFullname.Text, patternFullName, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtFullname.BorderBrush = new SolidColorBrush(Colors.Red);
                txtFullname.Foreground = new SolidColorBrush(Colors.Red);
                isValidFullName = false;
            }
            else
            {
                lblValidationFullname.Visibility = Visibility.Hidden;
                txtFullname.BorderBrush = new SolidColorBrush(Colors.Black);
                txtFullname.Foreground = new SolidColorBrush(Colors.Black);
                isValidFullName = true;
            }
            IsAddindEditUserEnabled();
            IsEditUserEnabled();
        }

        private void txtPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPhoneNumber.Focus())
            {
                lblValidationPhoneNumber.Visibility = Visibility.Visible;
                lblValidationPhoneNumber.FontSize = 16;
                lblValidationPhoneNumber.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationPhoneNumber.Content = "Phone number must be in \nformat 06xxxxxxx!!";
            }

            string pattern = @"^([06]{2}[0-9]{7,9})$";
            Match match = Regex.Match(txtPhoneNumber.Text, pattern, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                txtPhoneNumber.BorderBrush = new SolidColorBrush(Colors.Red);
                txtPhoneNumber.Foreground = new SolidColorBrush(Colors.Red);
                isValidPhoneNumber = false;
            }
            else
            {
                lblValidationPhoneNumber.Visibility = Visibility.Hidden;
                txtPhoneNumber.BorderBrush = new SolidColorBrush(Colors.Black);
                txtPhoneNumber.Foreground = new SolidColorBrush(Colors.Black);
                isValidPhoneNumber = true;
            }
            IsAddindEditUserEnabled();
            IsEditUserEnabled();
        }

        private void txtSector_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSector.Focus())
            {
                lblValidationSector.Visibility = Visibility.Visible;
                lblValidationSector.FontSize = 16;
                lblValidationSector.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationSector.Content = "The sector name must contain \nat least 2 caracters!";
            }

            string pattern = @"^([a-zA-Z0-9&%-*_@# ]{2,100})$";
            Match match = Regex.Match(txtSector.Text, pattern, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                txtSector.BorderBrush = new SolidColorBrush(Colors.Red);
                txtSector.Foreground = new SolidColorBrush(Colors.Red);
                isValidSector = false;
            }
            else
            {
                lblValidationSector.Visibility = Visibility.Hidden;
                txtSector.BorderBrush = new SolidColorBrush(Colors.Black);
                txtSector.Foreground = new SolidColorBrush(Colors.Black);
                isValidSector = true;
            }
            IsAddindEditUserEnabled();
            IsEditUserEnabled();
        }

        private void cmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbGender.Focus())
            {
                lblValidationGender.Visibility = Visibility.Visible;
                lblValidationGender.FontSize = 16;
                lblValidationGender.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationGender.Content = "You have to select gender!";
            }

            if (cmbGender.SelectedItem == null)
            {
                lblValidationGender.BorderBrush = new SolidColorBrush(Colors.Red);
                lblValidationGender.Foreground = new SolidColorBrush(Colors.Red);
                isValidGender = false;
            }
            else
            {
                lblValidationGender.BorderBrush = new SolidColorBrush(Colors.Black);
                lblValidationGender.Foreground = new SolidColorBrush(Colors.Black);
                isValidGender = true;
            }
            IsAddindEditUserEnabled();
            IsEditUserEnabled();
        }

        private void cmbLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbLocation.Focus())
            {
                lblValidationLocation.Visibility = Visibility.Visible;
                lblValidationLocation.FontSize = 16;
                lblValidationLocation.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationLocation.Content = "You have to select location!";
            }

            if (cmbLocation.SelectedItem == null)
            {
                lblValidationLocation.BorderBrush = new SolidColorBrush(Colors.Red);
                lblValidationLocation.Foreground = new SolidColorBrush(Colors.Red);
                isValidLocation = false;
            }
            else
            {
                lblValidationLocation.BorderBrush = new SolidColorBrush(Colors.Black);
                lblValidationLocation.Foreground = new SolidColorBrush(Colors.Black);
                isValidLocation = true;
            }
            IsAddindEditUserEnabled();
            IsEditUserEnabled();
        }

        private void dpDateOfBirth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            int currentYear = DateTime.Now.Year;
            int choosenDate = 0;
            if (dpDateOfBirth.SelectedDate != null)
            {
                choosenDate = dpDateOfBirth.SelectedDate.Value.Year;
            }

            if (!dpDateOfBirth.SelectedDate.HasValue)
            {
                dpDateOfBirth.BorderBrush = new SolidColorBrush(Colors.Red);
                dpDateOfBirth.Foreground = new SolidColorBrush(Colors.Red);
                isValidDate = false;
            }
            else if ((currentYear - choosenDate) < 18)
            {
                dpDateOfBirth.BorderBrush = new SolidColorBrush(Colors.Red);
                dpDateOfBirth.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationDateOfBirth.Foreground = new SolidColorBrush(Colors.Red);
                //lblValidationDateOfBirth.Content = "The person must be of legal age!";
                isValidDate = false;
            }
            else if ((currentYear - choosenDate) > 80)
            {
                dpDateOfBirth.BorderBrush = new SolidColorBrush(Colors.Red);
                dpDateOfBirth.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationDateOfBirth.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationDateOfBirth.Content = "Invalid year!";
                isValidDate = false;
            }
            else
            {
                lblValidationDateOfBirth.Visibility = Visibility.Hidden;
                dpDateOfBirth.BorderBrush = new SolidColorBrush(Colors.Black);
                dpDateOfBirth.Foreground = new SolidColorBrush(Colors.Black);
                isValidDate = true;
            }
            IsAddindEditUserEnabled();
            IsEditUserEnabled();
        }

        private void txtIDNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtIDNumber.Focus())
            {
                lblValidationIDNumber.Visibility = Visibility.Visible;
                lblValidationIDNumber.FontSize = 16;
                lblValidationIDNumber.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationIDNumber.Content = "The IDNumber must contain \n7 caracters!";
            }
            string pattern = @"^([0-9]{7})$";
            Match match = Regex.Match(txtIDNumber.Text, pattern, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                txtIDNumber.BorderBrush = new SolidColorBrush(Colors.Red);
                txtIDNumber.Foreground = new SolidColorBrush(Colors.Red);
                isValidIDNumber = false;
            }
            else
            {
                lblValidationIDNumber.Visibility = Visibility.Hidden;
                txtIDNumber.BorderBrush = new SolidColorBrush(Colors.Black);
                txtIDNumber.Foreground = new SolidColorBrush(Colors.Black);
                isValidIDNumber = true;
            }
            IsAddindEditUserEnabled();
            IsEditUserEnabled();
        }

        private void txtJmbg_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtJmbg.Focus())
            {
                lblValidationJmbg.Visibility = Visibility.Visible;
                lblValidationJmbg.FontSize = 16;
                lblValidationJmbg.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationJmbg.Content = "The JMBG must contain \n13 caracters!";
            }
            string patternJMBG = @"^([0-9]{13})$";
            Match match = Regex.Match(txtJmbg.Text, patternJMBG, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                txtJmbg.BorderBrush = new SolidColorBrush(Colors.Red);
                txtJmbg.Foreground = new SolidColorBrush(Colors.Red);
                isValidJmbg = false;
            }
            else
            {
                lblValidationJmbg.Visibility = Visibility.Hidden;
                txtJmbg.BorderBrush = new SolidColorBrush(Colors.Black);
                txtJmbg.Foreground = new SolidColorBrush(Colors.Black);
                isValidJmbg = true;
            }
            IsAddindEditUserEnabled();
            IsEditUserEnabled();
        }

        private void cmbMenagerForEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbMenagerForEdit.Focus())
            {
                lblValidationMenager.Visibility = Visibility.Visible;
                lblValidationMenager.FontSize = 16;
                lblValidationMenager.Foreground = new SolidColorBrush(Colors.Red);
                lblValidationMenager.Content = "You have to select gender!";
            }

            if (cmbMenagerForEdit.SelectedItem == null)
            {
                lblValidationMenager.BorderBrush = new SolidColorBrush(Colors.Red);
                lblValidationMenager.Foreground = new SolidColorBrush(Colors.Red);
                isValidMenager = false;
            }
            else
            {
                lblValidationMenager.BorderBrush = new SolidColorBrush(Colors.Black);
                lblValidationMenager.Foreground = new SolidColorBrush(Colors.Black);
                isValidMenager = true;
            }
            IsEditUserEnabled();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(IsAddindEditUserEnabled())
            {
                viewModel.SaveExecute();
            }
            else
            {
                MessageBox.Show("You have not filled in all required fields");
            }
        }
    }
}
