using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Dictionary<string, VendingInventory> inventoryDictionary = new Dictionary<string, VendingInventory>();

            VendingMachine vendingMachine = new VendingMachine();

            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-3\capstone\vendingmachine.csv"))
                {

                    while (!sr.EndOfStream)
                    {
                        string slotLocation = "";               // the following code takes information from document and adds to dictionary
                        VendingInventory itemGroup = new VendingInventory();

                        string line = sr.ReadLine();
                        string[] splitLine = line.Split(",");
                        slotLocation = splitLine[0];
                        itemGroup.ItemName = splitLine[1];
                        itemGroup.ItemPrice = decimal.Parse(splitLine[2]);
                        itemGroup.ItemType = splitLine[3];

                        vendingMachine.inventoryDictionary.Add(slotLocation, itemGroup);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("Welcome to the Umbrella Corp Vendo-Matic 800(TM)");
            Console.WriteLine("Please make a selection...");
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");

            int userInput = int.Parse(Console.ReadLine());

            if (userInput == 1)
            {
                foreach (KeyValuePair<string, VendingInventory> name in vendingMachine.inventoryDictionary)
                {
                    Console.WriteLine($"{name.Key}, {name.Value.ItemName}, ${name.Value.ItemPrice} ({name.Value.ItemQuantity} REMAINING)");
                    //make sure there is a method that reduces itemQuantity
                    //if item quantity == 0, SOLD OUT
                }
            }
            else if (userInput == 4)
            {

            }
            else if (userInput == 3)
            {
                Console.WriteLine("Thank you for shopping!");
            }
            else if (userInput == 2)
            {
                decimal totalMoneyProvided = 0.00M;
                
                Console.WriteLine($"Current money provided: {totalMoneyProvided}");
                Console.WriteLine();
                Console.WriteLine("Please select an option:");
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");

                int actionSelect = int.Parse(Console.ReadLine());
                while (actionSelect != 3)
                {
                    if (actionSelect == 1)
                    {
                        Console.WriteLine("Enter the amount to deposit in whole dollars.");
                        decimal inputMoney = decimal.Parse(Console.ReadLine());
                        totalMoneyProvided += inputMoney;
                        Console.WriteLine($"You have put a total of {totalMoneyProvided} in the machine.");
                    }
                    else if (actionSelect == 2)
                    {

                    }


                    Console.WriteLine($"Current money provided: {totalMoneyProvided}");
                    Console.WriteLine();
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("(1) Feed Money");
                    Console.WriteLine("(2) Select Product");
                    Console.WriteLine("(3) Finish Transaction");

                    actionSelect = int.Parse(Console.ReadLine()); 

                }
            };
        }
    }
}
