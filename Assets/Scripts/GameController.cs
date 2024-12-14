using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour
{
    public GameObject endScreen; // Reference to the End Screen panel
    public MusicManager musicManager; // Reference to the MusicManager
   

    void Start()
    {
        // Ensure the end screen is hidden at the start
        if (endScreen != null)
        {
            endScreen.SetActive(false);
        }
    }
    public void StartGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("Start screen"); // Replace "MainScene" with your actual scene name
    }

    public void PlayMusic1()
    {
        if (musicManager != null) musicManager.PlayMusic1();
    }

    public void PlayMusic2()
    {
        if (musicManager != null) musicManager.PlayMusic2();
    }

    public void PlayMusic3()
    {
        if (musicManager != null) musicManager.PlayMusic3();
    }

    public void PlayMusic4()
    {
        if (musicManager != null) musicManager.PlayMusic4();
    }

    public void StopMusic()
    {
        if (musicManager != null) musicManager.StopMusic();
    }
    public void ShowEndScreen()
    {
        // Activate the end screen
        if (endScreen != null)
        {
            endScreen.SetActive(true);
            Time.timeScale = 0; // Pause the game
        }
        else
        {
            Debug.LogError("Cannot show the end screen because it is not assigned!");
        }
    }


}
