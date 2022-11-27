using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

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
                    return $"{FirstName} {LastName}";

            }
        }

        public string StrFullAddress
        {
            get
            {
                if (Address == null)
                    return "Не указано";
                else
                    return $"{Address}, " +
                        $"{City}," +
                        $" {DBConnect.db.State.ToList().Find(x => x.Id == State.Id).FIPSCode} " +
                        $"{Zipcode}";
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

        public Visibility VisibilityBtn
        {
            get
            {

                if (MainPhoto.Length != 0)
                    return Visibility.Hidden;
                else
                    return Visibility.Visible;
            }
        }

        public Visibility MainPhotoVis
        {
            get
            {
                if (MainPhoto.Length != 0)
                    return Visibility.Hidden;
                else
                    return Visibility.Visible;
            }
        }

    }
}
