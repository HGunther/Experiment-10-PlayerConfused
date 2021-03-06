using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public float fleeRadius = 4f;

    private Path path;
    private int currentWaypoint = 0;

    private Seeker seeker;
    private Rigidbody2D rb;
    private Transform target;
    private Transform player;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>().transform;

        if (!seeker)
        {
            Debug.LogWarning("EnemyAI could not find Seeker component");
        }
        if (!rb)
        {
            Debug.LogWarning("EnemyAI could not find Rigidbody2D component");
        }
        if (!player)
        {
            Debug.LogWarning("EnemyAI could not find PlayerMovement gameobject.");
        }

        ChooseCheckpoint();
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
            ChooseCheckpoint();
            return;
        }



        var distanceFromPlayer = ((Vector2)player.position - rb.position).magnitude;
        if (distanceFromPlayer > fleeRadius)
        {
            MoveAlongPath();
            return;
        } else
        {
            // Too close to player
            const float safeAngle = 90f;
            Vector2 directionTowardsPlayer = ((Vector2)player.position - rb.position).normalized;
            Vector2 directionAlongPath = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

            // Safe to move along path normally
            if (Mathf.Abs(Vector2.SignedAngle(directionAlongPath, directionTowardsPlayer)) > safeAngle)
            {
                MoveAlongPath();
                return;
            }
            else
            {
                // Try next point in path
                if (currentWaypoint + 1 < path.vectorPath.Count)
                {
                    Vector2 directionNextPoint = ((Vector2)path.vectorPath[currentWaypoint + 1] - rb.position).normalized;
                    if (Mathf.Abs(Vector2.SignedAngle(directionNextPoint, directionTowardsPlayer)) > safeAngle)
                    {
                        MoveAlongPath();
                        return;
                    }
                }
                
            }
        }

        // As last resort, pick new path
        ChooseCheckpoint();
    }

    void MoveAlongPath()
    {
        Vector2 directionAlongPath = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = directionAlongPath * speed * Time.deltaTime;
        rb.rotation = Vector2.SignedAngle(Vector2.up, directionAlongPath);
        rb.MovePosition(rb.position + force);

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
}
