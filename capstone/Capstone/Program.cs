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

            //Instantiate the vending machine
            VendingMachine vendingMachine = new VendingMachine();
            Dictionary<string, int> changeDictionary = new Dictionary<string, int>();

            //populate the inventory list and/or restock
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-3\capstone\vendingmachine.csv"))
                {

                    while (!sr.EndOfStream)
                    {
                        string slotLocation = "";// the following code takes information from document and adds to dictionary
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

            //DISPLAY MENU 1 FIRST TIME
            vendingMachine.DisplayMenu1();

            //CAPTURE MENU 1 SELECTION
            int menu1ActionSelect = int.Parse(Console.ReadLine());

            //LOOP THROUGH MENU 1
            while (menu1ActionSelect != 3)
            {
                if (menu1ActionSelect == 1) //IF USER SELECTED DISPLAY ITEM LIST
                {
                    foreach (KeyValuePair<string, VendingInventory> name in vendingMachine.inventoryDictionary)
                    {
                        Console.WriteLine($"{name.Key}, {name.Value.ItemName}, ${name.Value.ItemPrice} ({name.Value.ItemQuantity} REMAINING)");
                        //make sure there is a method that reduces itemQuantity
                        //if item quantity == 0, SOLD OUT
                    }
                }
                else if (menu1ActionSelect == 4)  //IF USER SELECTS HIDDEN OPTION
                {

                }
                else if (menu1ActionSelect == 3) //IF USER SELECTS EXIT
                {
                    Console.WriteLine("Thank you for shopping!");
                }
                else if (menu1ActionSelect == 2) //IF USER SELECTS PURCHASE ITEMS
                {
                    decimal totalMoneyProvided = 0.00M;

                    Console.WriteLine();
                    Console.WriteLine($"Current money provided: ${totalMoneyProvided}");
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
                            Console.WriteLine($"You have put a total of ${totalMoneyProvided} in the machine.");
                            Console.WriteLine();
                        }
                        else if (actionSelect == 2)
                        {
                            foreach (KeyValuePair<string, VendingInventory> name in vendingMachine.inventoryDictionary)
                            {
                                Console.WriteLine($"{name.Key}, {name.Value.ItemName}, ${name.Value.ItemPrice} ({name.Value.ItemQuantity} REMAINING)");
           
                                //make sure there is a method that reduces itemQuantity
                                //if item quantity == 0, SOLD OUT
                            }
                            Console.WriteLine("Enter code of product to purchase:");
                            string itemSelection = Console.ReadLine();
                            if(!vendingMachine.inventoryDictionary.ContainsKey(itemSelection.ToUpper()))
                            {
                                Console.WriteLine("Does Not Exist!");
                            }
                            else if(vendingMachine.inventoryDictionary[itemSelection.ToUpper()].ItemQuantity<=0)
                            {
                                Console.WriteLine("Sold Out");
                            }
                            else
                            {
                                vendingMachine.SoundEffect(vendingMachine.inventoryDictionary[itemSelection.ToUpper()].ItemType);
                                totalMoneyProvided -= vendingMachine.inventoryDictionary[itemSelection.ToUpper()].ItemPrice;
                                vendingMachine.inventoryDictionary[itemSelection.ToUpper()].ItemQuantity -= 1;
                            }
                        }

                        Console.WriteLine($"Current money provided: ${totalMoneyProvided}");
                        Console.WriteLine();
                        Console.WriteLine("Please select an option:");
                        Console.WriteLine("(1) Feed Money");
                        Console.WriteLine("(2) Select Product");
                        Console.WriteLine("(3) Finish Transaction");

                        actionSelect = int.Parse(Console.ReadLine());

                    }

                    if (actionSelect == 3)
                    {
                        changeDictionary = vendingMachine.ReturnChange(totalMoneyProvided);
                        Console.WriteLine("Your change:");
                        Console.WriteLine($"Quarters : {changeDictionary["Quarters"]}");
                        Console.WriteLine($"Dimes : {changeDictionary["Dimes"]}");
                        Console.WriteLine($"Nickels : {changeDictionary["Nickels"]}");
                    }

                };

                //DISPLAY MENU 1 SECOND TIME BEFORE LOOPING BACK
                vendingMachine.DisplayMenu1();
                menu1ActionSelect = int.Parse(Console.ReadLine());
            }
        }
    }
}
