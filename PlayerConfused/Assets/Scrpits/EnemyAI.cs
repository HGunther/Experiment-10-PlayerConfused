using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
        public float speed = 200f;
    public float nextWaypointDistance = 3f;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    private Seeker seeker;
    private Rigidbody2D rb;
    private Transform target;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (!seeker)
        {
            Debug.LogWarning("EnemyAI could not find Seeker component");
        }
        if (!rb)
        {
            Debug.LogWarning("EnemyAI could not find Rigidbody2D component");
        }

        Invoke("ChooseCheckpoint", 0f);
        InvokeRepeating("ChooseNewCheckpoint", 3f, 3f);
    }

    void FixedUpdate()
    {
        if (path == null)
        {
            Debug.LogError("Error: EnemyAI did not have a valid path when fixedupdate was called!");
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            Debug.Log("Reached end of path");
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    void OnPathReady(Path p)
    {
        if (p.error)
        {
            Debug.LogError("Error: EnemyAI failed to generate a path!");
            return;
        }

        path = p;
        currentWaypoint = 0;
    }

    void ChooseCheckpoint()
    {
        var checkpoints = FindObjectsOfType<AICheckpoint>();
        Debug.Assert(checkpoints.Length > 0, "EnemyAI failed to find any valid checkpoints");
        var checkpointIndex = Random.Range(0, checkpoints.Length);

        target = checkpoints[checkpointIndex].transform;

        seeker.StartPath(rb.position, target.position, OnPathReady);
    }

    void ChooseNewCheckpoint()
    {
        if (!reachedEndOfPath) { return; }

        ChooseCheckpoint();
    }
}
