using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIII_Dejan_Prodanovic.Service
{
    class EmployeeService : IEmployeeService
    {
        public tblEmployee AddEmployee(tblEmployee employee)
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {

                    tblEmployee newEmployee = new tblEmployee();
                    newEmployee.FirstName = employee.LastName;
                    newEmployee.LastName = employee.LastName;
                    newEmployee.JMBG = employee.JMBG;
                    newEmployee.Email = employee.Email;
                    newEmployee.DateOfBirth = employee.DateOfBirth;
                    newEmployee.IsMenager = false;
                    newEmployee.Position = employee.Position;
                    newEmployee.Salary = employee.Salary;
                    newEmployee.AccountNumber = employee.AccountNumber;
                    newEmployee.Username = employee.Username;
                    newEmployee.Passwd = employee.Passwd;
                  

                    context.tblEmployees.Add(newEmployee);
                    context.SaveChanges();

                    employee.EmployeeID = newEmployee.EmployeeID;



                    return employee;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblEmployee> GetAllEmployees()
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    List<tblEmployee> list = new List<tblEmployee>();
                    list = (from x in context.tblEmployees select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblEmployee> GetAllNonMenagerEmployees()
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    List<tblEmployee> list = new List<tblEmployee>();
                    list = (from x in context.tblEmployees where x.IsMenager==false select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }

        }

        public tblEmployee GetEmployeeByUsername(string username)
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    tblEmployee currentUser = (from e in context.tblEmployees where e.Username == username select e).First();


                    return currentUser;

                    //FileLoging fileLog = FileLoging.Instance();
                    //fileLog.LogDeleteUserToFile(userToDelete);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
