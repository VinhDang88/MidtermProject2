using MidtermProject;

int quantityOfItem = 0;
int userChoice = 0;  // menu item they want 
bool keepShopping = true;           // loop to use while user shops 
double total = 0;

List<Product> shoppingCart = new List<Product>();    // user's "cart" 
//Product List 
List<Product> shoppingList = new List<Product>()
{
    //updated descriptions - KP
    new Product ("Mandarin Orange Chicken", "Frozen", "Quick and easy meal that serves 4-5", 4.99),
    new Product ("Butter Waffle Cookies", "Snacks", "Great sweet treat for any time of the day", 2.99),
    new Product ("Candied Mango", "Snacks", "The great taste of mango without all the work", 2.99),
    new Product ("Jasmine Rice", "Frozen", "Microwave perfect in 3 minutes", 3.99),
    new Product ("Green Goddess Salad Dressing", "Produce", "Packed with Hass avocados, fresh herbs, and seasonings", 2.49),
    new Product ("Organic Baby Lettuce Mix", "Produce", "It's better than iceberg lettuce", 2.49),
    new Product ("Organic Chicken Nuggets", "Frozen", "Organic, fully-cooked, fresh-food", 4.99),
    new Product ("BBQ Teriyaki Chicken", "Frozen", "BBQ dark meat chicken in teriyaki sauce", 5.49),
    new Product ("Cashew Butter Cashews", "Snacks", "Cashew butter on cashews, enough said", 4.99),
    new Product ("Seasoned Waffle Fries", "Frozen", "The best type of fry", 3.49),
    new Product ("Hash Browns", "Frozen", "All the flavor, none of the work", 2.99),
    new Product ("Mochi", "Frozen", "Sweet rice dough", 3.89),
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
        shoppingCart.Add(shoppingList[userChoice]);
    }

    //line total 
    Console.WriteLine($"Added {quantityOfItem} {shoppingList[userChoice].Name} for ${Math.Round(shoppingList[userChoice].Price * quantityOfItem, 2)} ");


    // Ask if they want to keep shopping.... 
    keepShopping = Transaction.ContinueShopping();
}

// calculate the total of all items in shopping cart, accounting for all duplicates 
foreach (Product product in shoppingCart)
{
    total += (product.Price);

}

//unique items 
List<Product> uniqueItems = shoppingCart.DistinctBy(item => item.Name).ToList();

//time to COUNT the unique items 
foreach (Product uniqueItem in uniqueItems)
{
    int quantity = shoppingCart.Where(item => (item.Name).Equals(uniqueItem.Name)).Count();
    Console.WriteLine($"{quantity} x {uniqueItem.Name} - ${uniqueItem.Price} each");
}

//display total 
Console.WriteLine($" Your total is ${Math.Round(total, 2)}\n");



Console.WriteLine("How would you like to pay?\n1. CC \n2. Check\n3. Cash ");
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
        //updated string format - KP
        Console.WriteLine(string.Format("{0,3}: {1}", i + 1, myList[i]));
    }

}

static int ChooseItem(List<Product> list)
{
    int choice = -1;
    while (true)
    {
        //added a space before this line
        Console.WriteLine($"\nPlease make a selection from the menu list.");
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
            choice--;
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
