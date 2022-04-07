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
        UpdateRenderer(gameState.vision);
        SubscribeToVisionChanges();
    }

    void UpdateRenderer(bool visionState)
    {
        GetComponent<SpriteRenderer>().enabled = visionState;
    }

    void SubscribeToVisionChanges() { GameState.OnVisionChanged += UpdateRenderer; }
    
    void UnsubscribdFromVisionChanges() { GameState.OnVisionChanged -= UpdateRenderer; }

    void OnDestroy()
    {
        UnsubscribdFromVisionChanges();
    }

    void OnDisable()
    {
        UnsubscribdFromVisionChanges();
    }

}
