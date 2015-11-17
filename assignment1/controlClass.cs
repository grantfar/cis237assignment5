using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    //A class for controlling the ui. There shoud only be one instance in a program
    class controlClass
    {
        EntityProcessor processCSV;
        BeverageCollection collectedWineItems;
        public controlClass(BeverageCollection collection, EntityProcessor processor)
        {
            processCSV = processor;
            collectedWineItems = collection;
        }
        //only public methiod starts the ui run through
        public void PrintPrompt()
        {
            Console.WriteLine("\nEnter command or type \"help\" to see a list of commands");
            processAnswer(Console.ReadLine());
        }
        //decifers the user input and calls the corresponding methiods
        private void processAnswer(String promptAnswer)
        {
            String promptSwitch = seperateSwitchString(promptAnswer);
            String promptParameters = seperateParameterString(promptAnswer);

            switch(promptSwitch)
            {
                    // Shows the help menu
                case "help":
                    Console.WriteLine("display (id/all)".PadRight(43) + "|Displays the wine with the id/displays all wines" + Environment.NewLine +
                        "display-multi (ids)".PadRight(43) + "|displays multible wines (inter ids seperated by commas" + Environment.NewLine +
                        "add (wine ID, wine description, wine pack)".PadRight(43) + "|adds a wine to the wine list" + Environment.NewLine +
                        "Remove (wine ID)".PadRight(43) + "|Removes the wine with that ID from the wine list" + Environment.NewLine);
                    break;
                    //Displays A wine
                case "display":
                    displayWine(promptParameters);
                    break;
                    //displays a list of wines
                case "display-multi":
                    displayMultiWines(promptParameters.Split(','));
                    break;
                    //adds a wine to the wine list
                case "add":
                    addWineItem(promptParameters.Split(','));
                    break;
                    //removes a wine from the list
                case "remove":
                    removeWineItems(promptParameters);
                    break;
                default:
                    Console.WriteLine("invalid Command: \"" + promptAnswer + "\"" + Environment.NewLine);
                    break;
            }
        }
        /// <summary>
        /// displays wine with the id 
        /// </summary>
        /// <param name="wineID"></param>
        private void displayWine(String wineID)
        {
            if (wineID == "all")
                Console.WriteLine(collectedWineItems.ToString());
            else
            {
                wineItem wineMatchingID = collectedWineItems.findBeverage(wineID);
                if (wineMatchingID != null)
                    Console.WriteLine(wineMatchingID.ToString());
                else
                    Console.WriteLine("No wine with id: " + wineID + " is found");
            }
        }
        /// <summary>
        /// displays a wine for each wine id in the input array
        /// </summary>
        /// <param name="wineIDs"></param>
        private void displayMultiWines(String[] wineIDs)
        {
            foreach(String s in wineIDs)
                displayWine(s);
        }
        /// <summary>
        /// checks to see if the peramiters are valid then adds the wine to the wine list
        /// </summary>
        /// <param name="peramitersStrings"></param>
        private void addWineItem(String[] peramitersStrings)
        {
            //if peramiters are vallid
            if (peramitersStrings.Length == 3)
            {
                if (collectedWineItems.findBeverage(peramitersStrings[0]) == null)
                {
                    // add wine item
                    wineItem addWine = new wineItem(peramitersStrings[0], peramitersStrings[1], peramitersStrings[2]);
                    collectedWineItems.AddWine(addWine);
                    processCSV.AddWine(addWine);
                }
                else
                {
                    Console.WriteLine("Error: " + peramitersStrings[0] + " matches a wine ID already in the database");
                }
            }
            else if (peramitersStrings.Length > 3)
                Console.WriteLine("Error: to many parameters");
            else
                Console.WriteLine("Error: to few parameters");
        }
        //seperates the switch from the command
        private string seperateSwitchString(String promptAnswer)
        {
            if (promptAnswer.Contains(' '))
                return promptAnswer.Substring(0, promptAnswer.IndexOf(' ')).Trim().ToLower();
            return promptAnswer.Trim().ToLower();
        }
        //Seperates the command parameters from the command
        private string seperateParameterString(String promptAnswer)
        {
            if (promptAnswer.Contains(" "))
                return promptAnswer.Substring(promptAnswer.IndexOf(' ') + 1);
            return "";
        }
        /// <summary>
        /// removes the a wine from the winelist
        /// </summary>
        /// <param name="removeWineId"></param>
        private void removeWineItems(String removeWineId)
        {
            //checks to see if wine exists
            wineItem removeItem = collectedWineItems.findBeverage(removeWineId);
            if (removeItem == null)
                Console.WriteLine("A wine with the id " + removeWineId + " doesn't exist in the list");
            else
            {
                //asks if you are sure
                Console.WriteLine("Are you sure you want to delete:" + Environment.NewLine + "\t" + removeItem.ToString() + "? (y/n)");
                String answer = Console.ReadLine();
                if (answer.ToLower().Trim().Equals("y"))
                {
                    //removes wine from list
                    processCSV.RemoveWine(removeItem);
                    collectedWineItems.removeWine(removeItem);
                }
                else if (!answer.ToLower().Trim().Equals("n"))
                    Console.WriteLine("Invalid Input: " + answer + ", assuming no");

            }
        }

    }
}
