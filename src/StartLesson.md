# File Setup w/ Students

Inside of the Projects folder, create a folder called "CRUD_Adventurer"

    - Cohort
        - Projects
            - CRUD_Adventure

*within CRUD_Adventure folder*

```dotnet new sln```

This will generate a solutions file for us in our project. It will auto populate with a name reference to the folder that we are currently within. 

We do have the option to include a name if we don't want it to be exactly like the folder we are within.

```dotnet new sln -n "FileName"```

---
## Creating Data/Repo/UI
Let's create a soruce (**src**) folder to house the overall build of our project. Inside of this, we'll have a Data, Repository, and UI to manage.

    - CRUD_Adventurer
      - src

We'll need to step inside of the **src** folder and generate our various assemblies.

```dotnet new classlib -o Adventurer.Data```

```dotnet new classlib -o Adventurer.Repository```

```dotnet new console -n Adventurer.UI```

Let's consider what these are in a higher scope. Each assembly will be in charge of managing certain functions. Our Data will be our base structure of our objects. The Repository will act like a fake database that will allow us to "store" information from our base objects. Lastly, our UI will use our base objects and utilize them within the "fake database" so that a user can interact with it all.

With all that said, our UI will need to "know" where the Repository and Data reside, and the Repository will need to know about the Data

---
## References
We'll need to **reference** the assemblies.

Still within the **src folder**:

```dotnet add .\Adventurer.UI\ reference .\Adventurer.Data\```

```dotnet add .\Adventurer.UI\ reference .\Adventurer.Repository\```

```dotnet add .\Adventurer.Repository\ reference .\Adventurer.Data\```

These references will need to first point to what will NEED the reference and then target what TO reference. In our case, we have the UI pointing to both the Repository and Data, while the Repository only needs the Data.

---
## Add Assembly to Solutions File

Now that we have our assemblies connected, we'll need to include them all to our solutions file.

Let's step back into the **CRUD_Adventurer** folder.

```dotnet sln add .\src\Adventurer.Data\```

```dotnet sln add .\src\Adventurer.Repository\```

```dotnet sln add .\src\Adventurer.UI\```

In short, the **Solution** is just a container for our application so that we can work through our IDE.

---
## Adventurer.Data Setup

```
    - CRUD_Adventurer
        - src
            - Adventurer.Data
```

We'll are first going to **DELETE** ```Class1.cs```. Then let's create a **POCOs Folder**.

Right-Clicking the new folder, we're going to select ```New C#``` and then select ```Class```. We will name our first class **Adventurer**.

Let's do this one more time, naming our second class **Item**

We've got a shell of our project. Last step prior to coding along, let's initiate a git repo. 

Making sure that we are in our parent folder of **CRUD_Adventurer**

```git init```

```git add .```

```git commit -m "Project frame"```

We'll worry about adding it to a repo later. For now, we've created our local repo and whenever we want to update it, we can at least do that.

Let's go to **Adventurer.cs** within our **POCOs Folder**.
