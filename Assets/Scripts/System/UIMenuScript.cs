using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuScript : MonoBehaviour
{
    public GameObject options;
    public GameObject menu;

    public void quitPauseMenu()
    {
        transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }
    public void Options()
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
            options.SetActive(true);
        } else
        {
            menu.SetActive(true);
            options.SetActive(false);
        }
    }
    public void toMenuScreen()
    {
        SceneManager.LoadScene("title");
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
