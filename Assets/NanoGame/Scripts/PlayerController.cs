using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Public Fields

    // A rigid body of this same game object (like a brother component)
    public Rigidbody MyRigidBody;
    public GameManager GameManager;

    public float Speed = 5;
    public float JumpForce = 5;

    #endregion


    #region Unity Methods

    // Update is called once per frame (this is the rendering cycle)
    private void Update()
    {
        // Capturing the input values (Always do this inside Update)
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // Get the input for the jump action
        // (this will be true during the first frame that the spacebar is pressed)
        if (Input.GetButtonDown("Jump"))
        {
            // This is an imaginary laser beam from the center of the player down
            // to just below the bottom part
            bool hit = Physics.Raycast(MyRigidBody.position, new Vector3(0, -1, 0), 1.1f);

            // Did the ray hit any collider? yes or no?
            if (hit)
            {
                // If it hit some ground, then the player can jump
                MyRigidBody.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            }
        }

    }

    // This is the update that is called by the physics engine
    private void FixedUpdate()
    {
        // I create the change in movement that I want in every frame
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // Multiply it by the speed
        movement = movement * Speed;

        // Finally I apply the movement
        MyRigidBody.MovePosition(MyRigidBody.position + movement * Time.fixedDeltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameManager.Lose();
        }
    }

    #endregion


    #region Private Fields

    // Capturing the input values
    private float horizontal;
    private float vertical;

    #endregion


}
