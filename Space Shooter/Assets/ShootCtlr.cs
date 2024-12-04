using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCtlr : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn; 
    public float shootInterval = 0.5f;
    private float shootTimer = 0f;
    [SerializeField] protected bool isPlayer = false;

    void Update()
    {
        ShootTrigger();
    }

    void ShootTrigger()
    {
        shootTimer += Time.deltaTime;

        if (isPlayer)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began && shootTimer >= shootInterval)
                {
                    Shoot();
                    shootTimer = 0f;
                }
            }
        }
        else
        {
            if (shootTimer >= shootInterval)
            {
                Shoot();
                shootTimer = 0f;
            }
        }
    }

    void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        if (!isPlayer)
        {
            bulletObj.transform.rotation = Quaternion.Euler(180f, 0f, 0f);
        }

        Bullet bullet = bulletObj.GetComponent<Bullet>();

        if (bullet != null) {
            bullet.SetDirection(Vector3.up);
        }
    }
}
