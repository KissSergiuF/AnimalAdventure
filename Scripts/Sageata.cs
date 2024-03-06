using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ArrowShooter : MonoBehaviour
{
    [SerializeField] private Transform startPoint;  // Punctul de plecare al săgeții
    [SerializeField] private Transform targetPoint;  // Punctul țintă al săgeții
    [SerializeField] private float moveSpeed = 5f;  // Viteza de deplasare a săgeții
    private bool movingToTarget = true;

    void Update()
    {
        if (movingToTarget)
        {
            MoveToTarget();
        }
        else
        {
            ResetArrow();
        }
    }
    void MoveToTarget()
    {
        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = targetPoint.position;

        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(currentPosition, targetPosition) < 0.1f)
        {
            movingToTarget = false;
            ResetArrow();
        }
    }
    void ResetArrow()
    {
        movingToTarget = true;
        transform.position = startPoint.position;  
    }
}