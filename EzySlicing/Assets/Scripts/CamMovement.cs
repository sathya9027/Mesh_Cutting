using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public enum MovementType
    {
        Mouse,
        Keyboard
    }

    public MovementType movementType;

    public float moveSpeed;
    public float distanceBetweenToMove = 200;

    private Vector3 moveDir;

    private void Update()
    {
        switch (movementType)
        {
            case MovementType.Mouse:
                MouseMovement();
                break;
            case MovementType.Keyboard:
                KeyboardMovement();
                break;
            default:
                break;
        }
        transform.Translate(moveSpeed * Time.deltaTime * moveDir);
    }

    private void MouseMovement()
    {
        if (Input.GetMouseButton(1))
        {
            if (Input.mousePosition.x >= Screen.width - distanceBetweenToMove && Input.mousePosition.x <= Screen.width)
            {
                moveDir.x = 1;
            }
            else if (Input.mousePosition.x >= 0 && Input.mousePosition.x <= distanceBetweenToMove)
            {
                moveDir.x = -1;
            }
            else if (Input.mousePosition.y >= Screen.height - distanceBetweenToMove && Input.mousePosition.y <= Screen.height)
            {
                moveDir.y = 1;
            }
            else if (Input.mousePosition.y >= 0 && Input.mousePosition.y <= distanceBetweenToMove)
            {
                moveDir.y = -1;
            }
            else
            {
                moveDir = Vector3.zero;
            }
        }
        else
        {
            moveDir = Vector3.zero;
        }
    }

    private void KeyboardMovement()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
    }
}
