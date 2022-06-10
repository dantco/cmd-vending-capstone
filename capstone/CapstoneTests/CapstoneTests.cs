using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class CapstoneTests
    {
        [TestMethod]
        public void TestLogItemSale()
        {
            //ARRANGE
            VendingInventory vendingInventory = new VendingInventory();

            DateTime dateTime = DateTime.Now;
            string itemType = "Chips";
            string slotLocation = "A1";
            decimal itemPrice = 3.00M; 
            decimal totalMoneyRemaining = 25.00M;

            //ACT
            string actual = vendingInventory.LogItemSale(itemType, slotLocation, itemPrice, totalMoneyRemaining);


            //ASSERT
            string expected = $"{dateTime}  Chips A1 $3.00 $25.00";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLogFeedMoney()
        {
            //ARRANGE
            VendingInventory vendingInventory = new VendingInventory();

            DateTime dateTime = DateTime.Now;
            decimal moneyInput = 3M;
            decimal totalMoneyRemaining = 25.00M;

            //ACT
            string actual = vendingInventory.LogFeedMoney(moneyInput, totalMoneyRemaining);


            //ASSERT
            string expected = $"{dateTime}  FEED MONEY: $3.00 $25.00";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLogGiveChange()
        {
            //ARRANGE
            VendingInventory vendingInventory = new VendingInventory();

            DateTime dateTime = DateTime.Now;
            decimal totalMoneyRemaining = 25.00M;

            //ACT
            string actual = vendingInventory.LogGiveChange(totalMoneyRemaining);


            //ASSERT
            string expected = $"{dateTime}  GIVE CHANGE: $25.00 $0.00";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSoundEffect()
        {
            VendingMachine vendingMachine = new VendingMachine();

            string itemType = "Chip";
            string actual = vendingMachine.SoundEffect(itemType);
            string expected = "Crunch Crunch, Yum!";
            Assert.AreEqual(expected, actual);

            itemType = "Candy";
            actual = vendingMachine.SoundEffect(itemType);
            expected = "Munch Munch, Yum!";
            Assert.AreEqual(expected, actual);

            itemType = "Drink";
            actual = vendingMachine.SoundEffect(itemType);
            expected = "Slurp Slurp, Yum!";
            Assert.AreEqual(expected, actual);

            itemType = "Gum";
            actual = vendingMachine.SoundEffect(itemType);
            expected = "Chewy Chewy, Yum!";
            Assert.AreEqual(expected, actual);

            itemType = "techelevator";
            actual = vendingMachine.SoundEffect(itemType);
            expected = "Not a valid item type";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReturnChange()
        {
            VendingMachine vendingMachine = new VendingMachine();

            decimal totalMoneyRemaining = 25.00M;
            Dictionary<string, int> actual = vendingMachine.ReturnChange(totalMoneyRemaining);
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("Quarters", 100);
            expected.Add("Dimes", 0);
            expected.Add("Nickels", 0);
            CollectionAssert.AreEqual(expected, actual);

            totalMoneyRemaining = 14.90M;
            actual = vendingMachine.ReturnChange(totalMoneyRemaining);
            expected["Quarters"] = 59;
            expected["Dimes"] = 1;
            expected["Nickels"] = 1;

            CollectionAssert.AreEqual(expected, actual);


        }
    }
}
