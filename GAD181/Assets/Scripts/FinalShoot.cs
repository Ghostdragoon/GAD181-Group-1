using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalShoot : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting;
    public float spread;
    public float range;
    public float reloadTime;
    public float timeBetweenShots;

    public int magazineSize;
    public int bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft;
    int bulletsShot;


    bool shooting;
    bool readyToShoot; 
    bool reloading;

    public GameObject fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    public ParticleSystem muzzleFlash;
    public TrailRenderer bulletTrail;
    public TextMeshProUGUI text;
    public AudioSource shooot;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        //SetText
        text.SetText(bulletsLeft + " / " + magazineSize);
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);


        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            var bullet = Instantiate(bulletTrail, attackPoint.position, Quaternion.identity);
            muzzleFlash.Play();
            shooot.Play();
            bullet.AddPosition(attackPoint.position);
            {
                bullet.transform.position = transform.position + (fpsCam.transform.forward * 200);
            }


            if (hit.collider.tag == "Enemy")
            {
                //Debug.Log(hit.transform.name);
                EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();

                if (enemyHealth == true)
                {
                    Debug.Log(hit.transform.name);
                    enemyHealth.EnemyTakeDamage(damage);
                }
            }
        }


        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}