using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJSCore;

namespace AngularJSData
{
    public class EmployeeContext:DbContext
    {
        public DbSet<EmployeeModel> EmployeeDataSet { get; set; }

        public EmployeeContext() : base("EmployeeDatabase")
        {

        }
    }
}
