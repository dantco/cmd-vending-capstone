using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {

        //PROPERTIES
        public decimal MoneyTotal { get; set; }
        public decimal MoneyProvided { get; set; }
        public Dictionary<string, VendingInventory> inventoryDictionary { get; set; } = new Dictionary<string, VendingInventory>();

        //CONSTRUCTOR
        public VendingMachine()
        {

        }

        //METHODS
        public void DisplayMenu1()
        {
            Console.WriteLine("Welcome to the Umbrella Corp Vendo-Matic 800(TM)");
            Console.WriteLine("Please make a selection...");
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            //make sure to account for the error if the user doesn't enter a valid entry at this point
        }

        public void SoundEffect(string itemType)
        {
            if (itemType == "Chip")
            {
                Console.WriteLine("Crunch Crunch, Yum!");
            }
            else if (itemType == "Candy")
            {
                Console.WriteLine("Munch Munch, Yum!");
            }
            else if (itemType == "Drink")
            {
                Console.WriteLine("Slurp Slurp, Yum!");
            }
            else if (itemType == "Gum")
            {
                Console.WriteLine("Chewy Chewy, Yum!");
            }
        }

        public virtual Dictionary<string, int> ReturnChange(decimal totalMoneyProvided)
        {
            Dictionary<string, int> changeDictionary = new Dictionary<string, int>();
                       
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            while (totalMoneyProvided > 0.00M)
            {

                if (totalMoneyProvided >= 0.25M)
                {
                    quarters += 1;
                    totalMoneyProvided -= 0.25M;
                }
                else if(totalMoneyProvided >= 0.10M)
                {
                    dimes += 1;
                    totalMoneyProvided -= 0.10M;
                }
                else if(totalMoneyProvided >= 0.05M)
                {
                    nickels += 1;
                    totalMoneyProvided -= 0.05M;
                }
            }
            changeDictionary.Add("Quarters", quarters);
            changeDictionary.Add("Dimes", dimes);
            changeDictionary.Add("Nickels", nickels);
            return changeDictionary;
        }
    }
}

