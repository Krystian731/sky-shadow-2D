using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deat : MonoBehaviour
{
    //public GameObject Rogue_01;
    public Transform spawnPoint;
    private Animator playerAnimator;
    public float deadTheAniamtionDelay = 0.1f;
    soundManager soundManager;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerAnimator = player.GetComponent<Animator>();
        }
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<soundManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 playerPosition = other.transform.position;
            Vector2 enemyPosition = transform.position;

            bool isHitFromAbove = playerPosition.y > enemyPosition.y + 0.5f;

            
            if (!isHitFromAbove)
            {
                if (playerAnimator != null)
                {
                    
                    playerAnimator.SetTrigger("Die");
                    soundManager.PlaySFX(soundManager.deadPlayer);
                    Invoke("ResetScene", deadTheAniamtionDelay);
                }
                else 
                {
                    ResetScene();
                }
                
            }
        }
    }
    private void ResetScene() 
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
