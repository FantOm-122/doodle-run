using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button StartButton;
    public Button ExitBitton;
    public Button LinkButton;
    public Button ResumeButton;
    public Button PauseButton;
    public GameObject Menu;
    

    private string _linkMessege="https://www.youtube.com/watch?v=B1zCN0YhW1s&list=RDEMuNoGZsKwOtmFzJbaW5DEFA&index=12";
    private bool _gameStarted;
    
    
    private void Start()
    {
        StartButton.onClick.AddListener(StartGame);  
        ExitBitton.onClick.AddListener(ExitGame);
        LinkButton.onClick.AddListener(LinkHandler);
        ResumeButton.onClick.AddListener(ResumeGame);
        PauseButton.onClick.AddListener(PauseGame);
        Menu.SetActive(true);
        Time.timeScale=0;
        ResumeButton.interactable=false;
        
    }

    private void StartGame()
    {
        if (!_gameStarted)
        {
            Time.timeScale=1;
            Menu.SetActive(false);
            _gameStarted=true;
           
        }
        else 
        {
            SceneManager.LoadScene(0);
        }
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void LinkHandler()
    {
        Application.OpenURL(_linkMessege);
    }

    private void ResumeGame()
    {
        Time.timeScale=1;
        Menu.SetActive(false);
    }

    private void PauseGame()
    {
        Time.timeScale=0;
        Menu.SetActive(true);
        ResumeButton.interactable=true;
    }

    public bool IsMenuActive()
    {
        return Menu.activeSelf;
    }

    public bool IsTimeFrozen()
    {
        return Time.timeScale==0;
    }


}
