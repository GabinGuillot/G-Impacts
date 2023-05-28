using UnityEngine;
using System.Collections;

public class LifeScript : MonoBehaviour
{
    public int maxLives = 3; //HP max
    public int currentLives;
    public float respawnDelay = 3f; //Délai entre chaque respawn
    public Transform respawnPoint; //Prefab de l'endroit où le player respawn
    public string deathZoneTag = "DeathZone";

    private bool isRespawning = false;

    private void Start()
    {
        currentLives = maxLives;
    }

    private void OnTriggerEnter(Collider other) //Interaction avec la DeathZone
    {
        if (other.CompareTag(deathZoneTag))
        {
            GetComponentInChildren<MeshRenderer>().enabled = false;
            DestroyPlayer();
        }
    }

    private void DestroyPlayer() //Destruction du mesh et lancement du respawn
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
        
        GetComponentInChildren<MeshRenderer>().enabled = true; //Respawn le joueur, réactive son mesh
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        isRespawning = false;
    }

    private void GameOver()
    {
        //Test pour voir si le joueur perd correctement
        Debug.Log("Game Over");
    }
}