using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Linq;

namespace Finals
{
    class Cart
    {
        public string Unit { get; set; }
        public double Price { get; set; }
        public Cart(string product, double price)
        {
            Unit = product;
            Price = price;
        }
    }
    internal class Program
    {
        static List<string> itemsProduct = new List<string>() {"A1 Classic", "A2 Okinawa", "A3 Hokkaido",
                                                               "B1 Lychee", "B2 Blueberry", "B3 Strawberry",
                                                               "C1 Lemon", "C2 Kiwi", "C3 Mango", 
                                                               "D1 Spaghetti", "D2 Lasagna", "D3 Carbonara",
                                                               "E1 Mac & Cheese", "E2 Shawarma Rice", "E3 Bangus Java"};
        static List<string> itemsPrice = new List<string>() {"A1 70", "A2 70", "A3 70",
                                                             "B1 70", "B2 70", "B3 70",
                                                             "C1 70", "C2 70", "C3 70",
                                                             "D1 80", "D2 90", "D3 90",
                                                             "E1 75", "E2 89", "E3 89"};
        static List<Cart> cart = new List<Cart>();
        static void Main(string[] args)
        {
            Console.WriteLine("        SHOPPING CART        ");
            Console.WriteLine("***************************");

            ShowMainMenu();

            string userInput = GetUserInput();

            while (userInput != "x")
            {
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("\n_________ADD ITEM__________");
                        AddToCart();
                        ShowMainMenu();
                        userInput = GetUserInput();
                        break;
                    case "2":
                        Console.WriteLine("\n_________REMOVE ITEM__________");
                        RemovetoCart();
                        ShowMainMenu();
                        userInput = GetUserInput();
                        break;
                    case "3":
                        Console.WriteLine("\n_________VIEW CART__________");
                        ViewCart();
                        ShowMainMenu();
                        userInput = GetUserInput();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again");
                        ShowMainMenu();
                        userInput = GetUserInput();
                        break;
                }
            }
        }
        static void ShowMainMenu()
        {

            Console.WriteLine("\nSelect Your Choice: ");
            Console.WriteLine("1. Add Item To Cart");
            Console.WriteLine("2. Remove Item From Cart");
            Console.WriteLine("3. View Cart And Total Prices");
            Console.WriteLine("Enter x to Exit");
        }
        static string GetUserInput()
        {
            Console.Write("\nEnter your choice here: ");
            string input = Console.ReadLine();

            return input;
        }
        static void AddToCart()
        {
            Dictionary<string, double> productPrices = new Dictionary<string, double>();
            for (int i = 0; i < itemsProduct.Count; i++)
            {
                string[] parts = itemsPrice[i].Split(' ');
                string productName = parts[0];
                productPrices.Add(productName, (double)double.Parse(parts[1]));
            }
                Console.WriteLine("Available Foods and Drinks:");
            foreach (string choice in itemsProduct)
            {
                Console.WriteLine("- " + choice + " - " + productPrices[choice.Split(' ')[0]]);
            }
            Console.WriteLine();

            Console.WriteLine("Enter the product code to add: ");
            string product = Console.ReadLine();
                if (!itemsProduct.Contains(product))
                {
                    Console.WriteLine("Invalid product code. Please enter a valid product code from the list.");
                    AddToCart();
                    return;
                }
            Console.WriteLine("Enter the quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            double price = productPrices[product.Split(' ')[0]] * quantity;

            Cart item = new Cart(product, price);
            cart.Add(item);

            Console.WriteLine(quantity + " " + product + " has been added to your cart. It costs " + price + " pesos.\n");
        }
        static void RemovetoCart()
        {
            Console.WriteLine("Please enter the name of the product you want to remove:");
            string product = Console.ReadLine();

            Cart productToRemove = cart.Find(item => item.Unit == product);

            if (productToRemove != null)
            {
                cart.Remove(productToRemove);
                Console.WriteLine(product + " has been removed from your cart.");
            }
            else
            {
                Console.WriteLine(product + " is not in your cart.");
            }
        }
        static void ViewCart()
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Your cart is empty. Please add some product/s.");
            }
            else
            {
                double totalAmount = 0;

                Console.WriteLine("Here is/are your selected product and its cost: ");
                foreach (Cart item in cart)
                {
                    Console.WriteLine($"{item.Unit} - {item.Price}");
                    totalAmount += item.Price;
                }
                Console.WriteLine("Amount to be paid: " + totalAmount);
            }
        }
    }
}
