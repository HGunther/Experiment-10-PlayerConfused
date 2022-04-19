using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesTrail : MonoBehaviour
{
    public GameObject node;
    public float node_lifetime = 10f;
    public float time_between_node_drops = .25f;

    Color scentColor;
    public int playerNumber = 0;
    
    private float last_node_drop_time = 0f;

    void Start()
    {
        scentColor = ColorGenerator.IndexToColor(playerNumber);
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
        var scentData = newNode.GetComponent<TrailNodeData>();
        scentData.createdTime = Time.time;
        scentData.destroyTime = Time.time + node_lifetime;
        scentData.lifetime = node_lifetime;
        scentData.scentColor = scentColor;
        Destroy(newNode, node_lifetime);
    }
}
