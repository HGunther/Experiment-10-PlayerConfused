using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOnCollisionWthAI : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        AIMovement enemy;
        if (col.gameObject.TryGetComponent<AIMovement>(out enemy))
        {
            var winscreen = FindObjectOfType<Canvas>();
            winscreen.enabled = true;
        }
    }

}
