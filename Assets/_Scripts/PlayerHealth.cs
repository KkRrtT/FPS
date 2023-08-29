using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    [SerializeField] bool rot = true;
    private PlayerControlViaAxis control;
    [SerializeField] GameObject ded;
    [SerializeField] MouseLook look;
    [SerializeField] Transform player;
    [SerializeField] Slider slider;
    [SerializeField] PostProcessVolume deathFX;


    private void Start()
    {
        if (PlayerPrefs.HasKey("CurrentHealth"))
        {
            currentHealth = PlayerPrefs.GetFloat("CurrentHealth");
        }
        else
        {
            currentHealth = maxHealth;
        }
        deathFX.weight = 0f;
        ded.SetActive(false);
        control = GetComponent<PlayerControlViaAxis>();
        slider.value = maxHealth;
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;
        deathFX.weight += damage / 100;
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
