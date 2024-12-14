using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen;  // Reference to the Start Screen panel
    public GameObject gameContent; // Reference to the main game objects
    public GameObject endScreen;   // Reference to the End Screen panel

    void Start()
    {
        // Ensure only the Start Screen is visible at the beginning
        startScreen.SetActive(true);   // Start Screen is active
        gameContent.SetActive(false); // Game content is hidden
        endScreen.SetActive(false);   // End Screen is hidden
    }

    public void StartGame()
    {
        // Hide the Start Screen and activate the game
        startScreen.SetActive(false);
        gameContent.SetActive(true);
    }

    public void ShowEndScreen()
    {
        // Hide the game and show the End Screen
        gameContent.SetActive(false);
        endScreen.SetActive(true);
    }

    public void RestartGame()
    {
        // Restart the game by reloading the scene
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
