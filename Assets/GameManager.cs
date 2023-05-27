using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LifeScript player1;
    public LifeScript player2;
    public Animator canvasAnimator;
    public Text winnerText;

    private bool gameOver = false;

    private void Update()
    {
        if (!gameOver)
        {
            if (player1.currentLives <= 0 || player2.currentLives <= 0)
            {
                string winner = player1.currentLives <= 0 ? "Player2" : "Player1";
                StartCoroutine(DisplayWinner(winner));
                gameOver = true;
            }
        }
    }

    private System.Collections.IEnumerator DisplayWinner(string winner)
    {
        winnerText.text = "The winner is: " + winner;
        canvasAnimator.SetTrigger("ShowWinner");

        yield return null;
    }
}