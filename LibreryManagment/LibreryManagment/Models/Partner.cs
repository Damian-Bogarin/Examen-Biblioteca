using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreryManagment.Presenter;

namespace LibreryManagment.Models
{
    internal class Partner : IPartner
    {

        string name;
        string lastName;
        int DNI;
        bool vip;
        int monthlyFee;
        List<Copy> retiredCopy;


        public Partner(string name, string lastName, int codeId, bool vip)
        {
            this.name = name;
            this.lastName = lastName;
            this.DNI = codeId;
            this.vip = vip;
            if (vip)
            {
                this.monthlyFee = 500;
                this.retiredCopy = new List<Copy>(3);
            }
            else
            {
                this.retiredCopy = new List<Copy>(1);
                this.monthlyFee = 0;
            }


        }

        public bool Available()
        {
            if (retiredCopy.Count == retiredCopy.Capacity)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetDNI()
        {
            return DNI;
        }

        public string GetLastName()
        {
           return lastName;
        }

        public string GetName()
        {
            return name;
        }

        public bool GetVip()
        {
            return vip;
        }

        public void GiveCopy(Copy copy)
        {
            retiredCopy.Add(copy);
        }

        public Copy ReturnCopy()
        {

            Copy copyToReturn = retiredCopy[0];
            retiredCopy.RemoveAt(0);
            return copyToReturn;
        }
    }
}
