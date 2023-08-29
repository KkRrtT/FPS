using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuing : MonoBehaviour
{
    [SerializeField] GunController controllerGun;
    [SerializeField] GunController controllerHandgun;
    [SerializeField] PlayerHealth health;
    [SerializeField] GameObject pauseMenu;

    public void Play()
    {
        PlayerPrefs.SetFloat("CurrentHealth", 100);
        PlayerPrefs.SetInt("kills", 0);
        PlayerPrefs.SetInt("round", 0);
        PlayerPrefs.SetInt("AmmoHandgun", 10);
        PlayerPrefs.SetInt("AmmoGun", 30);
        SceneManager.LoadScene("rpgpp_lt_scene_1.0");
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Application.Quit();
        print("Quit");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("AmmoGun", controllerGun.m14Bullets);
        PlayerPrefs.SetInt("AmmoHandgun", controllerGun.handgunBullets);
        PlayerPrefs.SetFloat("CurrentHealth", health.currentHealth);
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        controllerGun.enabled = true;
        controllerHandgun.enabled = true;
    }
}
