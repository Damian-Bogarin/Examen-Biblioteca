using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreryManagment.Presenter
{
    internal interface ILoan
    {
        string GetNameOfPartner();
        string GetDate();

        string GetNameOfCopy();

        string GetAccion();
    }
}
