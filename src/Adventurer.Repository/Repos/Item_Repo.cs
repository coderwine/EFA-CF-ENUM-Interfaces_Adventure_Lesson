using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ANCHOR: TOP
public class Item_Repo
{
    
    private readonly List<Item> _itemDB = new List<Item>();
    private int _count; 

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
        - 
    */
}
