using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Reference to the original prefab to instatiate
    public GameObject projectilePrefab;
    
	// Reference to the AudioSource component on the player
	public AudioSource sfxPlayer;

    public Sprite Bow_and_arrow_READY;
    public Sprite Bow_and_arrow_SET;
    public Sprite Bow_and_arrow_SET_b;
    public Sprite Bow_and_arrow_GO;

    public AudioClip Let_arrow_fly;
    public AudioClip Bow_loading;

    private SpriteRenderer spriteRenderer;
    private bool isHoldingButton = false; 

    public float holdSwitchInterval = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Bow_and_arrow_READY;
        if (!GetComponent<AudioSource>())
        {
            gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StartHoldingButton();
        }
        // Check for Jump button release
        else if (Input.GetButtonUp("Jump"))
        {
            StopHoldingButton();
            Shoot();
        }    
    }

    void Shoot()
    {	
		// We instantiate the prefab at the same position as the player,
        // since this script is on the player GameObject
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        sfxPlayer.Play();
        
    }
    void StartHoldingButton()
    {
        isHoldingButton = true;
        StartCoroutine(HoldButtonSwitchSprites());
        PlayDrawAudio();
    }

    void StopHoldingButton()
    {
        isHoldingButton = false;
        spriteRenderer.sprite = Bow_and_arrow_GO;
        PlayReleaseAudio();
        Invoke(nameof(SetBowAndArrowReadySprite), 0.2f);

    }
    private void PlayReleaseAudio()
    {
        if (Let_arrow_fly != null)
        {
            // Play the audio clip at the object's position
            AudioSource.PlayClipAtPoint(Let_arrow_fly, transform.position);
        }
        else
        {
            Debug.LogWarning("Let_arrow_fly audio clip is not assigned!");
        }
    }

    private void PlayDrawAudio()
    {
        if (Bow_loading != null)
        {
            // Play the audio clip at the object's position
            AudioSource.PlayClipAtPoint(Bow_loading, transform.position);
        }
        else
        {
            Debug.LogWarning("Bow_loading audio clip is not assigned!");
        }
    }

    System.Collections.IEnumerator HoldButtonSwitchSprites()
    {
        while (isHoldingButton)
        {
            // Alternate between Bow_and_arrow_SET and Bow_and_arrow_SET_2b
            spriteRenderer.sprite = spriteRenderer.sprite == Bow_and_arrow_SET
                ? Bow_and_arrow_SET_b
                : Bow_and_arrow_SET;

            yield return new WaitForSeconds(holdSwitchInterval); // Wait for the interval
        }
    }

    void SetBowAndArrowReadySprite()
    {
        if (Bow_and_arrow_READY != null)
        {
            spriteRenderer.sprite = Bow_and_arrow_READY;
        }
    }


}
