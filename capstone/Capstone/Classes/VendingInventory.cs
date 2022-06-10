using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace Capstone.Classes
{
    public class VendingInventory
    {
        //PROPERTIES
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemType { get; set; }
        public int ItemQuantity { get; set; } = 5;


        //CONSTRUCTORS
        public VendingInventory() { }
        public VendingInventory(string itemName, decimal itemPrice, string itemType, int itemQuantity)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemType = itemType;
            ItemQuantity = itemQuantity;
        }

        //METHODS

        public virtual void LogItemSale(string itemType, string slotLocation, decimal itemPrice, decimal totalMoneyRemaining)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-3\capstone\SalesLog.txt", true))
            {
                DateTime dateTime = DateTime.Now;
                string output = ($"{dateTime}  {itemType} {slotLocation} ${itemPrice} ${totalMoneyRemaining}");
                sw.WriteLine(output);
            }
        }

        public void LogFeedMoney(decimal moneyInput, decimal totalMoneyRemaining)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-3\capstone\SalesLog.txt", true))
            {
                DateTime dateTime = DateTime.Now;
                string output = ($"{dateTime}  FEED MONEY: ${moneyInput}.00 ${totalMoneyRemaining}");
                sw.WriteLine(output);
            }
        }
        public void LogGiveChange(decimal totalMoneyRemaining)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Student\git\c-sharp-mini-capstone-module-1-team-3\capstone\SalesLog.txt", true))
            {
                DateTime dateTime = DateTime.Now;
                string output = ($"{dateTime}  GIVE CHANGE: ${totalMoneyRemaining} $0.00");
                sw.WriteLine(output);
            }
        }
    }
}