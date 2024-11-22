using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

    public void returnToMenu()
    {
        Debug.Log("Returning to menu...");
        SceneManager.LoadScene("Menu");
    }
}
