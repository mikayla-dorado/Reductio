// See https://aka.ms/new-console-template for more information

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Hat",
        Price = 7.99M,
        Available = true,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Wand",
        Price = 10.99M,
        Available = true,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Scarves",
        Price = 4.99M,
        Available = false,
        ProductTypeId = 3
    },
    new Product()
    {
        Name = "Gloves",
        Price = 6.99M,
        Available = true,
        ProductTypeId = 4
    },
    new Product()
    {
        Name = "Cards",
        Price = 12.99M,
        Available = true,
        ProductTypeId = 5
    },
    new Product()
    {
        Name = "Trick Fingers",
        Price = 14.99M,
        Available = false,
        ProductTypeId = 6
    }
};

string greeting = "Welcome to Reductio & Absurdum!";

Console.WriteLine(greeting);


//main menu
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an Option:
            0. Exit
            1. View All Products
            2. Add a Product to Inventory
            3. Delete a Product from Inventory
            4. Update Product Details");
    choice = Console.ReadLine();
    Console.Clear();
    //add functionality for main menu
    switch (choice)
    {
        case "0":
            Console.WriteLine("Goodbye!");
            break;
            case "1":
            ListProducts();
            break;
            case "2":
            AddProduct();
            break;
            case "3":
            DeleteProduct();
            break;
            case "4":
            UpdateProduct();
            break;
        default:
            Console.WriteLine("Invalid input. Please choose a valid option.");
            break;
    }
}

void ListProducts()
{
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}


void AddProduct ()
{
    Console.WriteLine("Please enter the details for the product you are adding:");
    Console.WriteLine("What is the product name?");
    string productAddedName = Console.ReadLine();

    Console.WriteLine("How much does this product cost?");
    decimal productAddedPrice;
    while (!decimal.TryParse(Console.ReadLine(), out productAddedPrice) || productAddedPrice < 0)
    {
        Console.WriteLine("Invalid input. Please enter a non-negative number.");
    }

    Console.WriteLine("Is this product available? Enter 'true' or 'false':");
    bool productAddedAvailable;
    while (!bool.TryParse(Console.ReadLine(), out productAddedAvailable))
    {
        Console.WriteLine("Invalid input. Please enter 'true' or 'false'");
    }


    Product productAdded = new Product();
    productAdded.Name = productAddedName;
    productAdded.Price = productAddedPrice;
    productAdded.Available = productAddedAvailable;
    //productAdded.ProductTypeId = productAddedTypeId;
    products.Add(productAdded);

    Console.WriteLine("Your product has been added to the inventory!");
}

void DeleteProduct()
{

}

void UpdateProduct()
{

}