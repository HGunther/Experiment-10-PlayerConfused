using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScents : MonoBehaviour
{
    public VisualIndicator visualIndicator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        TrailNodeData scentData;
        if (other.TryGetComponent<TrailNodeData>(out scentData))
        {
            var newVisualIndicator = Instantiate<VisualIndicator>(visualIndicator, transform.position, transform.rotation);
            newVisualIndicator.ReadData(scentData);
            newVisualIndicator.UpdateVisual();
        }
    }


}
