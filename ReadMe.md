# The Adventurer - CRUD Lesson

## Lesson Setup

This needs to be spun up with the class. Creating a folder within the **Projects** folder of the Cohort. 

Project folder name: **CRUD_Adventurer**

**Instructor Notes**
- **START** in ```StartLesson.md``` - within the **src folder**.
- Test folder is simply for testing the lesson itself. Testing will be a focused, smaller lesson.

---

## Concept
The focus of this lesson is to spin up a small CRUD application using ```classlib``` and ```console``` as the core focus.

Within the ```src``` folder, it would house ```Data``` (POCO) and ```Repo``` (Main CRUD) class libraries along with the ```UI``` console application.

**POCO**
- Data
  - Character
  - Items
- Repository
  - CRUD
- UI
  - Methods to interact with CRUD
    - Create Character
    - View Character
    - Update Character
    - Delete Character
    - Create Item
    - Delete Item

## File / Folder Setup
Within Main Folder
```
- dotnet new sln
  or
  dotnet new sln -n "FileName"

- dotnet new gitignore
```
Create a src folder:
- Creating
  - Data Classlib
    - POCO *(Folder)*
      - ```Adventurer.cs``` *(C# Class)*
      - ```Items.cs``` *(C# Class)*
    - **REMOVE** ```Class1.cs```
  - Repository Classlib
    - Repos *(Folder)*
      - ```Adventurer_Repo.cs``` *(C# Class)*
  - UI Console
```
Data
- dotnet new classlib -o "FileName.Data"
- ex
  - dotnet new classlib -o "Adventurer.Data"

Repository
- dotnet new classlib -o "FileName.Repository"
- ex
  - dotnet new classlib -o "Adventurer.Repository"

UI
- dotnet new console -n "Filename.UI"
- ex
  - dotnet new classlib -n "Adventurer.UI"
```
**Adding to the Solutions File**

Within the main folder, ```Adventurer_CRUD```
- Adding Data, Repository, and UI Assemblies to the Solution file.
```
dotnet sln add [File Path]

ex:
    dotnet sln add .\src\Adventurer.Data\
    dotnet sln add .\src\Adventurer.Repository\
    dotnet sln add .\src\Adventurer.UI\
```
**Adding References**
  - References are used so that one assembly can refer to another assembly. The UI assembly will need to consider both the Repository and Data, for example, in order to accomplish its tasks.
```
- dotnet add [File Path NEEDING a reference] reference [File Path TO reference]

ex:
  - dotnet add .\src\Adventurer.UI\ reference .\src\Adventurer.Data\
  - dotnet add .\src\Adventurer.UI\ reference .\src\Adventurer.Repository\

  - dotnet add .\src\Adventurer.Repository\ reference .\src\Adventurer.Data\
```
*An Aside:*

*You can "step" into the folder that needs a reference and simply* 
 ```
dotnet add reference [File Path TO Reference]
``` 
*as an alternative way to connect the assemblies.*

**Git Ignore**

The .gitignore file defaults to ignore the **obj** and **bin** folders that are created upon the build process of the project. These come with the SDK for **dotnet**
```
dotnet new gitignore
```

**Creating a GitHub Repo**

Don't forget to backup your project. After framing it out, this would be a good point to initialize it.
```
git init
git add
git commit -m "Framed Project"
```

---
## CHALLENGES

These are also at the bottom of ```Program_UI.cs```

- Add an option to View a Single Adventurer.
- Consider selecting an existing item in character creation instead of starting at creating an item.
- Include a View all Items option.
- Include a View Item by ID option.
- Update the Adventurer Pack to add items from an the item list instead of currently the whole list.
    - Consider if there are more than one adventurer and they pull from the same item list.
    - What about removing items from the adventurers pack?

Don't limit to what these suggest. If you have something that you'd like to try out, go for it!