using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip destructionSFX;

    public GameObject lantern_ON_Prefab; // Prefab for the lantern_ON sprite

    private Vector3 initialPosition;

    private Quaternion initialRotation;

    void Start()
    {
        // Get the SpriteRenderer component
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // physical simulation hits. For Unity to call this function, at least one of the colliding objects
    // needs to have their RigidBody component set to "Dynamic" for Body Type
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("I Collided!");
    }

    // Unity calls this function if the Collider on the game object has "Is Trigger" checked.
	// Then it doesn't physically react to hits but still detects them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("I was triggered!");

		// Check the other colliding object's tag to know if it's
		// indeed a player projectile
        if (collision.tag == "Laser")
        {
            // Destroy the current game object (lantern_OFF)
            Destroy(gameObject);

            // Spawn the lantern_ON prefab at the same location and rotation
            if (lantern_ON_Prefab != null)
            {
                
                GameObject lantern_ON = Instantiate(lantern_ON_Prefab, initialPosition, initialRotation);

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
       
}
