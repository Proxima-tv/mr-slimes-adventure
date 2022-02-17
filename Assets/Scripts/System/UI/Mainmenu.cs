using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Mainmenu : MonoBehaviour
{
    bool BTNContinue = false;

    public void GameContinue()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
