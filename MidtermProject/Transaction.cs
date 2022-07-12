//written by Kris, Vinh and Mara 


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MidtermProject
{
    // this will be for all things billing, checking out, etc 
    internal class Transaction
    {
        public static List<Product>? shoppingList2; // just a copy of "shoppingLlist" for functionality. 

        // this will be for all things billing, checking out, etc 

        public static double GrandTotal(double total, double taxRate)
        {
            double grandTotal = Math.Round(total + (taxRate * total), 2);

            return grandTotal;
        }


        public static double PayCash(double grandTotal)
        {
            double money = 0;
            while (true)
            {
                Console.WriteLine("Please input cash amount: ");
                while (!double.TryParse(Console.ReadLine(), out money))
                {
                    Console.WriteLine("Not a valid input. Try again");
                }
                if (money < grandTotal)
                {
                    Console.WriteLine("Insufficient funds - please try again");
                }
                else
                {
                    break;
                }
            }
            double change = Math.Round(money - grandTotal, 2);
            Console.WriteLine($"Thank you!\nYour change is: ${change.ToString("F", CultureInfo.InvariantCulture)}."); // better $$ format? 
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

        public static string PayByCC()
        {
            string lastFour = "";
            //Regex viasRegEx = new Regex(@"^4[0-9]{12}(?:[0-9]{3})?$");
            //Regex americanExpressRegEx = new Regex(@"^3[47][0-9]{13}$");
            //Regex monthYear = new Regex(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$");
            //Regex masterCard = new Regex(@"^5[1-5][0-9]{14}$");

            Regex cvv = new Regex(@"^[0-9]{3,4}$");
            while (true)
            {
                Console.WriteLine("Please enter a credit card number.");
                string creditCard = Console.ReadLine();

                if (Regex.IsMatch(creditCard, @"^4[0-9]{12}(?:[0-9]{3})?$"))
                {
                    Console.WriteLine("VISA");
                    lastFour = $"x{creditCard.Substring(creditCard.Length - 4)} - VISA";
                    break;

                }

                else if (Regex.IsMatch(creditCard, @"^3[47][0-9]{13}$"))
                {
                    Console.WriteLine("AMEX");
                    lastFour = $"x{creditCard.Substring(creditCard.Length - 4)} - AMEX";
                    break;




                }
                else if (Regex.IsMatch(creditCard, @"^5[1-5][0-9]{14}$"))
                {
                    Console.WriteLine("MASTERCARD");
                    lastFour = $"x{creditCard.Substring(creditCard.Length - 4)} - MASTERCARD";
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
            return lastFour;
        }
        public static bool ContinueShopping() // just an option to have if we want 
        {
            while (true)
            {
                Console.WriteLine("\nWould you like to continue shopping? Press \"y\" to continue shopping, or \"n\" to go to check out." +
                    "\nYou can reply with 'menu' to see our available options again.");
                string checkOut = Console.ReadLine().ToLower().Trim();
                Console.WriteLine();

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

        public static void PrintReceipt(double total, double tax, double grandTotal,
           List<Product> uniqueList, List<Product> shoppingCart, DateTime now, string paymentMethod, double change, string lastFour)

        // this is a method because we didn't want this massive code block in main program. 
        {
            Console.WriteLine(String.Format("{0,50}", "TRADER JOSE'S"));
            Console.WriteLine(String.Format("{0,53}", "27880 Woodward Ave"));
            Console.WriteLine(String.Format("{0,53}", "Royal Oak, MI 48067"));
            Console.WriteLine(String.Format("{0,57}", "Store #690 - (248) 582-9002\n"));
            Console.WriteLine(String.Format("{0,58}", "OPEN 8:00AM TO 10:00PM DAILY\n"));
            Console.WriteLine(now);
            Console.WriteLine("Items Purchased:\n...........................");
            foreach (Product uniqueItem in uniqueList)
            {
                int quantity = shoppingCart.Where(item => (item.Name).Equals(uniqueItem.Name)).Count();
                Console.WriteLine($"{quantity} x {uniqueItem.Name} - ${uniqueItem.Price} each");
            }
            Console.WriteLine($"\nTotal: ${total.ToString("F", CultureInfo.InvariantCulture)}\nTax: ${tax.ToString("F", CultureInfo.InvariantCulture)}\nGrand Total: ${grandTotal.ToString("F", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Payment Method accepted: {paymentMethod}  {lastFour}  {now}");

            if (paymentMethod == "Cash")
            {
                Console.WriteLine($"Change: ${change.ToString("F", CultureInfo.InvariantCulture)}\n");
            }

            Console.WriteLine(String.Format("\n{0,53}", "THANK YOU FOR SHOPPING AT"));
            Console.WriteLine(String.Format("{0,46}", "TRADER JOSE'S"));
            Console.WriteLine(String.Format("{0,49}", "www.traderjoses.com\n"));
        }
    }
}



