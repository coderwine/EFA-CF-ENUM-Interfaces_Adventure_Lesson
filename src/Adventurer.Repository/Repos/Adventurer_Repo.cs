using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ANCHOR: TOP

//* Remove namespace
// namespace Adventurer.Repository.Repos
// {
public class Adventurer_Repo
{
    /* ANCHOR: CRUD Desc.
    ?   The Repository will be used to primarily hold our logic for our Data class libraries and act as a fake database for us. Our "database" will have some basic functionality, such as allowing us to "Create" a new instance of an object. We will also be able to "View" that object, "Update" objects within our database, and, finally, "Delete" said object if we need to do so. This is known as CRUD.
    NOTE: CRUD
        C: Create (Post)
        R: Read (Get)
        U: Update (Put)
        D: Delete (Delete)
    ?   These can also be noted as Post, Get, Put, Delete as well.

    ?   For us to manage this DB, we're going to use a Collection to hold all of our objects. We'll go into Collections later on. For now, we will be using a List to account for our possible adventurers.
        - List<T>
            - References a datatype of List. Within the < > is the "Type" of data it will hold.
            - List<T> == List<Adventurer>
    
    ?   We'll now need to set up a private variable to store the List of Adventurers.
    */

    //ANCHOR: Private Variables
    private readonly List<Adventurer> _adventurerDB = new List<Adventurer>();
    // Underscore for our variable denotes that it is a PRIVATE variable.

    private int _count = 0;

    //? This will govern our ID values for each adventurer. Remember, in order for us to target specific adventurers, there needs to be a very clear definition of what makes them unique. An ID helps us declare that.

    //NOTE: Create (POST)
    // 1    2              3                      4 
    public bool AddAdventurerToDatabase(Adventurer adventurer)
    {
        /*
        ?   We a creating a bool return type so that we can give a simple yes/no (true/false) reply as to whether or not the request to add our character to the List was successful. We are very purposeful with our naming of this method, as it will be called on within our UI to do exactly this when a user wants to create a character. Let's recap what parts make up this method.
            Recap!
                1. Accessor
                2. Return Type
                3. Method Name (naming should detail what it does)
                4. Parameters
                    - The argument to pass when we invoke this method should be an Adventurer type of object.
                    - Notes what datatype it is (Left - Uppercase) and placeholder variable name we'll use in the method logic.

        ?   Because we are asking for an adventurer to be added, we first need to make sure that the user is passing a character as an argument. If they don't, our response should be false.
        */

        if(adventurer is null)
        {
            return false;
        }

        //? If they do pass an adventurer, we'll need to establish that Adventurer objects ID and add it to the List.  
        _count++; // Adding one to the currently value of our private variable.
        adventurer.ID = _count; // Assigning the property ID of our Adventurer object with the current _count value.

        //? The List collection comes with its own methods for us to use. These methods are a part of the .Net SDK. We'll target our private List variable and use the add method.
        _adventurerDB.Add(adventurer); // Method Add() is part of the List collection.
        return true; // Feedback for user.

    }

    //NOTE: Read (GET)
    //? Let's make two different GET methods for our project. We'll be able to view ALL adventurers as well as individuals.
    // Get ALL Adventurers
    public List<Adventurer> GetAllAdventurers()
    {
        return _adventurerDB; // Simply returns the value of our private variable above.
        //? note our return type is expecting a List of Adventurers. Returning this will allow us to use available List Methods within our UI later.
    }
    
    // Get ONE Adventurer
    //? We're going to utilize that ID from our Adventurer object to target our response. To return one adventurer, we'll want to be sure that our return type is exactly that, an Adventurer.
    public Adventurer GetAdventurerByID(int id)
    {
        //? Notice that we requesting an integer datatype for our parameter. This means that our user will need to supply this method with a number so that it can be evaluated. This will need to equal a current ID of an adventurer. We're going to use this to ask the question, "Does this number match an ID for any of our Adventurers?" This also means that we need to cycle through the List of current Adventurers. This should be stored within our private List variable.

        foreach(Adventurer a in _adventurerDB) // using "a" to reference a singular "Adventurer" in our List<Adventurer>.
        {
            //? With each iteration of this foreach, we're going to ask that question, "Does id = a.ID?"
            if (a.ID == id)
            {
                return a; // Once (if) we do equal those values, we will return the complete object of that single Adventurer.
            }
        }

        //? It is possible that the Adventurer doesn't exist. Because our method is requiring something to be returned, we need a response if there simply isn't one that matches.
        return null; // Return null so that we can provide user feedback in the UI.
    }

    //NOTE: Update (PUT)
    //? Updating will require a couple things to be considered. First, we need to locate a current adventurer, or object, and then provide it's properties with new values. Regarding a return type, we'll return a simple "yes/no" to note that it was successfully completed.

    public bool UpdateAdventurerData(int id, Adventurer newAdventurerData)
    {
        /*
        ?   This method will need to first have the ID value to provide us an adventurer to manipulate. The second parameter will be what our user will provide to us in the UI. Consider that prior to us calling this method, we are asking questions to the user, via the UI, like "What is the new name for your adventurer?". We'll store that response in a variable and pass it through as an argument then.

        ?   We actually have a way to simply look for that singular adventurer that we want to update.
        !   Challenge students to consider how we can obtain that adventurer by ID
        */

        var oldAdventurer = GetAdventurerByID(id); // Using var as our datatype because "null" is a possibility.

        //? Because the return of oldAdventurer could be null, we'll need to evaluate if it is prior to updating the oldAdventurer with new info.

        if(oldAdventurer != null)
        {
            oldAdventurer.Name = newAdventurerData.Name;
            oldAdventurer.Race = newAdventurerData.Race;
            oldAdventurer.Profession = newAdventurerData.Profession;
            oldAdventurer.Pack = newAdventurerData.Pack;

            return true;

            //? Notice that we didn't alter the ID of the oldAdventurer. This is because we possibly want to still be able to reference it by its unique value later.
        }

        // If oldAdventurer returns "null", return false to indicate that this process couldn't be completed. 
        return false;

    }

    //NOTE: Delete
    //? Sometimes the adventurer is no longer wanted or should probably retire. Being able to delete the object from the database is complete depending on the type of project that you're building. Consider perhapes a grocery list app. That list may not be needed after you shop so you delete it completely to help you create a new one for the next trip.

    //? We're going to have the same return type to respond to users whether or not it was successfully completed.

    //! Challenge the students to consider how we can isolate a specific adventurer
    //* by ID

    public bool RemoveAdventurerFromDatabase(int id)
    {
        //? The ID will help us target that one adventurer. We can use the same logical process we did in the Update and process it through a conditional regarding its return.

        var adventurer = GetAdventurerByID(id);

        if(adventurer is null)
        {
            return false;
        }

        _adventurerDB.Remove(adventurer); // Remove() is a method provided to us within our List<T> Collection.
        return true;
    }
    
    /*LINK: Next
        - Item_Repo.cs
        - src\Adventurer.Repository\Repos\Item_Repo.cs
    */
}

// }