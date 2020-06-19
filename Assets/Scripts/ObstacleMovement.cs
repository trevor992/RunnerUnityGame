using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    
    public void AddRotation(GameObject gameObject, float rotation)
    {
        gameObject.transform.Rotate(Vector3.up * (rotation * Time.deltaTime));
    }

    public bool LateralOscilation(GameObject gameObject, float speed, float dist, float initX, bool movingLeft)
    {
        float currX = gameObject.transform.position.x;
        Vector3 direction;
        
        if(currX >= (initX + dist))
        {
            movingLeft = true;
            

        }else if(currX <= (initX - dist))
        {
            movingLeft = false;
        }
        if(movingLeft == true)
        {
            direction = Vector3.left;
            gameObject.transform.Translate(direction * speed * Time.deltaTime);
            return movingLeft;
        }
        else
        {
            direction = Vector3.right;
            gameObject.transform.Translate(direction * speed * Time.deltaTime);
            return movingLeft;
        }
        
    }
}
