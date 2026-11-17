using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    public Vector3 UpdateKeyBoardInput()
    {
        // 1. Get input from WASD / Arrow keys (-1 to 1)
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // 2. Create a movement vector and normalize it to prevent fast diagonal movement
        Vector2 movement = new Vector2(moveX, moveY).normalized;


        return movement;
    }

    public bool UpdateSpeed()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        if (moveX != 0f || moveY != 0f)
        {
            return true;
        }
        return false;
    }

}
