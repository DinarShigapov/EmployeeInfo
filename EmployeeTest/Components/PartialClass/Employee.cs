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
                if (FirstName == null || LastName == null)
                    return "Не указано";
                else
                    return $"{LastName} {FirstName}";

            }
        }

        public string StrFullAddress
        {
            get
            {
                if (Address == null)
                    return "Не указано";
                else
                    return $"{Address}, {City}, {State} {Zipcode}";
            }
        }

        public string StrEmail
        {
            get
            {
                if (Email == null)
                    return "Не указано";
                else
                    return $"{Email}";
            }
        }

        public string StrPhone
        {
            get
            {
                if (MobilePhone == null)
                    return "Не указано";
                else
                    return $"{MobilePhone}";
            }
        }

    }
}
