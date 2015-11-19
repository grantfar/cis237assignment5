using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace assignment1
{
    /// <summary>
    /// A Class for handling the csv file
    /// </summary>
    class EntityProcessor
    {
        List<Beverage> addedBeverages;
        List<Beverage> removedBeverages;
        private BeverageGFarnsworthEntities dataBase;
        public EntityProcessor()
        {
            dataBase = new BeverageGFarnsworthEntities();
            addedBeverages = new List<Beverage>();
            removedBeverages = new List<Beverage>();
        }


        //adds a wine to the Database
        public void AddBeverage(Beverage addedBeverage)
        {
            dataBase.Beverages.Add(addedBeverage);
            addedBeverages.Add(addedBeverage);
        }
        //removes the wine from the Database
        public void RemoveBeverage(Beverage toRemove)
        {
            dataBase.Beverages.Remove(toRemove);
            removedBeverages.Add(toRemove);
        }
        public void commitChanges()
        {
            dataBase.SaveChanges();
            addedBeverages = new List<Beverage>();
            removedBeverages = new List<Beverage>();
        }
        public void discardChanges()
        {
            dataBase = new BeverageGFarnsworthEntities();
            addedBeverages = new List<Beverage>();
            removedBeverages = new List<Beverage>();
        }
        public Beverage findBeverage(string id)
        {
            return dataBase.Beverages.Where(b => b.id == id).First();
        }
        public string viewChanges()
        {
            string toOutPut = "Added Beverages:" + Environment.NewLine + Environment.NewLine;
            foreach(Beverage b in addedBeverages)
            {
                toOutPut += formatBeverage(b) + Environment.NewLine;
            }
            toOutPut += Environment.NewLine + "Removed Beverages:" + Environment.NewLine + Environment.NewLine;
            foreach (Beverage b in removedBeverages)
            {
                toOutPut += formatBeverage(b) + Environment.NewLine;
            }
            return toOutPut;
        }

        public string formatBeverage(Beverage toFormat)
        {
            return toFormat.id + ", " + toFormat.name + ", " + ", " + toFormat.pack + ", " + toFormat.price;
        }
        public string printAll()
        {
            string toPrint = "";
            foreach(Beverage b in dataBase.Beverages)
            {
                toPrint += formatBeverage(b) + Environment.NewLine;
            }
            return toPrint;
        }
    }
}
