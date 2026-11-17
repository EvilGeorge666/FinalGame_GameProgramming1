using UnityEngine;

public class Player : Sprite
{
    public InputHandler input;

    
    public override void Move()
    {
        /*
        if (input.UpdateSpeed())
        {
            // 2. Increase speed gradually over time
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, 0, maxSpeed);
        }
        else
        {
            speed = 0;
        }

        base.Move();
        */
        if (input.UpdateSpeed())
        {
           speed = maxSpeed;
        }
        else
        {
            speed = 0;
        }

        base.Move();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        direction = input.UpdateKeyBoardInput();
        base.Update();
        RotateSprite();
    }
}
