using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   

    [SerializeField] private float speed = 50f;
    [SerializeField] private float rotationSpeed = 100f;

    private Rigidbody2D rb;

    private PlayerAwareness PlayerAwareness;
    private Vector2 targetDir;
    private Transform Player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerAwareness = GetComponent<PlayerAwareness>();
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (PlayerAwareness.AwareOfPlayer) 
        {
            targetDir = PlayerAwareness.DirectionToPlayer;
        }
        else
        {
            targetDir.y = 0;
            targetDir.x = 0;
        }
    }

    private void RotateTowardsTarget()
    {
        if (targetDir == Vector2.zero)
        {
            return;
        } 

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDir);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        rb.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (targetDir == Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = transform.up * speed;
        }
    }
}
