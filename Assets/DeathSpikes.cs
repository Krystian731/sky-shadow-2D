using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSpikes : MonoBehaviour
{
    public Transform spawnPoint;
    private Animator playerAnimator;
    private PlayerBehaviourScript playerBehaviourScript;
    private Rigidbody2D playerRigidbody2D;
    public float deadAnimationDelay = 1.0f;
    private soundManager soundManager;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerAnimator = player.GetComponent<Animator>();
            playerRigidbody2D = player.GetComponent<Rigidbody2D>();
            playerBehaviourScript = player.GetComponent<PlayerBehaviourScript>();
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

                    if (playerRigidbody2D != null)
                    {
                        playerRigidbody2D.velocity = Vector2.zero;
                        playerRigidbody2D.isKinematic = true;
                    }

                    if (playerBehaviourScript != null)
                    {
                        playerBehaviourScript.enabled = false;
                    }

                    // Debug log before playing game over sound
                    Debug.Log("Preparing to play game over sound");
                    Invoke("PlayGameOverSound", 0.2f);
                    Invoke("ResetScene", deadAnimationDelay);
                }
                else
                {
                    ResetScene();
                }
            }
        }
    }

    private void PlayGameOverSound()
    {
        // Debug log to check if PlayGameOverSound is called
        Debug.Log("Playing game over sound");
        if (soundManager != null && soundManager.gameOver != null)
        {
            soundManager.PlaySFX(soundManager.gameOver);
        }
        else
        {
            Debug.LogError("gameOver sound clip not assigned or soundManager is null");
        }
    }

    private void ResetScene()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
