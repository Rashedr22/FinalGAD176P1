using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : GunBase
{

    protected override void Start()
    {
        base.Start(); // get AudioSource
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            Fire(); // use overridden method
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopFire(); // stop flash
        }
    }

    public override void Fire()
    {
        base.Fire(); // keeps all the logic
        currentAmmo--;
    }

    protected override void StopFire()
    {
        base.StopFire(); // stops flash
    }

}
