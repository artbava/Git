using UnityEngine;
public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = { "books", "shelf", "notes", "novels" };
    string[] level2Passwords = { "delegate", "emergency", "call911", "crimescene", "witness" };
    string[] level3Passwords = { "SpaceProgram", "MilkWay", "BlackHole", "StarWars" };
    string[] locals = { @"    _    _  ___  ___  ___  ___  _ _ 
   | |  | || . >| . \| . || . \| | |
   | |_ | || . \|   /|   ||   /\   /
   |___||_||___/|_\_\|_|_||_\_\ |_|
", @"      ___  ___  _    _  ___  ___ 
     | . \| . || |  | ||  _>| __>
     |  _/| | || |_ | || <__| _> 
     |_|  `___'|___||_|`___/|___>
", @"        _  __   ___    ____   ___ 
       / |/ /  / _ |  / __/  / _ |
      /    /  / __ | _\ \   / __ |
     /_/|_/  /_/ |_|/___/  /_/ |_|
                             " };
    // Game state
    int tries = 3;
    int level;
    string password;
    enum Screen { MainMenu, Password, Win, Lose }
    Screen currentScreen;
    
    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello,");
        Terminal.WriteLine("What would you like to hack?");
        Terminal.WriteLine("Press 1 for Local Library");
        Terminal.WriteLine("Press 2 for Police Department");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Type 'menu' any time to restart.");
        Terminal.WriteLine("Enter your selection:");
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            tries = 3;
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            RunPassword(input);
        }
    }
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            Terminal.ClearScreen();
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please, choose a valid level!");
        }
    }
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        if (tries == 3)
        {
            SetRandomPassword();
            Terminal.WriteLine(locals[(level - 1)]);
            Terminal.WriteLine("You have 3 tries. Hint: " + password.Anagram());
            Terminal.WriteLine("Enter password:");
        }
        else
        {
            Terminal.WriteLine("Enter password: ");
        }
    }
    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                { password = level1Passwords[Random.Range(0, level1Passwords.Length)]; }
                break;
            case 2:
                { password = level2Passwords[Random.Range(0, level2Passwords.Length)]; }
                break;
            case 3:
                { password = level3Passwords[Random.Range(0, level3Passwords.Length)]; }
                break;
            default:
                Debug.LogError("Invalid number!");
                break;
        }
    }
    void RunPassword(string input)
    {
        if (input == password)
        {
            Win();
        }
        else
        {
        tries = tries - 1;
        Terminal.WriteLine("Wrong password! Tries left: " + tries);
            if (tries <= 0)
            {
               Lose(); 
            }
            else
            {
               AskForPassword();
            }
        }
    }
    void Win()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Congrats you're in!!! You win!");
        Terminal.WriteLine(@"              _________
            .-\:      /-.
            '-|:.     |-'
              \::.    /
               '::. .'
                 ) (
                /¨¨¨\               
");
        Terminal.WriteLine("Type 'menu' to restart the game.");
    }
    void Lose()
    {
        currentScreen = Screen.Lose;
        Terminal.ClearScreen();
        Terminal.WriteLine("Password lock!!! You lose!");
        Terminal.WriteLine(@"               .-----.
              / .---. \
            _| |_____| |_
          .' |_|     |_| '.
          '._____________.'
          '.             .'
          '.             .'
          '._____________.'
");
        Terminal.WriteLine("Type 'menu' to restart the game.");
    }
}