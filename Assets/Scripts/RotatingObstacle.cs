using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : ObstacleMovement
{

    void Update()
    {
        AddRotation(gameObject, 250);
    }
}
