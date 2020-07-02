using DAN_XLIII_Dejan_Prodanovic.Commands;
using DAN_XLIII_Dejan_Prodanovic.Service;
using DAN_XLIII_Dejan_Prodanovic.Validations;
using DAN_XLIII_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIII_Dejan_Prodanovic.ViewModel
{
    class AddEmployeeViewModel:ViewModelBase
    {
        AddEmployee addEmployee;
        IEmployeeService employeeService;
        #region Constructor
        public AddEmployeeViewModel(AddEmployee addEmployeeOpen)
        {
           
            employee = new tblEmployee();
            addEmployee = addEmployeeOpen;
            employeeService = new EmployeeService();

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
        #endregion

        #region Commands

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private void SaveExecute()
        {
            try
            {

                if (!ValidationClass.JMBGisValid(Employee.JMBG))
                {
                    MessageBox.Show("JMBG  nije validan.");
                    return;
                }

                //if (!ValidationClass.JMBGIsUnique(employee.JMBG))
                //{
                //    MessageBox.Show("JMBG  already exists in database");
                //    return;
                //}


                if (!ValidationClass.IsValidEmail(Employee.Email))
                {
                    MessageBox.Show("Email nije validan");
                    return;
                }

                int salary;
                if (!Int32.TryParse(Salary, out salary))
                {
                    MessageBox.Show("Plata mora biti broj");
                    return;
                }

                Employee.Salary = salary;
                Employee.DateOfBirth = StartDate;

               

                //string textForFile = String.Format("Added user {0} {1} JMBG {2}", employee.FirstName,
                //              employee.LastName, employee.JMBG);
                //eventObject.OnActionPerformed(textForFile);
                //employee.GenderID = gender.GenderID;

                isUpdateUser = true;


                employeeService.AddEmployee(employee);

                employee = new tblEmployee();
              
                Salary = "";
                //MessageBox.Show("Uspesno ste dodali menadzera");

                addEmployee.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {

            if (String.IsNullOrEmpty(Employee.FirstName) || String.IsNullOrEmpty(Employee.FirstName) ||
                String.IsNullOrEmpty(Employee.JMBG) || String.IsNullOrEmpty(Employee.Position) ||
                String.IsNullOrEmpty(Employee.Email) || String.IsNullOrEmpty(Employee.Username) ||
                String.IsNullOrEmpty(Employee.Passwd)
               )
            {
                return false;
            }
            else
            {
                return true;
            }
            //return true;
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        private void CloseExecute()
        {
            try
            {
                addEmployee.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }
 

        #endregion
    }
}
