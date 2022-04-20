using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    GameState gamestate;

    private void Start()
    {
        gamestate = FindObjectOfType<GameState>();

        if (!gamestate)
        {
            Debug.LogError("DestroyOnCollision could not find gamestate");
        }
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            Debug.Log("Collided with player! Destroying");
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            gameObject.SetActive(false);
            Destroy(gameObject);

            Debug.Assert(gamestate, "DestoryOnCollision needs gamestate but it is invalid");
            gamestate.ScorePoint();
        }
    }
}
