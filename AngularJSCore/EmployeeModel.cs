using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AngularJSCore
{
    public class EmployeeModel
    {
        [Key] public int EmployeeNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }
        public int Performance { get; set; }
        public string Group { get; set; }
    }
}
