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
        private Beverage[] beverageArray;
        private BeverageGFarnsworthEntities dataBase;
        public EntityProcessor()
        {
            dataBase = new BeverageGFarnsworthEntities();
            wineArrayCreator();

        }
        
        private void wineArrayCreator()
        {
            beverageArray = dataBase.Beverages.ToArray();
        }
        

        //adds a wine to the csv list
        public void AddBeverage(Beverage addedBeverage)
        {
            dataBase.Beverages.Add(addedBeverage);
        }
        //removes the wine from the csv file
        public void RemoveBeverage(Beverage removedBeverage)
        {
            dataBase.Beverages.Remove(removedBeverage);
        }
        
        public Beverage[] BeverageArray
        {
            get { return beverageArray; }
        }
    }
}
