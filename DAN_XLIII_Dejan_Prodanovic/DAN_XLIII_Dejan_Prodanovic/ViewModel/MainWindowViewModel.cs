using DAN_XLIII_Dejan_Prodanovic.Commands;
using DAN_XLIII_Dejan_Prodanovic.Service;
using DAN_XLIII_Dejan_Prodanovic.Utility;
using DAN_XLIII_Dejan_Prodanovic.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_XLIII_Dejan_Prodanovic.ViewModel
{
    class MainWindowViewModel:ViewModelBase
    {
        MainWindow main;
        IEmployeeService employeeService;
        IRoleService roleService;
        ISectorService sectorService;
        IMenagerService menagerService;
        #region Constructor

        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
            employeeList = new List<tblEmployee>();
            employee = new tblEmployee();
            menagerToAdd = new tblEmployee();

            employeeService = new EmployeeService();
            roleService = new RoleService();
            sectorService = new SectorService();
            menagerService = new MenagerService();

            //userList = service.GetAllUsers();
            roles = roleService.GetAllRoles();
            sectors = sectorService.GetAllSectors();
            employeeList = employeeService.GetAllEmployees();

        }


        #endregion

        #region Properties
        private tblEmployee employee;
        public tblEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        private tblEmployee menagerToAdd;
        public tblEmployee MenagerToAdd
        {
            get
            {
                return menagerToAdd;
            }
            set
            {
                menagerToAdd = value;
                OnPropertyChanged("MenagerToAdd");
            }
        }

        private tblRole menagerRole;
        public tblRole MenagerRole
        {
            get
            {
                return menagerRole;
            }
            set
            {
                menagerRole = value;
                OnPropertyChanged("MenagerRole");
            }
        }

        private tblSector menagerSector;
        public tblSector MenagerSector
        {
            get
            {
                return menagerSector;
            }
            set
            {
                menagerSector = value;
                OnPropertyChanged("MenagerSector");
            }
        }
        private List<tblEmployee> employeeList;
        public List<tblEmployee> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }

        private List<tblRole> roles;
        public List<tblRole> Roles
        {
            get
            {
                return roles;
            }
            set
            {
                roles = value;
                OnPropertyChanged("Roles");
            }
        }

        private List<tblSector> sectors;
        public List<tblSector> Sectors
        {
            get
            {
                return sectors;
            }
            set
            {
                sectors = value;
                OnPropertyChanged("Sectors");
            }
        }
        private Visibility viewAdminPage = Visibility.Collapsed;
        public Visibility ViewAdminPage
        {
            get
            {
                return viewAdminPage;
            }
            set
            {
                viewAdminPage = value;
                OnPropertyChanged("ViewAdminPage");
            }
        }

        private Visibility viewUserPage = Visibility.Collapsed;
        public Visibility ViewUserPage
        {
            get
            {
                return viewUserPage;
            }
            set
            {
                viewUserPage = value;
                OnPropertyChanged("ViewUserPage");
            }
        }

        private Visibility viewLoginPage = Visibility.Visible;
        public Visibility ViewLoginPage
        {
            get
            {
                return viewLoginPage;
            }
            set
            {
                viewLoginPage = value;
                OnPropertyChanged("ViewLoginPage");
            }
        }

        private Visibility viewAddMenagerPage = Visibility.Collapsed;
        public Visibility ViewAddMenagerPage
        {
            get
            {
                return viewAddMenagerPage;
            }
            set
            {
                viewAddMenagerPage = value;
                OnPropertyChanged("ViewAddMenagerPage");
            }
        }

        private Visibility viewMenagerMainPage = Visibility.Collapsed;
        public Visibility ViewMenagerMainPage
        {
            get
            {
                return viewMenagerMainPage;
            }
            set
            {
                viewMenagerMainPage = value;
                OnPropertyChanged("ViewMenagerMainPage");
            }
        }

        private DateTime _startDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; OnPropertyChanged("StartDate"); }
        }

        private bool isUpdateUser;
        public bool IsUpdateUser
        {
            get
            {
                return isUpdateUser;
            }
            set
            {
                isUpdateUser = value;
            }
        }
        #endregion

        #region Commands 
        private ICommand login;
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(LoginExecute, CanLogin);
                }
                return login;
            }
        }

        private void LoginExecute(object parameter)
        {
            try
            {
                var passwordBox = parameter as PasswordBox;
                var password = passwordBox.Password;

                if (employee.Username.Equals("WPFadmin") && password.Equals("WPFadmin"))
                {
                    ViewAddMenagerPage = Visibility.Visible;
                    ViewLoginPage = Visibility.Hidden;
                    return;
                }

               

                foreach (var empl in EmployeeList)
                {

                    if (empl.Username.Equals(employee.Username) && empl.Passwd.Equals(password))
                    {
                        ViewMenagerMainPage = Visibility.Visible;
                        ViewLoginPage = Visibility.Hidden;
                        return;
                    }
                }
                //string encryptedString = EncryptionHelper.Encrypt(password);


                //string decryptedString = EncryptionHelper.Decrypt(encryptedString);

                //bool userExists = false;
                //foreach (var u in UserList)
                //{

                //    if (u.Username.Equals(User.Username) && u.Password.Equals(encryptedString))
                //    {
                //        userExists = true;
                //        if (u.Role.Equals("Admin"))
                //        {
                //            ViewLoginPage = Visibility.Hidden;
                //            ViewAdminPage = Visibility.Visible;
                //            user = u;
                //        }
                //        else if (u.Role.Equals("User"))
                //        {
                //            ViewLoginPage = Visibility.Hidden;
                //            ViewUserPage = Visibility.Visible;
                //            user = u;
                //        }
                //    }
                //}
                //if (!userExists)
                //{
                //    MessageBox.Show("Invalid password or usrname");


                //}
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogin(object parameter)
        {
            //var passwordBox = parameter as PasswordBox;
            //var password = passwordBox.Password;
            //if (String.IsNullOrEmpty(user.Username) || String.IsNullOrEmpty(password))
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
            return true;
        }

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(LogoutExecute, CanLogout);
                }
                return logout;
            }
        }

        private void LogoutExecute(object parameter)
        {
            try
            {
                 
                ViewLoginPage = Visibility.Visible;

                ViewAddMenagerPage = Visibility.Hidden;
                ViewMenagerMainPage = Visibility.Hidden;
                //if (user.Role.Equals("Admin"))
                //{
                //    ViewLoginPage = Visibility.Visible;
                //    ViewAdminPage = Visibility.Hidden;
                //    User = new tblUser();
                //    //User.Password = "";
                //}
                //else if (user.Role.Equals("User"))
                //{
                //    ViewLoginPage = Visibility.Visible;
                //    ViewUserPage = Visibility.Hidden;
                //    User = new tblUser();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanLogout(object parameter)
        {
            return true;
        }

        private ICommand addMenager;

        public ICommand AddMenager
        {
            get
            {
                if (addMenager == null)
                {
                    addMenager = new RelayCommand(param => AddMenagerExecute(), param => CanAddMenagerExecute());
                }
                return addMenager;
            }
        }

        private void AddMenagerExecute()
        {
            try
            {

                if (!ValidationClass.JMBGisValid(MenagerToAdd.JMBG))
                {
                    MessageBox.Show("JMBG  nije validan.");
                    return;
                }

                //if (!ValidationClass.JMBGIsUnique(employee.JMBG))
                //{
                //    MessageBox.Show("JMBG  already exists in database");
                //    return;
                //}

                
                if (!ValidationClass.IsValidEmail(MenagerToAdd.Email))
                {
                    MessageBox.Show("Email nije validan");
                    return;
                }

                MenagerToAdd.RoleID = MenagerRole.RoleID;
                MenagerToAdd.SectorID = menagerSector.SectorID;

                MenagerToAdd.DateOfBirth = StartDate;

                

                //string textForFile = String.Format("Added user {0} {1} JMBG {2}", employee.FirstName,
                //              employee.LastName, employee.JMBG);
                //eventObject.OnActionPerformed(textForFile);
                //employee.GenderID = gender.GenderID;

                isUpdateUser = true;


                menagerService.AddMenager(MenagerToAdd);

                MenagerToAdd = new tblEmployee();
                MenagerRole = new tblRole();
                MenagerSector = new tblSector();
                MessageBox.Show("Uspesno ste dodali menadzera");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddMenagerExecute()
        {

            //if (String.IsNullOrEmpty(Employee.FirstName) || String.IsNullOrEmpty(Employee.FirstName) ||
            //    String.IsNullOrEmpty(Employee.JMBG) || String.IsNullOrEmpty(Employee.RegistrationNumber) ||
            //    String.IsNullOrEmpty(Employee.TelefonNumber) || String.IsNullOrEmpty(SelctedLocation.Location) ||
            //    String.IsNullOrEmpty(Sector)
            //   )
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
            return true;
        }

        //private ICommand register;
        //public ICommand Register
        //{
        //    get
        //    {
        //        if (register == null)
        //        {
        //            register = new RelayCommand(param => RegisterExecute(), param => CanRegisterExecute());
        //        }
        //        return register;
        //    }
        //}

        //private void RegisterExecute()
        //{
        //    try
        //    {
        //        Register register = new Register();
        //        register.ShowDialog();
        //        //if ((addStudent.DataContext as AddStudentViewModel).IsUpdateStudent == true)
        //        //{
        //        //    using (Service1Client wcf = new Service1Client())
        //        //    {
        //        //        StudentList = wcf.GetAllStudents().ToList();
        //        //    }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
        //private bool CanRegisterExecute()
        //{
        //    return true;
        //}
        #endregion
    }
}
