using DAN_XLIII_Dejan_Prodanovic.Commands;
using DAN_XLIII_Dejan_Prodanovic.Service;
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
    class ShowEmployeesViewModel: ViewModelBase
    {
        ShowEmployees showEmployees;
        IEmployeeService employeeService;

        #region Constructors

        public ShowEmployeesViewModel(ShowEmployees showEmployeesOpen)
        {
            showEmployees = showEmployeesOpen;
            employeeService = new EmployeeService();

            EmployeeList = employeeService.GetAllNonMenagerEmployees();
        }

        public ShowEmployeesViewModel(ShowEmployees showEmployeesOpen, tblEmployee currentUser)
        {                   
            showEmployees = showEmployeesOpen;
            employeeService = new EmployeeService();

            EmployeeList = employeeService.GetAllNonMenagerEmployees();
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
        #endregion

        #region Commands
        private ICommand addEmployee;
        public ICommand AddEmployee
        {
            get
            {
                if (addEmployee == null)
                {
                    addEmployee = new RelayCommand(param => AddEmployeeExecute(), param => CanAddEmployeeExecute());
                }
                return addEmployee;
            }
        }

        private void AddEmployeeExecute()
        {
            try
            {
                AddEmployee addEmployee = new AddEmployee();
                addEmployee.ShowDialog();


                EmployeeList = employeeService.GetAllNonMenagerEmployees();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddEmployeeExecute()
        {
            return true;
        }
        #endregion
    }
}
