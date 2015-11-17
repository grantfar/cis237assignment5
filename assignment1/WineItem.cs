using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    /// <summary>
    /// A class to hold a single wine
    /// </summary>
    class wineItem
    {
        //class variables
        protected String wineId;
        private String wineDescriptionString;
        private String winePackString;

        public wineItem(String id, String description, String pack)
        {
            wineId = id;
            wineDescriptionString = description;
            winePackString = pack;
        }
        //for finding a wine item
        public wineItem(String id)
        {
            wineId = id;
        }
        //non editable variables
        public String WineId
        {
            get
            {
                return wineId;
            }
        }

        public String WineDescription
        {
            get
            {
                return wineDescriptionString;
            }
        }

        public String WinePack
        {
            get
            {
                return winePackString;
            }
        }
        //overridden ToString
        public override string ToString()
        {
            return "ID: " + wineId + "    Description: " + wineDescriptionString + "    Pack: " + winePackString;
        }
        //equal if both are same class and share the same ID
        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(this.GetType()))
            {
                wineItem comp = (wineItem)obj;
                return comp.wineId.Equals(wineId);
            }
            return false;
        }
    }
}
