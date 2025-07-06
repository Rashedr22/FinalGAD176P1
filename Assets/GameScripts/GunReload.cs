using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GunReload : MonoBehaviour
{
    public GunBase gunShootScript; 
    public AudioClip reloadSound;
    public TextMeshProUGUI reloadText;

    public float reloadTime = 2f;
    public Vector3 recoilOffset = new Vector3(0, -0.1f, -0.1f); // Fake recoil

    private AudioSource audioSource;
    private bool isReloading = false;
    private Vector3 originalPos;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalPos = transform.localPosition;

        if (reloadText != null)
            reloadText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isReloading) return;

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        if (reloadText != null)
            reloadText.gameObject.SetActive(true);

        if (reloadSound != null)
            audioSource.PlayOneShot(reloadSound);

        
        transform.localPosition += recoilOffset;        // Vector addition 

        yield return new WaitForSeconds(reloadTime);

        
        float recoilDistance = (transform.localPosition - originalPos).magnitude;         // Vector magnitude 
        if (recoilDistance > 0.2f)
        {
            transform.localPosition = originalPos;
        }

        
        gunShootScript.currentAmmo = gunShootScript.magazineSize;       // Reset ammo

        if (reloadText != null)
            reloadText.gameObject.SetActive(false);

        isReloading = false;
    }
}
