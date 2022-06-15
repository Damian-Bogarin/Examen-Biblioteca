using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreryManagment.Presenter;
namespace LibreryManagment.Models
{
    internal class Copy
    {
        //atributos
        string edition;
        string location;

        public Copy(string edition, string location)
        {
            this.edition = edition;
            this.location = location;
        }

        public string Edition { get => edition; set => edition = value; }
        public string Location { get => location; set => location = value; }
    }
}
