using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deat : MonoBehaviour
{
    //public GameObject Rogue_01;
    public Transform spawnPoint;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 playerPosition = other.transform.position;
            Vector2 enemyPosition = transform.position;

            bool isHitFromAbove = playerPosition.y > enemyPosition.y + 0.5f;

            
            if (!isHitFromAbove)
            {
                Scene currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currentScene.name);
            }
        }
    }
}
