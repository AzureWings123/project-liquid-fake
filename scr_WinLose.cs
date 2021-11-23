using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_WinLose : MonoBehaviour
{
    public Text WinLoseText;
    private Color newColor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("lava")) //if you or the treasure touch lava
        {
            youLose();
        }
        else if (collision.gameObject.CompareTag("treasure"))
        {
            if(gameObject.CompareTag("Player")) // so the treasure doesn't win by being itself
            {
                youWon();
            }
        }
    }
    void youWon()
    {
        newColor = Color.green;
        WinLoseText.text = "You Won!";
        StartCoroutine(FadeIn());
    }
    void youLose()
    {
        newColor = Color.red;
        WinLoseText.text = "You Lost!";
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {

        while (WinLoseText.color.a < 255)
        {
            WinLoseText.color = Color.Lerp(WinLoseText.color, newColor, .1f);
            yield return null;
        }
    }
}
