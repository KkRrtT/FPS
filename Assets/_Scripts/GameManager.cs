using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPos;
    public TMP_Text killsTekst;
    public TMP_Text roundTekst;
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject[] weapons;
    [SerializeField] GameObject[] cameras;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject[] ammoTekst;
    [SerializeField] GunController gunController;
    [SerializeField] GunController gunController2;
    public int killsNew = default;
    private int enemiesToSpawn = default;
    [SerializeField] int round = default;
    public bool mode = default;
    public int kills = default;
    public int killsCurr = default;
    private bool a = true;
    private bool once = false;
    //[SerializeField] Transform[] bulletPoint;
    private void Awake()
    {
        //if (round == 0 || round == 1)
        //{
        //    round = 1;
        //}

        
    }
    private void Start()
    {
        kills = PlayerPrefs.GetInt("kills");
        killsCurr = kills;
        killsTekst.text = kills.ToString();
        round = PlayerPrefs.GetInt("round");
        roundTekst.text = round.ToString();
        if(kills > 0)
        {
            enemiesToSpawn = round * 10;       
            StartCoroutine(EnemySpawn(kills));            
        }
        else
        {
            round = 1;
            enemiesToSpawn = 10;
            StartCoroutine(EnemySpawn(kills));
            
        }
        roundTekst.text = round.ToString();
        //InvokeRepeating("EnemySpawn", 0, 3);
        for (int i = 0; i < weapons.Length; i++)
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
            gunController.enabled = !gunController.isActiveAndEnabled;
            gunController2.enabled = !gunController2.isActiveAndEnabled;
            a = !a;
        }

        
        if(killsNew >= enemiesToSpawn)
        {
            round++;
            kills += killsNew;
            PlayerPrefs.SetInt("round", round);
            PlayerPrefs.SetInt("kills", kills);
            SceneManager.LoadScene("rpgpp_lt_scene_1.0");
            
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            PlayerPrefs.SetInt("kills", 0);
        }
    }

    public IEnumerator EnemySpawn(int kills)
    {
        if(kills > 9)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                int rngSpawn = Random.Range(0, spawnPos.Length);
                int rngEnemy = Random.Range(0, enemies.Length);
                Instantiate(enemies[rngEnemy], spawnPos[rngSpawn].position, Quaternion.identity);
                yield return new WaitForSeconds(2.5f);
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                int rngSpawn = Random.Range(0, spawnPos.Length);
                int rngEnemy = Random.Range(0, enemies.Length);
                Instantiate(enemies[rngEnemy], spawnPos[rngSpawn].position, Quaternion.identity);
                yield return new WaitForSeconds(2.5f);
            }
        }
    }

    private void SwitchWeapon(int index)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
            ammoTekst[i].SetActive(false);
        }
        weapons[index].SetActive(true);
        ammoTekst[index].SetActive(true);



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
