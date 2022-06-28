Program_UI UI = new Program_UI(); // new-upped a UI object.
//? We've new-upped our UI class that we just generated.

UI.Run(); // Invoking our Run() method.
//? Just like all other classes, we've made an object that has a method of "Run". When we invoke it, it will run whatever logic that we've injected into it. For our test, we simply have a Console.WriteLine() to detail that for us.

/*
?   We're going to run this from our main project folder.
    dotnet run --project .\src\Adventurer.UI
*/