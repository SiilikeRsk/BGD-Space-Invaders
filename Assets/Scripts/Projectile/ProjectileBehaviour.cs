using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float destroyDelay = 5f;

    public float switchInterval = 0.1f;
    
    public Sprite Arrow_GO_a;
    public Sprite Arrow_GO_b;

    private SpriteRenderer spriteRenderer;

    private bool isUsingArrowA = true;

    // Start is called before the first frame update
    void Start()
    {
		// Another form of the Destroy function, which allows us to destroy an object
		// after a delay in seconds. We set the delay with a variable "destroyAfter"
        Destroy(gameObject, destroyDelay);
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer is missing on this GameObject!");
            return;
        }

        // Set the initial sprite
        if (Arrow_GO_a == null || Arrow_GO_b == null)
        {
            Debug.LogError("Sprites are not assigned in the Inspector!");
            return;
        }
        spriteRenderer.sprite = Arrow_GO_a;

        // Start the sprite switch loop
        InvokeRepeating("SwitchArrow", switchInterval, switchInterval);
        print("InvokeRepeating is set up");
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the game object along the Y-axis (X is 0f), and we make the Y value into 
        // a variable so we can change the direction (up or down) and make the script reusable
        // in different situations. (can do the same for X and then it'll move in any direction you want)
        Vector3 translationVector = new Vector3(0f, 1f) * moveSpeed * Time.deltaTime;
        transform.Translate(translationVector);
        
    }
    public void SwitchArrow()
    {
        if (spriteRenderer == null)
            return;
        // Toggle between Arrow_GO_a and Arrow_GO_b
        if (isUsingArrowA)
        {
            spriteRenderer.sprite = Arrow_GO_b;
        }
        else
        {
            spriteRenderer.sprite = Arrow_GO_a;
        }

        isUsingArrowA = !isUsingArrowA;
    }

}

