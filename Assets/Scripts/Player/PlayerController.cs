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
                
        if (inputHl > 0 && transform.position.x < rightScreenEdge - playerSpriteHalfWidth)
        {
            // Move right
            MovePlayer(Vector3.right);
        }
        else if (inputHl < 0 && transform.position.x > leftScreenEdge + playerSpriteHalfWidth)
        {
            // Move left
            MovePlayer(Vector3.left);
        }

    }
        
    void MovePlayer(Vector3 direction) //void made for touch screen testing
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = currentPosition + direction;
        transform.position = Vector3.MoveTowards(currentPosition, newPosition, moveSpeed * Time.deltaTime);
    }

}
