using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game state
    int level;
    enum Screen { MainMenu, Password, Win }
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
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the NASA");
        Terminal.WriteLine("Type 'menu' to restart.");
        Terminal.WriteLine("Enter your selection:");
    }
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
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
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
        }
    }
    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You choose level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }
    void RunPassword(string password)
    {
        if (level == 1 && password == "books")
        {
            Win();
        }
        else if (level == 2 && password == "pd911")
        {
            Win();
        }
        else if (level == 3 && password == "SpaceProgram")
        {
            Win();
        }
        else
        {
            Terminal.WriteLine("Wrong password, try again...");
            StartGame();
        }
    }
    void Win()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Congrats you're in!");
        Terminal.WriteLine("Type menu to restart the game...");
    }
}