using Marija_Bozic_Dan_60.Models;
using Marija_Bozic_Dan_60.Service;
using Marija_Bozic_Dan_60.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Marija_Bozic_Dan_60.ViewModels
{
    public class MainWindowViewModel:ViewModelBase
    {
        ServiceCode service = new ServiceCode();
        MainWindow mainView;
        #region Constructor

        public MainWindowViewModel(MainWindow main)
        {
            this.mainView = main;
            service.CheckNewLocation();
            ListOfGenders = new ObservableCollection<Gender>(service.GettAllGender());
            ListOfWorkers = new ObservableCollection<User>(service.GettAllUsers());
            ListOfLocation = new ObservableCollection<Location>(service.GettAllLocations().OrderBy(x=>x.Name));
        }
        #endregion
        #region Properties
        private ObservableCollection<Gender> listOfGenders;
        public ObservableCollection<Gender> ListOfGenders
        {
            get
            {
                return listOfGenders;
            }
            set
            {
                listOfGenders = value;
                OnPropertyChanged("ListOfGenders");
            }
        }

        private Gender selectedGender;
        public Gender SelectedGender
        {
            get
            {
                return selectedGender;
            }
            set
            {
                selectedGender = value;
                OnPropertyChanged("SelectedGender");
            }
        }

        private ObservableCollection<User> listOfWorkers;
        public ObservableCollection<User> ListOfWorkers
        {
            get
            {
                return listOfWorkers;
            }
            set
            {
                listOfWorkers = value;
                OnPropertyChanged("ListOfWorkers");
            }
        }

        private ObservableCollection<Location> listOfLocation;
        public ObservableCollection<Location> ListOfLocation
        {
            get
            {
                return listOfLocation;
            }
            set
            {
                listOfLocation = value;
                OnPropertyChanged("ListOfLocation");
            }
        }

        private Location selectedLocation;
        public Location SelectedLocation
        {
            get
            {
                return selectedLocation;
            }
            set
            {
                selectedLocation = value;
                OnPropertyChanged("SelectedLocation");
            }
        }

        private User selectedUser;
        public User SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        #endregion

        #region Commands        

        public void EditEmployee()
        {
            try
            {
                User userEdit = new User();
                userEdit.UserId = SelectedUser.UserId;
                userEdit.FullName = SelectedUser.FullName;
                userEdit.IDNumber = SelectedUser.IDNumber;
                userEdit.Jmbg = SelectedUser.Jmbg;
                userEdit.Date = SelectedUser.Date;
                userEdit.GenderId = SelectedUser.GenderId;
                userEdit.PhoneNumber = SelectedUser.PhoneNumber;
                userEdit.SectorId = SelectedUser.SectorId;
                userEdit.LocationId = SelectedUser.LocationId;
                userEdit.PhoneNumber = SelectedUser.PhoneNumber;
                userEdit.SectorName = selectedUser.SectorName;
                userEdit.MenagerId = selectedUser.MenagerId;

                AddEditNewWorkerView addEditView = new AddEditNewWorkerView(userEdit, true);
                addEditView.Show();
                mainView.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void DeleteExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete employee ?", "Deleting employee", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {

                    User userDeleted = new User();
                    userDeleted.UserId = SelectedUser.UserId;
                    if (service.DeleteUser(userDeleted.UserId))
                    {
                        MessageBox.Show("You have successfully deleted employee");
                        ListOfWorkers = new ObservableCollection<User>(service.GettAllUsers());
                        Thread t = new Thread(() => { Logging.LoggAction("Delete emplyee", "Success", "Succesfully deleted emplyee"); });
                        t.IsBackground = true;
                        t.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion
    }
}
