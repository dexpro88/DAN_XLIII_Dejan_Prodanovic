﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIII_Dejan_Prodanovic.Service
{
    interface IEmployeeService
    {
        List<tblEmployee> GetAllEmployees();
        List<tblEmployee> GetAllNonMenagerEmployees();
        tblEmployee AddEmployee(tblEmployee employee);
        tblEmployee GetEmployeeByUsername(string username);



    }
}
