using DAN_XLIII_Dejan_Prodanovic.Commands;
using DAN_XLIII_Dejan_Prodanovic.Service;
using DAN_XLIII_Dejan_Prodanovic.Utility;
using DAN_XLIII_Dejan_Prodanovic.Validations;
using DAN_XLIII_Dejan_Prodanovic.View;
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

        private tblEmployee currentUser;
 

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

        private string salary;
        public string Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
                OnPropertyChanged("Salary");
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
                        if (empl.IsMenager==true)
                        {
                            ViewMenagerMainPage = Visibility.Visible;
                            ViewLoginPage = Visibility.Hidden;
                            currentUser = employeeService.GetEmployeeByUsername(employee.Username);
                            return;
                        }
                       
                    }
                }

                MessageBox.Show("Pogresna sifra ili korisnicko ime");
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

                int salary;
                if (!Int32.TryParse(Salary,out salary))
                {
                    MessageBox.Show("Plata mora biti broj");
                    return;
                }

                MenagerToAdd.RoleID = MenagerRole.RoleID;
                MenagerToAdd.SectorID = menagerSector.SectorID;
                MenagerToAdd.Salary = salary;
                MenagerToAdd.DateOfBirth = StartDate;

                EmployeeList = employeeService.GetAllEmployees();

                //string textForFile = String.Format("Added user {0} {1} JMBG {2}", employee.FirstName,
                //              employee.LastName, employee.JMBG);
                //eventObject.OnActionPerformed(textForFile);
                //employee.GenderID = gender.GenderID;

                isUpdateUser = true;


                menagerService.AddMenager(MenagerToAdd);

                MenagerToAdd = new tblEmployee();
                MenagerRole = new tblRole();
                MenagerSector = new tblSector();
                Salary = "";
                MessageBox.Show("Uspesno ste dodali menadzera");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanAddMenagerExecute()
        {

            if (String.IsNullOrEmpty(MenagerToAdd.FirstName) || String.IsNullOrEmpty(MenagerToAdd.FirstName) ||
                String.IsNullOrEmpty(MenagerToAdd.JMBG) || String.IsNullOrEmpty(MenagerToAdd.Email) ||
                String.IsNullOrEmpty(MenagerToAdd.Position) || String.IsNullOrEmpty(MenagerToAdd.Passwd) ||
                String.IsNullOrEmpty(MenagerToAdd.Username) || String.IsNullOrEmpty(Salary)
               )
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private ICommand showEmployees;
        public ICommand ShowEmployees
        {
            get
            {
                if (showEmployees == null)
                {
                    showEmployees = new RelayCommand(param => ShowEmployeesExecute(), param => CanShowEmployeesExecute());
                }
                return showEmployees;
            }
        }

        private void ShowEmployeesExecute()
        {
            try
            {
                 
                tblRole currentUserRole = roleService.GetRoleByID((int)currentUser.RoleID);

                if (currentUserRole.RoleName.Equals("modify"))
                {
                    ShowEmployees showEmployees = new ShowEmployees(employee);
                    showEmployees.ShowDialog();
                }
                else if (currentUserRole.RoleName.Equals("read-only"))
                {
                    ShowEmployeesReadOnly showEmployeesReadOnly = new ShowEmployeesReadOnly();
                    showEmployeesReadOnly.ShowDialog();
                }
                      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanShowEmployeesExecute()
        {
            return true;
        }
        #endregion
    }
}
