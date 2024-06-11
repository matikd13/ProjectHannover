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

    [Header("Reloading")]
    public float reloadSpeed;
    public float shootingSpeed;
    public int magSize;
    [HideInInspector]
    public bool reloading;

    //public float recoil;



}
