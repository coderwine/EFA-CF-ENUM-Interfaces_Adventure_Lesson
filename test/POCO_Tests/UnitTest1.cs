using System;
using System.Collections.Generic;
using Xunit;

namespace POCO_Tests;

public class UnitTest1
{
    [Fact]
    public void CreateAdventurer_CheckProperties()
    {
        Adventurer character = new Adventurer("Gimli", "Dwarf", "Warrior");
        
        string exp = "dwarf";
        string act = character.Race.ToLower();

        Assert.Equal(exp, act);
    }

    [Fact]
    public void CreateItem_ExpectTrue()
    {
        Item item = new Item("sword");
        
        string exp = "sword";
        string act = item.Title;

        Assert.Equal(exp, act);
    }

    [Fact]
    public void PackCheck_ListCount()
    {
        Item sword = new Item("sting");
        Item pipe = new Item("pipe");

        Adventurer character = new Adventurer(
            "Bilbo",
            "Hobbit",
            "Burglar",
            new List<Item>{sword, pipe}
        );

        int exp = 2;
        int act = character.Pack.Count;

        Assert.Equal(exp, act);

    }
}