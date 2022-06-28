using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Repo_Tests;

public class UnitTest1
{
    private Adventurer_Repo _aRepo = new Adventurer_Repo();
    private Item_Repo _iRepo = new Item_Repo();
    private Adventurer _adventurer;
    private Item _item;

    [Fact]
    public void AddAdventurerToDatabase_ReturnCount_Two()
    {
        Adventurer bilbo = new Adventurer("Bilbo", "Hobbit", "Burglar");

        _aRepo.AddAdventurerToDatabase(bilbo);

        int exp = 1;
        int act = _aRepo.GetAllAdventurers().Count();

        Assert.Equal(exp, act);
    }

    [Fact]
    public void GetAdventurerByID_ReturnTrue()
    {
        Adventurer hobbit1 = new Adventurer("Bilbo", "Hobbit", "Burglar");
        Adventurer hobbit2 = new Adventurer("Frodo", "Hobbit", "Ring-Bearer");

        _aRepo.AddAdventurerToDatabase(hobbit1);
        _aRepo.AddAdventurerToDatabase(hobbit2);

        string exp = "Ring-Bearer";
        string act = _aRepo.GetAdventurerByID(2).Profession;

        Assert.Equal(exp, act);
    }

    [Fact]
    public void UpdateAdventurerData_ReturnTrue()
    {
        Adventurer oldCharacter = new Adventurer();
        oldCharacter.Name = "Smeagol";
        Adventurer newCharacter = new Adventurer("Gollum", "Hobbit","Cursed");

        _aRepo.AddAdventurerToDatabase(oldCharacter);

        bool result = _aRepo.UpdateAdventurerData(1,newCharacter);

        Assert.True(result);

    }

    [Fact]
    public void RemoveAdventurerFromDatabase_ReturnTrue()
    {
        Adventurer hobbit = new Adventurer();
        hobbit.Name = "Smeagol";
        

        _aRepo.AddAdventurerToDatabase(hobbit);

        bool result = _aRepo.RemoveAdventurerFromDatabase(1);

        Assert.True(result);
    }

    //TODO: Update LINK in Item_Repo.cs - start building UI
}