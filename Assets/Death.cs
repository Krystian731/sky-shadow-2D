using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public Transform spawnPoint;
    private Animator playerAnimator;
    private PlayerBehaviourScript playerBehaviourScript;
    private PlayerAnimationController playerAnimationController;
    private ProjectileLunch projectileLunch;
    private Rigidbody2D playerRigidbody2D;
    public float deadAnimationDelay = 1.0f;
    private soundManager soundManager;
    public string startSceneName = "Main Menu";

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerAnimator = player.GetComponent<Animator>();
            playerRigidbody2D = player.GetComponent<Rigidbody2D>();
            playerBehaviourScript = player.GetComponent<PlayerBehaviourScript>();
            playerAnimationController = player.GetComponent <PlayerAnimationController>();
            projectileLunch = player.GetComponent<ProjectileLunch>();
        }
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<soundManager>();
        

       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Je¿eli jakiœ obiekt ma tag "Player".
        {
            Vector2 playerPosition = other.transform.position; // przypisanie pozycji gracza
            Vector2 enemyPosition = transform.position; // przypisanie pozycji przeciwnika

            bool isHitFromAbove = playerPosition.y > enemyPosition.y + 0.5f; // sprawdza czy gracz uderzy³ przeciwnika od góry.

            if (!isHitFromAbove) // je¿eli nie 
            {
                if (playerAnimator != null) // Sprawdza, czy animator gracza jest przypisany.
                {
                    playerAnimator.SetTrigger("Die"); // Ustawia trigger animacji "Die" dla animatora gracza.
                    soundManager.PlaySFX(soundManager.deadPlayer); // Odtwarza dŸwiêk œmierci gracza

                    if (playerRigidbody2D != null) // Sprawdza, czy Rigidbody gracza jest przypisany.
                    {
                        playerRigidbody2D.velocity = Vector2.zero; // ustawia prêdkoœæ gracza na zero;
                        playerRigidbody2D.isKinematic = true; // Ustawia Rigidbody gracza jako kinematyczny (wy³¹cza fizyke)
                    }

                    if (playerBehaviourScript != null) // sprawdza, czy skrypt jest przypisany.
                    {
                        playerBehaviourScript.enabled = false; // wy³¹cza skrypt gracza.
                    }
                    if (playerAnimationController != null) 
                    {
                        playerAnimationController.enabled = false;
                    }
                    if (projectileLunch != null) 
                    {
                        projectileLunch.enabled = false;
                    }

                    // Debug log before playing game over sound
                    Debug.Log("Preparing to play game over sound");
                    Debug.Log("Invoking PlayGameOverSound");
                    Invoke("PlayGameOverSound", 0.2f);
                    Debug.Log("Invoking ResetScene");
                    Invoke("ResetScene", deadAnimationDelay);
                }
                else
                {
                    Debug.Log("Animator not found, resetting scene immediately.");
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
        Debug.Log("Resetting scene to: " + startSceneName);
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
