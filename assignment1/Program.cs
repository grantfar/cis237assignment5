using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initializes Each of the other classes
            EntityProcessor onlyRunOneCSVProcessor = new EntityProcessor(upPath(3,Environment.CurrentDirectory) + "\\datafiles\\WineList.csv");
            BeverageCollection theWineCollection = new BeverageCollection(onlyRunOneCSVProcessor);
            controlClass controlTheProgram = new controlClass(theWineCollection, onlyRunOneCSVProcessor);
            //repeats the ui
            while(true)
            {
                controlTheProgram.PrintPrompt();
            }
        }
        //moves file path up directories
        private static String upPath(int numUp, string path)
        {
            if(numUp <= 0)
                return path;
            return upPath(numUp - 1, Directory.GetParent(path).ToString());
        }

    }
}
