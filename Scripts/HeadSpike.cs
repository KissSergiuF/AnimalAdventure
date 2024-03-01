using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSpike : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int currentPosition = 0;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float pauseTime = 2f;

    private bool isPaused = false;
    private float pauseTimer = 0f;

    void Update()
    {
        if (!isPaused)
        {
            MoveToWaypoint();
        }
        else
        {
            pauseTimer += Time.deltaTime;
            if (pauseTimer >= pauseTime)
            {
                isPaused = false;
                pauseTimer = 0f;
            }
        }
    }

    void MoveToWaypoint()
    {
        Vector2 targetPosition = waypoints[currentPosition].position;
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            isPaused = true;
            currentPosition++;
            if (currentPosition >= waypoints.Length)
            {
                currentPosition = 0;
            }
        }
    }
}