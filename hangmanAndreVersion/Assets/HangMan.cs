using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using System;

public class HangMan : MonoBehaviour
{



    [SerializeField] GameObject wordcontainer; // Container for displaying the word to guess.
    [SerializeField] GameObject keyBoardcontainer; // Container for placing letter buttons.
    [SerializeField] GameObject lettercontainer; // Container for the letters being displayed as part of the word.
    [SerializeField] GameObject[] hangmanStages; // Array holding the hangman stages (parts) to show as the player makes incorrect guesses.
    [SerializeField] GameObject letterButton; // Prefab for letter buttons.
    [SerializeField] TextAsset wordsAvailible; // Text asset containing available words for the game.

    //Player Lose&Win objects/Datatypes
    private bool playerLose;
    public GameManagerScript gameManager;
    private bool playerWin;
    //Player Lose&Win Objects/Datatypes

    // Private variables to keep track of game state.
    private string words; // The word currently being guessed.
    private int currect, wrong; // Variables to track the number of correct guesses and wrong guesses.

    void Start()
    {
        initialButton();
        InitializeGame();
    }

    private void initialButton()
    {
        for (int i = 65; i <= 90; i++) // ASCII values for 'A' to 'Z'.
        {
            CreateButton(i);
        }
    }

    private void CreateButton(int i)
    {
        GameObject myTemp = Instantiate(letterButton, keyBoardcontainer.transform);
        myTemp.GetComponentInChildren<TextMeshProUGUI>().text = ((char)i).ToString();
        myTemp.GetComponent<Button>().onClick.AddListener(delegate { CheckLetter(((char)i).ToString()); });
    }

    protected void InitializeGame()
    {
        wrong = 0;
        currect = 0;

        foreach (Button child in keyBoardcontainer.GetComponentsInChildren<Button>())
        {
            child.interactable = true;
        }

        foreach (Transform child in wordcontainer.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (GameObject stage in hangmanStages)
        {
            stage.SetActive(false);
        }

        words = GenerateWord().ToUpper(); 
        
        foreach (char letter in words)
        {
            var myTemp = Instantiate(lettercontainer, wordcontainer.transform);
            
        }
    }

    private string GenerateWord()
    {
        string[] wordsList = wordsAvailible.text.Split('\n');
        string line = wordsList[UnityEngine.Random.Range(0, wordsList.Length - 1)].Trim();
        return line; // Trim to remove any trailing spaces or newline characters.
    }

    private void CheckLetter(string letter)
    {
        bool isPresent = false;

        for (int i = 0; i < words.Length; i++)
        {
            if (letter == words[i].ToString())
            {
                isPresent = true;
                currect++;

                // Set the correct guessed letter.
                Transform child = wordcontainer.transform.GetChild(i);
                child.GetComponentInChildren<TextMeshProUGUI>().text = letter;
            }
        }

        if (!isPresent)
        {
            wrong++;
            if (wrong - 1 < hangmanStages.Length) // Ensure index is within bounds.
            {
                hangmanStages[wrong - 1].SetActive(true);
            }
        }

        CheckOutcome();
    }

    private void CheckOutcome()
    {
        if (currect == words.Length && !playerWin) //!playerWin necessary for bool statement
        {
            playerWin = true; //playerWin is made true
            gameManager.gameWin(); //This true statement triggers this function.
            Debug.Log("Game Over! You Won");
            foreach (Transform child in wordcontainer.transform)
            {
                child.GetComponentInChildren<TextMeshProUGUI>().color = Color.blue;
            }
           // Invoke("InitializeGame", 2f); Disabled
        }

        if (wrong == hangmanStages.Length && !playerLose)//!playerLose necessary for bool statement
        {
            playerLose = true;//playerLose is made true
            gameManager.gameOver();//This true statement triggers this function.
            Debug.Log("Game Over! You Lost");
            
            for (int i = 0; i < words.Length; i++)
            { 
                Transform child = wordcontainer.transform.GetChild(i);
                child.GetComponentInChildren<TextMeshProUGUI>().text = words[i].ToString();
                child.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
               
            }
          //  Invoke("InitializeGame", 2f); Disabled
        }
    }
    //Loss and Win Screen Functions
}

