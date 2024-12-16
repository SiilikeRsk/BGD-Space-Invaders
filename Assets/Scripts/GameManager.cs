using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject gameContent;
    public GameObject endScreen;

    void Start()
    {
        startScreen.SetActive(true); 
        gameContent.SetActive(false);
        endScreen.SetActive(false);
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        gameContent.SetActive(true);
    }

    public void BackToStart()
    {
        // Show the Start Screen and hide the Game Content and End Screen
        startScreen.SetActive(false);
        gameContent.SetActive(false);
        endScreen.SetActive(false);
    }


    public void ShowEndScreen()
    {        
        gameContent.SetActive(false);
        endScreen.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
