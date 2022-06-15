using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreryManagment.Presenter;


namespace LibreryManagment.Models
{
    internal class Loan : ILoan
    {
        IBook example;
        IPartner partner;
        DateTime date;
        string accion;

        public Loan(IBook  book ,IPartner partner, string accion)
        {
            this.partner = partner;
            example = book;
            date = DateTime.Now;
            this.accion = accion;
        }

        public string GetAccion()
        {
            return accion;
        }

        public string GetDate()
        {
            return date.ToString();
        }

        public string GetNameOfCopy()
        {
            return example.GetName();
        }

        public string GetNameOfPartner()
        {
           return partner.GetName();
        }
    }
}
