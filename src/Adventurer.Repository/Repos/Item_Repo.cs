using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ANCHOR: TOP

//* Remove namespace
// namespace Adventurer.Repository.Repos
// {
public class Item_Repo
{
    //? We're going to create the same CRUD functionality for our Items that can did for our adventurer. 
    //! Have Students build out with you.
    //* We can split screen what we did in the previous build

    private readonly List<Item> _itemDB = new List<Item>();
    private int _count; 

    //CREATE
    public bool AddItemToDatabase(Item item)
    {
        if(item is null)
        {
            return false;
        }

        _count++;
        item.ID = _count;
        _itemDB.Add(item);
        return true;
    }

    //READ
    public List<Item> GetAllItemsFromDatabase()
    {
        return _itemDB;
    }

    public Item GetItemByID(int id)
    {
        foreach(Item i in _itemDB)
        {
            if(i.ID == id)
            {
                return i;
            }
        }

        return null;
    }

    //UPDATE
    public bool UpdateItem(int id, Item newItem)
    {
        var oldItem = GetItemByID(id);

        if(oldItem is null)
        {
            return false;
        }

        oldItem.Title = newItem.Title;
        oldItem.Description = newItem.Description;

        return true;
    }

    //DELETE
    public bool RemoveItemFromDatabase(int id)
    {
        var item = GetItemByID(id);

        if(item != null)
        {
            _itemDB.Remove(item);
            return true;
        }

        return false;
    }


    /*
    LINK: Next
    ?   We're going now going to go to our Adventurer.UI folder and create a folder within that, naming it "UI".

    ?   Inside that folder, let's create a class file and name it, "Program_UI"

        - Program_UI.cs
        - src\Adventurer.UI\UI\Program_UI.cs
    */
}

// }