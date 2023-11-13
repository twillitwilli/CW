using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacingDirection : MonoBehaviour
{
    public bool lockDirection { get; set; }
    public Vector2 movementDir { get; set; }

    float _previousDirection;

    public void FacingDirection(Vector2 movement)
    {
        if (!lockDirection)
        {
            transform.eulerAngles = new Vector3(0, 0, GetDirection(movement));
            _previousDirection = GetDirection(movement);
        }
    }

    public float GetDirection(Vector2 movement)
    {
        Vector2 moveDirection = movement * 100;

        movementDir = moveDirection;

        if (moveDirection.y > 60 && moveDirection.x > 30)
            return -45f;

        else if (moveDirection.y > 60 && moveDirection.x < -30)
            return 45f;

        else if (moveDirection.y < -60 && moveDirection.x > 30)
            return -135f;

        else if (moveDirection.y < -60 && moveDirection.x < -30)
            return 135f;

        else if (moveDirection.y > 60 && moveDirection.x < 30 && moveDirection.x > -30)
            return 0;

        else if (moveDirection.y < -60 && moveDirection.x < 30 && moveDirection.x > -30)
            return 180;

        else if (moveDirection.x > 60 && moveDirection.y < 30 && moveDirection.y > -30)
            return -90;

        else if (moveDirection.x < -60 && moveDirection.y < 30 && moveDirection.y > -30)
            return 90;

        else
            return _previousDirection;
    }
}
