using UnityEngine;

public class Sprite : MonoBehaviour
{
    public Vector3 direction;
    public float acceleration = 5f;
    public float maxSpeed = 20f;
    public float speed = 0;
    public float rotation = 0;

    protected Vector2 screenBounds;
    protected float spriteWidth;
    protected float spriteHeight;


    public virtual void KeepOnScreen()
    {
        // Clamp the object's position within calculated bounds
        Vector3 viewPos = transform.position;

        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + spriteWidth, screenBounds.x - spriteWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + spriteHeight, screenBounds.y - spriteHeight);

        transform.position = viewPos;
    }

    protected void RotateSprite()
    {
        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotation * Time.deltaTime);
        }
    }

    public virtual void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {

        // Calculate the world coordinates of the screen edges
        // (0,0) is bottom-left, (1,1) is top-right in viewport space
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.transform.position.z));

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteWidth = spriteRenderer.bounds.extents.x;
            spriteHeight = spriteRenderer.bounds.extents.y;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
        KeepOnScreen();
    }
}
