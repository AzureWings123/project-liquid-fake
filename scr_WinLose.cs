using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scr_WinLose : MonoBehaviour
{
    public Text WinLoseText;
    public GameObject WinLoseUI;
    public static bool GameIsPaused = false;
    public static bool DidYouWin;

    private void Start()
    {
        WinLoseUI.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("lava")) //if you or the treasure touch lava
        {
            GameIsPaused = true;
            DidYouWin = false;
            WinLoseUI.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("treasure"))
        {
            if(gameObject.CompareTag("Player")) // so the treasure doesn't win by being itself
            {
                GameIsPaused = true;
                DidYouWin = true;
                WinLoseUI.SetActive(true);
            }
        }
    }
}
