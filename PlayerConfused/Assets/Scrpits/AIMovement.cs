using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float movementForce = 1000;
    public float directionSwitchTimer = 3f;

    private float lastDirectionSwitch = 0f;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        PickDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= lastDirectionSwitch + directionSwitchTimer)
        {
            PickDirection();
        }
    }

    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction * movementForce);
        var angle = Vector2.SignedAngle(Vector2.up, direction);
        gameObject.GetComponent<Rigidbody2D>().rotation = angle;
    }

    void PickDirection()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        lastDirectionSwitch = Time.time;
    }
}
