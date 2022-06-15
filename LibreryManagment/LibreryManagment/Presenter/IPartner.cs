using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreryManagment.Models;

namespace LibreryManagment.Presenter
{
    internal interface IPartner
    {
        bool Available();
        void GiveCopy(Copy copy);
        Copy ReturnCopy();

        string GetName();

        string GetLastName();

        int GetDNI();

        bool GetVip();
    }
}
