using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTest.Components
{
    public partial class Task
    {
        public string StrFullNameA
        {
            get
            {
                var fullName = DBConnect.db.Employee.ToList().Find(x => x.Id == AssignedId);
                return $"{fullName.FirstName} {fullName.LastName}";
            }
        }
        public string StrFullNameO
        {
            get
            {
                var fullName = DBConnect.db.Employee.ToList().Find(x => x.Id == OwnedId);
                return $"{fullName.FirstName} {fullName.LastName}";
            }
        }
    }
}
