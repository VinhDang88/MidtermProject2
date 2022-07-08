using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{

    // this will be for all things billing, checking out, etc 

    internal class Transaction
    {
        public double PayCash(int total, int money)
        {
            double change = money - total;
            return change;
        }

        //public string PayByCheck(double checkNumber) // do we need a parameter?
        //{
        //    Console.WriteLine("Please provide the check number:");

        //    string message = "Check accepted";
        //}

        //public string PayByCC(double something)
        //{

        //    return 
        //}

       





    }
}
