using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ANCHOR: TOP

public class Item
{
    public Item(string title)
    {
        Title = title;
    }
    public Item(string title, string desc)  
    {
        Title = title;
        Description = desc;
    }

    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    /*
    LINK: Next
        -
    */

}