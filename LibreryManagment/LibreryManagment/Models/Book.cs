using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreryManagment.Models;
using LibreryManagment.Presenter;


namespace LibreryManagment
{
    internal class Book : IBook
    {
        //Atributos
        string name;
        string autor;
        int isbn;
        List<Copy> copys;


        //Constructor
        public Book(string name, string autor, int isbn, List<Copy> copys)
        {
            this.name = name;
            this.autor = autor;
            this.isbn = isbn;
            this.copys = copys;
        }

        //Propiedades
        public string Name { get => name; set => name = value; }

        public int Isbn { get => isbn; set => isbn = value; }
        public string Autor { get => autor; set => autor = value; }

        internal List<Copy> Copys { get => copys; set => copys = value; }

        public void AddCopy(Copy copy)
        {
            
            copys.Add(copy);
        }

        public Copy GetCopy()
        {
            Copy copyToReturn = copys[0];
            copys.RemoveAt(0);
            return copyToReturn;
        }

        public bool StockCopy()
        {
            if (copys.Count == 0)
            {
                return false;
            }
            else return true;
        }

        public string GetName()
        {
            return name;
        }

        public string GetAutor()
        {
            return autor;
        }

        public string GetListCount()
        {
            return copys.Count.ToString();
        }
    }
}
