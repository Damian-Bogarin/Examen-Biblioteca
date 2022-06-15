using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreryManagment.Models;

namespace LibreryManagment.Presenter
{
    internal interface IlibraryView
    {
        // Metodos Book
        string GetInputName();
        string GetInputAutor();
        string GetInputISBN();

        string GetBookSelected();

        string GetInputDate();

        string GetInputLocation();


        void ShowResult(string result);

        void ShowBook(string autor, bool count);

        void ShowCopyError(bool result);
        void ShowBooks(string result);


        // Metodos para Partner
        string GetName();

        string GetLastName();

        string GetDNI();

        bool GetVip();


        void ShowAddResult(string result);

        void ShowPartners(string result);


        //Metodos Prestamo

        string GetPartnerSelected();
        string GetBookToGive();

        void ShowPartnerAtribute(string nameComplete, string vip, string dni, string available);

        void ShowBookAtribute(string available);

        void LoanError(string result);

        void LoanCharge(string result);
    }
}
