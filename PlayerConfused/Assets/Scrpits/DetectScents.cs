using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered trigger");
        TrailNodeData scentData;
        if (other.TryGetComponent<TrailNodeData>(out scentData))
        {
            var scentStrength = (Time.time - scentData.createdTime) / scentData.lifetime;
            Debug.Log(scentStrength);
        }
    }


}
