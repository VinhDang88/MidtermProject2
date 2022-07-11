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
        // this will be for all things billing, checking out, etc 
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
                else
                {
                    Console.WriteLine("Invalid input");

                }
            }
            return true;
        }
    }
}





//NOT USING, old method for quantity 

//static int ChooseQuantity(List<Product> list, int x)  // int x is userFoodInput/userChoice for now
//{
//    int quantity = 0;
//    while (true)
//    {

//        Console.WriteLine("How many do you want?");
//        while (!int.TryParse(Console.ReadLine(), out quantity))
//        {
//            Console.WriteLine("Not a valid input. Try again");
//        }
//        if (quantity < 1)
//        {
//            Console.WriteLine("Not valid choices");
//        }
//        else
//        {
//            //valid input
//            break;
//        }
//    }
//    return quantity;
//}

