using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]
public class GunData : ScriptableObject
{
    [Header("Info")]
    public new string name;
    public Sprite image;
    public Vector3 position;
    //public new string description;

    [Header("Shooting")]
    public float damage;
    public float shootingSpeed;
    public GameObject bulletPrefab;
    public float bulletSpeed;

    [Header("Reloading")]
    public float reloadSpeed;
    public int magSize;
    public int currentAmmo;
    [HideInInspector]
    public bool reloading;

}
