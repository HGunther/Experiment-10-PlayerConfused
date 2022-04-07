using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOnCollisionWthAI : MonoBehaviour
{
    public GameObject winscreen;

    void OnCollisionEnter2D(Collision2D col)
    {
        AIMovement enemy;
        if (col.gameObject.TryGetComponent<AIMovement>(out enemy))
        {
            Debug.Log("Collided with AI - Game over!");
            if (!winscreen)
            {
                Debug.LogError("No win screen found!");
            }
            //var winscreen = FindObjectOfType<WinMenu>().gameObject;
            winscreen.SetActive(true);
        }
    }

}
