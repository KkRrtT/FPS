using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;   //dodajemo novi using kako bi smo mogli koristit navmesh

public class EnemyAIDva : MonoBehaviour
{
    public Transform player;    //gameobject do kojeg ce enemy ici
                                // tj referenca na transformaciju igraca, postavljamo ju u unity inspectoru
    public float closeCombatDistance = 2f;  // udaljenist na kojoj se Enemy prebacuje na cqc
    public float damageAmount = 10f; // dmg koju enemy nanosi igracu kad ga dotakne
    public float health = 100;
    [SerializeField] bool isAttacking = false; //varijabla koja ozunacava je li neprijatelj u fazi napada
    [SerializeField] bool isDead = false; //varijabla koja ozunacava je li neprijatelj u fazi napada
    private bool died = false;
    GameManager gameManager;
    private Animator animator;
    NavMeshAgent agent; //referenca na "NavMeshAgent" komponentu neprijatelja

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();   // dohvacamo "NavMeshAgent" komponentu iz objekta na kojemu je skripta
        player = GameObject.FindGameObjectWithTag("Player").transform;  //Pronalazimo igraca prema tagu player i postavljamo referencu
                                                                        // na njegovu transformaciju
    }
    private void Update()
    {
        animator.SetBool("isAttacking", isAttacking);
        animator.SetBool("isDead", isDead);

        //if (!isAttacking)
        //{
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            //Ako je udaljenost veca od udaljenosti za qcc, kretaj se prema igracu
            if (distanceToPlayer > closeCombatDistance && !isDead)
            {
                agent.SetDestination(player.position);
                isAttacking = false;
            }
            else if(distanceToPlayer <= closeCombatDistance && !isDead)
            {
                //ako smo dovoljno blizu igraca, prestani se kretati i zapocni napad
                agent.ResetPath();
                isAttacking = true;
                AttackPlayer();
            }
        //}
        
    }

    void AttackPlayer()
    {
        //metoda koja izaziva napad na igraca
        //poziva metodu TakeDamage() u skripti PlayerHealth i nanosi stetu
        player.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
    }
    public void TakeDamageEnemy(float damage)
    {
        health -= damage;
        if(health <= 0 && !died)
        {
            isDead = true;
            isAttacking = false;
            agent.enabled = false;
            gameManager.kills++;
            gameManager.killsTekst.text = gameManager.kills.ToString();
            Destroy(gameObject, 10);
            died = true;
        }
    }
}