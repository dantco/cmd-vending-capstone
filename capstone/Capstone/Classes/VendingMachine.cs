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
        
        

    }
}

