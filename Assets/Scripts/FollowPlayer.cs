using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Transform with capital T refers to the Transform component that every object contains

    public Transform player;

    //Vector3 stores 3 floats
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        //transform with lowercase t means the position of this object (in the case the camera)
        transform.position = player.position + offset;
    }
}
