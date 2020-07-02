using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIII_Dejan_Prodanovic.Service
{
    class EmployeeService : IEmployeeService
    {
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
    }
}
