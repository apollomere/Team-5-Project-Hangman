using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver() 
    {
        gameOverUI.SetActive(true);
    }
    public void gameWin() 
    {
        gameWinUI.SetActive(true);
    }

    public void retry() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void quitGame() // Return to the menu or quit
    {
        Debug.Log("Quitting game...");
#if UNITY_EDITOR
        // Simulate quitting in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Works only in the built game
#endif
    }
}
