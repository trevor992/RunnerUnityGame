using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    // Start is called before the first frame update
    //The function is called whenever "this" object collides with something
    void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.CompareTag("Obstacle"))
        {
            movement.enabled = false;



        }
    }
}
