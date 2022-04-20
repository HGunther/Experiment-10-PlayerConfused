using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            Debug.Log("Collided with player! Destroying");
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
