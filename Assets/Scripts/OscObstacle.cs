using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscObstacle : ObstacleMovement
{
    float initX;
    bool movingLeft = true;

    private void Start()
    {
        initX = gameObject.transform.position.x;

    }
    void Update()
    {       
        movingLeft = LateralOscilation(gameObject, 5, 3, initX, movingLeft);
    }
}
