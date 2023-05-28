using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public LifeScript player1;
    public LifeScript player2;

    public Image[] player1Lives;
    public Image[] player2Lives;

    private void Start()
    {
        DisableAllLives(player1Lives);
        DisableAllLives(player2Lives);
    }

    private void Update()
    {
        for (int i = 0; i < player1Lives.Length; i++)
        {
            player1Lives[i].enabled = i < player1.currentLives;
        }

        for (int i = 0; i < player2Lives.Length; i++)
        {
            player2Lives[i].enabled = i < player2.currentLives;
        }
    }

    private void DisableAllLives(Image[] lives)
    {
        foreach (Image life in lives)
        {
            life.enabled = false;
        }
    }
}