using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//ANCHOR: TOP

public class Adventurer_Repo
{
    private readonly List<Adventurer> _adventurerDB = new List<Adventurer>();
    private int _count = 0;
    public bool AddAdventurerToDatabase(Adventurer adventurer)
    {
        if(adventurer is null)
        {
            return false;
        }
 
        _count++;
        adventurer.ID = _count;

        _adventurerDB.Add(adventurer);
        return true;

    }

    public List<Adventurer> GetAllAdventurers()
    {
        return _adventurerDB;
    }
    
    public Adventurer GetAdventurerByID(int id)
    {
        foreach(Adventurer a in _adventurerDB)
        {
            if (a.ID == id)
            {
                return a;
            }
        }

        return null;
    }

    public bool UpdateAdventurerData(int id, Adventurer newAdventurerData)
    {
        var oldAdventurer = GetAdventurerByID(id);

        if(oldAdventurer != null)
        {
            oldAdventurer.Name = newAdventurerData.Name;
            oldAdventurer.Race = newAdventurerData.Race;
            oldAdventurer.Profession = newAdventurerData.Profession;
            oldAdventurer.Pack = newAdventurerData.Pack;

            return true;

        }

        return false;

    }

    public bool RemoveAdventurerFromDatabase(int id)
    {
        var adventurer = GetAdventurerByID(id);

        if(adventurer is null)
        {
            return false;
        }

        _adventurerDB.Remove(adventurer);
        return true;
    }
    
    /*LINK: Next
    */
}
