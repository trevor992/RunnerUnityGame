using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, InputMaster.IPlayerActions
{
    public Rigidbody rb;
    //note f at the end of the number signifies that we are talking about a float
    public float forwardForce = 2000f;
    public float sideWaysForce = 500f;
    
    

    public float jumpForce = 100f;

    private InputMaster controls;
    private float yPos;
    private bool isJumping;
    private bool isMoving;


    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        controls = new InputMaster();
        controls.Player.SetCallbacks(this); // this script will be able to use the Player action map...
    }

    private void Start()
    {
        yPos = gameObject.transform.position.y;
        
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        
        if(context.started && yPos <= 50)
        {
            isJumping = true;
        }
        else if(context.canceled || yPos >50)
        {
            isJumping = false;
        }
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        
        if(context.started)
        {            
            isMoving = true;
        }else if (context.canceled)
        {
            isMoving = false;
        }
    }


    // when ever this script is enabled/ disabled the Player action map will also be enabled/ disabled appropriately
    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    // Start is called before the first frame update
    //start function runs when game starts...
    //Debug.Log() to print to console...

    // Update is called once per frame
    //FixedUpdate should be used instead of Update when updating physics
    //Updaet is called once per frame Fixed Update can run once, zero or several times per
    //frame, depending on how many physics frames per second are set in the time settings, and
    //how fast/slow the framerate is.

    // this is not the most efficient way to manage player movement.
    //Input.GetKey() works here but if you want to smooth player movement or use a controller 
    //Unity has much better ways of doing it

    //Input is ussually done in the Update() method because FixedUpdate may be "updating"
    // slower than update which could result in missing play input

    /*
    the reccomended thing to do is check for input in Update() function and then store that input
    in global variables (boolean) and then check if those variables are true or false in the
    FixedUpdate function to add a force.
    */

    void FixedUpdate()
    {
        //Time.deltaTime is the amount of seconds since the computer drew the last frame...
        //so if the update is running 10 times a second this value will be .1 and if it's running
        //20 times a second the value will be .05...

        
        rb.AddForce(0, 0, forwardForce * Time.fixedDeltaTime);

        if(isJumping == true)
        {
            rb.AddForce(Vector3.up * Time.fixedDeltaTime * jumpForce);
        }
        if(isMoving == true)
        {
            rb.AddForce(controls.Player.Movement.ReadValue<float>() * Time.fixedDeltaTime * sideWaysForce, 0, 0, ForceMode.VelocityChange);
        }
      
        
    }
}
