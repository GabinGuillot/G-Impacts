using UnityEngine;
using System.Collections;

public class LifeScript : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives;
    public float respawnDelay = 3f;
    public Transform respawnPoint;
    public string deathZoneTag = "DeathZone";

    private bool isRespawning = false;

    private void Start()
    {
        currentLives = maxLives;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(deathZoneTag))
        {
            GetComponentInChildren<MeshRenderer>().enabled = false;
            DestroyPlayer();
        }
    }

    private void DestroyPlayer()
    {
        if (!isRespawning)
        {
            currentLives--;

            if (currentLives > 0)
            {
                StartCoroutine(RespawnPlayer());
            }
            else
            {
                GameOver();
            }
        }
    }

    private IEnumerator RespawnPlayer()
    {
        isRespawning = true;
        yield return new WaitForSeconds(respawnDelay);

        // Respawn the player at the respawn point
        GetComponentInChildren<MeshRenderer>().enabled = true;
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        isRespawning = false;
    }

    private void GameOver()
    {
        // Implement your game over logic here
        Debug.Log("Game Over");
    }
}