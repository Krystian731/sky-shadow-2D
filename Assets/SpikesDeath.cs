using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesDeath : MonoBehaviour
{
    public string startSceneName = "Main Menu"; // Nazwa sceny startowej
    public float deadAnimationDelay = 1.0f; // OpóŸnienie przed resetem sceny
    private PlayerBehaviourScript playerBehaviourScript;
    private PlayerAnimationController playerAnimationController;
    private ProjectileLunch projectileLunch;

    private Animator playerAnimator;
    private Rigidbody2D playerRigidbody2D;
    private bool isDead;
    private soundManager soundManager;
    public gameManagerScript gameManagerScript;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerAnimator = player.GetComponent<Animator>();
            playerRigidbody2D = player.GetComponent<Rigidbody2D>();
        }

        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<soundManager>();
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Je¿eli jakiœ obiekt ma tag "Player".
        {
            Vector2 playerPosition = other.transform.position; // przypisanie pozycji gracza
            Vector2 spikes = transform.position; // przypisanie pozycji przeciwnika

            bool isHitFromAbove = playerPosition.y > spikes.y + 0.5f; // sprawdza czy gracz uderzy³ przeciwnika od góry.

            if (!isHitFromAbove) // je¿eli nie 
            {

                if (playerAnimator != null && !isDead) // Sprawdza, czy animator gracza jest przypisany.
                {
                    isDead = true;
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

                }
            }
        }
    }
}


