using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;



public class GameController : MonoBehaviour
{
    public List<TMP_Text> buttonList;
    public GameObject gameOverPanel;
    public UnityEngine.UI.Button buttonAgain;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void RestartGame()
    {
        gameOverPanel.SetActive(false);
    }
}
