using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    /// <summary>
    ///  A Class used to hold and search through the wine database
    /// </summary>

    class BeverageCollection
    {
        private List<Beverage> collectionList;
        public BeverageCollection(EntityProcessor refrence)
            : this(refrence.BeverageArray)
        { }

        public BeverageCollection(Beverage[] creationArray)
        {
            collectionList = new List<Beverage>();
            for (int i = 0; i < creationArray.Length; i++)
            {
                collectionList.Add(creationArray[i]);
            }
        }
        public Beverage findBeverage(String id)
        {
            foreach(Beverage b in collectionList)
            {
                if(b.id.Equals(id))
                    return b;
            }
            return null;
        }
        /// <summary>
        /// removes the wine item matching the input wine item from the list
        /// </summary>
        /// <param name="removealItem"></param>
        public void removeBeverage(Beverage removealItem)
        {
            collectionList.Remove(removealItem);
        }
        public void AddWine(wineItem addedWine)
        {
            collectionList.Add(addedWine);
        }
        /// <summary>
        /// outputs all the wine items in the array
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            String returnString = "";
            foreach (wineItem w in collectionList)
                returnString += w.ToString() + Environment.NewLine;
            return returnString;
        }
    }
}
