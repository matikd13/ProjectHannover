using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Strza³a posz³a w pizdu");
        // Destroy the bullet after 2 seconds to prevent memory leaks
    }

    private void Update()
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collision with enemy or other objects
        // For example, you can reduce enemy health here
        Destroy(gameObject);
    }
}
