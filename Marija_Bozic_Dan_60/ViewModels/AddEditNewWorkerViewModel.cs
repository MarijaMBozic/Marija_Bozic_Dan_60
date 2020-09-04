using Marija_Bozic_Dan_60.Commands;
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
using System.Windows.Input;

namespace Marija_Bozic_Dan_60.ViewModels
{
    public class AddEditNewWorkerViewModel:ViewModelBase
    {
        AddEditNewWorkerView addEditUserView;
        ServiceCode service = new ServiceCode();
        #region Constructor
        public AddEditNewWorkerViewModel(User user, AddEditNewWorkerView addEditUserViewOpen, bool isForEdit)
        {
            this.isForEdit = isForEdit;
            this.user = user;
            addEditUserView = addEditUserViewOpen;
            GenderList = new ObservableCollection<Gender>(service.GettAllGender());
            SelectedGender = GenderList.FirstOrDefault(p => p.GenderId == user.GenderId);
            LocationList = new ObservableCollection<Location>(service.GettAllLocations());
            SelectedLocation = LocationList.FirstOrDefault(p => p.LocationId == user.LocationId);
            MenagerList = new ObservableCollection<User>(service.GettAllUsers());
            SelectedMenager = MenagerList.FirstOrDefault(p => p.UserId == user.MenagerId);
            MenagerListForEdit = new ObservableCollection<User>(service.GettAllMenagersForEdit(user.UserId));
            SelectedMenagerForEdit = MenagerListForEdit.FirstOrDefault(p=>p.UserId==user.MenagerId);
            
        }
        #endregion

        #region Properties
        private bool isForEdit;
        public bool IsForEdit
        {
            get
            {
                return isForEdit;
            }
        }
        private ObservableCollection<Gender> genderList;
        public ObservableCollection<Gender> GenderList
        {
            get
            {
                return genderList;
            }
            set
            {
                genderList = value;
                OnPropertyChanged("GenderList");
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

        private ObservableCollection<Location> locationList;
        public ObservableCollection<Location> LocationList
        {
            get
            {
                return locationList;
            }
            set
            {
                locationList = value;
                OnPropertyChanged("LocationList");
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

        private User user = new User();
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private User selectedMenager;
        public User SelectedMenager
        {
            get
            {
                return selectedMenager;
            }
            set
            {
                selectedMenager = value;
                OnPropertyChanged("SelectedMenager");
            }
        }
        private ObservableCollection<User> menagerList;
        public ObservableCollection<User> MenagerList
        {
            get
            {
                return menagerList;
            }
            set
            {
                menagerList = value;
                OnPropertyChanged("MenagerList");
            }
        }

        private User selectedMenagerForEdit;
        public User SelectedMenagerForEdit
        {
            get
            {
                return selectedMenagerForEdit;
            }
            set
            {
                selectedMenagerForEdit = value;
                OnPropertyChanged("SelectedMenagerForEdit");
            }
        }
        private ObservableCollection<User> menagerListForEdit;
        public ObservableCollection<User> MenagerListForEdit
        {
            get
            {
                return menagerListForEdit;
            }
            set
            {
                menagerListForEdit = value;
                OnPropertyChanged("MenagerListForEdit");
            }
        }


        #endregion

        #region Commands

        private ICommand save;

        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute());
                }
                return save;
            }
        }

        public void SaveExecute()
        {
            try
            {
                User.GenderId = selectedGender.GenderId;
                User.LocationId = selectedLocation.LocationId;                
                int sectorId = service.CheckSectorName(User.SectorName);
                if (sectorId == 0)
                {
                    sectorId = service.AddSector(User.SectorName);
                }
                User.SectorId = sectorId;
                if (User.UserId== 0)
                {
                    bool uniqueJmbg = service.CheckJmbg(User.Jmbg);
                    bool uniqueIdNumber = service.CheckIDNumber(User.IDNumber);

                    if(!uniqueIdNumber && !uniqueJmbg)
                    {
                        if (selectedMenager == null)
                        {
                            User.MenagerId = 0;
                        }
                        else
                        {
                            User.MenagerId = selectedMenager.UserId;
                        }                        
                        if (service.AddUser(User) != 0)
                        {
                            MessageBox.Show("You have successfully added new employee");
                            Thread t = new Thread(() => { Logging.LoggAction("Add new emplyee", "Success", "Succesfully added new emplyee"); });
                            t.IsBackground = true;
                            t.Start();
                        }
                    }
                    else if(uniqueJmbg)
                    {
                        MessageBox.Show("Jmbg is not unique!");
                    }
                    else if (uniqueIdNumber)
                    {
                        MessageBox.Show("ID number is not unique!");
                    }
                }
                else
                {
                    bool uniqueJmbg = service.Check_JMBG_Update(User.Jmbg, User.UserId);
                    bool uniqueIdNumber = service.Check_IDNumber_Update(User.IDNumber, User.UserId);
                    User.MenagerId = selectedMenagerForEdit.UserId;
                    if (uniqueIdNumber && uniqueJmbg)
                    {
                        service.UpdateUser(User);
                        MessageBox.Show("You have successfully changed employee data");
                        Thread t = new Thread(() => { Logging.LoggAction("Update emplyee", "Success", "Succesfully updated emplyee"); });
                        t.IsBackground = true;
                        t.Start();
                    }
                    else if (!uniqueJmbg)
                    {
                        MessageBox.Show("Jmbg is not match with user!");
                    }
                    else if (!uniqueIdNumber)
                    {
                        MessageBox.Show("ID number is not not match with user!");
                    }
                }
                MainWindow main = new MainWindow();
                main.Show();
                addEditUserView.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        #endregion
    }
}
