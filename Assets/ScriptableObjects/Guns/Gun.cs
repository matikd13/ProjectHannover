using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] GunData gunData;
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private AmmoCounter ammoCounter;
    [SerializeField] private AudioSource audioSource;
    SpriteRenderer spriteRenderer;
    float timeSinceLastShot;
    float timeSinceLastReload;

    public void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
        timeSinceLastShot = 0f;
        UpdateAmmoCounter();
        //Debug.Log(spriteRenderer.sprite);
        //Debug.Log(spriteRenderer.isVisible);
        //Debug.Log(gunData.name);
    }

    public void Update()
    {
        spriteRenderer.sprite = gunData.image;
        timeSinceLastShot += Time.deltaTime;
        timeSinceLastReload += Time.deltaTime;

        //Debug.Log(timeSinceLastShot);

        if (GameInstance.Instance.playerController.focus != null) return;

        if (Input.GetMouseButtonDown(0) && timeSinceLastShot >= gunData.shootingSpeed)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }

        if (Input.GetKeyDown(KeyCode.R) && (gunData.currentAmmo != gunData.magSize) && (timeSinceLastReload > gunData.reloadSpeed))
        {
            ManualReload();
            timeSinceLastReload = 0f;
        }
    }

    void ManualReload()
    {
        StartCoroutine(Reload());
    }

    void Shoot()
    {
        if (gunData.currentAmmo > 0 && !gunData.reloading)
        {
            Debug.Log("Shoot");

            audioSource.Play();

            // Instantiate the bullet at the shoot point
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
            Debug.Log("Ammo before shoot: " + gunData.currentAmmo);

            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), playerTransform.GetComponent<Collider2D>());

            Bullet bulletScript = bullet.GetComponent<Bullet>();

            if (bulletScript != null)
            {
                bulletScript.SetDamage(gunData.damage);
            }

            rigidbody.velocity = gunData.bulletSpeed * transform.right;

            // Reduce ammo count
            gunData.currentAmmo--;
            UpdateAmmoCounter();
            Debug.Log("Ammo after shoot: " + gunData.currentAmmo);

            if (gunData.currentAmmo == 0)
                ManualReload();


            // Add other shooting logic (e.g., recoil, sound) here
        }

    }

    void UpdateAmmoCounter()
    {
        if (ammoCounter != null)
        {
            ammoCounter.UpdateCounter(gunData.currentAmmo, gunData.magSize);
        }
    }

    IEnumerator Reload()
    {
        if (GameInstance.Instance.magCount == 0)
            yield break;

        GameInstance.Instance.magCount--;
        gunData.reloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(gunData.reloadSpeed);

        gunData.currentAmmo = gunData.magSize;
        gunData.reloading = false;
        Debug.Log("Reloaded");
        UpdateAmmoCounter();
    }
}
