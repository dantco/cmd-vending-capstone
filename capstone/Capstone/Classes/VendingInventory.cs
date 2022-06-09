using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
        
        

    }
}
