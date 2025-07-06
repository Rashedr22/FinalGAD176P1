using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [SerializeField] protected ParticleSystem muzzleFlash;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform bulletSpawnPoint;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected AudioClip shootSound;

    protected AudioSource audioSource;

    public int magazineSize = 10;
    [HideInInspector] public int currentAmmo;

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentAmmo = magazineSize;
    }

    public virtual void Fire()
    {
        if (muzzleFlash != null)
            muzzleFlash.Play();

        if (shootSound != null && audioSource != null)
            audioSource.PlayOneShot(shootSound);

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
            rb.AddForce(Camera.main.transform.forward * bulletSpeed, ForceMode.Acceleration);

        Destroy(bullet, 2f);
    }

    protected virtual void StopFire()
    {
        if (muzzleFlash != null)
            muzzleFlash.Stop();
    }
}
