using MidtermProject;

bool keepShopping = true;           // loop to use while user shops 
List <Product> shoppingCart = new List <Product> ();    // user's "cart" 


//Product List 
List<Product> shoppingList = new List<Product>()
{
    new Product ("Mandarin Orange Chicken", "Frozen", "Delicious", 4.99),
    new Product ("Butter Waffle Cookies", "Snacks", "Tangy", 2.99),
    new Product ("Candied Mango", "Snacks", "", 2.99),
    new Product ("Jasmine Rice", "Frozen", "", 3.99),
    new Product ("Green Goddess Salad Dressing", "Produce", "", 2.49),
    new Product ("Organic Baby Lettuce Mix", "Produce", "", 2.49),
    new Product ("Organic Chicken Nuggets", "", "", 4.99),
    new Product ("BBQ Teriyaki Chicken", "", "", 5.49),
    new Product ("Cashew Butter Cashews", "Snacks", "", 4.99),
    new Product ("Seasoned Waffle Fries", "Frozen", "", 3.49),
    new Product ("Hash Browns", "Frozen", "", 2.99),
    new Product ("Mochi", "Frozen", "", 3.89),
};

Console.WriteLine("Welcome to Trader Jose's! \nHere is our current menu:"); 

//DISPLAY LIST 
ShowShoppingList(shoppingList);

// set up a loop to let the user "shop" 
//while (keepShopping) 
//{ 


// has to be a method to remove last item from a list; idea to for an "undo" option
// idea: "hit 0 to display the menu again" 

//}





// user will be out of keepShopping loop when they get to this point 

Console.WriteLine("How would you like to pay?\n 1.CC \n2. Check\n 3. Cash "); 
string input = Console.ReadLine().ToLower().Trim(); 
if (input.Contains("1") || input.Contains("credit")) 
{
    // PayByCC()
}
else if (input.Contains("2") || input.Contains("check"))
{
    // PayByCheck
}
else if (input.Contains("3") || input.Contains("cash"))
{
    //PayCash 
}
else
{
    Console.WriteLine("please fix your input");
}
// Loop????

//method to display the list 

static void ShowShoppingList(List<Product> myList)
{
    int i = 0;
    for (i = 0; i < myList.Count(); i++)
    {
        Console.WriteLine($"{i + 1}: {myList[i]}");
    }

}
