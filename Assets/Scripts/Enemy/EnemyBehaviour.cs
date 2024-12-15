using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip destructionSFX;
    public GameObject lantern_ON_Prefab; // Prefab for the lantern_ON sprite
    public string lanternTag = "Lantern";
    
    public GameController gameController;

    private Quaternion initialRotation;



    void Start()
    {
        gameController = FindObjectOfType<GameController>();

        if (gameController == null)
        {
            Debug.LogError("GameController is not found in the scene!");
        }
    }


   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("I was triggered!");

        // Check the other colliding object's tag to know if it's indeed a player projectile
        if (collision.tag == "Laser")
        {
            // Destroy the current game object (lantern_OFF)
            Destroy(gameObject);

            // Spawn the lantern_ON prefab at the same location and orig. rotation
            if (lantern_ON_Prefab != null)
            {
                GameObject lantern_ON = Instantiate(lantern_ON_Prefab, transform.position, initialRotation);

                // Ensure the lantern_ON floats up using negative gravity
                Rigidbody2D rb2D = lantern_ON.GetComponent<Rigidbody2D>();
                if (rb2D != null)
                {
                    rb2D.gravityScale = -1; // Apply negative gravity to make it float upwards
                }
            }
            else
            {
                Debug.LogError("lantern_ON_Prefab is not assigned!");
            }

            // Destroy the colliding Laser game object
            Destroy(collision.gameObject);

            // Play an audio clip in the scene and not attached to the alien
            // so the sound keeps playing even after it's destroyed
            AudioSource.PlayClipAtPoint(destructionSFX, transform.position);
        }
    }

    public void CheckForRemainingLanterns()
    {
        // Find all Lantern objects with the specified tag
        GameObject[] lanterns = GameObject.FindGameObjectsWithTag(lanternTag);

        if (lanterns.Length > 0)
        {
            Debug.Log($"There are {lanterns.Length} Lanterns remaining.");
        }

        if (lanterns.Length <= 0)
        {
            print("WE HAVE NO LANTERNS");
            if (gameController != null)
            {
                gameController.ShowEndScreen();
            }
            else
            {
                Debug.LogError("GameController reference is missing!");
            }
        }
    }

    private void OnDestroy()
    {
        // Call CheckForRemainingLanterns when a lantern is destroyed
        CheckForRemainingLanterns();
    }
}
