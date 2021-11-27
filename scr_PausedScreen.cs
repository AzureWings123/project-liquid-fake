using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scr_PausedScreen : MonoBehaviour
{
    public Text WinLoseText;
    public GameObject WinLoseUI;
    public Button WinLoseButton1, WinLoseButton2, WinLoseButton3;

    // Update is called once per frame
    void Update()
    {
        if (scr_WinLose.GameIsPaused)
        {
            if (scr_WinLose.DidYouWin)
            {
                youWon();
            }
            else
            {
                youLose();
            }
        }
    }
    public void youWon()
    {
        WinLoseText.color = Color.green;
        WinLoseText.text = "You Won!";
        WinLoseButton1.GetComponentInChildren<Text>().text = "Try Again?";
        WinLoseButton2.GetComponentInChildren<Text>().text = "Next Level";
        WinLoseButton3.GetComponentInChildren<Text>().text = "Quit to Main";
        WinLoseUI.SetActive(true);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 0f;
    }
    void youLose()
    {
        WinLoseText.color = Color.red;
        WinLoseText.text = "You Lost!";
        WinLoseButton1.GetComponentInChildren<Text>().text = "Try Again?";
        WinLoseButton2.GetComponentInChildren<Text>().text = "Main Menu";
        WinLoseButton3.GetComponentInChildren<Text>().text = "Quit";
        WinLoseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetryButton()
    {
        Retry();
        Resume();
    }
    public void NextOrMainButton()
    {
        if (scr_WinLose.DidYouWin)
        {
            nextLevel();
        }
        else
        {
            toMain();
        }
    }
    public void QuittingButton()
    {
        if (scr_WinLose.DidYouWin)
        {
            toMain();
        }
        else
        {
            quitGame();
        }
   
    }
    void Resume()
    {
        WinLoseUI.SetActive(false);
        scr_WinLose.GameIsPaused = false;
        Time.timeScale = 1f;
    }
    void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void nextLevel()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void toMain()
    {
        SceneManager.LoadScene(0); //Scene 0 = menu
    }
    void quitGame()
    {
        SceneManager.LoadScene(1); //scene 1 = credits
    }
}
