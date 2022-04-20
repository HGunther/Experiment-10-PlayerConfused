using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualIndicator : MonoBehaviour
{
    ScentData scentData;

    public void ReadData(TrailNodeData node)
    {
        scentData = node.data;
        GetComponent<SpriteRenderer>().color = scentData.scentColor;
    }

    void FixedUpdate()
    {
        //if (!scentData)
        //{
        //    Debug.LogWarning("Visual Indicator called FixedUpdate without having data");
        //    return;
        //}

        UpdateVisual();
    }

    public void UpdateVisual()
    {
        var remainingTime = scentData.lifetime - (Time.time - scentData.createdTime);
        var scentStrength = remainingTime / scentData.lifetime;
        if (remainingTime <= 0.001f)
        {
            Destroy(gameObject);
            return;
        }

        SetSize(3 * (1 - scentStrength));
        SetOpacity(Mathf.Pow(scentStrength, 2));
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
