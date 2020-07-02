using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIII_Dejan_Prodanovic.Service
{
    class RoleService : IRoleService
    {
        public List<tblRole> GetAllRoles()
        {
            try
            {
                using (WorkingHoursDBEntities context = new WorkingHoursDBEntities())
                {
                    List<tblRole> list = new List<tblRole>();
                    list = (from x in context.tblRoles select x).ToList();
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
