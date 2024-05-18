using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] GunData gunData;
    SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = gunData.image;
        spriteRenderer.enabled = true;
        Debug.Log(spriteRenderer.sprite);
        Debug.Log(spriteRenderer.isVisible);
        Debug.Log(gunData.name);
    }

    public void Update()
    {
        Debug.Log(spriteRenderer.isVisible);
        Debug.Log(spriteRenderer.transform.position);
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
    }


}
