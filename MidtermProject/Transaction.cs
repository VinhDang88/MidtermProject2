using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MidtermProject
{
    // this will be for all things billing, checking out, etc 
    internal class Transaction
    {
        public static List<Product> shoppingList2; // just a copy of "shoppingLlist" for functionality. 

        // this will be for all things billing, checking out, etc 
        public double PayCash(int total, int money)
        {
            double change = money - total;
            return change;
        }

        public static void PayByCheck()
        {
            double message = 0;
            Console.WriteLine("Please provide the check number:");
            //if parse fails, get input again
            while (!double.TryParse(Console.ReadLine(), out message) || message > 9999)
            {
                Console.WriteLine("Invalid input");

            }
            //Should we tell the user they enter a valid check number?
        }
        public static void PayByCC()
        {
            Regex viasRegEx = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$");
            Regex americanExpressRegEx = new Regex(@"^3[47][0-9]{13}$");
            Regex monthYear = new Regex(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$");
            Regex cvv = new Regex(@"^[0-9]{3,4}$");
            while (true)
            {
                Console.WriteLine("Please enter a credit card number.");
                string creditCard = Console.ReadLine();

                if (Regex.IsMatch(creditCard, @"^4[0-9]{12}(?:[0-9]{3})?$"))
                {
                    Console.WriteLine("VISA");
                    break;

                }

                else if (Regex.IsMatch(creditCard, @"^3[47][0-9]{13}$"))
                {
                    Console.WriteLine("AMEX");
                    break;

                }
                else
                {
                    Console.WriteLine("NOT ACCEPTED");
                }
            }

            while (true)
            {
                Console.WriteLine("Please enter the month/year.");
                string _monthYear = Console.ReadLine();
                if (Regex.IsMatch(_monthYear, @"^(0[1-9]|1[0-2])\/?([0-9]{2})$"))
                {
                    Console.WriteLine("Valid");
                    break;

                }
                else
                {
                    Console.WriteLine("Not Valid");
                }
            }
            while (true)
            {
                Console.WriteLine("Please enter a cvv.");
                string _cvv = Console.ReadLine();
                if (Regex.IsMatch(_cvv, @"^[0-9]{3,4}$"))
                {
                    Console.WriteLine("Valid");
                    break;

                }
                else
                {
                    Console.WriteLine("Not Valid");
                }
            }
        }
        public static bool ContinueShopping() // just an option to have if we want 
        {
            while (true)
            {
                Console.WriteLine("Would you like to continue shopping? Press Y to continue shopping, or N to go to check out.");
                string checkOut = Console.ReadLine().ToLower().Trim();

                if (checkOut == "y")
                {
                    break;
                    //return true; // will set keepShopping bool to "true"
                }
                else if (checkOut == "n")
                {
                    return false; // will set keepShopping bool to "false"
                }
                else if (checkOut == "menu")
                {
                    ShowShoppingList();
                }
                else
                {
                    Console.WriteLine("Invalid input");

                }
            }
            return true;
        }
        static void ShowShoppingList()
        {
            int i = 0;
            for (i = 0; i < shoppingList2.Count(); i++)
            {
                Console.WriteLine(string.Format("{0,3}: {1}", i + 1, shoppingList2[i]));
            }

        }


    }
}


