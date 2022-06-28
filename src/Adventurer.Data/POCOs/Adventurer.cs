using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ANCHOR: TOP
public class Adventurer
{
    public Adventurer(){}
    public Adventurer(string name, string race, string job)
    {
        Name = name;
        Race = race;
        Profession = job;
    }

    public Adventurer(string name, string race, string job, List<Item> item)
    {
        Name = name;
        Race = race;
        Profession = job;
        Pack = item;
    }

    public int ID { get; set; }
    public string Name { get; set; }
    public string Race { get; set; }
    public string Profession { get; set; }  
    public List<Item> Pack { get; set; } = new List<Item>();

    /*
        LINK: NEXT
            -
    */

}