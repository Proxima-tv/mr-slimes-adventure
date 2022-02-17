using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedScreen : MonoBehaviour
{
    public string level;
    public void Continue()
    {
        SceneManager.LoadScene(level);
    }
}
