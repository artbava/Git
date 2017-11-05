using UnityEngine;
public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = { "books", "shelf", "notes" };
    string[] level2Passwords = { "pd911", "sos911", "call911" };
    string[] level3Passwords = { "SpaceProgram", "MilkWay", "BlackHole" };
    string[] locals = { "Local Library", "Police Department", "NASA" };

    // Game state
    int tries = 3;
    int level;
    int rnd;
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
        Terminal.WriteLine("Press 1 for the " + locals[0]);
        Terminal.WriteLine("Press 2 for the " + locals[1]);
        Terminal.WriteLine("Press 3 for the " + locals[2]);
        Terminal.WriteLine("Type 'menu' to restart the game...");
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
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please, choose a valid level!");
        }
    }
    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You are at " + locals [(level-1)] + " network.");
        Terminal.WriteLine("Enter your password. Tries left: " + tries);
        int rnd = Random.Range(0, 3);
        switch (level)
        {
            case 1:
                if (tries == 3) { password = level1Passwords[rnd]; }
                break;
            case 2:
                if (tries == 3) { password = level2Passwords[rnd]; }
                break;
            case 3:
                if (tries == 3) { password = level3Passwords[rnd]; }
                break;
            default:
                Debug.LogError("Invalid number");
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
            Terminal.ClearScreen();
            Terminal.WriteLine("Wrong password, try again...");
            tries = tries - 1;
            if (tries <= 0)
            {
               Lose(); 
            }
            else
            {
                StartGame();
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
        Terminal.WriteLine("Type 'menu' to restart the game...");
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
        Terminal.WriteLine("Type 'menu' to restart the game...");
    }
}