using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Events : MonoBehaviour
{
    //Try Again Button 
    public void TryAgain()
    {
        //Hier sp�ter herausfinden in welcher szene man sich befindet und die dann laden.
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
        
    }
}
