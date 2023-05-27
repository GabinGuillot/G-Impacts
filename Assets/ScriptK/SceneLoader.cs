using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public float countdownDuration = 3f; // Duration of the countdown in seconds
    public Text countdownText; // Text component to display the countdown
    public Image countdownPanel;
    public GameObject player1;
    public GameObject player2;

    private bool isCountdownFinished = false;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        float timer = countdownDuration;

        while (timer > 0)
        {
            countdownText.text = timer.ToString("F0");
            yield return new WaitForSeconds(1f);
            timer--;
        }

        countdownText.gameObject.SetActive(false);
        countdownPanel.gameObject.SetActive(false);
        player1.gameObject.SetActive(true);
        player2.gameObject.SetActive(true);
        isCountdownFinished = true;
    }
}