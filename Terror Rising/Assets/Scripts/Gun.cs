using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float ClipSize = 30;
    public float AmmoCount = 30;
    public float ReserveAmmo = 220;
    public float NoAmmoDis = 0;
    public Text AmmoDisplayC;
    public Text AmmoDisplayR;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;


    // Update is called once per frame
    void Update()
    {
        AmmoDisplayC.text = AmmoCount.ToString();
        AmmoDisplayR.text = ReserveAmmo.ToString();
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            if(AmmoCount > 0)
            {
                Shoot();
                AmmoCount -= 1;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.R) && ReserveAmmo != 0)
        {
            if(ReserveAmmo < ClipSize)
            {
                AmmoCount = ReserveAmmo;
                ReserveAmmo = ReserveAmmo - (ClipSize - AmmoCount);
            }
            else
            {
                ReserveAmmo = ReserveAmmo - (ClipSize - AmmoCount);
                AmmoCount = ClipSize;
            }
        }
        if(ReserveAmmo < 0)
        {
            ReserveAmmo = 0;
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
