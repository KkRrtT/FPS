using JetBrains.Annotations;
using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject muzzleFlashGun;
    public GameObject muzzleFlashPistol;
    public Transform muzzlePoint;
    private float fireRate = 0.1f;
    [SerializeField] float fireRateGun = 0.2f;
    public float damage;
    GameManager manager;
    private int m14BulletsFull = 30;
    [SerializeField] int m14Bullets = default;
    private int handgunBulletsFull = 10;
    private int handgunBullets = default;
    public float aimBloom = 10;
    [SerializeField] float speed = 50;

    [SerializeField] bool canShootPistol = true;
    [SerializeField] bool canShootGun = true;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
        aimBloom = 45;
        handgunBulletsFull = 10;
        handgunBullets = 10;
        m14BulletsFull = 30;
        m14Bullets = 30;
    }

    private void Update()
    {
        if (manager.mode == false)
        {
            //aimBloom = 20;
            if (canShootPistol && Input.GetMouseButtonDown(0))
            {
                StartCoroutine(MuzzleFlash(muzzleFlashPistol));
                ShootBullet(ref handgunBullets, ref canShootPistol);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(ReloadPistol());
            }
        }
        else if (manager.mode == true)
        {
            //aimBloom = 45;
            if (canShootGun && Input.GetMouseButton(0))
            {
                fireRate -= Time.deltaTime;
                if (fireRate <= 0)
                {
                    fireRate = fireRateGun;
                    StartCoroutine(MuzzleFlash(muzzleFlashGun));
                    ShootBullet(ref m14Bullets, ref canShootGun);
                }
            }
            if (canShootGun && Input.GetMouseButtonDown(0))
            {
                StartCoroutine(MuzzleFlash(muzzleFlashGun));
                ShootBullet(ref m14Bullets, ref canShootGun);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(ReloadGun());
            }
        }
    }
    private void ShootBullet(ref int usedGunAmmo, ref bool canShoot)
    {
        float x = Screen.width / 2;
        float y = Screen.height / 2;

        float xAcc = Random.Range(x - aimBloom, x + aimBloom);
        float yAcc = Random.Range(y - aimBloom, y + aimBloom);

        //print(yAcc);
        //print(xAcc);

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(xAcc, yAcc, 0));


        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        usedGunAmmo--;
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletRB.velocity = speed * ray.direction;

        if(usedGunAmmo <= 0)
        {
            canShoot = false;
        }

        if (bulletScript != null)
        {
            bulletScript.damage = damage;
        }
    }


    public void BulletHitEnemy(EnemyAIDva enemy)
    {
        if (enemy != null)
        {
            enemy.TakeDamageEnemy(damage);
        }
    }



    private IEnumerator MuzzleFlash(GameObject flash)
    {
        flash.SetActive(true);
        //print("Routine started");

        yield return new WaitForSeconds(0.05f);

        flash.SetActive(false);
        //print("Routine finished");
    }

    private void ReloadM(ref int a, int b, ref bool c)
    {
        a = b;
        c = true;
        print("Metoda");
    }
    private IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1.5f);
        ReloadM( ref m14Bullets, m14BulletsFull, ref canShootGun); 
    }
    private IEnumerator ReloadPistol()
    {
        yield return new WaitForSeconds(1.5f);
        ReloadM(ref handgunBullets, handgunBulletsFull, ref canShootPistol);
    }

}
