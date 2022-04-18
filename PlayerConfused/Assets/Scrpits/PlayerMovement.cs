using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10;
    public float slowdown = 0.11f;

    private bool moving = false;
    private Vector2 accellerationDirection = new Vector2();

    void Awake(){
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (moving){
            GetComponent<Rigidbody2D>().velocity = accellerationDirection * moveSpeed;
        }
        else {
            var vel = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Rigidbody2D>().velocity = vel * (1 - slowdown);
        }
    }

    public void OnMove(InputAction.CallbackContext context){
        if (context.phase != InputActionPhase.Canceled){
            moving = true;
            accellerationDirection = context.ReadValue<Vector2>();
        }
        else {
            moving = false;
        }
    }

}
