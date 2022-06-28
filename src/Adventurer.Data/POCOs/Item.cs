using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ANCHOR: TOP

// namespace Adventurer.Data.POCOs
// {
public class Item
{
    /*
    ?   We're only going to create three properties and two constructors. Our items will have an ID, to isolate them when needed, a Title, and a Description property.
    */

    //ANCHOR: Constructor
    public Item(string title)
    {
        Title = title;
    }

    //REVIEW: Challenge
    //! Have students build out a constructor that populates the Title and Description.
    public Item(string title, string desc)  
    {
        Title = title;
        Description = desc;
    }

    //ANCHOR: Properties
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    /*
    LINK: Next
    ?   We're now ready to build within our repositories since our POCOs are established.

    *   Open Adventurer.Repository
    *       - Delete Class1.cs
    *       - Create a folder called: Repos
    *           - Create a Class File: Adventurer_Repo
    *           - Create a Class File: Item_Repo

        - Adventurer_Repo.cs
        - src\Adventurer.Repository\Repos\Adventurer_Repo.cs
    */

}

// }