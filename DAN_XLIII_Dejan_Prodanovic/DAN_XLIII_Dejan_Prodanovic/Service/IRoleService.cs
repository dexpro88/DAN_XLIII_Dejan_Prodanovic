﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIII_Dejan_Prodanovic.Service
{
    interface IRoleService
    {
        List<tblRole> GetAllRoles();
        tblRole GetRoleByID(int roleId);
    }
}
