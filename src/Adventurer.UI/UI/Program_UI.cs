using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//ANCHOR: TOP
    public class Program_UI
    {
        private readonly Adventurer_Repo _aRepo = new Adventurer_Repo();
        private readonly Item_Repo _iRepo = new Item_Repo();
        public void Run()
        {

            bool isRunning = true;

            while(isRunning)
            {
                Console.Clear();
                System.Console.WriteLine(" \t==== Create Your Adventurer ====");

                System.Console.WriteLine(
                    " \tPlease make an selection\n"
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

                var userInput = Console.ReadLine();

                switch(userInput.ToLower())
                {
                    case "1":
                        AddAdventurerToDatabase();
                        break;
                    case "2":
                        ViewAllAdventurers();
                        break;
                    case "3":
                        UpdateAdventurer();
                        break;
                    case "4":
                        DeleteAdventurer();
                        break;
                    case "5":
                        AddItemToDatabase();
                        break;
                    case "6":
                        DeleteItem();
                        break;
                    case "x":
                        isRunning = CloseApplication();
                        break;
                    default:
                        System.Console.WriteLine("Invalid Selection");
                        PressAnyKey();
                        break;
                }
            }
        }

    private void AddAdventurerToDatabase()
    {
        Console.Clear();

        Adventurer newAdventurer = new Adventurer();
        var currentItems = _iRepo.GetAllItemsFromDatabase();

        System.Console.Write("\tPlease enter a name for your Adventurer: ");
        newAdventurer.Name = Console.ReadLine();

        System.Console.Write(
            "\tPlease select your race: \n"
            +"\t 1. Human\n"
            +"\t 2. Dwarf\n"
            +"\t 3. Elf\n"
        );

        string raceSelect = Console.ReadLine();

        newAdventurer.Race = raceSelect switch
        {
            "1" => "human",
            "2" => "dwarf",
            "3" => "elf",
            _ => "Please select from one of the available races."
        };

        System.Console.Write("\t Please choose your profession: ");
        newAdventurer.Profession = Console.ReadLine();

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

        if(!_aRepo.AddAdventurerToDatabase(newAdventurer))
        {
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

    private void ViewAllAdventurers()
    {
        Console.Clear();

        System.Console.WriteLine("\t=== Adventurers === \n");

        List<Adventurer> adventurersInDB = _aRepo.GetAllAdventurers();

        foreach(Adventurer a in adventurersInDB)
        {
            displayCharacter(a);
        }

        PressAnyKey();
    }

    private void UpdateAdventurer()
    {
        Console.Clear();

        List<Adventurer> adventurers = _aRepo.GetAllAdventurers(); 

        foreach (var a in adventurers)
        {
            displayCharacter(a);
        }

        System.Console.Write("\tPlease select a character by ID: ");
        int idSelected = int.Parse(Console.ReadLine());
        var selectedAdventurer = _aRepo.GetAdventurerByID(idSelected);
        if(selectedAdventurer is null)
        {
            System.Console.WriteLine($"Sorry, the adventurer with the ID {selectedAdventurer.ID} doesn't exist");
        }

        Console.Clear();
        Adventurer updatedAdventurer = new Adventurer();

        System.Console.WriteLine("Would you like to change the adventurers name? y/n \n");
        string nameChange = Console.ReadLine().ToLower();

        if(nameChange == "y")
        {
            System.Console.WriteLine("What is your adventurers new name?");
            string newName = Console.ReadLine();
            updatedAdventurer.Name = newName;
        }
        else
        {
            updatedAdventurer.Name = selectedAdventurer.Name;
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

        updatedAdventurer.Race = selectedAdventurer.Race;

        bool isSuccessful = _aRepo.UpdateAdventurerData(idSelected, updatedAdventurer);

        string response = isSuccessful ? "Adventurer has been updated" : "Unable to update this adventurer...";

        System.Console.WriteLine(response);        

        PressAnyKey();
    }

    private void DeleteAdventurer()
    {
        Console.Clear();

        var adventurers = _aRepo.GetAllAdventurers();

        System.Console.WriteLine("\t=== Remove Adventurer ===\n");
        foreach (Adventurer a in adventurers)
        {
            displayCharacter(a);
        }

        try
        {
            System.Console.Write("\tPlease select an adventurer by ID: ");
            int idSelected = int.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine("\tAre you sure? (y/n) ");
            Console.ResetColor();
            string doubleCheck = Console.ReadLine().ToLower();

            if(doubleCheck == "y" || doubleCheck == "yes")
            {
                bool isSuccessful = _aRepo.RemoveAdventurerFromDatabase(idSelected);

                if(isSuccessful)
                {
                    System.Console.WriteLine("Adventurer was removed from the roster.");
                }
                else
                {
                    System.Console.WriteLine("Failed to remove the adventurer from the roster.");
                }
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, invalid selection.");
        }

        PressAnyKey();
    }

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

        bool isSuccessful = _iRepo.AddItemToDatabase(newItem);

        string response = isSuccessful ? $"\t{newItem.Title} added to list\n" : $"\t{newItem.Title} was not added to list.\n";
        System.Console.WriteLine(response);

        PressAnyKey();
    }

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

    private void displayCharacter(Adventurer a)
    {
        System.Console.WriteLine(
                $"\tID: {a.ID}\n" +
                $"\tName: {a.Name}\n" +
                $"\tRace: {a.Race}\n" +
                $"\tClass: {a.Profession}\n"
            );
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
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        System.Console.WriteLine("\t---------------------------\n");
        Console.ResetColor();
    }

    private void PressAnyKey()
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        System.Console.WriteLine("Press ANY KEY to continue...");
        Console.ResetColor();
        Console.ReadKey();
    }

    private bool CloseApplication()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        System.Console.WriteLine("Until next time...");
        Console.ResetColor();
        PressAnyKey();
        return false;
    }
}