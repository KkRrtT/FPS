using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzlePoint;
    private float fireRate = 0.1f;
    [SerializeField] float fireRateGun = 0.2f;
    public float damage;
    GameManager manager;
    private int m14BulletsFull = 30;
    [SerializeField] int m14Bullets;
    private int handgunBulletsFull = 10;
    private int handgunBullets = default;
    public float aimBloom = 10;
    [SerializeField] float speed = 50;

    bool canShoot = true;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
        aimBloom = 45;
    }

    private void Update()
    {
        if(manager.mode == false)
        {
            //aimBloom = 20;
            if (canShoot && Input.GetMouseButtonDown(0))
            {
                ShootBullet();
            }
            if(Input.GetKeyDown(KeyCode.R))
            {
                Reload(manager.mode);
            }
        }
        else if (manager.mode == true)
        {
            //aimBloom = 45;
            if (canShoot && Input.GetMouseButton(0))
            {
                fireRate -= Time.deltaTime;
                if(fireRate <= 0)
                {
                    fireRate = fireRateGun;
                    ShootBullet();
                }
            
                //StartCoroutine(FireRate());
            }
        }
    }
    private void ShootBullet()
    {
        float x = Screen.width / 2;
        float y = Screen.height / 2;

        float xAcc = Random.Range(x - aimBloom, x + aimBloom);
        float yAcc = Random.Range(y - aimBloom, y + aimBloom);

        print(yAcc);
        print(xAcc);

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(xAcc, yAcc, 0));


        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletRB.velocity = speed * ray.direction;

        if(bulletScript != null )
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
    private void Reload(bool mode)
    {
        float timer = 1.5f;
        timer -= Time.deltaTime;
        if (timer < 0 && mode == false)
        {
            handgunBullets = handgunBulletsFull;
            canShoot = true;
        }
        else if(timer < 0 && mode == true)
        {
            m14Bullets = m14BulletsFull;
            canShoot = true;
        }
    }
}
