using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    [SerializeField] GameObject ded;
    private PlayerControlViaAxis control;
    [SerializeField] MouseLook look;
    [SerializeField] Transform player;
    [SerializeField] bool rot = true;
    [SerializeField] Slider slider;


    private void Start()
    {
        currentHealth = maxHealth;
        ded.SetActive(false);
        control = GetComponent<PlayerControlViaAxis>();
        slider.value = maxHealth;
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;
        if(currentHealth <= 0 )
        {
            Death();
        }
    }
    public void Death()
    {
        

        print("Umbro si");
        ded.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        control.enabled = false;
        look.enabled = false;
        Rotation(rot);
        rot = false;

    }
    private void Rotation(bool rot)
    {
        if (rot)
        {
            float rX = Random.Range(-90, 90);
            player.Rotate(rX, rX, rX);
        }
    }
}
