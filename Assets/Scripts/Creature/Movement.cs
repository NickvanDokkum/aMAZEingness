﻿using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public int speed = 3;
    public Vector2 movementVector;
    
    public void Move(Vector2 movement) {
        movementVector = movement;
        transform.Translate(Vector2.up * Time.deltaTime * movement.y * speed);
        transform.Translate(Vector2.right * Time.deltaTime * movement.x * speed);
    }
}
