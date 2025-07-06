using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARGunShoot : GunBase
{
    [SerializeField] private float fireRate;
    private float nextFireTime = 0f;

    protected override void Start()
    {
        base.Start(); // Call base Start to set audioSource
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime && currentAmmo > 0)
        {
            Fire(); // Use overridden method
            nextFireTime = Time.time + fireRate;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopFire(); // Use base stop
        }
    }

    public override void Fire()
    {
        base.Fire(); // Keep all original behavior
        currentAmmo--;
    }

    protected override void StopFire()
    {
        base.StopFire(); // Call base
    }
}
