using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTest.Components
{
    public partial class Employee
    {
        public string StrFullName
        {
            get 
            {
                return $"{LastName} {FirstName}";
            }
        }

        public string StrFullAddress
        {
            get
            {
                return $"{Address}, {City}, {State} {Zipcode}";
            }
        }
    }
}
