using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float limitRight = 0f;
    public float limitLeft = 0f;

    public SpriteRenderer playerSprite;
    private float playerSpriteHalfWidth;


    public float rightScreenEdge;
    public float leftScreenEdge;

    public Sprite Bow_and_arrow_READY;
    public Sprite Bow_and_arrow_SET;
    public Sprite Bow_and_arrow_GO;

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        SetupScreenBounds();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void SetupScreenBounds()
    {
        // Assign the game's current main camera to local variable mainCamera, to use it multiple times
        Camera mainCamera = Camera.main;

        // Find the point in game world where the right screen edge touches
        Vector2 screenTopRightCorner = new Vector2(Screen.width, Screen.height);
        Vector2 topRightCornerInWorldSpace = mainCamera.ScreenToWorldPoint(screenTopRightCorner);
        rightScreenEdge = topRightCornerInWorldSpace.x;

        // Find the point in game world where the left screen edge touches
        Vector2 screenBottomLeftCorner = new Vector2(0f, 0f);
        Vector2 bottomLeftCornerInWorldSpace = mainCamera.ScreenToWorldPoint(screenBottomLeftCorner);
        leftScreenEdge = bottomLeftCornerInWorldSpace.x;

        // Calculate the player sprite's half-width
        playerSpriteHalfWidth = playerSprite.bounds.size.x / 2f;
    }

    void Move()
    {
        float inputHl = Input.GetAxis("Horizontal");

        // if pressed right (inputHl will be 1) and the player character hasn't crossed the right limit of the screen,
        // allow them to keep moving right
        if (inputHl > 0 && transform.position.x < rightScreenEdge - playerSpriteHalfWidth)
        {
            // Move to the right

            Vector3 currentPosition = transform.position;

            // we ADD 1 point along the X direction
            Vector3 newPosition = currentPosition + new Vector3(1f, 0f);

            // Apply the movement to the player character's position, adjusted by the speed and deltaTime
            transform.position = Vector3.MoveTowards(currentPosition, newPosition, moveSpeed * Time.deltaTime);
        }
        else if (inputHl < 0 && transform.position.x > leftScreenEdge + playerSpriteHalfWidth)
        {
            // Move to the left

            Vector3 currentPosition = transform.position;

            // we SUBTRACT 1 point along the X direction
            Vector3 newPosition = currentPosition - new Vector3(1f, 0f);

            transform.position = Vector3.MoveTowards(currentPosition, newPosition, moveSpeed * Time.deltaTime);
        }
    }
    

















}
