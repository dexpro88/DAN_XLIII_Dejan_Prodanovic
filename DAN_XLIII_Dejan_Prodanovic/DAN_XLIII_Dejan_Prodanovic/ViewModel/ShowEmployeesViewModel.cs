using DAN_XLIII_Dejan_Prodanovic.Service;
using DAN_XLIII_Dejan_Prodanovic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIII_Dejan_Prodanovic.ViewModel
{
    class ShowEmployeesViewModel: ViewModelBase
    {
        ShowEmployees showEmployees;
        IEmployeeService employeeService;

        #region Constructor
        public ShowEmployeesViewModel(ShowEmployees showEmployeesOpen)
        {                   
            showEmployees = showEmployeesOpen;
            employeeService = new EmployeeService();

            employeeService.GetAllNonMenagerEmployees();
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
    }
}
