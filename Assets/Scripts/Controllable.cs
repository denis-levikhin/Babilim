using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllable : MonoBehaviour
{
    //-------CONST----------------------//

    //-------STATS----------------------//


   public float speed = 0.5f;                  // lenght of single step in units

    //-------META-----------------------//

    enum State
    {
        MOVING,
        ATTACKING,
        HURT,
        IDLE
    }

    State currentState = State.IDLE;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput); 
        if (horizontalInput != 0 || verticalInput != 0) {
            currentState = State.MOVING;
            inputVector = Vector2.ClampMagnitude(inputVector, 1);
            Vector2 movement = inputVector * speed;
            Vector2 oldPose = transform.position;
            Vector2 newPos = oldPose + movement * Time.fixedDeltaTime;
            transform.position = newPos;
        }
    }
}
