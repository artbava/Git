using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] level1Passwords = { "books", "shelf", "notes" };
    string[] level2Passwords = { "pd911", "sos911", "call911" };
    string[] level3Passwords = { "SpaceProgram", "MilkWay", "BlackHole" };

    // Game state
    int level;
    int tries = 3;
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
        int rnd = Random.Range(0, 3);
        if (input == "1")
        {
            level = 1;
            password = level1Passwords[rnd];
            print(level1Passwords[rnd]);
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = level2Passwords[rnd];
            print(level2Passwords[rnd]);
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            password = level3Passwords[rnd];
            print(level3Passwords[rnd]);
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
        Terminal.WriteLine("Tries left:" + tries);
        Terminal.WriteLine("Please enter your password: ");
    }
    void RunPassword(string input)
    {
        if (input == password)
        {
            Win();
        }
        else
        {
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
        Terminal.WriteLine("Congrats you're in! You win!");
        Terminal.WriteLine("Type menu to restart the game...");
    }
    void Lose()
    {
        currentScreen = Screen.Lose;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have been caught! You lose!!!");
        Terminal.WriteLine("Type menu to restart the game...");
    }
}