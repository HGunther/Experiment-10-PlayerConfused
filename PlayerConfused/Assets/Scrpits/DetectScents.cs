using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScents : MonoBehaviour
{
    public VisualIndicator visualIndicator;
    public float maxOpacity = 1f;
    public float minOpacity = 0f;
    public float sizeMultiplier = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        TrailNodeData scentData;
        if (other.TryGetComponent<TrailNodeData>(out scentData))
        {
            var scentStrength = (scentData.lifetime - (Time.time - scentData.createdTime)) / scentData.lifetime;
            var newVisualIndicator = Instantiate<VisualIndicator>(visualIndicator, transform.position, transform.rotation);
            newVisualIndicator.SetSize(3 * scentStrength);
            newVisualIndicator.SetOpacity(scentStrength);
            Destroy(newVisualIndicator.gameObject, 1f);
        }
    }


}
