using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreryManagment.Models;

namespace LibreryManagment.Presenter
{
    internal interface IBook
    {
        string GetName();
        string GetAutor();

        string GetListCount();
        void AddCopy(Copy copy);
        bool StockCopy();
        Copy GetCopy();

    }
}
