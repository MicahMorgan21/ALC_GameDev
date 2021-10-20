using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletProjectile;
    public Transform muzzle;
    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;
    public float bulletSpeed;
    public float shootrate;
    public float lastShootTime;
    private bool isPlayer;

    void Awake ()

    {
        // are we attached to the player 
        if(GetComponent<PlayerController>())
        {
        isPlayer = true;
        }

    }
    // can we shooot a bullet
    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
            {
                return true;
            }
        }

        return false;
    }

    public void Shoot()
    {
        // Adjust shoot time and reduce ammo by one
        lastShootTime = Time.time;
        curAmmo --;

        // Create projectile
        GameObject bullet = Instantiate(bulletProjectile, muxzzle.position, muzzle.rotation);

        // Set Velocity of bulletProjectile
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
