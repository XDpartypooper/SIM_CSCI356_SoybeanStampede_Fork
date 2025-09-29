using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameStateContoller : MonoBehaviour
{
    public float Timer = 0; //in game timer
    private bool EndOfGame; //game state
    public int Kills;       //kills

    //gamestate
    public GameObject pauseMenu;
    public GameObject LeveledUp;
    public GameObject GameOverScreen;
    private static bool Pause;     //game state 
    public TextMeshProUGUI FinalScore;

    //rouge lv up thing
    public TextMeshProUGUI Choice1;
    public TextMeshProUGUI Choice2;
    public TextMeshProUGUI Choice3;

    public GameObject Weap1;
    public GameObject Weap2;
    public GameObject Weap3;

    private List<int> uniqueNumbers = new List<int>();

    void Start()
    {
        pauseMenu.SetActive(false);
        LeveledUp.SetActive(false);
        //Note to Gun 
        //if (PausedMenu.pause==true) return;// so that it doesnt shoot when paused
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.activeInHierarchy || GameOverScreen.activeInHierarchy|| LeveledUp.activeInHierarchy)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause = !Pause; //false become true
            if (Pause)
                PauseGame(); // pause game
            else
                ResumGame(); // resume game
        }
    }

    public void ScoreUpdate()
    {
        Kills++;// Plus score
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;//pause the game
        Pause = true;
    }

    public void LVUP()
    {
        //Cursor.visible = true;
        LeveledUp.SetActive(true);
        Time.timeScale = 0;//pause the game
        

        System.Random rand = new System.Random();
        uniqueNumbers.Clear();//clear the list before adding again
        int count = 0;

        while (count < 3) // Generate 3 unique numbers
        {
            int randomNumber = rand.Next(1, 10); // Generate a number between 1 and 9
            if (!uniqueNumbers.Contains(randomNumber))
            {
                uniqueNumbers.Add(randomNumber);
                count++;
            }
        }

        Debug.Log("Three unique random numbers:");
        foreach (int num in uniqueNumbers)
        {
            Console.WriteLine(num);

        }

        Choice1.text = BuffOptions(uniqueNumbers[0]);
        Choice2.text = BuffOptions(uniqueNumbers[1]);
        Choice3.text = BuffOptions(uniqueNumbers[2]);

    }

 
    public void Choice(GameObject choice)
    {

        switch (choice.name)
        {
            
            case "Choice1":
                Buffs(uniqueNumbers[0]);

                LeveledUp.SetActive(false);
                Time.timeScale = 1;//pause the game
                //Cursor.visible = false;
                break;
            case "Choice2":
                Buffs(uniqueNumbers[1]);

                LeveledUp.SetActive(false);
                Time.timeScale = 1;//pause the game
                //Cursor.visible = false;
                break;
            case "Choice3":
                Buffs(uniqueNumbers[2]);

                LeveledUp.SetActive(false);
                Time.timeScale = 1;//pause the game
                //Cursor.visible = false;
                break;
        }
    }

    private String BuffOptions(int options)
    {


        switch (options)
        {
            case 1:
                //Magnus Mega Blaster
                //Weapon1.dmg = Weapon1.dmg * 2;
                return "Pistol Buff I \n \nIncrease Magnus Mega Blaster damage by 100%";
            case 2:
                //Weapon1.interval = Weapon1.interval / 2;
                return "Pistol Buff II \n \nIncrease Magnus Mega Blaster fire rate by 50%";
            case 3:
                //Weapon1.mag = (int)(Weapon1.mag * 1.5);
                return "Pistol Buff III \n \nIncrease Magnus Mega Blaster mag by 50%";
            case 4:
                //Stryfe Flywheel Blaster
                //Weapon2.dmg = (int)(Weapon2.dmg * 1.5);
                return "SMG Buff I \n \nIncrease Stryfe Flywheel Blaster damage by 50%";
            case 5:
                //Weapon2.interval = Weapon2.interval / 2;
                return "SMG Buff II \n \nIncrease Stryfe Flywheel Blaster fire rate by 50%";
            case 6:
                //Weapon2.mag = (int)(Weapon2.mag * 1.5);
                return "SMG Buff II \n \nIncrease Stryfe Flywheel Blaster mag by 50%";
            case 7:
                //Nerf Fortnite RPG Blaster
                //Weapon3.dmg = (int)(Weapon3.dmg * 1.5);
                return "RPG Buff I \n \nIncrease Nerf Fortnite RPG Blaster damage by 50%";
            case 8:
                //Weapon3.interval = Weapon3.interval / 2;
                return "RPG Buff II \n \nIncrease Nerf Fortnite RPG Blaster Fire rate by 50%";
            case 9:
                //Weapon3.mag = (int)(Weapon3.mag * 1.5);
                return "RPG Buff III \n \nIncrease Nerf Fortnite RPG Blaster Mag by 50%";
            case 10:
                //unReachable for now
                //"Vampire /n Each kill recovers some HP"
                return "Vampire \n Each kill recovers some HP";
        }
        return "ERROR";
    }

    private void Buffs(int options)
    {
        Pistol Weapon1 = Weap1.GetComponent<Pistol>();
        MachineGun Weapon2 = Weap2.GetComponent<MachineGun>();
        RocketLauncher Weapon3 = Weap3.GetComponent<RocketLauncher>();

        switch (options)
        {
            case 1:
                //Magnus Mega Blaster
                Weapon1.dmg = Weapon1.dmg * 2;
                break;// "Pistol Buff I /n Increase Magnus Mega Blaster damage by 100%";
            case 2:
                Weapon1.interval = Weapon1.interval / 1.5f;
                break;//  "Pistol Buff II /n Increase Magnus Mega Blaster fire rate by 50%";
            case 3:
                Weapon1.mag = (int)(Weapon1.mag * 1.5);
                break;//  "Pistol Buff III /n Increase Magnus Mega Blaster mag by 50%";
            case 4:
                //Stryfe Flywheel Blaster
                Weapon2.dmg = (int)(Weapon2.dmg * 1.5);
                break;//  "SMG Buff I /n Increase Stryfe Flywheel Blaster damage by 50%";
            case 5:
                Weapon2.interval = Weapon2.interval / 1.5f;
                break;//  "SMG Buff II /n Increase Stryfe Flywheel Blaster fire rate by 50%";
            case 6:
                Weapon2.mag = (int)(Weapon2.mag * 1.5);
                break;//  "SMG Buff II /n Increase Stryfe Flywheel Blaster mag by 50%";
            case 7:
                //Nerf Fortnite RPG Blaster
                Weapon3.dmg = (int)(Weapon3.dmg * 1.5);
                break;//  "RPG Buff I /n Increase Nerf Fortnite RPG Blaster damage by 50%";
            case 8:
                Weapon3.interval = Weapon3.interval / 1.5f;
                break;//  "RPG Buff II /n Increase Nerf Fortnite RPG Blaster fire rate by 50%";
            case 9:
                Weapon3.mag = (int)(Weapon3.mag * 1.5);
                break;//  "RPG Buff III /n Increase Nerf Fortnite RPG Blaster mag by 50%";
            case 10:
                //unReachable for now
                //"Vampire /n Each kill recovers some HP"
                break;//  "Vampire /n Each kill recovers some HP";
        }
       
    }

    public void ResumGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;//resume the game
        Pause = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        pauseMenu.SetActive(false);
        GameOverScreen.SetActive(true);
        Time.timeScale = 0;//pause the game
        Pause = true;

        FinalScore.text = "You died,Final Score :" + Kills.ToString();
    }


    public void Survived()
    {
        pauseMenu.SetActive(false);
        GameOverScreen.SetActive(true);
        Time.timeScale = 0;//pause the game
        Pause = true;

        FinalScore.text = "Game Cleared,Final Score :" + Kills.ToString();
    }
}

