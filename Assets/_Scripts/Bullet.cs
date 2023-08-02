using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 25f;
    public float lifeTime = 2f;
    public float damage;
    public EnemyAIDva ai;

    private void Start()
    {
        Destroy(gameObject, lifeTime); //lifeTime je delay nakon kolko se unistava
    }

    private void Update()
    {
        //Vector3 forwardDirection = transform.forward;
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        print("Kinda");
        if (other.CompareTag("Enemy"))
        {
            EnemyAIDva enemyAII = other.GetComponent<EnemyAIDva>();
            GunController gunController = GetComponentInParent<GunController>();
            print("Entered enemy");

            BulletHitEnemy(enemyAII);
            print("Took damaga");


            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void BulletHitEnemy(EnemyAIDva enemy)
    {
        if (enemy != null)
        {
            enemy.TakeDamageEnemy(damage);
        }
    }


}
