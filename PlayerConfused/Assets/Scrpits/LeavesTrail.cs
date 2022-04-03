using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesTrail : MonoBehaviour
{
    public GameObject node;
    public float node_lifetime = 10f;
    public float time_between_node_drops = .25f;
    
    private float last_node_drop_time = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time >= last_node_drop_time + time_between_node_drops){
            DropNode();
            last_node_drop_time += time_between_node_drops;
        }
    }

    public void DropNode(){
        var newNode = Instantiate<GameObject>(node, transform.position, transform.rotation);
        Destroy(newNode, node_lifetime);
    }
}
