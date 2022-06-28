using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//ANCHOR: TOP
// namespace Adventurer.UI.UI
// {
    public class Program_UI
    {
        //? We're first going to initialize our connections to all of our repositories, or DB.

        // Repository (DB) connections
        private readonly Adventurer_Repo _aRepo = new Adventurer_Repo();
        private readonly Item_Repo _iRepo = new Item_Repo();

        //ANCHOR: Test Connection
        //! ********************* TESTING CONNECTION ***************** //
        //? We're going to create a method for us to start up our console Application.

        // public void Run()
        // {
        //     System.Console.WriteLine("Running!");
        // }

        //? Our console application will run through the Program.cs within our Console App. Think of this like a bridge for us. We could technically write all of our code in that file; however, we are separating it simply for the sake of isolating this part of of our project. Maybe later we can build additional aspects of our project.

        //? Let's hope into that file now.

        //! ***************** END OF TESTING CONNECTION ************** //

        //ANCHOR: Run Application
        public void Run()
        {
            //? We're going to first start with the ability to turn on or off our application. This means that we are going to create a variable that starts with a position. When we start up our console app, we are firing off this Run() method. Because we want it to run, let's have a boolean variable staged at an "on" position.

            bool isRunning = true;

            //? We're going to create a loop to manage our inputs. As long as "isRunning" is true, our user will have access to all of our options.

            while(isRunning)
            {
                Console.Clear(); // Clears console for user.
                System.Console.WriteLine(" \t==== Create Your Adventurer ====");

                //? We're going to create a menu that provides option for our user to select. We will need to consider the following:
                /*
                Menu Options to think about

                    Adventurer:
                        - Add, View, Update, Delete
                    Item:
                        - Add, Delete
                    
                    A way to stop or exit
                */

                System.Console.WriteLine(
                    " \tPlease make an selection\n"
                    //? We're going to make 10 Different Points (Ctrl+Alt+DownArrow)
                    + " \t=== Adventurer Options === \n"
                    + " \t 1. Create Character\n"
                    + " \t 2. View Characters\n"
                    + " \t 3. Update Character\n"
                    + " \t 4. Delete Character\n"
                    + " \t=== Item Options === \n"
                    + " \t 5. Create Item\n"
                    + " \t 6. Delete Item\n"
                    + " \t=== Settings === \n"
                    + " \t x. Close Application \n"
                );

                //? We've created a menu option. Now we have to capture the response.

                // Capture and store user reponse in variable.
                var userInput = Console.ReadLine(); // Set as "var" because the value can result as a null value.

                //NOTE: May want to comment out Nullable within the csproj file.

                //? We'll then need to evaluate what that input was and respond to it depending on that.
                //* What kind of "tool" might we use to accomplish checking and responding to the users input?
                //? Let's use a Switch Statement.

                //ANCHOR: Menu Switch
                switch(userInput.ToLower())
                {
                    //? Let's frame it out and then plug in each one.
                    //* Create Default first - generating the PRESSANYKEY()
                    //* Create the CloseApplication() prior to case 1
                    case "1":
                        //? Let's create all our methods and utilize a VSCode shortcut to help us out.

                        /* 
                            CTRL + .
                                - "Generate Method"
                                - Automatically frames a default method for us.
                                - Created outside of our current method.
                        
                        *   Start from option 6 and go to 1 so that the methods are in the same order as the options.
                        * After shelling out all the methods, start with Option 1
                        
                        */

                        // Add Adventurer
                        AddAdventurerToDatabase();
                        break;
                    case "2":
                        // View Adventurer
                        ViewAllAdventurers();
                        break;
                    case "3":
                        // Update Adventurer
                        UpdateAdventurer();
                        break;
                    case "4":
                        // Delete Adventurer
                        DeleteAdventurer();
                        break;
                    case "5":
                        // Add Item
                        AddItemToDatabase();
                        break;
                    case "6":
                        // Delete Item
                        DeleteItem();
                        break;
                    case "x":
                        isRunning = CloseApplication(); // Changes isRunning to false due to the return.
                        //? Remember, as long as "isRunning" is true, this loop will run. The method we are calling is returning a false value, thus closing our application.

                        //? Let's test it out.
                        //* dotnet run --project \src\Adventurer.UI\

                        //? Now that we see that works, let's start building out our main methods.
                        break;
                    default:
                        System.Console.WriteLine("Invalid Selection");
                        PressAnyKey();
                        break;
                }
            }
        }

//NOTE: Adventurer
    //ANCHOR: Create Adventurer
    private void AddAdventurerToDatabase()
    {
        //? We're going to have some base concepts of our UI. We'll want to clear our console at the start, and then use our PressAnyKey() method for the interfacing.
        //* First Create Console.Clear() & PressAnyKey() methods. [Suggestion to CTRL+D all default boilerplate and replace]. All other code will be between these methods.

        Console.Clear();

        Adventurer newAdventurer = new Adventurer(); // Creating a new object.

        //? For the our items, we're going to provide temporary containers to allot space in our Adventurer object.
        // Temporary containers that hold our lists of items
        var currentItems = _iRepo.GetAllItemsFromDatabase();

        //? Because we're adding a character, the user should be including a name, race, and profession.
        System.Console.Write("\tPlease enter a name for your Adventurer: "); // Using Write to keep all on the same line.
        newAdventurer.Name = Console.ReadLine(); // The Name Property is expecting a string, which is being returned by our ReadLine().

        //? Let's make this easy and provide 3 races to choose from:
        System.Console.Write(
            "\tPlease select your race: \n"
            +"\t 1. Human\n"
            +"\t 2. Dwarf\n"
            +"\t 3. Elf\n"
        );

        string raceSelect = Console.ReadLine();

        //? Based on that selection, let's respond to it.
        newAdventurer.Race = raceSelect switch
        {
            "1" => "human",
            "2" => "dwarf",
            "3" => "elf",
            _ => "Please select from one of the available races."
        };

        System.Console.Write("\t Please choose your profession: ");
        newAdventurer.Profession = Console.ReadLine();

        //! ----------------------------------------------------------------------//
        //NOTE: Add Items here after Item method is created
        
            //?We're going to ask if the user would even like to do this. Let's allow the user to add multiple items if they want.
        
        bool addingItems = true;
        List<Item> itemsToAdd = new List<Item>();

        while(addingItems)
        {
            System.Console.WriteLine("\nWould you like to add items? (y/n)  \n");
            string addItemsResponse = Console.ReadLine().ToLower();

            if(addItemsResponse == "y")        
            {
                AddItemToDatabase();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                System.Console.WriteLine("Select item by ID: ");
                Console.ResetColor();
                DisplayItems(_iRepo.GetAllItemsFromDatabase());
                int itemSelected = int.Parse(Console.ReadLine());

                if(itemSelected != null)
                {
                    Item chosenItem = _iRepo.GetItemByID(itemSelected);
                    itemsToAdd.Add(chosenItem);
                    _iRepo.RemoveItemFromDatabase(itemSelected);
                }
            }
            else
            {
                addingItems = false;
            }

        }

        newAdventurer.Pack = itemsToAdd;

        //? Because we've updated this, perhaps we update what we view of our character in the Display.
        //LINK: Go to DisplayCharacter()
        //! ----------------------------------------------------------------------//

        if(!_aRepo.AddAdventurerToDatabase(newAdventurer))
        {
            //? We're asking if our method of adding the adventurer, per the repo, is true. The ! represents "NOT" true in this case
            System.Console.WriteLine("Unable to create adventurer");
        }

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        System.Console.WriteLine(
            $"\n\n\t{newAdventurer.Name}, the {newAdventurer.Race} {newAdventurer.Profession} has stepped forth!\n\n"
        );
        Console.ResetColor();

        PressAnyKey();
    }

    //ANCHOR: View Adventurer
    private void ViewAllAdventurers()
    {
        Console.Clear();

        System.Console.WriteLine("\t=== Adventurers === \n");

        List<Adventurer> adventurersInDB = _aRepo.GetAllAdventurers(); // Accessing the repo method ot obtain the complete list.

        //? We are going to cycle through them, or iterate, using a foreach and displaying them until the end of that list.

        foreach(Adventurer a in adventurersInDB)
        {
            //? We'll simply do a WriteLine() to display each character
            //* Write this out first - will make Helper Method after.
            // System.Console.WriteLine(
            //     $"\tName: {a.Name}\n" +
            //     $"\tRace: {a.Race}\n" +
            //     $"\tClass: {a.Profession}\n"+
            //     "\t---------------------------\n"
            // );

            //? This works great for what we are using it for; however, what if we wanted to use this sort of display elsewhere, like when we are wanting to view a single character?

            //? Let's create a helper method to do just that for us.
            
            displayCharacter(a); // passing "a", which represents a singular adventurer in our list, as an argument.
        }

        PressAnyKey();
    }

    //ANCHOR: Update Adventurer
    private void UpdateAdventurer()
    {
        Console.Clear();

        //? There's a bit to consider with our update. First, we need to locate a current character, ask what information they would like to change, store and pass those updates to that specific adventurer. Lastly, we'll need to then display the update for our user as feedback that it has changed.

        List<Adventurer> adventurers = _aRepo.GetAllAdventurers(); // Variable storing our complete list of current adventurers.

        foreach (var a in adventurers)
        {
            //Cycling through our options
            displayCharacter(a); // Using a Helper Method to handle our display. *reduces our code to write.
        }

        System.Console.Write("\tPlease select a character by ID: ");
        int idSelected = int.Parse(Console.ReadLine()); // Taking the input and parsing the value into an integer.
        var selectedAdventurer = _aRepo.GetAdventurerByID(idSelected); // This method requires an integer as an argument (see repo). Making our datatype a "var" because we can have a "null" value returned.

        if(selectedAdventurer is null)
        {
            System.Console.WriteLine($"Sorry, the adventurer with the ID {selectedAdventurer.ID} doesn't exist");
        } // Handling a response if selectedAdventurer is null

        Console.Clear();
        Adventurer updatedAdventurer = new Adventurer(); // Creating a new adventurer object.

        //NOTE: Will update with Items HERE
        //* UPDATE WITH ITEMS HERE [PLACEHOLDER VARIABLES]

        System.Console.WriteLine("Would you like to change the adventurers name? y/n \n");
        string nameChange = Console.ReadLine().ToLower(); // Making the response all lowercase for conditional handling.

        if(nameChange == "y")
        {
            System.Console.WriteLine("What is your adventurers new name?");
            string newName = Console.ReadLine();
            updatedAdventurer.Name = newName;
        }
        else
        {
            updatedAdventurer.Name = selectedAdventurer.Name;
            //If the user selects "n", we'll need to make sure the name for our "updated" matches the selected.
        }

        System.Console.WriteLine("Would you like to change the adventurers profession? y/n \n");
        string profChange = Console.ReadLine().ToLower();

        if(profChange == "y")
        {
            System.Console.WriteLine("What is your adventurers new profession?");
            string newProf = Console.ReadLine();
            updatedAdventurer.Profession = newProf;
        }
        else
        {
            updatedAdventurer.Profession = selectedAdventurer.Profession;
        }

        //? We're not going to offer the user to change the race; however, feel free to build that out if you would like to offer that. Because we have created a new object, it's properties doesn't automatically get assigned. We still have to detail what that looks like.

        updatedAdventurer.Race = selectedAdventurer.Race;

        //NOTE: Will update with Items HERE
        //* UPDATE WITH ITEMS HERE [Conditions to update Items]

        //? We'll then need to use our update method that we created within our Repo and pass the needed info. Following that, we'll respond to the user that their character was updated.

        //User Response
        bool isSuccessful = _aRepo.UpdateAdventurerData(idSelected, updatedAdventurer);

        string response = isSuccessful ? "Adventurer has been updated" : "Unable to update this adventurer...";

        System.Console.WriteLine(response);        

        PressAnyKey();
    }

    //ANCHOR: Delete Adventurer
    private void DeleteAdventurer()
    {
        Console.Clear();

        //? We'll first need to be able to see all of our adventurers. Select one and then remove it.

        var adventurers = _aRepo.GetAllAdventurers();

        System.Console.WriteLine("\t=== Remove Adventurer ===\n");
        foreach (Adventurer a in adventurers)
        {
            displayCharacter(a);
        }

        //? Once we have them displayed, we're going to need to ask them to select one and respond as necessary. We're going to use a Try/Catch to handle this.

        try
        {
            //? Essentially, we are going to attempt the process. If there are any issues, our catch will provide our error handling for us.

            System.Console.Write("\tPlease select an adventurer by ID: ");
            int idSelected = int.Parse(Console.ReadLine());

            //? Let's double-check if the user wants to delete this adventurer.
            Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine("\tAre you sure? (y/n) ");
            Console.ResetColor();
            string doubleCheck = Console.ReadLine().ToLower();

            if(doubleCheck == "y" || doubleCheck == "yes")
            {
                bool isSuccessful = _aRepo.RemoveAdventurerFromDatabase(idSelected); // Our Delete method in our Adventurer Repo requires an integer (ID) to be considered and returns a true/false response.

                if(isSuccessful)
                {
                    System.Console.WriteLine("Adventurer was removed from the roster.");
                }
                else
                {
                    System.Console.WriteLine("Failed to remove the adventurer from the roster.");
                }
            }
            /*
            !   CHALLENGE
                    See about writing this considitional as a ternary.
            */
        }
        catch
        {
            System.Console.WriteLine("Sorry, invalid selection.");
        }

        PressAnyKey();
    }

//NOTE: Items
    //ANCHOR: Create Item
    private void AddItemToDatabase()
    {
        Console.Clear();

        System.Console.WriteLine("\t=== Item Creation ===\n\n");
        System.Console.Write("\tWhat is your item called? ");
        string itemName = Console.ReadLine();

        Console.WriteLine("\tGot it.");
        System.Console.Write("\tWould you like to add a description? (y/n)  ");
        string descResponse = Console.ReadLine().ToLower();
        Item newItem;

        if(descResponse == "y")
        {
            System.Console.WriteLine("\tSure thing. Add a description: \n");
            string description = Console.ReadLine();
            newItem = new Item(itemName, description);
        }
        else
        {
            newItem = new Item(itemName);
        }

        //? We've established our item, now all we have to do is add it to our repo.
        bool isSuccessful = _iRepo.AddItemToDatabase(newItem);

        //? Of course, we need to verify that it's been added to our DB.

        string response = isSuccessful ? $"\t{newItem.Title} added to list\n" : $"\t{newItem.Title} was not added to list.\n";
        System.Console.WriteLine(response);

        //? Let's update our Create Adventurer method to allow for us to add items to its "Pack"
        //LINK: Back to Create Adventurer.

        PressAnyKey();
    }
    //ANCHOR: Delete Item
    private void DeleteItem()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.DarkRed;
        System.Console.WriteLine("\t---- REMOVE ITEM ----\n");
        Console.ResetColor();

        List<Item> items = _iRepo.GetAllItemsFromDatabase();
        
        DisplayItems(items);
        
        System.Console.Write("\tPlease select item by ID: ");
        int itemID = int.Parse(Console.ReadLine());

        bool isSuccessful = _iRepo.RemoveItemFromDatabase(itemID);
        if(!isSuccessful)
        {
            System.Console.WriteLine("Items successfully removed.");
        }
        else
        {
            System.Console.WriteLine("Items was removed.");
        }

        PressAnyKey();
    }


    //ANCHOR: Helper Methods 
    private void displayCharacter(Adventurer a)
    {
        //? The parameter should expect our Adventurer class and a single adventurer. We may want to also include the ID of our character in case we need to target a specific character.

        System.Console.WriteLine(
                $"\tID: {a.ID}\n" +
                $"\tName: {a.Name}\n" +
                $"\tRace: {a.Race}\n" +
                $"\tClass: {a.Profession}\n"
            );
        // The "a" is a parameter in this instance, NOT a part of the foreach in the "View ALL"
        
        //!--------- ADD THIS AFTER UPDATING Create Character -----------
        if(a.Pack.Count() > 0) // Checking to see if there is anything in the Pack.
        {
            DisplayItems(a.Pack);
        }
        //!-------------------------- END -------------------------------
    }

    private void DisplayItems(List<Item> pack)
    {
        System.Console.WriteLine("\t----------ITEMS-------------\n");
        foreach(Item p in pack)
        {
            System.Console.WriteLine(
                $"\tID: {p.ID}\n"+
                $"\tTitle: {p.Title}\n"+
                $"\tDescription: {p.Description}\n"
            );
        }
        Console.ForegroundColor = ConsoleColor.DarkMagenta; // UI to help separate each item 
        System.Console.WriteLine("\t---------------------------\n");
        Console.ResetColor();

        //? Let's finish this up with the delete item method.
        //LINK: Go to Delete Item
    }

    private void PressAnyKey()
    {
        //? We're going to create our first Helper Method. These are methods that can be utilized by other methods to help simplify our code or to just help our user in this case.
        //? We've responded and so that the user can move forward, we're going to ask them to just hit any key.
        /*
            Helper Methods:
                - Helps simplify code within one class.
                - reuseability for other methods.
        */

        //? Let's add a little "flavor" to this.
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        System.Console.WriteLine("Press ANY KEY to continue...");
        Console.ResetColor();
        Console.ReadKey();

        //? While We're here, let's create a method to allow us to Close it. This will help simply while we're testing our application out.
    }

    private bool CloseApplication()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        System.Console.WriteLine("Until next time...");
        Console.ResetColor();
        PressAnyKey();
        return false; // Returning false to use within our menu option.

        //? Let's go back to our Switch Statement and incorporate this option into it.
    }


    //ANCHOR: Challenges
    /*
        - Create an option to view a single adventurer.
        - Consider selecting an existing item in character creation instead of starting at creating an item.
        - Include a View all Items option.
        - Include a View Item by ID option.
        - Update the Adventurer Pack to add items from an the item list instead of currently the whole list.
            - Consider if there are more than one adventurer and they pull from the same item list.
            - What about removing items from the adventurers pack?

        - Don't limit to what these suggest. If you have something that you'd like to try out, go for it!
    */

    //* Add IN CLASS Readme w/ dotnet commands
}
// }