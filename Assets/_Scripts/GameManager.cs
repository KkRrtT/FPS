using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPos;
    public TMP_Text killsTekst;
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject[] weapons;
    [SerializeField] GameObject[] cameras;
    [SerializeField] GameObject pauseMenu;
    public bool mode = default;
    public int kills = default;
    private bool a = true;
    //[SerializeField] Transform[] bulletPoint;

    private void Start()
    {
        InvokeRepeating("EnemySpawn", 0, 3);
        for(int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[0].SetActive(true);
        mode = true;
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            SwitchWeapon(0);
            print("Switch");
        }
        else if(Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Aim(true);
        }
        else if(Input.GetKeyUp(KeyCode.Mouse1))
        {
            Aim(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause(a);
            a = !a;
        }

    }

    public void EnemySpawn()
    {
        int rngSpawn = Random.Range(0, spawnPos.Length);
        int rngEnemy = Random.Range(0, enemies.Length);

        Instantiate(enemies[rngEnemy], spawnPos[rngSpawn].position, Quaternion.identity);
    }

    private void SwitchWeapon(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
        weapons[index].SetActive(true);



        if (index == 0)
        {
            GunController activeGunScript = weapons[0].GetComponent<GunController>();
            activeGunScript.aimBloom = 45;
            mode = true;
        }
        else
        {
            GunController activeGunScript = weapons[1].GetComponent<GunController>();
            activeGunScript.aimBloom = 20;
            mode = false;
        }
    }

    private void Aim(bool a)
    {
        GunController activeGunScript;

        if (weapons[0].activeSelf == true)
        {
            activeGunScript = weapons[0].GetComponent<GunController>();
        }
        else
        {
            activeGunScript = weapons[1].GetComponent<GunController>();
        }

        if(a)
        {
            for (int i = 0; i < (cameras.Length - 1); i++)
            {
                cameras[i].SetActive(true);
            }
            cameras[2].SetActive(false);

            activeGunScript.aimBloom = 0;
        }
        else 
        {
            for (int i = 0; i < (cameras.Length - 1); i++)
            {
                cameras[i].SetActive(false);
            }
            cameras[2].SetActive(true);

            if (weapons[0].activeSelf == true)
            {
                activeGunScript.aimBloom = 45;
            }
            else 
            {
                activeGunScript.aimBloom = 20;
            }
            
        }
    }

    private void Shoot(int a)
    {
        if(a == 0)
        {

        }
    }
    private void Pause(bool a)
    {
        if (a)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
