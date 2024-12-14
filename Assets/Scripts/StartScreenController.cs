using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour
{
    public MusicManager musicManager; // Reference to the MusicManager

    public void StartGame()
    {
        // Load the main game scene
        SceneManager.LoadScene("MainScene"); // Replace "MainScene" with your actual scene name
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
}
