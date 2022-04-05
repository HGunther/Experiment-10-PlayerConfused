using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideRender : MonoBehaviour
{
    void Start()
    {
        var gameState = FindObjectOfType<GameState>();
        if (!gameState)
        {
            Debug.LogError("Error: Could not find gamestate object");
        }
        GetComponent<SpriteRenderer>().enabled = gameState.vision;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
