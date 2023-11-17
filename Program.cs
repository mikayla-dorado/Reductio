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
        ProductTypeId = 4
    },
    new Product()
    {
        Name = "Scarves",
        Price = 4.99M,
        Available = false,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Gloves",
        Price = 6.99M,
        Available = true,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Cards",
        Price = 12.99M,
        Available = true,
        ProductTypeId = 3
    },
    new Product()
    {
        Name = "Trick Fingers",
        Price = 14.99M,
        Available = false,
        ProductTypeId = 1
    }
};


List<ProductTypeId> productTypeIds = new List<ProductTypeId>()
{
     new ProductTypeId()
  {
    Name = "Apparel",
    Id = 1
  },
  new ProductTypeId()
  {
    Name = "Potions",
    Id = 2
  },
  new ProductTypeId()
  {
    Name = "Enchanted objects",
    Id = 3
  },
  new ProductTypeId()
  {
    Name = "Wands",
    Id = 4
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


void ListProductTypeIds()
{
    Console.WriteLine("Product types:");
    foreach (ProductTypeId productTypeId in productTypeIds)
    {
        Console.WriteLine($"{productTypeIds.IndexOf(productTypeId) + 1}. {productTypeId.Name}");
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


void AddProduct()
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
    Console.WriteLine("What product Id is this product?");
    ListProductTypeIds();
    int productAddedTypeId = int.Parse(Console.ReadLine());

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
    productAdded.ProductTypeId = productAddedTypeId;
    products.Add(productAdded);

    Console.WriteLine("Your product has been added to the inventory!");
}

void DeleteProduct()
{
    Console.WriteLine("Which product would you like to remove?");

    Product chosenProduct = null;

    ListProducts();

    while (chosenProduct == null)
    {
        try
        {
            int response = int.Parse((Console.ReadLine()));
            chosenProduct = products[response - 1];
            products.RemoveAt(response - 1);
        }
        catch (FormatException)
        {
            Console.WriteLine("Please write only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an item on the list only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Uh-oh! You made an error");
        }
    }
    Console.WriteLine($"You have removed the {chosenProduct.Name} from inventory");
}

void UpdateProduct()
{
    // Console.WriteLine("Please choose the product you wish to update:");

    ListProducts();

    try
    {
        int response = int.Parse(Console.ReadLine());
        //this checks to see if the response is within the range of products
        if (response >= 1 && response <= products.Count)
        {
            Product selectedProduct = products[response - 1];

            //displays the choices for the users
            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1. Product Name");
            Console.WriteLine("2. Product Price");
            Console.WriteLine("3. Product Availability");

            //asks the user to choose an option
            int updateChoice = int.Parse(Console.ReadLine());

            switch (updateChoice)
            {
                case 1:
                    //where user enters a new product name
                    Console.WriteLine("Enter the new product name:");
                    string newName = Console.ReadLine();
                    selectedProduct.Name = newName;
                    break;
                case 2:
                    //where user enters a new price
                    Console.WriteLine("Enter the new product price:");
                    //declares a new variable 'newPrice' set to a type of decimal
                    decimal newPrice;
                    //loop condition checks whether parsing was unsuccessful or if parsed value is < 0
                    //if the parsing is unsuccessful, or parsed value is < 0, the loop continues
                    //if parsing is sucessful, the ' out newPrice ' is where the parsed value will be stored
                    while (!decimal.TryParse(Console.ReadLine(), out newPrice) || newPrice < 0)
                    {
                        //if condition is true, it means the input was invalid and the loop
                        //continues to prompt the user until a valid input is provided
                        Console.WriteLine("Invalid input. Please enter a non-negative number.");
                    }
                    //sets the 'price' property of the 'selectedProduct' to the 'newPrice' variable declared above
                    selectedProduct.Price = newPrice;
                    break;
                case 3:
                    //where user enters if available
                    Console.WriteLine("Is the product available? Enter 'true' or 'false':");
                    bool newAvailability;
                    while (!bool.TryParse(Console.ReadLine(), out newAvailability))
                    {
                        Console.WriteLine("Invalid input. Please enter 'true' or 'false'");
                    }
                    selectedProduct.Available = newAvailability;
                    break;
                default:
                    Console.WriteLine("Invalid option. No updates were made.");
                    break;
            }

            Console.WriteLine($"Product {selectedProduct.Name} has been updated.");
        }
        else
        {
            Console.WriteLine("Invalid choice. Please choose a valid product to update.");
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Please write only integers!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Console.WriteLine("Uh-oh! Something went wrong.");
    }
}