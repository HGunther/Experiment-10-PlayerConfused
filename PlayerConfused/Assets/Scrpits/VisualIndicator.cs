using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualIndicator : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSize(float size) {
        transform.localScale = Vector3.one * size;
    }

    public void SetOpacity(float opacity) {
        var currentColor = GetComponent<SpriteRenderer>().color;
        var newColor = new Color(currentColor.r, currentColor.g, currentColor.b, opacity);
        GetComponent<SpriteRenderer>().color = newColor;
    }
}
