using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuing : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void Play()
    {
        SceneManager.LoadScene("rpgpp_lt_scene_1.0");
    }
    public void Quit()
    {
        Application.Quit();
        print("Quit");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
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
    }
}
