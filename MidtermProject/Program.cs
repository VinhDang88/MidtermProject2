using MidtermProject;

int quantityOfItem = 0;
int userChoice = 0;  // menu item they want 
bool keepShopping = true;           // loop to use while user shops 
double total = 0;

List<Product> shoppingCart = new List<Product>();    // user's "cart" 
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
Console.WriteLine("- - - - - - - - - - - - - ");

//DISPLAY LIST 
ShowShoppingList(shoppingList);

while (keepShopping)
{
    // get what item they want 
    userChoice = ChooseItem(shoppingList);

    // decide how many to add 
    quantityOfItem = ChooseQuantity();

    // add item and quantity to shoppingCart list we made 

    for (int i = 0; i < quantityOfItem; i++) // make sure correct # is added.... 
    {
        shoppingCart.Add(shoppingList[userChoice - 1]);
    }

    // Ask if they want to keep shopping.... 
    keepShopping = Transaction.ContinueShopping();

}


// user will be out of keepShopping loop when they get to this point 

Console.WriteLine();  // adding space 

// calculate the total of all items in shopping cart, accounting for all duplicates 
foreach (Product product in shoppingCart)
{
    total += (product.Price);

}

//display total 
Console.WriteLine($" Your total is ${Math.Round(total, 2)}\n");

//testingggg testing, write out full list to make sure everything is there 
// don't want to use this in the final code, need to display unique items better 
foreach (Product product in shoppingCart)
{
    Console.WriteLine(product);
}



Console.WriteLine("How would you like to pay?\n1.CC \n2. Check\n3. Cash ");
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

// ^ that needs to be looped 


//methods 
static void ShowShoppingList(List<Product> myList)
{
    int i = 0;
    for (i = 0; i < myList.Count(); i++)
    {
        Console.WriteLine($"{i + 1}: {myList[i]}");
    }

}

static int ChooseItem(List<Product> list)
{
    int choice = 0;
    while (true)
    {

        Console.WriteLine("Please make a selection from the menu list.");
        while (!int.TryParse(Console.ReadLine(), out choice))
        {
            Console.WriteLine("Not a valid input. Try again");
        }
        if (choice < 1 || choice > list.Count)
        {
            Console.WriteLine("Not valid choices");
        }
        else
        {
            //valid input
            break;
        }
    }
    return choice;
    // returns the list item # that user wants 
    // will need to return choice - 1 to get list index :] 
}

static int ChooseQuantity()  // int x is userFoodInput/userChoice for now
{
    int quantity = 0;
    while (true)
    {

        Console.WriteLine("How many do you want?");
        while (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.WriteLine("Not a valid input. Try again");
        }
        if (quantity < 1)
        {
            Console.WriteLine("Not valid choices");
        }
        else
        {
            //valid input
            break;
        }
    }
    return quantity;
}
