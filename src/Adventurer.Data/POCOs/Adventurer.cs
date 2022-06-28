using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ANCHOR: TOP

// namespace Adventurer.Data.POCOs
// {

/*
?   The namespace within VSCode is something that is auto generated with the dotnet SDK. With .Net6, we actually don't need this any longer, so we'll just remove it. 

?   The purpose of this project is to create two simple classes, add them to a mock database, and allow our user to create an adventurer that can store items within their pack.

?   Because we've create some base classes already, we're going to make these real simple.

*/

public class Adventurer
{
    /*
    ANCHOR: Constructors
    ?   We're going to build our a couple different constructors. When we have multiple constructors, this is considered having "overloads".

        NOTE: Constructor
            - Constructors help us define an object upon creation (new-up or new-upping)
            - Overloads provide us options as to how we generate that object.
    */
    public Adventurer(){}

    //REVIEW: Create Properties
    public Adventurer(string name, string race, string job)
    {
        Name = name;
        Race = race;
        Profession = job;
        //? In this example, we are able to create a character with the Name, Race, and Profession property established right away.
    }

    public Adventurer(string name, string race, string job, List<Item> item)
    {
        Name = name;
        Race = race;
        Profession = job;
        Pack = item;
        //? Here we are able to create our character already with a pack.
    }

    /*
    ANCHOR: Properties
    ?   Properties allow us to establish what exactly make up our objects traits. In our case, we're creating a fantasy character so it makes sense to include a Name, Race, Profession. 

    ?   When working with DBs, we should also note that each object should have their own respective unique identifier. This will help us isolate individual objects if we ever need to call upon them in anyway. Typically, these IDs are structured in many ways, such as UUIDs or other forms of hashed characters. In our very simple application, we're just going to use simple numbers. 

    ?   Lastly, our character will have the capability to carry a pack that can store a number of various items. This will target our Item class, which we'll build out after this one.

        NOTE: Properties
            ID: Unique Identifier. Set upon creation. Will be an integer datatype.
            Name: string datatype
            Race: string datatype
            Profession: string datatype
            Pack: List<Item> datatype
    */

    public int ID { get; set; }
    public string Name { get; set; }
    public string Race { get; set; }
    public string Profession { get; set; }  
    public List<Item> Pack { get; set; } = new List<Item>(); // We are creating space in memory for our list of items. 

    //? Let's make our last overload.

    //REVIEW: Create 3rd Overload constructor

    /*
        LINK: NEXT
            - Items.cs
            - src\Adventurer.Data\POCOs\Item.cs
    */

}

// }