using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour
{
    public GameObject endScreen; 
    public MusicManager musicManager;
   

    void Start()
    {
        if (endScreen != null)
        {
            endScreen.SetActive(false);
        }
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
            Time.timeScale = 1; // Don't! pause the game, for pause, change to 0.
        }
        else
        {
            Debug.LogError("Cannot show the end screen because it is not assigned!");
        }
    }


}
