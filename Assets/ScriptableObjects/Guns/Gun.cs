using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] GunData gunData;
    [SerializeField] Transform playerTransform;
    SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = gunData.image;
        spriteRenderer.enabled = true;
        Debug.Log(spriteRenderer.sprite);
        Debug.Log(spriteRenderer.isVisible);
        Debug.Log(gunData.name);
    }

    public void Update()
    {
        spriteRenderer.sprite = gunData.image;


        Debug.Log(spriteRenderer.isVisible);
        Debug.Log(spriteRenderer.transform.position);
        Debug.Log(playerTransform.transform.position);
        Debug.Log("Parent: " + transform.parent); // Log parent
        Debug.Log("Local Position: " + transform.localPosition); // Log local position

    }

    public void Shoot()
    {
        Debug.Log("Shoot");
    }


}
